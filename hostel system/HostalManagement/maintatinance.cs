using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HostalManagement
{
    public partial class maintatinance : Form
    {
        private string connectionString;

        public maintatinance()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
            dataGridViewMaintenance.SelectionChanged += new EventHandler(dataGridViewMaintenance_SelectionChanged);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string staffID = textBoxStaffID.Text;
            string name = textBoxName.Text;
            string contactNo = textBoxContactNo.Text;
            int floor;

            // Validate inputs
            if (string.IsNullOrEmpty(staffID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactNo) ||
                !int.TryParse(textBoxFloor.Text, out floor))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Maintenance (StaffID, Name, ContactNo, Floor) " +
                           "VALUES (@StaffID, @Name, @ContactNo, @Floor)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", staffID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Floor", floor);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Maintenance staff record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMaintenanceStaff(); // Refresh the DataGridView with updated data
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string staffID = textBoxStaffID.Text;
            string name = textBoxName.Text;
            string contactNo = textBoxContactNo.Text;
            int floor;

            // Validate inputs
            if (string.IsNullOrEmpty(staffID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactNo) ||
                !int.TryParse(textBoxFloor.Text, out floor))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE Maintenance SET Name = @Name, ContactNo = @ContactNo, Floor = @Floor WHERE StaffID = @StaffID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", staffID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Floor", floor);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Maintenance staff record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMaintenanceStaff(); // Refresh the DataGridView with updated data
                        ClearFields(); // Clear the input fields
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStaffID.Text))
            {
                MessageBox.Show("Please select a maintenance staff to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string staffID = textBoxStaffID.Text;

            string query = "DELETE FROM Maintenance WHERE StaffID = @StaffID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", staffID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Maintenance staff record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMaintenanceStaff(); // Refresh the DataGridView with updated data
                        ClearFields(); // Clear the input fields
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchStaffID = textBoxSearchStaffID.Text;

            if (string.IsNullOrEmpty(searchStaffID))
            {
                MessageBox.Show("Please enter a Staff ID to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM Maintenance WHERE StaffID = @StaffID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", searchStaffID);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridViewMaintenance.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No maintenance staff found with the specified Staff ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dataGridViewMaintenance_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMaintenance.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewMaintenance.SelectedRows[0];
                textBoxStaffID.Text = selectedRow.Cells["StaffID"].Value.ToString();
                textBoxName.Text = selectedRow.Cells["Name"].Value.ToString();
                textBoxContactNo.Text = selectedRow.Cells["ContactNo"].Value.ToString();
                textBoxFloor.Text = selectedRow.Cells["Floor"].Value.ToString();
            }
        }

        private void LoadMaintenanceStaff()
        {
            string query = "SELECT * FROM Maintenance";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewMaintenance.DataSource = dataTable;
            }
        }

        private void ClearFields()
        {
            textBoxStaffID.Clear();
            textBoxName.Clear();
            textBoxContactNo.Clear();
            textBoxFloor.Clear();
        }

        private void maintatinance_Load(object sender, EventArgs e)
        {
            LoadMaintenanceStaff();
        }
    }
}
