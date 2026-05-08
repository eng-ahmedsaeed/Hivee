using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Hivee.Messages
{
    public partial class InboxForm : Form
    {
        string connStr = "Server=localhost;Database=SocialMedia;Integrated Security=True;TrustServerCertificate=True;";
        int currentUserId;
        private string? selectedAttachmentPath = null;

        public InboxForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void InboxForm_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            string query = "SELECT User_id, First_name + ' ' + Last_name AS FullName FROM [User] WHERE User_id != @myId";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@myId", currentUserId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                lstContacts.DisplayMember = "FullName";
                lstContacts.ValueMember = "User_id";
                lstContacts.DataSource = dt;
                lstContacts.SelectedIndex = -1;
                if (lstContacts.Items.Count > 0)
                {
                    lstContacts.SelectedIndex = 0;
                }
            }
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex == -1 || lstContacts.SelectedValue == null)
            {
                return;
            }

            try
            {
                int selectedContactId = Convert.ToInt32(lstContacts.SelectedValue);

                LoadChatHistory(selectedContactId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debug Error: " + ex.Message);
            }
        }

        private void LoadChatHistory(int contactId)
        {
            flpChatHistory.Controls.Clear();

            string query = "SELECT * FROM GetDMsBetweenUsers(@me, @them) ORDER BY Timestamp ASC";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@me", currentUserId);
                cmd.Parameters.AddWithValue("@them", contactId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int messageId = Convert.ToInt32(reader["Message_id"]);
                        int senderId = Convert.ToInt32(reader["Suser_id"]);
                        string messageBody = reader["Message_body"].ToString();
                        DateTime time = Convert.ToDateTime(reader["Timestamp"]);
                        string mediaPath = reader["Media_path"] != DBNull.Value ? reader["Media_path"].ToString() : "";

                        bool isMe = (senderId == currentUserId);

                        Panel rowPanel = new Panel();
                        rowPanel.Width = flpChatHistory.Width - 30;
                        rowPanel.Margin = new Padding(0, 5, 0, 5);

                        Label lblMsg = new Label();
                        lblMsg.Text = isMe ? $"You ({time:HH:mm}):\n{messageBody}" : $"{lstContacts.Text} ({time:HH:mm}):\n{messageBody}";
                        lblMsg.AutoSize = true;
                        lblMsg.MaximumSize = new Size(rowPanel.Width / 2, 0);
                        lblMsg.Padding = new Padding(10);
                        lblMsg.Font = new Font("Segoe UI", 10F);

                        // store the database ID inside the label!
                        lblMsg.Tag = messageId;

                        if (isMe)
                        {
                            lblMsg.BackColor = Color.FromArgb(0, 120, 212);
                            lblMsg.ForeColor = Color.White;
                            lblMsg.Left = rowPanel.Width - lblMsg.PreferredWidth - 10;
                            lblMsg.Cursor = Cursors.Hand;
                            lblMsg.Click += MyMessage_Click;
                        }
                        else
                        {
                            lblMsg.BackColor = Color.FromArgb(255, 255, 255);
                            lblMsg.ForeColor = Color.Black;
                            lblMsg.Left = 10;
                        }

                        rowPanel.Controls.Add(lblMsg);
                        int currentBottom = lblMsg.Bottom;

                        if (!string.IsNullOrEmpty(mediaPath))
                        {
                            string safeMediaPath = mediaPath.Replace("/", "\\");
                            string fullImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, safeMediaPath);

                            if (File.Exists(fullImagePath))
                            {
                                PictureBox pic = new PictureBox();
                                pic.SizeMode = PictureBoxSizeMode.Zoom;
                                pic.Size = new Size(200, 150);
                                pic.Top = currentBottom + 5;
                                pic.Tag = messageId; // Store ID in image too

                                using (var stream = new FileStream(fullImagePath, FileMode.Open, FileAccess.Read))
                                {
                                    pic.Image = Image.FromStream(stream);
                                }

                                if (isMe)
                                {
                                    pic.Left = rowPanel.Width - pic.Width - 10;
                                    pic.Cursor = Cursors.Hand;
                                    pic.Click += MyMessage_Click;
                                }
                                else
                                {
                                    pic.Left = 10;
                                }

                                rowPanel.Controls.Add(pic);
                                currentBottom = pic.Bottom;
                            }
                            else
                            {
                                Label lblError = new Label();
                                lblError.Text = "[Media not found]";
                                lblError.ForeColor = Color.Red;
                                lblError.AutoSize = true;
                                lblError.Top = currentBottom + 5;
                                lblError.Left = isMe ? rowPanel.Width - lblError.PreferredWidth - 10 : 10;
                                rowPanel.Controls.Add(lblError);
                                currentBottom = lblError.Bottom;
                            }
                        }

                        rowPanel.Height = currentBottom + 10;
                        flpChatHistory.Controls.Add(rowPanel);
                    }
                }
            }

            flpChatHistory.AutoScrollPosition = new Point(0, flpChatHistory.VerticalScroll.Maximum);
        }

        private void btnSendReply_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedValue == null)
            {
                MessageBox.Show("Select a contact first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReply.Text) && selectedAttachmentPath == null)
            {
                MessageBox.Show("Cannot send an empty message.");
                return;
            }

            int contactId = Convert.ToInt32(lstContacts.SelectedValue);
            string? mediaPathToSave = null;
            string attachmentType = "File";

            if (selectedAttachmentPath != null)
            {
                string mediaFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Media");
                if (!Directory.Exists(mediaFolder))
                {
                    Directory.CreateDirectory(mediaFolder);
                }

                string fileExtension = Path.GetExtension(selectedAttachmentPath);
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                string destinationPath = Path.Combine(mediaFolder, uniqueFileName);

                File.Copy(selectedAttachmentPath, destinationPath);

                mediaPathToSave = "Media/" + uniqueFileName;

                string[] imageExts = { ".jpg", ".jpeg", ".png", ".gif" };
                if (imageExts.Contains(fileExtension.ToLower()))
                {
                    attachmentType = "Image";
                }
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdSend = new SqlCommand("SendDM", conn, transaction);
                    cmdSend.CommandType = CommandType.StoredProcedure;
                    cmdSend.Parameters.AddWithValue("@Suser_id", currentUserId);
                    cmdSend.Parameters.AddWithValue("@Ruser_id", contactId);
                    cmdSend.Parameters.AddWithValue("@Message_body", txtReply.Text);

                    cmdSend.Parameters.AddWithValue("@Media_path", (object?)mediaPathToSave ?? DBNull.Value);
                    cmdSend.Parameters.AddWithValue("@Attachment_type", attachmentType);
                    cmdSend.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error sending message: " + ex.Message);
                    return;
                }
            }

            txtReply.Clear();
            selectedAttachmentPath = null;
            lblAttachment.Text = "";

            LoadChatHistory(contactId);
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Attachment";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedAttachmentPath = ofd.FileName;
                    lblAttachment.Text = "Attached: " + Path.GetFileName(selectedAttachmentPath);
                }
            }
        }

        private void MyMessage_Click(object sender, EventArgs e)
        {
            Control clickedBubble = (Control)sender;
            int messageId = Convert.ToInt32(clickedBubble.Tag);

            string currentText = clickedBubble.Text;
            if (currentText.Contains("\n"))
            {
                currentText = currentText.Substring(currentText.IndexOf("\n") + 1);
            }

            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("Edit Message", null, (s, args) => EditMessage(messageId, currentText));
            menu.Items.Add("Unsend Message", null, (s, args) => DeleteMessage(messageId));

            menu.Show(Cursor.Position);
        }

        private void DeleteMessage(int messageId)
        {
            var confirm = MessageBox.Show("Unsend this message for everyone?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    new SqlCommand("DELETE FROM Attachment_type_Message WHERE Message_id = " + messageId, conn, transaction).ExecuteNonQuery();
                    new SqlCommand("DELETE FROM DM WHERE Message_id = " + messageId, conn, transaction).ExecuteNonQuery();
                    new SqlCommand("DELETE FROM Message WHERE Message_id = " + messageId, conn, transaction).ExecuteNonQuery();
                    transaction.Commit();

                    LoadChatHistory(Convert.ToInt32(lstContacts.SelectedValue));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void EditMessage(int messageId, string currentText)
        {
            using (EditMessageForm editForm = new EditMessageForm(messageId, currentText))
            {
                // ShowDialog freezes the InboxForm until the user finishes editing
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedContactId = Convert.ToInt32(lstContacts.SelectedValue);
                    LoadChatHistory(selectedContactId);
                }
            }
        }
    }
}