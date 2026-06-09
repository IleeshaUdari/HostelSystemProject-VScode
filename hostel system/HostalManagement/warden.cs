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
   

    public partial class warden : Form
    {
        private string connectionString;
        public warden()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
            dataGridView1.SelectionChanged += new EventHandler(dataGridViewWarden_SelectionChanged);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wardenID = textBox1.Text;
            int floor;
            string name = textBox3.Text;
            string contactNo = textBox2.Text;
            string email = textBox5.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(wardenID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactNo) ||
                string.IsNullOrEmpty(email) || !int.TryParse(textBox4.Text, out floor))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Warden (WardenID, Floor, Name, ContactNo, Email) " +
                           "VALUES (@WardenID, @Floor, @Name, @ContactNo, @Email)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WardenID", wardenID);
                    command.Parameters.AddWithValue("@Floor", floor);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Warden record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadWardens(); // Refresh the DataGridView with updated data
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
            string wardenID = textBox1.Text;
            int floor;
            string name = textBox3.Text;
            string contactNo = textBox2.Text;
            string email = textBox5.Text;

            if (!int.TryParse(textBox4.Text, out floor))
            {
                MessageBox.Show("Please enter a valid number for Floor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE Warden SET Floor = @Floor, Name = @Name, ContactNo = @ContactNo, Email = @Email WHERE WardenID = @WardenID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WardenID", wardenID);
                    command.Parameters.AddWithValue("@Floor", floor);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Warden record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadWardens(); // Refresh the DataGridView with updated data
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
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select a warden to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string wardenID = textBox1.Text;

            string query = "DELETE FROM Warden WHERE WardenID = @WardenID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WardenID", wardenID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Warden record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadWardens(); // Refresh the DataGridView with updated data
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
            string searchWardenID = textBox9.Text;

            if (string.IsNullOrEmpty(searchWardenID))
            {
                MessageBox.Show("Please enter a Warden ID to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM Warden WHERE WardenID = @WardenID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WardenID", searchWardenID);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No warden found with the specified Warden ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void warden_Load(object sender, EventArgs e)
        {
            LoadWardens();
        }

        private void dataGridViewWarden_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["WardenID"].Value.ToString();
                textBox4.Text = selectedRow.Cells["Floor"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox2.Text = selectedRow.Cells["ContactNo"].Value.ToString();
                textBox5.Text = selectedRow.Cells["Email"].Value.ToString();
            }
        }

        private void LoadWardens()
        {
            string query = "SELECT * FROM Warden";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Assuming you have a DataGridView named dataGridViewWarden
            }
        }


        private void ClearFields()
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }















    }
}
