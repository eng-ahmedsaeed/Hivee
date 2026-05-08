using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
namespace Hivee

{

    public partial class Form1 : Form
    {
        int userId;
        SqlConnection con;
        public Form1(int UserId)
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
             con = new SqlConnection("Data Source = (local);Initial Catalog=SocialMedia;Integrated Security = SSPI");
            con.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 

            }
            finally
            {
                con.Close();
            }
        }
        private DataTable FetchPostsFromFollower()
        {
            
            SqlCommand cmd = new SqlCommand("GetFollowing", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter User = cmd.Parameters.Add("@User_id", SqlDbType.Int);
            User.Direction = ParameterDirection.Output;
            User.Value = userId;
            //Another way
            //    SqlParameter User = cmd.Parameters.Add(new SqlParameter("@User_id",10));
            //    User.Direction = ParameterDirection.Output;
            //    User.Value = userId;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable PostsFromFollowing = new DataTable();
            PostsFromFollowing.Columns.Add("Post_id");
            PostsFromFollowing.Columns.Add("Text_content");
            PostsFromFollowing.Columns.Add("Publish_TimeStamp");
            PostsFromFollowing.Columns.Add("Media_Path");
            PostsFromFollowing.Columns.Add("First_name");
            PostsFromFollowing.Columns.Add("Last_name");
            DataRow row;
            //here we get Table of usersId thet is followed by the user
            while (reader.Read())
            {
                row = PostsFromFollowing.NewRow();
                row["Post_id"] = reader["Post_id"];
                row["text_content"] = reader["text_content"];
                row["Publish_TimeStamp"] = reader["Publish_TimeStamp"];
                row["Media_Path"] = reader["Media_Path"];
                row["First_name"] = reader["Last_name"];
                PostsFromFollowing.Rows.Add(row);

            }
            reader.Close();
            return PostsFromFollowing;

   


        

        }

        private DataTable FetchPostsFromPage()
        {
            SqlCommand cmd = new SqlCommand("GetPostsByJoined",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserId= cmd.Parameters.Add(new("@User_id",userId));
            UserId.Direction = ParameterDirection.Input;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable PostsFromPages = new DataTable();
            PostsFromPages.Columns.Add("Post_id");
            PostsFromPages.Columns.Add("Text_content");
            PostsFromPages.Columns.Add("Publish_TimeStamp");
            PostsFromPages.Columns.Add("Media_Path");
            PostsFromPages.Columns.Add("First_name");
            PostsFromPages.Columns.Add("Last_name");


            return new DataTable("afa");
        }
       


    }
}
