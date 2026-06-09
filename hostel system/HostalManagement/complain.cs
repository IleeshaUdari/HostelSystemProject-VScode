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
using System.Windows.Forms.VisualStyles;

namespace HostalManagement
{
    public partial class complain : Form
    {
        private string connectionString;
        public complain()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
            dataGridView1.SelectionChanged += new EventHandler(dataGridViewComplain_SelectionChanged);
            LoadStudentIDs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string complainID = textBox1.Text;
            string studentID = comboBox1.SelectedItem.ToString();
            string status = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            string description = textBox2.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(complainID) || string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Complain (ComplainID, StudentID, Status, Date, Description) " +
                           "VALUES (@ComplainID, @StudentID, @Status, @Date, @Description)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComplainID", complainID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Complain record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComplains(); // Refresh the DataGridView with updated data
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
            string complainID = textBox1.Text;
            string studentID = comboBox1.SelectedItem.ToString();
            string status = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            string description = textBox2.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(complainID) || string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE Complain SET StudentID = @StudentID, Status = @Status, Date = @Date, Description = @Description WHERE ComplainID = @ComplainID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComplainID", complainID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Complain record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComplains(); // Refresh the DataGridView with updated data
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
                MessageBox.Show("Please select a complain to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string complainID = textBox1.Text;

            string query = "DELETE FROM Complain WHERE ComplainID = @ComplainID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComplainID", complainID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Complain record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComplains(); // Refresh the DataGridView with updated data
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
            string searchComplainID = textBox9.Text;

            if (string.IsNullOrEmpty(searchComplainID))
            {
                MessageBox.Show("Please enter a Complain ID to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM Complain WHERE ComplainID = @ComplainID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComplainID", searchComplainID);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No complain found with the specified Complain ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void complain_Load(object sender, EventArgs e)
        {
            LoadComplains();
        }

        private void dataGridViewComplain_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["ComplainID"].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells["StudentID"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Status"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                textBox2.Text = selectedRow.Cells["Description"].Value.ToString();
            }
        }

        private void LoadComplains()
        {
            string query = "SELECT * FROM Complain";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void LoadStudentIDs()
        {
            string query = "SELECT StudentID FROM Student";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["StudentID"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading student IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Clear();
        }









    }
}
