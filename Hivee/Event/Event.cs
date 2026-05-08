using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hivee
{
    public partial class Event : Form
    {

        private string connectionString = "Server=.;Database=SocialMedia;Trusted_Connection=True;TrustServerCertificate=True;";

        private int currentLoggedInUserId;
        private int selectedEventId = -1;


        private string oldStreet = "";
        private string oldZip = "";

        public Event(int userId)
        {
            InitializeComponent();
            currentLoggedInUserId = userId;
            this.Load += EventForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnJoin.Click += btnJoin_Click;
            this.dgvEvents.CellClick += dgvEvents_CellClick;
        }

        private void EventForm_Load(object? sender, EventArgs e)
        {
            LoadEventsData();
        }

        private void LoadEventsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query = @"
                        SELECT e.Event_id, e.Title, e.Start_time, e.End_time, l.Street, l.ZIP 
                        FROM Event e 
                        LEFT JOIN Location l ON e.Event_id = l.Event_id";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEvents.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvEvents.Rows.Add(
                            row["Title"].ToString(),
                            Convert.ToDateTime(row["Start_time"]).ToString("MM/dd/yyyy hh:mm tt"),
                            Convert.ToDateTime(row["End_time"]).ToString("MM/dd/yyyy hh:mm tt"),
                            row["Street"].ToString(),
                            row["ZIP"].ToString(),
                            row["Event_id"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database not connected yet: " + ex.Message);
            }
        }

        private void dgvEvents_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEvents.Rows[e.RowIndex];

                txtTitle.Text = row.Cells["Title"].Value.ToString();
                dtpStartTime.Value = Convert.ToDateTime(row.Cells["Start_Time"].Value);
                dtpEndTime.Value = Convert.ToDateTime(row.Cells["End_Time"].Value);
                txtStreet.Text = row.Cells["Street"].Value.ToString();
                txtZip.Text = row.Cells["ZipCode"].Value.ToString();

                selectedEventId = Convert.ToInt32(row.Cells["EventID"].Value);


                oldStreet = txtStreet.Text;
                oldZip = txtZip.Text;
            }
        }

        private void btnCreate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter an event title.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {

                        string eventQuery = @"
                            DECLARE @NewID INT = (SELECT ISNULL(MAX(Event_id), 0) + 1 FROM Event);
                            INSERT INTO Event (Event_id, Creator_id, Start_time, End_time, Title) 
                            VALUES (@NewID, @CreatorID, @Start, @End, @Title);
                            SELECT @NewID;";

                        int newEventId;
                        using (SqlCommand cmdEvent = new SqlCommand(eventQuery, conn, transaction))
                        {
                            cmdEvent.Parameters.AddWithValue("@CreatorID", currentLoggedInUserId);
                            cmdEvent.Parameters.AddWithValue("@Start", dtpStartTime.Value);
                            cmdEvent.Parameters.AddWithValue("@End", dtpEndTime.Value);
                            cmdEvent.Parameters.AddWithValue("@Title", txtTitle.Text);
                            newEventId = (int)cmdEvent.ExecuteScalar();
                        }

                        string locationQuery = "INSERT INTO Location (Event_id, ZIP, Street) VALUES (@EventID, @Zip, @Street)";
                        using (SqlCommand cmdLoc = new SqlCommand(locationQuery, conn, transaction))
                        {
                            cmdLoc.Parameters.AddWithValue("@EventID", newEventId);
                            cmdLoc.Parameters.AddWithValue("@Zip", txtZip.Text);
                            cmdLoc.Parameters.AddWithValue("@Street", txtStreet.Text);
                            cmdLoc.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Event Created Successfully!");
                        LoadEventsData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error creating event: " + ex.Message);
                    }
                }
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedEventId == -1)
            {
                MessageBox.Show("Please select an event from the list to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("UpdateEvent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Event_id", selectedEventId);
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Start_time", dtpStartTime.Value);
                        cmd.Parameters.AddWithValue("@End_time", dtpEndTime.Value);
                        cmd.Parameters.AddWithValue("@Old_ZIP", oldZip);
                        cmd.Parameters.AddWithValue("@Old_Street", oldStreet);
                        cmd.Parameters.AddWithValue("@New_ZIP", txtZip.Text);
                        cmd.Parameters.AddWithValue("@New_Street", txtStreet.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Event Updated Successfully!");
                        LoadEventsData();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating event: " + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedEventId == -1)
            {
                MessageBox.Show("Please select an event to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {

                        string delLocQuery = "DELETE FROM Location WHERE Event_id = @EventID";
                        using (SqlCommand cmdLoc = new SqlCommand(delLocQuery, conn))
                        {
                            cmdLoc.Parameters.AddWithValue("@EventID", selectedEventId);
                            cmdLoc.ExecuteNonQuery();
                        }

                        string delPartQuery = "DELETE FROM Participate WHERE Event_id = @EventID";
                        using (SqlCommand cmdPart = new SqlCommand(delPartQuery, conn))
                        {
                            cmdPart.Parameters.AddWithValue("@EventID", selectedEventId);
                            cmdPart.ExecuteNonQuery();
                        }


                        using (SqlCommand cmdEvent = new SqlCommand("DeleteEvent", conn))
                        {
                            cmdEvent.CommandType = CommandType.StoredProcedure;
                            cmdEvent.Parameters.AddWithValue("@Event_id", selectedEventId);
                            cmdEvent.ExecuteNonQuery();
                        }

                        MessageBox.Show("Event Deleted Successfully!");
                        LoadEventsData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting event: " + ex.Message);
                    }
                }
            }
        }

        private void btnJoin_Click(object? sender, EventArgs e)
        {
            if (selectedEventId == -1)
            {
                MessageBox.Show("Please select an event from the list to join.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string joinQuery = "INSERT INTO Participate (User_id, Event_id) VALUES (@UserID, @EventID)";
                    using (SqlCommand cmd = new SqlCommand(joinQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentLoggedInUserId);
                        cmd.Parameters.AddWithValue("@EventID", selectedEventId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have successfully joined the event!");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("You are already participating in this event.");
                    else
                        MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Navigation triggered! Connect this to your main menu form.");
        }

        private void ClearFields()
        {
            txtTitle.Text = "";
            txtStreet.Text = "";
            txtZip.Text = "";
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            selectedEventId = -1;
            oldStreet = "";
            oldZip = "";
        }
    }
}