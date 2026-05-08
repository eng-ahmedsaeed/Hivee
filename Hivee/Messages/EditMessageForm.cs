using System.Data.SqlClient;

namespace Hivee.Messages
{
    public partial class EditMessageForm : Form
    {
        string connStr = "Server=localhost;Database=SocialMedia;Integrated Security=True;TrustServerCertificate=True;";
        private int messageId;

        public EditMessageForm(int msgId, string currentText)
        {
            InitializeComponent();
            messageId = msgId;
            txtEditBody.Text = currentText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditBody.Text))
            {
                MessageBox.Show("Message cannot be empty.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Message SET Message_body = @newText WHERE Message_id = @msgId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@newText", txtEditBody.Text);
                cmd.Parameters.AddWithValue("@msgId", messageId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating message: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}