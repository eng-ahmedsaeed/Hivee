using System.Data;
using System.Data.SqlClient;

namespace Hivee.Profile
{
    public class UserProfileForm : Form
    {
        private const string ConnectionString = "Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI";

        private readonly int userId;
        private readonly int currentUserId;
        private readonly bool isOwnProfile;
        private readonly PictureBox avatarPictureBox = new();
        private readonly Label nameLabel = new();
        private readonly Label emailLabel = new();
        private readonly Label bioLabel = new();
        private readonly Button followersButton = new();
        private readonly Button followingButton = new();
        private readonly ListBox peopleListBox = new();
        private readonly Button unfollowButton = new();
        private readonly Button userSettingsButton = new();
        private readonly Button deleteUserButton = new();
        private readonly Button followButton = new();
        private readonly Label listTitleLabel = new();

        public UserProfileForm(int userId) : this(userId, userId)
        {
        }

        public UserProfileForm(int profileUserId, int currentUserId)
        {
            userId = profileUserId;
            this.currentUserId = currentUserId;
            isOwnProfile = profileUserId == currentUserId;
            InitializeProfileForm();
            Load += UserProfileForm_Load;
        }

        private void InitializeProfileForm()
        {
            Text = "Profile";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(620, 620);
            MinimumSize = new Size(560, 560);

            avatarPictureBox.Location = new Point(24, 24);
            avatarPictureBox.Size = new Size(96, 96);
            avatarPictureBox.BorderStyle = BorderStyle.FixedSingle;
            avatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            nameLabel.Location = new Point(140, 28);
            nameLabel.Size = new Size(420, 28);
            nameLabel.Font = new Font(Font, FontStyle.Bold);

            emailLabel.Location = new Point(140, 62);
            emailLabel.Size = new Size(420, 24);

            bioLabel.Location = new Point(140, 92);
            bioLabel.Size = new Size(420, 56);

            followersButton.Location = new Point(24, 150);
            followersButton.Size = new Size(150, 36);
            followersButton.Click += FollowersButton_Click;

            followingButton.Location = new Point(190, 150);
            followingButton.Size = new Size(150, 36);
            followingButton.Click += FollowingButton_Click;

            userSettingsButton.Location = new Point(356, 150);
            userSettingsButton.Size = new Size(115, 36);
            userSettingsButton.Text = "User Settings";
            userSettingsButton.Click += UserSettingsButton_Click;

            deleteUserButton.Location = new Point(485, 150);
            deleteUserButton.Size = new Size(110, 36);
            deleteUserButton.Text = "Delete User";
            deleteUserButton.Click += DeleteUserButton_Click;

            followButton.Location = new Point(356, 150);
            followButton.Size = new Size(115, 36);
            followButton.Text = "Follow";
            followButton.Visible = !isOwnProfile;
            followButton.Click += FollowButton_Click;

            userSettingsButton.Visible = isOwnProfile;
            deleteUserButton.Visible = isOwnProfile;

            listTitleLabel.Location = new Point(24, 210);
            listTitleLabel.Size = new Size(530, 24);
            listTitleLabel.Text = "Click Followers or Following";

            peopleListBox.Location = new Point(24, 240);
            peopleListBox.Size = new Size(530, 260);
            peopleListBox.DisplayMember = nameof(ProfilePerson.DisplayName);

            unfollowButton.Location = new Point(24, 515);
            unfollowButton.Size = new Size(150, 34);
            unfollowButton.Text = "Unfollow";
            unfollowButton.Enabled = false;
            unfollowButton.Click += UnfollowButton_Click;

            Controls.Add(avatarPictureBox);
            Controls.Add(nameLabel);
            Controls.Add(emailLabel);
            Controls.Add(bioLabel);
            Controls.Add(followersButton);
            Controls.Add(followingButton);
            Controls.Add(userSettingsButton);
            Controls.Add(deleteUserButton);
            Controls.Add(followButton);
            Controls.Add(listTitleLabel);
            Controls.Add(peopleListBox);
            Controls.Add(unfollowButton);
        }

        private void UserProfileForm_Load(object? sender, EventArgs e)
        {
            LoadProfile();
        }

        private void FollowersButton_Click(object? sender, EventArgs e)
        {
            LoadPeopleList("Followers", allowUnfollow: false);
        }

        private void FollowingButton_Click(object? sender, EventArgs e)
        {
            LoadPeopleList("Following", allowUnfollow: true);
        }

        private void UnfollowButton_Click(object? sender, EventArgs e)
        {
            if (!isOwnProfile)
            {
                return;
            }

            if (peopleListBox.SelectedItem is not ProfilePerson selectedPerson)
            {
                MessageBox.Show("Select a user to unfollow first.");
                return;
            }

            Unfollow(selectedPerson.UserId);
            LoadProfile();
            LoadPeopleList("Following", allowUnfollow: true);
            MessageBox.Show("User unfollowed.");
        }

        private void FollowButton_Click(object? sender, EventArgs e)
        {
            FollowProfileUser();
            LoadProfile();
            MessageBox.Show("User followed.");
        }

        private void UserSettingsButton_Click(object? sender, EventArgs e)
        {
            using UserSettingsForm settingsForm = new UserSettingsForm(userId);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadProfile();
            }
        }

        private void DeleteUserButton_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Delete this user and related data such as posts, pages, comments, follows, messages, and events?",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            DeleteUserAndOwnedData();
            MessageBox.Show("User deleted.");
            Close();
        }

        private void LoadProfile()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"SELECT u.First_name, u.Last_name, u.Email, u.Bio, u.Avatar_url,
                         (SELECT COUNT(*) FROM Follow WHERE Followed_user_id = u.User_id) AS FollowersCount,
                         (SELECT COUNT(*) FROM Follow WHERE Follower_user_id = u.User_id) AS FollowingCount
                  FROM [User] u
                  WHERE u.User_id = @User_id",
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

            string firstName = reader["First_name"]?.ToString() ?? "";
            string lastName = reader["Last_name"]?.ToString() ?? "";
            string avatarPath = reader["Avatar_url"]?.ToString() ?? "";

            nameLabel.Text = $"{firstName} {lastName}".Trim();
            emailLabel.Text = reader["Email"]?.ToString() ?? "";
            bioLabel.Text = reader["Bio"]?.ToString() ?? "";
            followersButton.Text = $"Followers: {reader["FollowersCount"]}";
            followingButton.Text = $"Following: {reader["FollowingCount"]}";
            LoadAvatar(avatarPath);
        }

        private void LoadPeopleList(string listType, bool allowUnfollow)
        {
            peopleListBox.Items.Clear();
            unfollowButton.Enabled = isOwnProfile && allowUnfollow;
            listTitleLabel.Text = listType;

            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                allowUnfollow
                    ? @"SELECT u.User_id, u.First_name, u.Last_name, u.Email
                        FROM Follow f
                        JOIN [User] u ON u.User_id = f.Followed_user_id
                        WHERE f.Follower_user_id = @User_id"
                    : @"SELECT u.User_id, u.First_name, u.Last_name, u.Email
                        FROM Follow f
                        JOIN [User] u ON u.User_id = f.Follower_user_id
                        WHERE f.Followed_user_id = @User_id",
                con);

            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                peopleListBox.Items.Add(new ProfilePerson(
                    Convert.ToInt32(reader["User_id"]),
                    reader["First_name"]?.ToString() ?? "",
                    reader["Last_name"]?.ToString() ?? "",
                    reader["Email"]?.ToString() ?? ""));
            }
        }

        private void Unfollow(int followedUserId)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"DELETE FROM Follow
                  WHERE Follower_user_id = @Follower_user_id
                    AND Followed_user_id = @Followed_user_id",
                con);

            cmd.Parameters.Add("@Follower_user_id", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@Followed_user_id", SqlDbType.Int).Value = followedUserId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private void FollowProfileUser()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"IF NOT EXISTS (
                      SELECT 1
                      FROM Follow
                      WHERE Follower_user_id = @Current_user_id
                        AND Followed_user_id = @Profile_user_id
                  )
                  BEGIN
                      INSERT INTO Follow (Follower_user_id, Followed_user_id)
                      VALUES (@Current_user_id, @Profile_user_id)
                  END",
                con);

            cmd.Parameters.Add("@Current_user_id", SqlDbType.Int).Value = currentUserId;
            cmd.Parameters.Add("@Profile_user_id", SqlDbType.Int).Value = userId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private void DeleteUserAndOwnedData()
        {
            using SqlConnection con = new(ConnectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();

            try
            {
                ExecuteNonQuery(con, transaction,
                    @"DECLARE @OwnedPosts TABLE (Post_id INT PRIMARY KEY);

                      INSERT INTO @OwnedPosts (Post_id)
                      SELECT Post_id
                      FROM Post
                      WHERE User_ID = @User_id
                         OR Page_id IN (SELECT Page_id FROM Page WHERE Creator_id = @User_id);

                      DECLARE @OwnedMessages TABLE (Message_id INT PRIMARY KEY);

                      INSERT INTO @OwnedMessages (Message_id)
                      SELECT Message_id
                      FROM DM
                      WHERE Suser_id = @User_id OR Ruser_id = @User_id;

                      DELETE FROM Hashtag
                      WHERE Post_id IN (SELECT Post_id FROM @OwnedPosts);

                      DELETE FROM Comment
                      WHERE User_ID = @User_id
                         OR Post_id IN (SELECT Post_id FROM @OwnedPosts);

                      DELETE FROM Attachment_type_Message
                      WHERE Message_id IN (SELECT Message_id FROM @OwnedMessages);

                      DELETE FROM DM
                      WHERE Suser_id = @User_id OR Ruser_id = @User_id;

                      DELETE FROM Message
                      WHERE Message_id IN (SELECT Message_id FROM @OwnedMessages);

                      DELETE FROM Follow
                      WHERE Follower_user_id = @User_id OR Followed_user_id = @User_id;

                      DELETE FROM Join_Page
                      WHERE User_id = @User_id
                         OR Page_id IN (SELECT Page_id FROM Page WHERE Creator_id = @User_id);

                      DELETE FROM Participate
                      WHERE User_id = @User_id
                         OR Event_id IN (SELECT Event_id FROM Event WHERE Creator_id = @User_id);

                      DELETE FROM Location
                      WHERE Event_id IN (SELECT Event_id FROM Event WHERE Creator_id = @User_id);

                      DELETE FROM Phone_Number
                      WHERE User_id = @User_id;

                      DELETE FROM Post
                      WHERE Post_id IN (SELECT Post_id FROM @OwnedPosts);

                      DELETE FROM Page
                      WHERE Creator_id = @User_id;

                      DELETE FROM Event
                      WHERE Creator_id = @User_id;

                      DELETE FROM [User]
                      WHERE User_id = @User_id;");

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private void ExecuteNonQuery(SqlConnection con, SqlTransaction transaction, string commandText)
        {
            using SqlCommand cmd = new(commandText, con, transaction);
            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;
            cmd.ExecuteNonQuery();
        }

        private void LoadAvatar(string avatarPath)
        {
            avatarPictureBox.Image = ImageLoader.LoadFromPathOrUrl(avatarPath);
        }

        private sealed class ProfilePerson
        {
            public ProfilePerson(int userId, string firstName, string lastName, string email)
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
