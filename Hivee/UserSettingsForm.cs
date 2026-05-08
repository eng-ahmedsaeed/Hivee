using System.Data;
using System.Data.SqlClient;

namespace Hivee
{
    public class UserSettingsForm : Form
    {
        private const string ConnectionString = "Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI";

        private readonly int userId;
        private readonly TextBox firstNameTextBox = new();
        private readonly TextBox lastNameTextBox = new();
        private readonly TextBox emailTextBox = new();
        private readonly TextBox bioTextBox = new();
        private readonly TextBox avatarUrlTextBox = new();
        private readonly TextBox passwordTextBox = new();
        private readonly CheckBox privateCheckBox = new();
        private readonly DateTimePicker birthDatePicker = new();
        private readonly Button saveButton = new();

        public UserSettingsForm(int userId)
        {
            this.userId = userId;
            InitializeSettingsForm();
            Load += UserSettingsForm_Load;
        }

        private void InitializeSettingsForm()
        {
            Text = "User Settings";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(560, 560);
            MinimumSize = new Size(520, 520);

            TableLayoutPanel layout = new()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(18),
                ColumnCount = 2,
                RowCount = 9
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            AddTextRow(layout, "First name", firstNameTextBox, 0);
            AddTextRow(layout, "Last name", lastNameTextBox, 1);
            AddTextRow(layout, "Email", emailTextBox, 2);
            AddTextRow(layout, "Bio", bioTextBox, 3);
            AddTextRow(layout, "Avatar URL", avatarUrlTextBox, 4);
            AddTextRow(layout, "Password", passwordTextBox, 5);

            birthDatePicker.Format = DateTimePickerFormat.Short;
            AddControlRow(layout, "Birth date", birthDatePicker, 6);
            AddControlRow(layout, "Private", privateCheckBox, 7);

            saveButton.Text = "Save Changes";
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveButton.Size = new Size(140, 34);
            saveButton.Click += SaveButton_Click;

            layout.Controls.Add(saveButton, 1, 8);
            Controls.Add(layout);
        }

        private static void AddTextRow(TableLayoutPanel layout, string labelText, TextBox textBox, int row)
        {
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox.Width = 350;

            if (labelText == "Bio")
            {
                textBox.Multiline = true;
                textBox.Height = 80;
            }

            AddControlRow(layout, labelText, textBox, row);
        }

        private static void AddControlRow(TableLayoutPanel layout, string labelText, Control control, int row)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Label label = new()
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 8, 8, 8)
            };

            control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            control.Margin = new Padding(0, 8, 0, 8);

            layout.Controls.Add(label, 0, row);
            layout.Controls.Add(control, 1, row);
        }

        private void UserSettingsForm_Load(object? sender, EventArgs e)
        {
            LoadUserSettings();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            SaveUserSettings();
            MessageBox.Show("User settings updated.");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoadUserSettings()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"SELECT Bio, Private, Birth_date, Email, Avatar_url, First_name, Last_name, password
                  FROM [User]
                  WHERE User_id = @User_id",
                con);

            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("User was not found in the database.");
                Close();
                return;
            }

            bioTextBox.Text = reader["Bio"]?.ToString() ?? "";
            privateCheckBox.Checked = reader["Private"] != DBNull.Value && Convert.ToBoolean(reader["Private"]);
            birthDatePicker.Value = reader["Birth_date"] == DBNull.Value
                ? DateTime.Today
                : Convert.ToDateTime(reader["Birth_date"]);
            emailTextBox.Text = reader["Email"]?.ToString() ?? "";
            avatarUrlTextBox.Text = reader["Avatar_url"]?.ToString() ?? "";
            firstNameTextBox.Text = reader["First_name"]?.ToString() ?? "";
            lastNameTextBox.Text = reader["Last_name"]?.ToString() ?? "";
            passwordTextBox.Text = reader["password"]?.ToString() ?? "";
        }

        private void SaveUserSettings()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"UPDATE [User]
                  SET Bio = @Bio,
                      Private = @Private,
                      Birth_date = @Birth_date,
                      Email = @Email,
                      Avatar_url = @Avatar_url,
                      First_name = @First_name,
                      Last_name = @Last_name,
                      password = @Password
                  WHERE User_id = @User_id",
                con);

            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@Bio", SqlDbType.VarChar, 500).Value = bioTextBox.Text;
            cmd.Parameters.Add("@Private", SqlDbType.Bit).Value = privateCheckBox.Checked;
            cmd.Parameters.Add("@Birth_date", SqlDbType.Date).Value = birthDatePicker.Value.Date;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = emailTextBox.Text;
            cmd.Parameters.Add("@Avatar_url", SqlDbType.VarChar, 500).Value = avatarUrlTextBox.Text;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar, 100).Value = firstNameTextBox.Text;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar, 100).Value = lastNameTextBox.Text;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 255).Value = passwordTextBox.Text;

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
