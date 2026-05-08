namespace User
{
    partial class User
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            textBoxPasswordLogin = new TextBox();
            textBoxEmailLogin = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelLoginError = new Label();
            panel2 = new Panel();
            labelEmailError = new Label();
            labelPasswordError = new Label();
            button4 = new Button();
            label11 = new Label();
            textBoxLastName = new TextBox();
            button3 = new Button();
            textBoxConfirmPassword = new TextBox();
            textBoxPasswordSignUp = new TextBox();
            textBoxEmailSignUp = new TextBox();
            textBoxDOB = new TextBox();
            textBoxFirstName = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBoxPasswordLogin);
            panel1.Controls.Add(textBoxEmailLogin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelLoginError);
            panel1.Location = new Point(53, 13);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 595);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Font = new Font("Lucida Calligraphy", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(333, 472);
            button2.Name = "button2";
            button2.Size = new Size(119, 37);
            button2.TabIndex = 6;
            button2.Text = "Sign Up";
            button2.UseVisualStyleBackColor = false;
            button2.Click += OpenSignupBtn_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(292, 390);
            button1.Name = "button1";
            button1.Size = new Size(196, 51);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LoginBtn_Click;
            // 
            // textBoxPasswordLogin
            // 
            textBoxPasswordLogin.Location = new Point(211, 292);
            textBoxPasswordLogin.Name = "textBoxPasswordLogin";
            textBoxPasswordLogin.Size = new Size(345, 34);
            textBoxPasswordLogin.TabIndex = 4;
            textBoxPasswordLogin.TextChanged += textBox2_TextChanged;
            // 
            // textBoxEmailLogin
            // 
            textBoxEmailLogin.Location = new Point(211, 166);
            textBoxEmailLogin.Name = "textBoxEmailLogin";
            textBoxEmailLogin.Size = new Size(345, 34);
            textBoxEmailLogin.TabIndex = 3;
            textBoxEmailLogin.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(177, 239);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(171, 135);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 1;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(309, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 51);
            label1.TabIndex = 0;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // labelLoginError
            // 
            labelLoginError.AutoSize = true;
            labelLoginError.Location = new Point(292, 359);
            labelLoginError.Name = "labelLoginError";
            labelLoginError.Size = new Size(17, 28);
            labelLoginError.TabIndex = 8;
            labelLoginError.Text = " ";
            labelLoginError.Click += label12_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(labelEmailError);
            panel2.Controls.Add(labelPasswordError);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(textBoxLastName);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBoxConfirmPassword);
            panel2.Controls.Add(textBoxPasswordSignUp);
            panel2.Controls.Add(textBoxEmailSignUp);
            panel2.Controls.Add(textBoxDOB);
            panel2.Controls.Add(textBoxFirstName);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(53, 13);
            panel2.Name = "panel2";
            panel2.Size = new Size(822, 596);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // labelEmailError
            // 
            labelEmailError.AutoSize = true;
            labelEmailError.BackColor = SystemColors.ButtonFace;
            labelEmailError.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEmailError.Location = new Point(387, 359);
            labelEmailError.Name = "labelEmailError";
            labelEmailError.Size = new Size(15, 23);
            labelEmailError.TabIndex = 18;
            labelEmailError.Text = " ";
            labelEmailError.Click += label14_Click;
            // 
            // labelPasswordError
            // 
            labelPasswordError.AutoSize = true;
            labelPasswordError.BackColor = SystemColors.ButtonFace;
            labelPasswordError.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPasswordError.Location = new Point(215, 500);
            labelPasswordError.Name = "labelPasswordError";
            labelPasswordError.Size = new Size(15, 23);
            labelPasswordError.TabIndex = 17;
            labelPasswordError.Text = " ";
            labelPasswordError.Click += label13_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.AliceBlue;
            button4.Location = new Point(46, 526);
            button4.Name = "button4";
            button4.Size = new Size(254, 50);
            button4.TabIndex = 16;
            button4.Text = " I already have account ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += BackToLoginBtn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(171, 220);
            label11.Name = "label11";
            label11.Size = new Size(129, 28);
            label11.TabIndex = 15;
            label11.Text = "Date OF Birth";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(214, 174);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(458, 34);
            textBoxLastName.TabIndex = 14;
            textBoxLastName.TextChanged += textBox8_TextChanged;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(556, 526);
            button3.Name = "button3";
            button3.Size = new Size(154, 50);
            button3.TabIndex = 13;
            button3.Text = "Submit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += SignupBtn_Click;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(214, 461);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(458, 34);
            textBoxConfirmPassword.TabIndex = 11;
            textBoxConfirmPassword.TextChanged += textBox7_TextChanged;
            // 
            // textBoxPasswordSignUp
            // 
            textBoxPasswordSignUp.Location = new Point(211, 393);
            textBoxPasswordSignUp.Name = "textBoxPasswordSignUp";
            textBoxPasswordSignUp.Size = new Size(458, 34);
            textBoxPasswordSignUp.TabIndex = 10;
            textBoxPasswordSignUp.TextChanged += textBox6_TextChanged;
            // 
            // textBoxEmailSignUp
            // 
            textBoxEmailSignUp.Location = new Point(211, 319);
            textBoxEmailSignUp.Name = "textBoxEmailSignUp";
            textBoxEmailSignUp.Size = new Size(458, 34);
            textBoxEmailSignUp.TabIndex = 9;
            textBoxEmailSignUp.TextChanged += textBox5_TextChanged;
            // 
            // textBoxDOB
            // 
            textBoxDOB.Location = new Point(211, 251);
            textBoxDOB.Name = "textBoxDOB";
            textBoxDOB.Size = new Size(458, 34);
            textBoxDOB.TabIndex = 8;
            textBoxDOB.TextChanged += textBox4_TextChanged;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(211, 106);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(458, 34);
            textBoxFirstName.TabIndex = 7;
            textBoxFirstName.TextChanged += textBox3_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(171, 416);
            label10.Name = "label10";
            label10.Size = new Size(0, 28);
            label10.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(174, 430);
            label9.Name = "label9";
            label9.Size = new Size(168, 28);
            label9.TabIndex = 5;
            label9.Text = "Confirm Password";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(174, 362);
            label8.Name = "label8";
            label8.Size = new Size(93, 28);
            label8.TabIndex = 4;
            label8.Text = "Password";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(171, 288);
            label7.Name = "label7";
            label7.Size = new Size(59, 28);
            label7.TabIndex = 3;
            label7.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(171, 143);
            label6.Name = "label6";
            label6.Size = new Size(103, 28);
            label6.TabIndex = 2;
            label6.Text = "Last Name";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(171, 75);
            label5.Name = "label5";
            label5.Size = new Size(106, 28);
            label5.TabIndex = 1;
            label5.Text = "First Name";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(297, 14);
            label4.Name = "label4";
            label4.Size = new Size(191, 51);
            label4.TabIndex = 0;
            label4.Text = "Sign UP";
            label4.Click += label4_Click;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(938, 634);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "User";
            Text = "Form1";
            Load += Form1_Load;
            Resize += User_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBoxPasswordLogin;
        private TextBox textBoxEmailLogin;
        private Label label3;
        private Label label2;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private Label label4;
        private TextBox textBoxConfirmPassword;
        private TextBox textBoxPasswordSignUp;
        private TextBox textBoxEmailSignUp;
        private TextBox textBoxDOB;
        private TextBox textBoxFirstName;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button button3;
        private TextBox textBoxLastName;
        private Label label11;
        private Button button4;
        private Label labelLoginError;
        private Label labelPasswordError;
        private Label labelEmailError;
    }
}
