namespace Hivee.Pages
{
    partial class PageForm
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
            panelPages = new Panel();
            lblSearchTitle = new Label();
            lblManageTitle = new Label();
            divider = new Panel();
            lblPageNameLabel = new Label();
            lblDescLabel = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnShowAll = new Button();
            btnMyPages = new Button();
            dgvPages = new DataGridView();
            btnJoin = new Button();
            txtPageName = new TextBox();
            txtDescription = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnManageMembers = new Button();
            btnDelete = new Button();
            panelMembers = new Panel();
            lblMembersTitle = new Label();
            lblManagingPage = new Label();
            dgvMembers = new DataGridView();
            btnBackToPages = new Button();
            divider2 = new Panel();
            btnPromote = new Button();
            btnDemote = new Button();
            btnRemoveMember = new Button();
            panelPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPages).BeginInit();
            panelMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // panelPages
            // 
            panelPages.BackColor = Color.WhiteSmoke;
            panelPages.Controls.Add(lblSearchTitle);
            panelPages.Controls.Add(lblManageTitle);
            panelPages.Controls.Add(divider);
            panelPages.Controls.Add(lblPageNameLabel);
            panelPages.Controls.Add(lblDescLabel);
            panelPages.Controls.Add(txtSearch);
            panelPages.Controls.Add(btnSearch);
            panelPages.Controls.Add(btnShowAll);
            panelPages.Controls.Add(btnMyPages);
            panelPages.Controls.Add(dgvPages);
            panelPages.Controls.Add(btnJoin);
            panelPages.Controls.Add(txtPageName);
            panelPages.Controls.Add(txtDescription);
            panelPages.Controls.Add(btnCreate);
            panelPages.Controls.Add(btnUpdate);
            panelPages.Controls.Add(btnManageMembers);
            panelPages.Controls.Add(btnDelete);
            panelPages.Dock = DockStyle.Fill;
            panelPages.Location = new Point(0, 0);
            panelPages.Name = "panelPages";
            panelPages.Size = new Size(1000, 600);
            panelPages.TabIndex = 0;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSearchTitle.ForeColor = Color.FromArgb(0, 120, 212);
            lblSearchTitle.Location = new Point(30, 20);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(233, 32);
            lblSearchTitle.TabIndex = 1;
            lblSearchTitle.Text = "FIND / JOIN PAGES";
            // 
            // lblManageTitle
            // 
            lblManageTitle.AutoSize = true;
            lblManageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblManageTitle.ForeColor = Color.FromArgb(0, 120, 212);
            lblManageTitle.Location = new Point(630, 20);
            lblManageTitle.Name = "lblManageTitle";
            lblManageTitle.Size = new Size(257, 32);
            lblManageTitle.TabIndex = 2;
            lblManageTitle.Text = "PAGE MANAGEMENT";
            // 
            // divider
            // 
            divider.BackColor = Color.LightGray;
            divider.Location = new Point(600, 20);
            divider.Name = "divider";
            divider.Size = new Size(2, 550);
            divider.TabIndex = 3;
            // 
            // lblPageNameLabel
            // 
            lblPageNameLabel.AutoSize = true;
            lblPageNameLabel.Location = new Point(630, 70);
            lblPageNameLabel.Name = "lblPageNameLabel";
            lblPageNameLabel.Size = new Size(88, 20);
            lblPageNameLabel.TabIndex = 4;
            lblPageNameLabel.Text = "Page Name:";
            // 
            // lblDescLabel
            // 
            lblDescLabel.AutoSize = true;
            lblDescLabel.Location = new Point(630, 140);
            lblDescLabel.Name = "lblDescLabel";
            lblDescLabel.Size = new Size(124, 20);
            lblDescLabel.TabIndex = 5;
            lblDescLabel.Text = "Description / Bio:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(30, 65);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " 🔍 Type a name...";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(300, 63);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 32);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(390, 63);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(80, 32);
            btnShowAll.TabIndex = 8;
            btnShowAll.Text = "Show All";
            // 
            // btnMyPages
            // 
            btnMyPages.BackColor = Color.LightYellow;
            btnMyPages.Location = new Point(480, 63);
            btnMyPages.Name = "btnMyPages";
            btnMyPages.Size = new Size(90, 32);
            btnMyPages.TabIndex = 9;
            btnMyPages.Text = "My Pages";
            btnMyPages.UseVisualStyleBackColor = false;
            // 
            // dgvPages
            // 
            dgvPages.BackgroundColor = Color.White;
            dgvPages.ColumnHeadersHeight = 29;
            dgvPages.Location = new Point(30, 110);
            dgvPages.Name = "dgvPages";
            dgvPages.RowHeadersWidth = 51;
            dgvPages.Size = new Size(540, 380);
            dgvPages.TabIndex = 10;
            // 
            // btnJoin
            // 
            btnJoin.BackColor = Color.SeaGreen;
            btnJoin.FlatStyle = FlatStyle.Flat;
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(30, 500);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(540, 45);
            btnJoin.TabIndex = 11;
            btnJoin.Text = "\U0001f91d Join Selected Page";
            btnJoin.UseVisualStyleBackColor = false;
            // 
            // txtPageName
            // 
            txtPageName.Location = new Point(630, 95);
            txtPageName.Name = "txtPageName";
            txtPageName.Size = new Size(320, 27);
            txtPageName.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(630, 165);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(320, 90);
            txtDescription.TabIndex = 13;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(630, 270);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(155, 45);
            btnCreate.TabIndex = 14;
            btnCreate.Text = "➕ Create";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(795, 270);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(155, 45);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "✏️ Update";
            // 
            // btnManageMembers
            // 
            btnManageMembers.Location = new Point(630, 330);
            btnManageMembers.Name = "btnManageMembers";
            btnManageMembers.Size = new Size(320, 45);
            btnManageMembers.TabIndex = 16;
            btnManageMembers.Text = "👥 Manage Members";
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Firebrick;
            btnDelete.Location = new Point(630, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(320, 40);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "🗑️ Delete Page";
            // 
            // panelMembers
            // 
            panelMembers.BackColor = Color.WhiteSmoke;
            panelMembers.Controls.Add(lblMembersTitle);
            panelMembers.Controls.Add(lblManagingPage);
            panelMembers.Controls.Add(dgvMembers);
            panelMembers.Controls.Add(btnBackToPages);
            panelMembers.Controls.Add(divider2);
            panelMembers.Controls.Add(btnPromote);
            panelMembers.Controls.Add(btnDemote);
            panelMembers.Controls.Add(btnRemoveMember);
            panelMembers.Dock = DockStyle.Fill;
            panelMembers.Location = new Point(0, 0);
            panelMembers.Name = "panelMembers";
            panelMembers.Size = new Size(1000, 600);
            panelMembers.TabIndex = 1;
            panelMembers.Visible = false;
            // 
            // lblMembersTitle
            // 
            lblMembersTitle.AutoSize = true;
            lblMembersTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMembersTitle.ForeColor = Color.FromArgb(0, 120, 212);
            lblMembersTitle.Location = new Point(30, 20);
            lblMembersTitle.Name = "lblMembersTitle";
            lblMembersTitle.Size = new Size(272, 37);
            lblMembersTitle.TabIndex = 0;
            lblMembersTitle.Text = "MANAGE MEMBERS";
            // 
            // lblManagingPage
            // 
            lblManagingPage.AutoSize = true;
            lblManagingPage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblManagingPage.Location = new Point(32, 60);
            lblManagingPage.Name = "lblManagingPage";
            lblManagingPage.Size = new Size(189, 23);
            lblManagingPage.TabIndex = 1;
            lblManagingPage.Text = "Managing: [Page Name]";
            // 
            // dgvMembers
            // 
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.ColumnHeadersHeight = 29;
            dgvMembers.Location = new Point(30, 100);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.Size = new Size(600, 400);
            dgvMembers.TabIndex = 2;
            // 
            // btnBackToPages
            // 
            btnBackToPages.BackColor = Color.LightGray;
            btnBackToPages.Location = new Point(30, 520);
            btnBackToPages.Name = "btnBackToPages";
            btnBackToPages.Size = new Size(200, 40);
            btnBackToPages.TabIndex = 3;
            btnBackToPages.Text = "⬅ Back to Pages";
            btnBackToPages.UseVisualStyleBackColor = false;
            // 
            // divider2
            // 
            divider2.BackColor = Color.LightGray;
            divider2.Location = new Point(660, 20);
            divider2.Name = "divider2";
            divider2.Size = new Size(2, 550);
            divider2.TabIndex = 4;
            // 
            // btnPromote
            // 
            btnPromote.BackColor = Color.White;
            btnPromote.Location = new Point(690, 150);
            btnPromote.Name = "btnPromote";
            btnPromote.Size = new Size(260, 50);
            btnPromote.TabIndex = 5;
            btnPromote.Text = "⭐ Promote to Admin";
            btnPromote.UseVisualStyleBackColor = false;
            // 
            // btnDemote
            // 
            btnDemote.BackColor = Color.White;
            btnDemote.Location = new Point(690, 220);
            btnDemote.Name = "btnDemote";
            btnDemote.Size = new Size(260, 50);
            btnDemote.TabIndex = 6;
            btnDemote.Text = "⬇️ Demote to Member";
            btnDemote.UseVisualStyleBackColor = false;
            // 
            // btnRemoveMember
            // 
            btnRemoveMember.BackColor = Color.MistyRose;
            btnRemoveMember.ForeColor = Color.Firebrick;
            btnRemoveMember.Location = new Point(690, 320);
            btnRemoveMember.Name = "btnRemoveMember";
            btnRemoveMember.Size = new Size(260, 50);
            btnRemoveMember.TabIndex = 7;
            btnRemoveMember.Text = "🚫 Remove from Page";
            btnRemoveMember.UseVisualStyleBackColor = false;
            // 
            // PageForm
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(panelPages);
            Controls.Add(panelMembers);
            Name = "PageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hivee | Pages";
            panelPages.ResumeLayout(false);
            panelPages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPages).EndInit();
            panelMembers.ResumeLayout(false);
            panelMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Variable Declarations
        private System.Windows.Forms.Panel panelPages;
        private System.Windows.Forms.DataGridView dgvPages;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnMyPages;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnManageMembers;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Label lblManageTitle;
        private System.Windows.Forms.Panel divider;
        private System.Windows.Forms.Label lblPageNameLabel;
        private System.Windows.Forms.Label lblDescLabel;

        private System.Windows.Forms.Panel panelMembers;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.Button btnDemote;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Button btnBackToPages;
        private System.Windows.Forms.Label lblManagingPage;
        private System.Windows.Forms.Label lblMembersTitle;
        private System.Windows.Forms.Panel divider2;
    }
}
