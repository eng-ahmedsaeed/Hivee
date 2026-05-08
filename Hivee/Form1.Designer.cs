namespace Hivee
{
    partial class Form1
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
            Wrapper = new Panel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            CommentCount = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            UserPic = new PictureBox();
            label1 = new Label();
            Postcontent = new RichTextBox();
            label2 = new Label();
            CreatePostPanel = new Panel();
            Wrapper.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UserPic).BeginInit();
            CreatePostPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Wrapper
            // 
            Wrapper.Anchor = AnchorStyles.Top;
            Wrapper.Controls.Add(panel1);
            Wrapper.Location = new Point(3, 3);
            Wrapper.Name = "Wrapper";
            Wrapper.Size = new Size(1171, 533);
            Wrapper.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(CommentCount);
            panel1.Controls.Add(richTextBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1171, 533);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(18, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 42);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 20);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 8;
            label3.Text = "Hi user ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 40);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 9;
            label4.Text = "Hi user ";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(71, 73);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1023, 69);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Location = new Point(71, 148);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1013, 165);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(81, 326);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 12;
            label5.Text = "Hi user ";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(975, 467);
            button1.Name = "button1";
            button1.Size = new Size(148, 29);
            button1.TabIndex = 13;
            button1.Text = "Add Comment";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.Location = new Point(71, 361);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(1023, 69);
            richTextBox2.TabIndex = 14;
            richTextBox2.Text = "";
            // 
            // CommentCount
            // 
            CommentCount.Location = new Point(169, 326);
            CommentCount.Name = "CommentCount";
            CommentCount.Size = new Size(131, 29);
            CommentCount.TabIndex = 15;
            CommentCount.Text = "Show Comments";
            CommentCount.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(Wrapper);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(40, 173);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1181, 548);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // UserPic
            // 
            UserPic.Location = new Point(3, 3);
            UserPic.Name = "UserPic";
            UserPic.Size = new Size(51, 42);
            UserPic.TabIndex = 3;
            UserPic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 25);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 4;
            label1.Text = "Create Post";
            // 
            // Postcontent
            // 
            Postcontent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Postcontent.Location = new Point(58, 48);
            Postcontent.Name = "Postcontent";
            Postcontent.Size = new Size(1030, 69);
            Postcontent.TabIndex = 5;
            Postcontent.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 5);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 7;
            label2.Text = "Hi user ";
            // 
            // CreatePostPanel
            // 
            CreatePostPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreatePostPanel.Controls.Add(label2);
            CreatePostPanel.Controls.Add(Postcontent);
            CreatePostPanel.Controls.Add(label1);
            CreatePostPanel.Controls.Add(UserPic);
            CreatePostPanel.Location = new Point(40, 26);
            CreatePostPanel.Name = "CreatePostPanel";
            CreatePostPanel.Size = new Size(1173, 121);
            CreatePostPanel.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 745);
            Controls.Add(CreatePostPanel);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Wrapper.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UserPic).EndInit();
            CreatePostPanel.ResumeLayout(false);
            CreatePostPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Wrapper;
        private Panel panel1;
        private Button CommentCount;
        private RichTextBox richTextBox2;
        private Button button1;
        private Label label5;
        private PictureBox pictureBox2;
        private RichTextBox richTextBox1;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox UserPic;
        private Label label1;
        private RichTextBox Postcontent;
        private Label label2;
        private Panel CreatePostPanel;
    }
}
