using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
namespace Hivee

{

    public partial class Form1 : Form
    {
        int userId;
        string firstName = "";
        string lastName = "";
        string PfPPath = "";

        public Form1(int UserId)
        {
            InitializeComponent();
            userId = UserId;
            GetuserData();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Getting User Reuired data


            Random rnd = new Random();
            DataTable allPosts = FetchuserPosts().Clone();
            //allPosts.Merge(FetchPostsFromFollower());
            //allPosts.Merge(FetchPostsFromPage());
            allPosts.Merge(FetchuserPosts());
            var shuffledRows = allPosts.AsEnumerable().OrderBy(r => rnd.Next()).ToList();

            foreach (var post in shuffledRows)
            {
                int currentY = 20;
                String userFirstName = post["First_name"].ToString();
                String userLastName = post["Last_name"].ToString();
                String PublishTime = post["Publish_TimeStamp"].ToString();
                String Posttext = post["text_content"].ToString();
                String PostImagePath = post["Media_Path"].ToString();
                String postid = post["Post_id"].ToString();
                String ownerPFP = post["Owner_Avatar_Url"].ToString();
                //Creating wrapper
                Panel wrapper = new Panel();

                wrapper.Name = "Wrapper";

                wrapper.Size = new Size(1171, 533);

                wrapper.Margin = new Padding(3);

                wrapper.Padding = new Padding(0);

                wrapper.Anchor =
                            AnchorStyles.Top;

                wrapper.AutoSize = false;

                wrapper.AutoSizeMode = AutoSizeMode.GrowOnly;

                wrapper.TabStop = false;

                wrapper.Visible = true;


                //PostOwnerPfP
                PictureBox PostOwnerPic = new PictureBox();

                PostOwnerPic.Name = "PostOwnerPic";

                PostOwnerPic.Size = new Size(51, 42);

                PostOwnerPic.Location = new Point(18, 20);

                PostOwnerPic.Margin = new Padding(3);

                PostOwnerPic.Padding = new Padding(0);

                PostOwnerPic.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                PostOwnerPic.Dock = DockStyle.None;

                PostOwnerPic.Enabled = true;

                PostOwnerPic.Visible = true;

                PostOwnerPic.TabStop = false;

                //taking the Pfp path from the DB and get teh photo from the file system 
                if (File.Exists(ownerPFP))
                {
                    PostOwnerPic.Image = Image.FromFile(ownerPFP);
                    PostOwnerPic.SizeMode = PictureBoxSizeMode.StretchImage;

                }

                //PostOwnername
                Label PostOwnername = new Label();

                PostOwnername.Name = "Postownername";
                PostOwnername.Text = post["First_name"].ToString() + " " + post["Last_name"].ToString();

                PostOwnername.AutoSize = true;

                PostOwnername.Location = new Point(81, 20);

                PostOwnername.Margin = new Padding(3, 0, 3, 0);

                PostOwnername.Padding = new Padding(0);

                PostOwnername.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                PostOwnername.Dock = DockStyle.None;

                PostOwnername.Size = new Size(59, 20);

                PostOwnername.UseCompatibleTextRendering = false;

                PostOwnername.Visible = true;

                PostOwnername.CausesValidation = true;

                //PostContent

                RichTextBox PostTextContent = new RichTextBox();

                PostTextContent.Name = "PostTextContent";
                PostTextContent.Text = Posttext;

                PostTextContent.Size = new Size(1023, 69);

                PostTextContent.Location = new Point(71, 73);

                PostTextContent.Margin = new Padding(3);

                PostTextContent.Anchor = AnchorStyles.Top
                                    | AnchorStyles.Left
                                    | AnchorStyles.Right;

                PostTextContent.Dock = DockStyle.None;

                PostTextContent.Visible = true;

                PostTextContent.TabStop = true;

                PostTextContent.WordWrap = true;
                PostTextContent.ReadOnly = true;

                PostTextContent.ZoomFactor = 1f;

                PostTextContent.CausesValidation = true;

                //////PostPicture
                if (File.Exists(PostImagePath))
                {
                    currentY = 148;
                    PictureBox PostPicture = new PictureBox();
                    PostPicture.Image = Image.FromFile(PostImagePath);
                    PostPicture.SizeMode = PictureBoxSizeMode.StretchImage;





                    PostPicture.Name = "PostPicture";

                    PostPicture.Size = new Size(1013, 165);

                    PostPicture.Location = new Point(71, currentY);

                    PostPicture.Margin = new Padding(3);

                    PostPicture.Padding = new Padding(0);

                    PostPicture.Anchor = AnchorStyles.Top
                                       | AnchorStyles.Left
                                       | AnchorStyles.Right;

                    PostPicture.Dock = DockStyle.None;



                    PostPicture.Enabled = true;

                    PostPicture.Visible = true;

                    PostPicture.TabStop = false;
                    wrapper.Controls.Add(PostPicture);
                    currentY += 180;
                }

                ///////////////////////CommentSection////////////////////
                ///CommentCount
                if (!File.Exists(PostImagePath))
                {
                    currentY = 150;
                }
                Label CommentCount = new Label();

                CommentCount.Name = "CommentCount";
                int count = GetCommentCount(post["Post_id"].ToString());

                CommentCount.Text = "💬No.OfComments" + count.ToString();

                CommentCount.AutoSize = true;

                CommentCount.Location = new Point(81, currentY + 10);

                CommentCount.Margin = new Padding(3, 0, 3, 0);

                CommentCount.Padding = new Padding(0);

                CommentCount.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                CommentCount.Dock = DockStyle.None;

                CommentCount.Size = new Size(59, 20);

                CommentCount.UseCompatibleTextRendering = false;

                CommentCount.Visible = true;

                CommentCount.CausesValidation = true;

                //AddComment
                RichTextBox AddCommentText = new RichTextBox();

                AddCommentText.Name = "richTextBox2";


                AddCommentText.Size = new Size(1023, 69);

                AddCommentText.Location = new Point(71, currentY + 45);

                AddCommentText.Margin = new Padding(3);

                AddCommentText.Anchor = AnchorStyles.Top
                                    | AnchorStyles.Left
                                    | AnchorStyles.Right;

                AddCommentText.Dock = DockStyle.None;

                AddCommentText.Visible = true;

                AddCommentText.TabStop = true;

                AddCommentText.WordWrap = true;

                AddCommentText.ZoomFactor = 1f;

                AddCommentText.CausesValidation = true;
                //////////////USer PFP



                PictureBox UserPFP = new PictureBox();


                if (File.Exists(PfPPath))
                {
                    UserPFP.Name = "UserPFP";
                    UserPFP.Image = Image.FromFile(PfPPath);
                    UserPFP.SizeMode = PictureBoxSizeMode.StretchImage;

                    UserPFP.Size = new Size(51, 42);
                    UserPFP.Location = new Point(18, currentY + 45);
                    UserPFP.Margin = new Padding(3);
                    UserPFP.Padding = new Padding(0);
                    UserPFP.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    UserPFP.Dock = DockStyle.None;

                    UserPFP.Enabled = true;
                    UserPFP.Visible = true;
                    UserPFP.TabStop = false;
                    wrapper.Controls.Add(UserPFP);

                }
                ////Creating AddComment Button
                Button ShowComments = new Button();

                ShowComments.Name = "AddCommentButton";

                ShowComments.Text = "Show Comments";

                ShowComments.Size = new Size(120, 35);

                ShowComments.Location = new Point(850, currentY + 120);

                ShowComments.Margin = new Padding(3);

                ShowComments.Padding = new Padding(0);

                ShowComments.Anchor = AnchorStyles.Top
                                          | AnchorStyles.Left
                                          | AnchorStyles.Right;

                ShowComments.Dock = DockStyle.None;

                ShowComments.AutoSize = false;

                ShowComments.AutoSizeMode = AutoSizeMode.GrowOnly;

                ShowComments.Visible = true;

                ShowComments.CausesValidation = true;
                ////Creating AddComment Button
                Button AddCommentButton = new Button();

                AddCommentButton.Name = "AddCommentButton";

                AddCommentButton.Text = "Add Comment";

                AddCommentButton.Size = new Size(120, 35);

                AddCommentButton.Location = new Point(974, currentY + 120);

                AddCommentButton.Margin = new Padding(3);

                AddCommentButton.Padding = new Padding(0);

                AddCommentButton.Anchor = AnchorStyles.Top
                                          | AnchorStyles.Left
                                          | AnchorStyles.Right;

                AddCommentButton.Dock = DockStyle.None;

                AddCommentButton.AutoSize = false;

                AddCommentButton.AutoSizeMode = AutoSizeMode.GrowOnly;

                AddCommentButton.Visible = true;

                AddCommentButton.CausesValidation = true;


                //////////////////
                wrapper.Controls.Add(PostOwnerPic);
                wrapper.Controls.Add(PostOwnername);
                wrapper.Controls.Add(PostTextContent);

                wrapper.Controls.Add(CommentCount);
                wrapper.Controls.Add(AddCommentText);
                wrapper.Height = currentY + 170;
                wrapper.Controls.Add(ShowComments);
                wrapper.Controls.Add(AddCommentButton);
                Scroll.Controls.Add(wrapper);

            }

        }



        private DataTable FetchPostsFromFollower()
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            con.Open();
            SqlDataReader reader = null;
            DataTable PostsFromFollowing = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GetPostsByFollowing(@User_id)", con);

                SqlParameter User = cmd.Parameters.Add("@User_id", SqlDbType.Int);
                User.Direction = ParameterDirection.Input;
                User.Value = userId;
                //Another way
                //    SqlParameter User = cmd.Parameters.Add(new SqlParameter("@User_id",10));
                //    User.Direction = ParameterDirection.Output;
                //    User.Value = userId;
                reader = cmd.ExecuteReader();
                PostsFromFollowing.Columns.Add("Post_id");
                PostsFromFollowing.Columns.Add("Text_content");
                PostsFromFollowing.Columns.Add("Publish_TimeStamp");
                PostsFromFollowing.Columns.Add("Media_Path");
                PostsFromFollowing.Columns.Add("First_name");
                PostsFromFollowing.Columns.Add("Last_name");
                PostsFromFollowing.Columns.Add("Owner_Avatar_Url");
                DataRow row;
                //here we get Table of usersId thet is followed by the user
                while (reader.Read())
                {
                    row = PostsFromFollowing.NewRow();
                    row["Post_id"] = reader["Post_id"];
                    row["text_content"] = reader["text_content"];
                    row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
                    row["Media_Path"] = reader["Media_Path"];
                    row["First_name"] = reader["First_name"];
                    row["Last_name"] = reader["Last_name"];
                    row["Owner_Avatar_Url"] = reader["Owner_Avatar_Url"];
                    PostsFromFollowing.Rows.Add(row);

                }
                return PostsFromFollowing;
            }
            catch (Exception Ex)

            {
                MessageBox.Show(Ex.Message);
                return PostsFromFollowing;

            }
            finally
            {
                if (con != null)
                {

                    con.Close();
                }
                if (reader != null)
                {

                    reader.Close();
                }
            }





        }

        private DataTable FetchPostsFromPage()
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            con.Open();
            SqlDataReader reader = null;
            DataTable PostsFromPages = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GetPostsByJoinedPages(@User_id)", con);

                SqlParameter UserId = cmd.Parameters.Add(new("@User_id", userId));
                UserId.Direction = ParameterDirection.Input;
                reader = cmd.ExecuteReader();
                PostsFromPages.Columns.Add("Post_id");
                PostsFromPages.Columns.Add("Text_content");
                PostsFromPages.Columns.Add("Publish_TimeStamp");
                PostsFromPages.Columns.Add("Media_Path");
                PostsFromPages.Columns.Add("First_name");
                PostsFromPages.Columns.Add("Last_name");
                PostsFromPages.Columns.Add("Owner_Avatar_Url");
                DataRow row;
                while (reader.Read())
                {
                    row = PostsFromPages.NewRow();
                    row["Post_id"] = reader["Post_id"];
                    row["text_content"] = reader["text_content"];
                    row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
                    row["Media_Path"] = reader["Media_Path"];
                    row["First_name"] = reader["First_name"];
                    row["Owner_Avatar_Url"] = reader["Owner_Avatar_Url"];
                    row["Last_name"] = reader["Last_name"];
                    PostsFromPages.Rows.Add(row);

                }
                return PostsFromPages;
            }


            catch (Exception Ex)

            {
                MessageBox.Show(Ex.Message);
                return PostsFromPages;

            }
            finally
            {
                if (con != null)
                {

                    con.Close();
                }
                if (reader != null)
                {

                    reader.Close();
                }
            }

        }

        private DataTable FetchuserPosts()
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            SqlDataReader reader = null;
            DataTable UserPosts = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM GetPostsByUser(@User_id)", con);

                SqlParameter UserId = cmd.Parameters.Add(new("@User_id", userId));
                UserId.Direction = ParameterDirection.Input;
                reader = cmd.ExecuteReader();
                UserPosts.Columns.Add("Post_id");
                UserPosts.Columns.Add("Text_content");
                UserPosts.Columns.Add("Publish_TimeStamp");
                UserPosts.Columns.Add("Media_Path");
                UserPosts.Columns.Add("First_name");
                UserPosts.Columns.Add("Last_name");
                UserPosts.Columns.Add("Owner_Avatar_Url");
                DataRow row;
                while (reader.Read())
                {
                    row = UserPosts.NewRow();
                    row["Post_id"] = reader["Post_id"];
                    row["text_content"] = reader["text_content"];
                    row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
                    row["Media_Path"] = reader["Media_Path"];
                    row["Owner_Avatar_Url"] = reader["Owner_Avatar_Url"];
                    row["First_name"] = firstName;
                    row["Last_name"] = lastName;
                    UserPosts.Rows.Add(row);

                }
                return UserPosts;
            }


            catch (Exception Ex)

            {

                MessageBox.Show(Ex.Message);
                return UserPosts;

            }
            finally
            {
                if (con != null)
                {

                    con.Close();
                }
                if (reader != null)
                {

                    reader.Close();
                }
            }

        }

        private void GetuserData()
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            SqlDataReader reader = null;
            SqlCommand userCmd = new SqlCommand("SELECT First_name, Last_name,Avatar_url FROM [User] WHERE User_id = @User_id", con);
            SqlParameter user = userCmd.Parameters.Add(new("@User_id", userId));
            try
            {

                con.Open();
                reader = userCmd.ExecuteReader();
                if (reader.Read())
                {
                    firstName = reader["First_name"].ToString();
                    lastName = reader["Last_name"].ToString();
                    PfPPath = reader["Avatar_url"].ToString();
                }


            }
            catch (Exception Ex)

            {

                MessageBox.Show(Ex.Message);


            }
            finally
            {
                if (con != null)
                {

                    con.Close();
                }
                if (reader != null)
                {

                    reader.Close();

                }
            }

        }


        private int GetCommentCount(String posts)
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand(@"Select count(*) From Comment c inner join Post p on p.Post_iD=c.Post_iD  Where p.Post_iD=@Id", con);
                SqlParameter idparam = cmd.Parameters.Add(new SqlParameter("@ID", posts));
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return -1;
            }
            finally
            {
                con.Close();
            }

        }

        private void CreatePost(string userID)
        {
            //SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
            //con.Open();
            //try
            //{

            //    SqlCommand cmd = new SqlCommand("Select * From AddPost(    @User_ID , @Page_id INT  ,@Text_Content , @Media_path ) ", con);
            //    SqlParameter idparam = cmd.Parameters.Add(new SqlParameter("@ID", posts));
            //    return (int)cmd.ExecuteScalar();
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //    return -1;
            //}
            //finally
            //{
            //    con.Close();
            //}


        }

        private void CreatePostButton_Click(object sender, EventArgs e)
        {

        }


        //private void GetPostsComment()
        // {
        //     SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=Social Media;Integrated Security = SSPI");
        //     SqlDataReader reader = null;
        //     DataTable PostComment = new DataTable();

        //     try
        //     {
        //         con.Open();
        //         SqlCommand cmd = new SqlCommand("SELECT * FROM GetCommentsByPost(@User_id)", con);

        //         SqlParameter UserId = cmd.Parameters.Add(new("@User_id", userId));
        //         UserId.Direction = ParameterDirection.Input;
        //         reader = cmd.ExecuteReader();

        //         DataRow row;
        //         while (reader.Read())
        //         {
        //             row = PostComment.NewRow();
        //             row["Post_id"] = reader["Post_id"];
        //             row["text_content"] = reader["text_content"];
        //             row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
        //             row["Media_Path"] = reader["Media_Path"];
        //             row["First_name"] = firstName;
        //             row["Last_name"] = lastName;
        //             UserPosts.Rows.Add(row);

        //         }
        //         return UserPosts;
        //     }


        //     catch (Exception Ex)

        //     {

        //         MessageBox.Show(Ex.Message);
        //         return UserPosts;

        //     }
        //     finally
        //     {
        //         if (con != null)
        //         {

        //             con.Close();
        //         }
        //         if (reader != null)
        //         {

        //             reader.Close();
        //         }
        //     }
        // }



    }
}
