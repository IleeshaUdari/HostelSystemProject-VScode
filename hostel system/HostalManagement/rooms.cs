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
    public partial class rooms : Form
    {
        private string connectionString;
        public rooms()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
            dataGridView1.SelectionChanged += new EventHandler(dataGridViewRooms_SelectionChanged);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text;
            string roomType = textBox2.Text;
            int capacity;
            int occupantCount;

            // Validate inputs
            if (string.IsNullOrEmpty(roomID) || string.IsNullOrEmpty(roomType) ||
                !int.TryParse(textBox3.Text, out capacity) ||
                !int.TryParse(textBox4.Text, out occupantCount))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (occupantCount > capacity)
            {
                MessageBox.Show("Occupant count cannot be greater than capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Room (RoomID, RoomType, Capacity, OccupantCount) " +
                           "VALUES (@RoomID, @RoomType, @Capacity, @OccupantCount)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    command.Parameters.AddWithValue("@Capacity", capacity);
                    command.Parameters.AddWithValue("@OccupantCount", occupantCount);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Room record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Refresh the DataGridView with updated data if you have a method to do so
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            
            textBox4.Clear();
            
            textBox3.Clear();
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text;
            string roomType = textBox2.Text;
            int capacity;
            int occupantCount;

            if (!int.TryParse(textBox3.Text, out capacity))
            {
                MessageBox.Show("Please enter a valid number for Capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox4.Text, out occupantCount))
            {
                MessageBox.Show("Please enter a valid number for Occupant Count.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE Room SET RoomType = @RoomType, Capacity = @Capacity, OccupantCount = @OccupantCount WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    command.Parameters.AddWithValue("@Capacity", capacity);
                    command.Parameters.AddWithValue("@OccupantCount", occupantCount);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Room record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Refresh the DataGridView with updated data
                        ClearFields(); // Refresh the DataGridView with updated data
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
                MessageBox.Show("Please select a room to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string roomID = textBox1.Text;

            string query = "DELETE FROM Room WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Room record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Refresh the DataGridView with updated data
                        ClearFields(); // Clear the text boxes
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
            string searchRoomID = textBox9.Text;

            if (string.IsNullOrEmpty(searchRoomID))
            {
                MessageBox.Show("Please enter a Room ID to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM Room WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", searchRoomID);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No room found with the specified Room ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void rooms_Load(object sender, EventArgs e)
        {
            LoadRooms();
            
        }
        private void dataGridViewRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["RoomID"].Value.ToString();
                textBox2.Text = selectedRow.Cells["RoomType"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Capacity"].Value.ToString();
                textBox4.Text = selectedRow.Cells["OccupantCount"].Value.ToString();
            }
        }


        private void LoadRooms()
        {
            string query = "SELECT * FROM Room";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Assuming you have a DataGridView named dataGridViewRooms
            }
        }
    }
}
