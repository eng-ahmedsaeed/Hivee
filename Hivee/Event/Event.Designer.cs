namespace Hivee
{
    partial class Event
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvEvents = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Start_Time = new DataGridViewTextBoxColumn();
            End_Time = new DataGridViewTextBoxColumn();
            Street = new DataGridViewTextBoxColumn();
            ZipCode = new DataGridViewTextBoxColumn();
            EventID = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblStreet = new Label();
            txtStreet = new TextBox();
            lblZip = new Label();
            txtZip = new TextBox();
            lblStart = new Label();
            dtpStartTime = new DateTimePicker();
            lblEnd = new Label();
            dtpEndTime = new DateTimePicker();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnJoin = new Button();
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            pnlCard = new Panel();
            lblCardTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.BackgroundColor = Color.White;
            dgvEvents.BorderStyle = BorderStyle.None;
            dgvEvents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 119, 242);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Columns.AddRange(new DataGridViewColumn[] { Title, Start_Time, End_Time, Street, ZipCode, EventID });
            dgvEvents.EnableHeadersVisualStyles = false;
            dgvEvents.Location = new Point(380, 119);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvEvents.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvEvents.Size = new Size(671, 395);
            dgvEvents.TabIndex = 2;
            // 
            // Title
            // 
            Title.HeaderText = "Event Title";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.ReadOnly = true;
            Title.Width = 150;
            // 
            // Start_Time
            // 
            Start_Time.HeaderText = "Starts";
            Start_Time.MinimumWidth = 6;
            Start_Time.Name = "Start_Time";
            Start_Time.ReadOnly = true;
            Start_Time.Width = 140;
            // 
            // End_Time
            // 
            End_Time.HeaderText = "Ends";
            End_Time.MinimumWidth = 6;
            End_Time.Name = "End_Time";
            End_Time.ReadOnly = true;
            End_Time.Width = 140;
            // 
            // Street
            // 
            Street.HeaderText = "Street";
            Street.MinimumWidth = 6;
            Street.Name = "Street";
            Street.ReadOnly = true;
            Street.Width = 150;
            // 
            // ZipCode
            // 
            ZipCode.HeaderText = "ZIP";
            ZipCode.MinimumWidth = 6;
            ZipCode.Name = "ZipCode";
            ZipCode.ReadOnly = true;
            ZipCode.Width = 80;
            // 
            // EventID
            // 
            EventID.HeaderText = "EventID";
            EventID.MinimumWidth = 6;
            EventID.Name = "EventID";
            EventID.ReadOnly = true;
            EventID.Visible = false;
            EventID.Width = 125;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.FromArgb(101, 103, 107);
            lblTitle.Location = new Point(20, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(89, 23);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Event Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(20, 85);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 30);
            txtTitle.TabIndex = 2;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.ForeColor = Color.FromArgb(101, 103, 107);
            lblStreet.Location = new Point(20, 125);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(54, 23);
            lblStreet.TabIndex = 3;
            lblStreet.Text = "Street";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(20, 150);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(180, 30);
            txtStreet.TabIndex = 4;
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.ForeColor = Color.FromArgb(101, 103, 107);
            lblZip.Location = new Point(210, 125);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(80, 23);
            lblZip.TabIndex = 5;
            lblZip.Text = "ZIP Code";
            // 
            // txtZip
            // 
            txtZip.Location = new Point(210, 150);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(110, 30);
            txtZip.TabIndex = 6;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.ForeColor = Color.FromArgb(101, 103, 107);
            lblStart.Location = new Point(20, 190);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(52, 23);
            lblStart.TabIndex = 7;
            lblStart.Text = "Starts";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(20, 215);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(300, 30);
            dtpStartTime.TabIndex = 8;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.ForeColor = Color.FromArgb(101, 103, 107);
            lblEnd.Location = new Point(20, 255);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(46, 23);
            lblEnd.TabIndex = 9;
            lblEnd.Text = "Ends";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(20, 280);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(300, 30);
            dtpEndTime.TabIndex = 10;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(24, 119, 242);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(20, 340);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(300, 45);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Create Event";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(228, 230, 235);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Location = new Point(20, 513);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 40);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(228, 230, 235);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(187, 513);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 40);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnJoin
            // 
            btnJoin.BackColor = SystemColors.MenuHighlight;
            btnJoin.FlatAppearance.BorderSize = 0;
            btnJoin.FlatStyle = FlatStyle.Flat;
            btnJoin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(380, 80);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(198, 33);
            btnJoin.TabIndex = 0;
            btnJoin.Text = "★ Join Selected Event";
            btnJoin.UseVisualStyleBackColor = false;
            btnJoin.Click += btnJoin_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 119, 242);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1080, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 11);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(100, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Events";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblCardTitle);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(txtTitle);
            pnlCard.Controls.Add(lblStreet);
            pnlCard.Controls.Add(txtStreet);
            pnlCard.Controls.Add(lblZip);
            pnlCard.Controls.Add(txtZip);
            pnlCard.Controls.Add(lblStart);
            pnlCard.Controls.Add(dtpStartTime);
            pnlCard.Controls.Add(lblEnd);
            pnlCard.Controls.Add(dtpEndTime);
            pnlCard.Controls.Add(btnCreate);
            pnlCard.Location = new Point(12, 80);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(344, 405);
            pnlCard.TabIndex = 1;
            // 
            // lblCardTitle
            // 
            lblCardTitle.AutoSize = true;
            lblCardTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardTitle.Location = new Point(20, 23);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(181, 28);
            lblCardTitle.TabIndex = 0;
            lblCardTitle.Text = "Create New Event";
            // 
            // Event
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1080, 600);
            Controls.Add(btnJoin);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            Controls.Add(dgvEvents);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Font = new Font("Segoe UI", 10.2F);
            Name = "Event";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Events";
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEndTime;

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnJoin;

       
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCardTitle;
        private Label lblHeaderTitle;
    }
}