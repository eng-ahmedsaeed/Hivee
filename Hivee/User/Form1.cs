using Microsoft.Data.SqlClient;
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
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=SocialMedia;Integrated Security=True;TrustServerCertificate=True;";
        public static int LoggedInUserId;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)//login
        {
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            string query = "LoginUser ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);

            int count = (int)cmd.ExecuteScalar();

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                LoggedInUserId = Convert.ToInt32(result);

                MessageBox.Show("Login Successful!"); 
            }
            else
            {
                MessageBox.Show("Invalid Email or Password");
            }

            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)//sign up
        {
            panel1.Visible = false;
            panel2.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e) //submit
        {
            if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (textBox6.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters/numbers.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();

                string query = "AddUser";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email=@Email", con);

                checkCmd.Parameters.AddWithValue("@Email", textBox5.Text);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("Email already exists!");
                    return;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Last_name", textBox8.Text);
                cmd.Parameters.AddWithValue("@Birth_date", DateTime.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@Password", textBox6.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Account Created Successfully!");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
