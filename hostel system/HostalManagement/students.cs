using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HostalManagement
{
    public partial class students : Form
    {
        private string connectionString;
        public students()
        {
            InitializeComponent();
            connectionString = "Data Source=SEKIRO;Initial Catalog=hostal;Integrated Security=True";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentID = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "Male" : "Female";
            string contactNo = textBox4.Text;
            string roomID = cmbRoomID.SelectedItem.ToString();
            string address = textBox7.Text;
            string email = textBox5.Text;
            DateTime date = dateTimePicker1.Value;

            // Use the initialized connection string
            string queryCheckRoom = "SELECT OccupantCount, Capacity FROM Room WHERE RoomID = @RoomID";
            string queryInsertStudent = "INSERT INTO Student (StudentID, Name, Gender, ContactNo, RoomID, Address, Email, Date) " +
                                        "VALUES (@StudentID, @Name, @Gender, @ContactNo, @RoomID, @Address, @Email, @Date)";
            string queryUpdateRoom = "UPDATE Room SET OccupantCount = OccupantCount + 1 WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check the room's current occupant count and capacity
                using (SqlCommand commandCheckRoom = new SqlCommand(queryCheckRoom, connection))
                {
                    commandCheckRoom.Parameters.AddWithValue("@RoomID", roomID);
                    SqlDataReader reader = commandCheckRoom.ExecuteReader();

                    if (reader.Read())
                    {
                        int occupantCount = Convert.ToInt32(reader["OccupantCount"]);
                        int capacity = Convert.ToInt32(reader["Capacity"]);
                        reader.Close();

                        if (occupantCount < capacity)
                        {
                            // Proceed with inserting the student and updating the room's occupant count
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Insert the student record
                                    using (SqlCommand commandInsertStudent = new SqlCommand(queryInsertStudent, connection, transaction))
                                    {
                                        commandInsertStudent.Parameters.AddWithValue("@StudentID", studentID);
                                        commandInsertStudent.Parameters.AddWithValue("@Name", name);
                                        commandInsertStudent.Parameters.AddWithValue("@Gender", gender);
                                        commandInsertStudent.Parameters.AddWithValue("@ContactNo", contactNo);
                                        commandInsertStudent.Parameters.AddWithValue("@RoomID", roomID);
                                        commandInsertStudent.Parameters.AddWithValue("@Address", address);
                                        commandInsertStudent.Parameters.AddWithValue("@Email", email);
                                        commandInsertStudent.Parameters.AddWithValue("@Date", date);

                                        commandInsertStudent.ExecuteNonQuery();
                                    }

                                    // Update the room's occupant count
                                    using (SqlCommand commandUpdateRoom = new SqlCommand(queryUpdateRoom, connection, transaction))
                                    {
                                        commandUpdateRoom.Parameters.AddWithValue("@RoomID", roomID);
                                        commandUpdateRoom.ExecuteNonQuery();
                                    }

                                    // Commit the transaction
                                    transaction.Commit();
                                    MessageBox.Show("Student record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadStudents();
                                    ClearFields();
                                }
                                catch (Exception ex)
                                {
                                    // Rollback the transaction in case of an error
                                    transaction.Rollback();
                                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The selected room is already at full capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void students_Load(object sender, EventArgs e)
        {
            PopulateRoomIDs();
            LoadStudents();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void PopulateRoomIDs()
        {
            string query = "SELECT RoomID FROM Room";

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
                            cmbRoomID.Items.Add(reader["RoomID"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading room IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadStudents()
        {
            string query = "SELECT * FROM Student";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["StudentID"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Name"].Value.ToString();
                if (selectedRow.Cells["Gender"].Value.ToString() == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox4.Text = selectedRow.Cells["ContactNo"].Value.ToString();
                cmbRoomID.SelectedItem = selectedRow.Cells["RoomID"].Value.ToString();
                textBox7.Text = selectedRow.Cells["Address"].Value.ToString();
                textBox5.Text = selectedRow.Cells["Email"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentID = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "Male" : "Female";
            string contactNo = textBox4.Text;
            string roomID = cmbRoomID.SelectedItem.ToString();
            string address = textBox7.Text;
            string email = textBox5.Text;
            DateTime date = dateTimePicker1.Value;

            // Queries
            string queryGetOldRoom = "SELECT RoomID FROM Student WHERE StudentID = @StudentID";
            string queryCheckRoom = "SELECT OccupantCount, Capacity FROM Room WHERE RoomID = @RoomID";
            string queryUpdateStudent = "UPDATE Student SET Name = @Name, Gender = @Gender, ContactNo = @ContactNo, " +
                                        "RoomID = @RoomID, Address = @Address, Email = @Email, Date = @Date " +
                                        "WHERE StudentID = @StudentID";
            string queryUpdateRoomOccupantCount = "UPDATE Room SET OccupantCount = OccupantCount + @Count WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                // Get the student's current room ID
                string oldRoomID;
                using (SqlCommand commandGetOldRoom = new SqlCommand(queryGetOldRoom, connection))
                {
                    commandGetOldRoom.Parameters.AddWithValue("@StudentID", studentID);
                    oldRoomID = commandGetOldRoom.ExecuteScalar()?.ToString();
                }

                // Check the new room's capacity
                using (SqlCommand commandCheckRoom = new SqlCommand(queryCheckRoom, connection))
                {
                    commandCheckRoom.Parameters.AddWithValue("@RoomID", roomID);
                    SqlDataReader reader = commandCheckRoom.ExecuteReader();

                    if (reader.Read())
                    {
                        int occupantCount = Convert.ToInt32(reader["OccupantCount"]);
                        int capacity = Convert.ToInt32(reader["Capacity"]);
                        reader.Close();

                        if (occupantCount < capacity || roomID == oldRoomID)
                        {
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Update the student record
                                    using (SqlCommand commandUpdateStudent = new SqlCommand(queryUpdateStudent, connection, transaction))
                                    {
                                        commandUpdateStudent.Parameters.AddWithValue("@StudentID", studentID);
                                        commandUpdateStudent.Parameters.AddWithValue("@Name", name);
                                        commandUpdateStudent.Parameters.AddWithValue("@Gender", gender);
                                        commandUpdateStudent.Parameters.AddWithValue("@ContactNo", contactNo);
                                        commandUpdateStudent.Parameters.AddWithValue("@RoomID", roomID);
                                        commandUpdateStudent.Parameters.AddWithValue("@Address", address);
                                        commandUpdateStudent.Parameters.AddWithValue("@Email", email);
                                        commandUpdateStudent.Parameters.AddWithValue("@Date", date);
                                        commandUpdateStudent.ExecuteNonQuery();
                                    }

                                    // Update the old and new room occupant counts if the room is changed
                                    if (roomID != oldRoomID)
                                    {
                                        using (SqlCommand commandUpdateRoomOccupantCount = new SqlCommand(queryUpdateRoomOccupantCount, connection, transaction))
                                        {
                                            // Decrease the old room's occupant count
                                            commandUpdateRoomOccupantCount.Parameters.AddWithValue("@RoomID", oldRoomID);
                                            commandUpdateRoomOccupantCount.Parameters.AddWithValue("@Count", -1);
                                            commandUpdateRoomOccupantCount.ExecuteNonQuery();

                                            // Increase the new room's occupant count
                                            commandUpdateRoomOccupantCount.Parameters["@RoomID"].Value = roomID;
                                            commandUpdateRoomOccupantCount.Parameters["@Count"].Value = 1;
                                            commandUpdateRoomOccupantCount.ExecuteNonQuery();
                                        }
                                    }

                                    // Commit transaction
                                    transaction.Commit();
                                    MessageBox.Show("Student record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadStudents(); // Refresh the DataGridView with updated data
                                    ClearFields();
                                }
                                catch (Exception ex)
                                {
                                    // Rollback transaction
                                    transaction.Rollback();
                                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The selected room is already at full capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string studentID = textBox1.Text;
            string roomID;

            // Queries
            string queryGetRoomID = "SELECT RoomID FROM Student WHERE StudentID = @StudentID";
            string queryDeleteStudent = "DELETE FROM Student WHERE StudentID = @StudentID";
            string queryUpdateRoomOccupantCount = "UPDATE Room SET OccupantCount = OccupantCount - 1 WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                // Get the student's current room ID
                using (SqlCommand commandGetRoomID = new SqlCommand(queryGetRoomID, connection))
                {
                    commandGetRoomID.Parameters.AddWithValue("@StudentID", studentID);
                    roomID = commandGetRoomID.ExecuteScalar()?.ToString();
                }

                if (roomID != null)
                {
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Delete the student record
                            using (SqlCommand commandDeleteStudent = new SqlCommand(queryDeleteStudent, connection, transaction))
                            {
                                commandDeleteStudent.Parameters.AddWithValue("@StudentID", studentID);
                                commandDeleteStudent.ExecuteNonQuery();
                            }

                            // Decrease the room's occupant count
                            using (SqlCommand commandUpdateRoomOccupantCount = new SqlCommand(queryUpdateRoomOccupantCount, connection, transaction))
                            {
                                commandUpdateRoomOccupantCount.Parameters.AddWithValue("@RoomID", roomID);
                                commandUpdateRoomOccupantCount.ExecuteNonQuery();
                            }

                            // Commit transaction
                            transaction.Commit();
                            MessageBox.Show("Student record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudents(); // Refresh the DataGridView with updated data
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction
                            transaction.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Clear();
            cmbRoomID.SelectedIndex = -1;
            textBox7.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string studentID = textBox9.Text.Trim();

            if (string.IsNullOrEmpty(studentID))
            {
                MessageBox.Show("Please enter a StudentID to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT * FROM Student WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("StudentID not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
