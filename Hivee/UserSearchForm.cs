using System.Data;
using System.Data.SqlClient;

namespace Hivee
{
    public class UserSearchForm : Form
    {
        private const string ConnectionString = "Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI";

        private readonly int currentUserId;
        private readonly TextBox searchTextBox = new();
        private readonly Button searchButton = new();
        private readonly ListBox resultsListBox = new();
        private readonly Label hintLabel = new();

        public UserSearchForm(int currentUserId)
        {
            this.currentUserId = currentUserId;
            InitializeSearchForm();
        }

        private void InitializeSearchForm()
        {
            Text = "Search Users";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(560, 500);
            MinimumSize = new Size(520, 420);

            searchTextBox.Location = new Point(18, 18);
            searchTextBox.Size = new Size(380, 27);
            searchTextBox.PlaceholderText = "Type part of a user's name";

            searchButton.Location = new Point(410, 17);
            searchButton.Size = new Size(110, 29);
            searchButton.Text = "Search";
            searchButton.Click += SearchButton_Click;

            hintLabel.Location = new Point(18, 56);
            hintLabel.Size = new Size(500, 24);
            hintLabel.Text = "Click Search with an empty box to show up to 100 users.";

            resultsListBox.Location = new Point(18, 88);
            resultsListBox.Size = new Size(502, 340);
            resultsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsListBox.DisplayMember = nameof(SearchUserResult.DisplayName);
            resultsListBox.Click += ResultsListBox_Click;

            Controls.Add(searchTextBox);
            Controls.Add(searchButton);
            Controls.Add(hintLabel);
            Controls.Add(resultsListBox);
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            SearchUsers(searchTextBox.Text.Trim());
        }

        private void ResultsListBox_Click(object? sender, EventArgs e)
        {
            OpenSelectedProfile();
        }

        private void OpenSelectedProfile()
        {
            if (resultsListBox.SelectedItem is not SearchUserResult selectedUser)
            {
                return;
            }

            using UserProfileForm profileForm = selectedUser.UserId == currentUserId
                ? new UserProfileForm(currentUserId)
                : new UserProfileForm(selectedUser.UserId, currentUserId);

            profileForm.ShowDialog(this);
        }

        private void SearchUsers(string searchText)
        {
            resultsListBox.Items.Clear();

            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                string.IsNullOrWhiteSpace(searchText)
                    ? @"SELECT TOP 100 User_id, First_name, Last_name, Email
                        FROM [User]
                        ORDER BY First_name, Last_name"
                    : @"SELECT TOP 100 User_id, First_name, Last_name, Email
                        FROM [User]
                        WHERE First_name LIKE @Search
                           OR Last_name LIKE @Search
                           OR (First_name + ' ' + Last_name) LIKE @Search
                        ORDER BY First_name, Last_name",
                con);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 201).Value = $"%{searchText}%";
            }

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                resultsListBox.Items.Add(new SearchUserResult(
                    Convert.ToInt32(reader["User_id"]),
                    reader["First_name"]?.ToString() ?? "",
                    reader["Last_name"]?.ToString() ?? "",
                    reader["Email"]?.ToString() ?? ""));
            }
        }

        private sealed class SearchUserResult
        {
            public SearchUserResult(int userId, string firstName, string lastName, string email)
            {
                UserId = userId;
                DisplayName = $"{firstName} {lastName}".Trim();
                if (!string.IsNullOrWhiteSpace(email))
                {
                    DisplayName = $"{DisplayName} ({email})";
                }
            }

            public int UserId { get; }
            public string DisplayName { get; }
        }
    }
}
