using System.Data;
using System.Data.SqlClient;

namespace Hivee.Pages
{
    public partial class PageForm : Form
    {
        private string connectionString = "Server=.;Database=SocialMedia;Trusted_Connection=True;TrustServerCertificate=True;";

        private int currentLoggedInUserId;

        private int selectedPageId = -1;
        private bool selectedIsAdmin = false;
        private bool selectedIsCreator = false;

        private int selectedMemberUserId = -1;
        private string selectedMemberRole = "";

        public PageForm(int userId)
        {
            InitializeComponent();
            currentLoggedInUserId = userId;

            // Form Load
            this.Load += PageForm_Load;

            // Panel 1 Wiring (Pages)
            dgvPages.CellClick += DgvPages_CellClick;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnJoin.Click += BtnJoin_Click;
            btnManageMembers.Click += BtnManageMembers_Click;
            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
            btnMyPages.Click += BtnMyPages_Click;

            // Panel 2 Wiring (Members)
            dgvMembers.CellClick += DgvMembers_CellClick;
            btnPromote.Click += BtnPromote_Click;
            btnDemote.Click += BtnDemote_Click;
            btnRemoveMember.Click += BtnRemoveMember_Click;
            btnBackToPages.Click += BtnBackToPages_Click;
        }

        private void PageForm_Load(object? sender, EventArgs e)
        {
            panelPages.Visible = true;
            panelMembers.Visible = false;
            LoadPages(); // Load all pages on startup
        }

        // ==========================================
        // PANEL 1: LOAD DATA
        // ==========================================

        private void LoadPages(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Raw query used here to allow keyword searching
                    string query = @"
                        SELECT p.Page_id, p.Page_name, p.Description, p.Creation_date, p.Creator_id,
                               u.First_name + ' ' + u.Last_name AS CreatorName,
                               (SELECT COUNT(*) FROM Join_Page jp WHERE jp.Page_id = p.Page_id) AS Members
                        FROM Page p
                        JOIN [User] u ON u.User_id = p.Creator_id
                        WHERE p.Page_name LIKE '%' + @Keyword + '%'
                        ORDER BY p.Creation_date DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Keyword", keyword);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    BindPagesGrid(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading pages: " + ex.Message); }
        }

        private void LoadMyPages()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Utilizing your custom SQL Function: GetPagesByUser
                    string query = "SELECT * FROM GetPagesByUser(@UserId) ORDER BY Creation_date DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@UserId", currentLoggedInUserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    BindPagesGrid(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading your pages: " + ex.Message); }
        }

        private void BindPagesGrid(DataTable dt)
        {
            dgvPages.DataSource = dt;

            // Hide raw IDs
            if (dgvPages.Columns.Contains("Page_id")) dgvPages.Columns["Page_id"].Visible = false;
            if (dgvPages.Columns.Contains("Creator_id")) dgvPages.Columns["Creator_id"].Visible = false;
            if (dgvPages.Columns.Contains("Description")) dgvPages.Columns["Description"].Visible = false;

            // Rename columns
            if (dgvPages.Columns.Contains("Page_name")) dgvPages.Columns["Page_name"].HeaderText = "Page Name";
            if (dgvPages.Columns.Contains("Creation_date")) dgvPages.Columns["Creation_date"].HeaderText = "Created On";
            if (dgvPages.Columns.Contains("CreatorName")) dgvPages.Columns["CreatorName"].HeaderText = "Created By";

            // Format Grid Data
            dgvPages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPages.ReadOnly = true;

            ClearFields();
        }

        private void DgvPages_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPages.Rows[e.RowIndex];

            selectedPageId = Convert.ToInt32(row.Cells["Page_id"].Value);
            txtPageName.Text = row.Cells["Page_name"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();

            selectedIsCreator = Convert.ToInt32(row.Cells["Creator_id"].Value) == currentLoggedInUserId;
            CheckMembership();
        }

        private void CheckMembership()
        {
            if (selectedPageId == -1) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Role FROM Join_Page WHERE User_id = @Uid AND Page_id = @Pid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Uid", currentLoggedInUserId);
                cmd.Parameters.AddWithValue("@Pid", selectedPageId);

                conn.Open();
                object result = cmd.ExecuteScalar();

                bool isMember = result != null;
                selectedIsAdmin = isMember && result.ToString() == "Admin";

                // Setup Join/Leave Button Colors
                if (selectedIsCreator)
                {
                    btnJoin.Text = "You are Creator";
                    btnJoin.Enabled = false;
                    btnJoin.BackColor = Color.LightGray;
                }
                else if (isMember)
                {
                    btnJoin.Text = "Leave Page";
                    btnJoin.Enabled = true;
                    btnJoin.BackColor = Color.IndianRed;
                }
                else
                {
                    btnJoin.Text = "Join Page";
                    btnJoin.Enabled = true;
                    btnJoin.BackColor = Color.SeaGreen;
                }

                // Admins unlock update/delete controls
                btnUpdate.Enabled = selectedIsAdmin;
                btnDelete.Enabled = selectedIsAdmin;
                btnManageMembers.Enabled = selectedIsAdmin;
            }
        }

        // ==========================================
        // PANEL 1: ACTIONS (CRUD)
        // ==========================================

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPageName.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddPage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Page_name", txtPageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Creator_id", currentLoggedInUserId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Page created! You are now Admin.");
                    LoadPages();
                }
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedPageId == -1 || string.IsNullOrWhiteSpace(txtPageName.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Page_id", selectedPageId);
                    cmd.Parameters.AddWithValue("@Page_name", txtPageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Page updated successfully!");
                    LoadPages();
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedPageId == -1) return;
            if (MessageBox.Show("Delete this page entirely?", "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Page_id", selectedPageId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Page deleted!");
                    LoadPages();
                }
            }
        }

        private void BtnJoin_Click(object? sender, EventArgs e)
        {
            if (selectedPageId == -1) return;

            bool isLeaving = btnJoin.Text == "Leave Page";
            string procName = isLeaving ? "LeavePage" : "JoinPage";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_id", currentLoggedInUserId);
                        cmd.Parameters.AddWithValue("@Page_id", selectedPageId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(isLeaving ? "You left the page." : "You joined the page!");
                    }
                }
                catch (SqlException ex) when (ex.Number == 2627) { MessageBox.Show("You are already a member."); }
            }
            CheckMembership();
            LoadPages();
        }

        // Search Button Logic
        private void BtnSearch_Click(object? sender, EventArgs e) => LoadPages(txtSearch.Text.Trim());
        private void BtnShowAll_Click(object? sender, EventArgs e) { txtSearch.Clear(); LoadPages(); }
        private void BtnMyPages_Click(object? sender, EventArgs e) { txtSearch.Clear(); LoadMyPages(); }
        private void BtnBack_Click(object? sender, EventArgs e) { this.Hide(); }

        private void ClearFields()
        {
            txtPageName.Clear();
            txtDescription.Clear();
            selectedPageId = -1;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnManageMembers.Enabled = false;
            btnJoin.Text = "🤝 Join Selected Page";
            btnJoin.BackColor = Color.SeaGreen;
        }

        // ==========================================
        // PANEL 2: MEMBER MANAGEMENT
        // ==========================================

        private void BtnManageMembers_Click(object? sender, EventArgs e)
        {
            if (selectedPageId == -1) return;
            lblManagingPage.Text = "Managing: " + txtPageName.Text;
            panelPages.Visible = false;
            panelMembers.Visible = true;
            LoadMembers();
        }

        private void LoadMembers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Utilizing your custom SQL Function: GetPageMembers
                string query = "SELECT * FROM GetPageMembers(@PageId) ORDER BY Role DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@PageId", selectedPageId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMembers.DataSource = dt;
                if (dgvMembers.Columns.Contains("User_id")) dgvMembers.Columns["User_id"].Visible = false;
                if (dgvMembers.Columns.Contains("Page_id")) dgvMembers.Columns["Page_id"].Visible = false;

                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMembers.ReadOnly = true;

                selectedMemberUserId = -1;
                UpdateMemberButtons();
            }
        }

        private void DgvMembers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
            selectedMemberUserId = Convert.ToInt32(row.Cells["User_id"].Value);
            selectedMemberRole = row.Cells["Role"].Value.ToString();
            UpdateMemberButtons();
        }

        private void UpdateMemberButtons()
        {
            bool valid = selectedMemberUserId != -1 && selectedMemberUserId != currentLoggedInUserId;
            btnPromote.Enabled = valid && selectedMemberRole == "Member";
            btnDemote.Enabled = valid && selectedMemberRole == "Admin";
            btnRemoveMember.Enabled = valid;
        }

        private void BtnPromote_Click(object? sender, EventArgs e) => UpdateRole("Admin");
        private void BtnDemote_Click(object? sender, EventArgs e) => UpdateRole("Member");

        private void UpdateRole(string newRole)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateMemberRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_id", selectedMemberUserId);
                    cmd.Parameters.AddWithValue("@Page_id", selectedPageId);
                    cmd.Parameters.AddWithValue("@Role", newRole);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadMembers();
                }
            }
        }

        private void BtnRemoveMember_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Remove this member?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("LeavePage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_id", selectedMemberUserId);
                        cmd.Parameters.AddWithValue("@Page_id", selectedPageId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        LoadMembers();
                        this.Close();
                    }
                }
            }
        }

        private void BtnBackToPages_Click(object? sender, EventArgs e)
        {
            panelMembers.Visible = false;
            panelPages.Visible = true;
            LoadPages();
            
        }
    }
}
