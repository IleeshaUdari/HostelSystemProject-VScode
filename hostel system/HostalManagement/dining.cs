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
    public partial class dining : Form
    {
        private string connectionString;
        public dining()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
            dataGridView1.SelectionChanged += new EventHandler(dataGridViewDiningHall_SelectionChanged);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void dining_Load(object sender, EventArgs e)
        {
            LoadDiningHalls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string diningAreaID = textBoxDiningAreaID.Text;
            int floorID;
            string location = textBoxLocation.Text;
            string name = textBoxName.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(diningAreaID) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(name) ||
                !int.TryParse(textBoxFloorID.Text, out floorID))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO DiningHall (DiningAreaID, FloorID, Location, Name) " +
                           "VALUES (@DiningAreaID, @FloorID, @Location, @Name)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DiningAreaID", diningAreaID);
                    command.Parameters.AddWithValue("@FloorID", floorID);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Dining hall record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDiningHalls(); // Refresh the DataGridView with updated data
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
            string diningAreaID = textBoxDiningAreaID.Text;
            int floorID;
            string location = textBoxLocation.Text;
            string name = textBoxName.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(diningAreaID) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(name) ||
                !int.TryParse(textBoxFloorID.Text, out floorID))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE DiningHall SET FloorID = @FloorID, Location = @Location, Name = @Name WHERE DiningAreaID = @DiningAreaID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DiningAreaID", diningAreaID);
                    command.Parameters.AddWithValue("@FloorID", floorID);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Dining hall record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDiningHalls(); // Refresh the DataGridView with updated data
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
            if (string.IsNullOrEmpty(textBoxDiningAreaID.Text))
            {
                MessageBox.Show("Please select a dining hall to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string diningAreaID = textBoxDiningAreaID.Text;

            string query = "DELETE FROM DiningHall WHERE DiningAreaID = @DiningAreaID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DiningAreaID", diningAreaID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Dining hall record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDiningHalls(); // Refresh the DataGridView with updated data
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
            string searchDiningAreaID = textBoxSearchDiningAreaID.Text;

            if (string.IsNullOrEmpty(searchDiningAreaID))
            {
                MessageBox.Show("Please enter a Dining Area ID to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM DiningHall WHERE DiningAreaID = @DiningAreaID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DiningAreaID", searchDiningAreaID);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No dining hall found with the specified Dining Area ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void DiningHallForm_Load(object sender, EventArgs e)
        {
            LoadDiningHalls();
        }

        private void dataGridViewDiningHall_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBoxDiningAreaID.Text = selectedRow.Cells["DiningAreaID"].Value.ToString();
                textBoxFloorID.Text = selectedRow.Cells["FloorID"].Value.ToString();
                textBoxLocation.Text = selectedRow.Cells["Location"].Value.ToString();
                textBoxName.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }

        private void LoadDiningHalls()
        {
            string query = "SELECT * FROM DiningHall";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void ClearFields()
        {
            textBoxDiningAreaID.Clear();
            textBoxFloorID.Clear();
            textBoxLocation.Clear();
            textBoxName.Clear();
        }
    }
}
