using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Hivee

{

    public partial class Form1 : Form
    {
        int userId;
        string firstName = "";
        string lastName = "";
        string PfPPath = "";
        string uploadedMedia = "";
       
        public Form1(int UserId)
        {
            InitializeComponent();
            userId = UserId;
            GetuserData();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Getting User Reuired data



            LoadPosts();



        }


        private void LoadPosts()
        {

            Random rnd = new Random();
            DataTable allPosts = FetchuserPosts().Clone();
            allPosts.Merge(FetchPostsFromFollower());
            allPosts.Merge(FetchPostsFromPage());
            allPosts.Merge(FetchuserPosts());
            var shuffledRows = allPosts.AsEnumerable().OrderBy(r => rnd.Next()).ToList();
            DataTable Pages = GetUserPages();
            PagesComboBox.DataSource = Pages;
            PagesComboBox.DisplayMember = "Page_name";
            PagesComboBox.ValueMember = "Page_id";
            PagesComboBox.SelectedIndex = -1;
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
                //7ot 2el id hena we 7ot 2el Text box kolo fe 2el button
                AddCommentText.Tag = postid;
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
                ////Creating Show comments Button
                Button ShowComments = new Button();

                ShowComments.Name = "AddCommentButton";
                ShowComments.Click+= ViewComments;
                ShowComments.Tag = postid;

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
                AddCommentButton.Tag = AddCommentText;
                AddCommentButton.Click += SubmitComment;

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
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
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
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
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
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
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
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
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
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
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

        private void CreatePost(
               string textContent,
               string mediaPath,
               int? pageId)
        {
            SqlConnection con =
                new SqlConnection(
                "Data Source=(local);Initial Catalog=SocialMedia;Integrated Security=SSPI");

            try
            {
                con.Open();

                SqlCommand cmd =
                    new SqlCommand("AddPost", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@User_ID",
                    userId);

                if (pageId == null)
                {
                    cmd.Parameters.AddWithValue(
                        "@Page_id",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@Page_id",
                        pageId);
                }

                cmd.Parameters.AddWithValue(
                    "@Text_Content",
                    textContent);

                if (string.IsNullOrEmpty(mediaPath))
                {
                    cmd.Parameters.AddWithValue(
                        "@Media_path",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@Media_path",
                        mediaPath);
                }

                cmd.ExecuteNonQuery();

                MessageBox.Show("Post Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //hashtof 2el donya warya 
                CreatePostText.Clear();
                PagesComboBox.SelectedIndex = -1;
                Preivew.Image = null;
                CreatePostText.Text = "";

                con.Close();
            }
        }




        private DataTable GetUserPages()
        {
            SqlConnection con = new SqlConnection(
                "Data Source=(local);Initial Catalog=SocialMedia;Integrated Security=SSPI");

            DataTable table = new DataTable();

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"SELECT p.Page_id, p.Page_name
          FROM Page p
          INNER JOIN Join_Page jp
          ON p.Page_id = jp.Page_id
          WHERE jp.User_id = @ID", con);

                cmd.Parameters.AddWithValue("@ID", userId);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return table;
        }




        private DataTable GetPostsComment(string postId)
        {
            SqlConnection con = new SqlConnection(
                "Data Source=(local);Initial Catalog=SocialMedia;Integrated Security=SSPI");

            SqlDataReader reader = null;

            DataTable comments = new DataTable();

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM GetCommentsByPost(@Post_id)", con);

                cmd.Parameters.AddWithValue("@Post_id", postId);

                reader = cmd.ExecuteReader();

                comments.Columns.Add("Comment_seq");
                comments.Columns.Add("Text_content");
                comments.Columns.Add("Creation_timestamp");
                comments.Columns.Add("First_name");
                comments.Columns.Add("Last_name");

                DataRow row;

                while (reader.Read())
                {
                    row = comments.NewRow();

                    row["Comment_seq"] =
                        reader["Comment_seq"];

                    row["Text_content"] =
                        reader["Text_content"];

                    row["Creation_timestamp"] =
                        reader["Creation_timestamp"];

                    row["First_name"] =
                        reader["First_name"];

                    row["Last_name"] =
                        reader["Last_name"];

                    comments.Rows.Add(row);
                }

                return comments;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return comments;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                con.Close();
            }
        }


       private void CreateComment(String PostId,String text)
        {

            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=SocialMedia;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("AddComment", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", PostId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@Text_content", text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ur comment is added successfully ");
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {

                con.Close();
            }
        }


















        private void CreatePostButton_Click(object sender, EventArgs e)

        {
            string postText =
       CreatePostText.Text;

            int? pageId = null;

            if (PagesComboBox.SelectedIndex != -1)
            {
                pageId =
                Convert.ToInt32(
                PagesComboBox.SelectedValue);
            }

            CreatePost(
                postText,
                uploadedMedia,
                pageId
            );

        }




        //dah 2el dilog box beya5od jpg
        private void AddMeida_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter =
                "Image Files|*.jpg;*.png;*.jpeg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //ha5od bas 2el file name
                string fileName =
                    Path.GetFileName(dialog.FileName);
                //haro7 a7oto fe 2el bin folder
                string imagesFolder =
                    Path.Combine(
                        Application.StartupPath,
                        "Images");
                //law mesh ma3mol 2e3mlo 
                Directory.CreateDirectory(imagesFolder);
                //hena 3amlt 2el path be 2el folder location 2ely 2e5tartoo
                string destinationPath =
                    Path.Combine(
                        imagesFolder,
                        fileName);
                //3amlt copy le 2el photo we 2el true te3mel overwrite
                File.Copy(
                    dialog.FileName,
                    destinationPath,
                    true);

                uploadedMedia =
                    destinationPath;

                Preivew.Image =
                    Image.FromFile(uploadedMedia);

                Preivew.SizeMode =
                    PictureBoxSizeMode.StretchImage;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Scroll.Controls.Clear();

            LoadPosts();
        }

        private void ViewComments(
    object sender,
    EventArgs e)
        
            {
                Button btn = (Button)sender;

                string postId =
                    btn.Tag.ToString();

                DataTable comments =
                    GetPostsComment(postId);

                CommentsForm form =
                    new CommentsForm(comments);

                form.Show();
            }
   //Form tanya 3lshan 2azher feha 2el Comments
        public partial class CommentsForm : Form
        {
            public CommentsForm(DataTable comments)
            {
                
                ListBox ListBox1 = new ListBox();

                ListBox1.Size =
                    new Size(500, 400);

                Controls.Add(ListBox1);
                foreach (DataRow row in comments.Rows)
                {
                    ListBox1.Items.Add(
                        row["First_name"].ToString()
                        + " : " +
                        row["Text_content"].ToString());
                }
            }
        }

        private void SubmitComment(
object sender,
EventArgs e)
        {
            Button b = (Button)sender;
            string postId =
                   ((RichTextBox)b.Tag).Tag.ToString();
            string Text = ((RichTextBox)b.Tag).Text;
            CreateComment(postId, Text);
            ((RichTextBox)b.Tag).Text = "";

            
            

        }

    }
}
