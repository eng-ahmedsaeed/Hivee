using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace User
{
    public partial class User : Form
    {
        string connectionString = "Server=localhost;Database=SocialMedia;Integrated Security=True;TrustServerCertificate=True;";
        public static int LoggedInUserId;
        public User()
        {
            InitializeComponent();

        }

        private void CenterPanel(Panel panel)
        {
            panel.Left = (this.ClientSize.Width - panel.Width) / 2;
            panel.Top = (this.ClientSize.Height - panel.Height) / 2;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            labelLoginError.Visible = false;
            labelEmailError.Visible = false;
            labelPasswordError.Visible = false;

            CenterPanel(panel1);
            CenterPanel(panel2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)//login
        {
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            string query = "LoginUser";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", textBoxEmailLogin.Text);
            cmd.Parameters.AddWithValue("@Password", textBoxPasswordLogin.Text);

            object result = cmd.ExecuteScalar();
            labelLoginError.Visible = false;

            if (result != null)
            {
                LoggedInUserId = Convert.ToInt32(result);

                labelLoginError.ForeColor = Color.Green;
                labelLoginError.Text = "Login Successful!";
                labelLoginError.Visible = true;
            }
            else
            {
                labelLoginError.ForeColor = Color.Red;
                labelLoginError.Text = "Invalid Email or Password";
                labelLoginError.Visible = true;
            }

            con.Close();
        }
        private void OpenSignupBtn_Click(object sender, EventArgs e)//sign up
        {
            panel1.Visible = false;
            panel2.Visible = true;
            CenterPanel(panel2);
            labelEmailError.Visible = false;
            labelPasswordError.Visible = false;

        }

        private void SignupBtn_Click(object sender, EventArgs e) //submit
        {
            labelPasswordError.Visible = false;

            if (textBoxPasswordSignUp.Text != textBoxConfirmPassword.Text)
            {
                labelPasswordError.ForeColor = Color.Red;
                labelPasswordError.Text = "Passwords do not match!";
                labelPasswordError.Visible = true;
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();

                string query = "AddUser";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email=@Email", con);

                checkCmd.Parameters.AddWithValue("@Email", textBoxEmailSignUp.Text);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    labelEmailError.ForeColor = Color.Red;
                    labelEmailError.Text = "Email already exists!";
                    labelEmailError.Visible = true;
                    return;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_name", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@Last_name", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@Birth_date", DateTime.Parse(textBoxDOB.Text));
                cmd.Parameters.AddWithValue("@Email", textBoxEmailSignUp.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPasswordSignUp.Text);

                cmd.ExecuteNonQuery();

                labelPasswordError.ForeColor = Color.Green;
                labelPasswordError.Text = "Account Created Successfully!";
                labelPasswordError.Visible = true;

                con.Close();
            }
            catch (Exception ex)
            {
                labelPasswordError.ForeColor = Color.Red;
                labelPasswordError.Text = ex.Message;
                labelPasswordError.Visible = true;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

            CenterPanel(panel1);

            labelLoginError.Visible = false;
            labelEmailError.Visible = false;
            labelPasswordError.Visible = false;

            textBoxFirstName.Clear();
            textBoxDOB.Clear();
            textBoxEmailSignUp.Clear();
            textBoxPasswordSignUp.Clear();
            textBoxConfirmPassword.Clear();
            textBoxLastName.Clear();
        }

        private void User_Resize(object sender, EventArgs e)
        {
            CenterPanel(panel1);
            CenterPanel(panel2);
        }

        private void label12_Click(object sender, EventArgs e)//Login Error Label
        {

        }

        private void label13_Click(object sender, EventArgs e)//Comfirm Pass Error
        {

        }

        private void label14_Click(object sender, EventArgs e) //Email Existance
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
