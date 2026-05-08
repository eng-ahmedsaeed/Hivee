using System.Data;
using System.Data.SqlClient;

namespace Hivee
{
    public partial class Form2 : Form
    {
        private const string ConnectionString = "Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI";

        private readonly int userId;
        private string firstName = "";
        private string lastName = "";
        private string profilePicturePath = "";
        private int? editingPostId;

        public Form2() : this(1)
        {
        }

        public Form2(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetUserData();
            LoadCurrentUserPosts();
        }

        private void DisplayProfileButton_Click(object? sender, EventArgs e)
        {
            using UserProfileForm profileForm = new UserProfileForm(userId);
            profileForm.ShowDialog(this);
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            using UserSearchForm searchForm = new UserSearchForm(userId);
            searchForm.ShowDialog(this);
        }

        private void LoadCurrentUserPosts()
        {
            PostsScroll.Controls.Clear();

            DataTable posts = FetchUserPosts();
            foreach (DataRow post in posts.Rows)
            {
                PostsScroll.Controls.Add(CreatePostPanelFromRow(post));
            }
        }

        private Panel CreatePostPanelFromRow(DataRow post)
        {
            int postId = Convert.ToInt32(post["Post_id"]);
            string postText = post["Text_content"]?.ToString() ?? "";
            string publishTime = post["Publish_TimeStamp"]?.ToString() ?? "";
            string mediaPath = post["Media_Path"]?.ToString() ?? "";
            string ownerAvatarPath = post["Owner_Avatar_Url"]?.ToString() ?? "";
            int currentY = 20;

            Panel wrapper = new()
            {
                Name = "PostWrapper",
                Size = new Size(1171, 533),
                Margin = new Padding(3),
                Anchor = AnchorStyles.Top,
                AutoSize = false
            };

            PictureBox ownerPicture = new()
            {
                Name = "PostOwnerPic",
                Size = new Size(51, 42),
                Location = new Point(18, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                TabStop = false
            };

            ownerPicture.Image = ImageLoader.LoadFromPathOrUrl(ownerAvatarPath);

            Label ownerName = new()
            {
                Name = "PostOwnerName",
                Text = $"{post["First_name"]} {post["Last_name"]}".Trim(),
                AutoSize = true,
                Location = new Point(81, 20)
            };

            Label publishedAt = new()
            {
                Name = "PublishedAt",
                Text = publishTime,
                AutoSize = true,
                Location = new Point(81, 42)
            };

            Button deleteButton = new()
            {
                Name = "DeletePostButton",
                Text = "Delete",
                Size = new Size(132, 40),
                Location = new Point(815, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = postId
            };
            deleteButton.Click += DeletePostButton_Click;

            Button updateButton = new()
            {
                Name = "UpdatePostButton",
                Text = "Update",
                Size = new Size(132, 40),
                Location = new Point(953, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = postId
            };
            updateButton.Click += UpdatePostButton_Click;

            RichTextBox postContent = new()
            {
                Name = "PostTextContent",
                Text = postText,
                Size = new Size(1023, 69),
                Location = new Point(71, 73),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                WordWrap = true,
                Tag = postId
            };

            wrapper.Controls.Add(ownerPicture);
            wrapper.Controls.Add(ownerName);
            wrapper.Controls.Add(publishedAt);
            wrapper.Controls.Add(deleteButton);
            wrapper.Controls.Add(updateButton);
            wrapper.Controls.Add(postContent);

            Image? postImage = ImageLoader.LoadFromPathOrUrl(mediaPath);
            if (postImage is not null)
            {
                currentY = 148;
                PictureBox postPicture = new()
                {
                    Name = "PostPicture",
                    Image = postImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(1013, 165),
                    Location = new Point(71, currentY),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    TabStop = false
                };
                wrapper.Controls.Add(postPicture);
                currentY += 180;
            }
            else
            {
                currentY = 150;
            }

            Label commentCount = new()
            {
                Name = "CommentCount",
                Text = "Comments: " + GetCommentCount(postId),
                AutoSize = true,
                Location = new Point(81, currentY + 10)
            };

            wrapper.Controls.Add(commentCount);
            wrapper.Height = currentY + 70;
            return wrapper;
        }

        private void DeletePostButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not int postId)
            {
                MessageBox.Show("No post is selected for deletion.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this post?",
                "Delete Post",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            DeletePost(postId);
            LoadCurrentUserPosts();
            MessageBox.Show("Post deleted.");
        }

        private void UpdatePostButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not int postId)
            {
                MessageBox.Show("No post is selected for update.");
                return;
            }

            string? postText = GetPostTextById(postId);
            if (postText is null)
            {
                MessageBox.Show("Post was not found in the database.");
                return;
            }

            editingPostId = postId;
            using PostEditorForm editor = new(postText);
            if (editor.ShowDialog(this) != DialogResult.OK)
            {
                editingPostId = null;
                return;
            }

            UpdatePost(editingPostId.Value, editor.PostText, GetPostMediaPathById(editingPostId.Value));
            editingPostId = null;
            LoadCurrentUserPosts();
            MessageBox.Show("Post updated.");
        }

        private DataTable FetchUserPosts()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new("SELECT * FROM GetPostsByUser(@User_id)", con);
            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;

            DataTable userPosts = CreatePostsTable();

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DataRow row = userPosts.NewRow();
                row["Post_id"] = reader["Post_id"];
                row["Text_content"] = reader["Text_content"];
                row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
                row["Media_Path"] = reader["Media_Path"];
                row["Owner_Avatar_Url"] = reader["Owner_Avatar_Url"];
                row["First_name"] = firstName;
                row["Last_name"] = lastName;
                userPosts.Rows.Add(row);
            }

            return userPosts;
        }

        private static DataTable CreatePostsTable()
        {
            DataTable table = new();
            table.Columns.Add("Post_id", typeof(int));
            table.Columns.Add("Text_content");
            table.Columns.Add("Publish_TimeStamp");
            table.Columns.Add("Media_Path");
            table.Columns.Add("First_name");
            table.Columns.Add("Last_name");
            table.Columns.Add("Owner_Avatar_Url");
            return table;
        }

        private void GetUserData()
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                "SELECT First_name, Last_name, Avatar_url FROM [User] WHERE User_id = @User_id",
                con);

            cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = userId;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                firstName = reader["First_name"]?.ToString() ?? "";
                lastName = reader["Last_name"]?.ToString() ?? "";
                profilePicturePath = reader["Avatar_url"]?.ToString() ?? "";
                UserNameLabel.Text = $"{firstName} {lastName}".Trim();

                UserPic.Image = ImageLoader.LoadFromPathOrUrl(profilePicturePath);
                UserPic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private static int GetCommentCount(int postId)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                @"SELECT COUNT(*)
                  FROM Comment c
                  INNER JOIN Post p ON p.Post_id = c.Post_id
                  WHERE p.Post_id = @Post_id",
                con);

            cmd.Parameters.Add("@Post_id", SqlDbType.Int).Value = postId;

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static void DeletePost(int postId)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new("DeletePost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Post_id", SqlDbType.Int).Value = postId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private static void UpdatePost(int postId, string newText, string? mediaPath)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new("UpdatePost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Post_id", SqlDbType.Int).Value = postId;
            cmd.Parameters.Add("@Text_Content", SqlDbType.VarChar).Value = newText;
            cmd.Parameters.Add("@Media_path", SqlDbType.VarChar, 500).Value =
                string.IsNullOrWhiteSpace(mediaPath) ? DBNull.Value : mediaPath;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private static string? GetPostTextById(int postId)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                "SELECT Text_Content FROM Post WHERE Post_id = @Post_id",
                con);

            cmd.Parameters.Add("@Post_id", SqlDbType.Int).Value = postId;

            con.Open();
            object? result = cmd.ExecuteScalar();
            return result?.ToString();
        }

        private static string? GetPostMediaPathById(int postId)
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new(
                "SELECT Media_path FROM Post WHERE Post_id = @Post_id",
                con);

            cmd.Parameters.Add("@Post_id", SqlDbType.Int).Value = postId;

            con.Open();
            object? result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : result?.ToString();
        }
    }
}
