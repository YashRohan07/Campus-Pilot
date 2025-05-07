using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _20AdminStudentUpdate : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _20AdminStudentUpdate()
        {
            InitializeComponent();
        }

        private void ResetControl()
        {
            // Clear all the relevant textboxes and controls
            textBox1.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
           // dateTimePicker1.Value = DateTime.Now; // Set the date picker to the current date
            textBox2.Clear(); // Password
            textBox5.Clear(); // Email
            textBox4.Clear(); // Phone Number
            textBox7.Clear(); // Address
            // Add more controls as needed
        }

        private void BindGridView()
        {
            // Implement your logic to bind data to the GridView here
            // For example, reload data into DataGridView
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            // Implement your logic to load data into the DataGridView
            // This method should be similar to the one in _17AdminStudentViewAll form
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM StudentPanel";
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _20AdminStudentUpdate_Load(object sender, EventArgs e)
        {
            // Implement code to run when the form loads
            // For example, you can load initial data or perform any necessary setup.
            BindGridView(); // Call the method to initially bind data to the GridView
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values from the form
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Student ID cannot be empty. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int studentID))
                {
                    MessageBox.Show("Invalid Student ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create SQL query for updating selected fields of an existing student
                string updateQuery = "UPDATE StudentPanel SET ";

                bool hasUpdateFields = false; // Flag to check if any fields are updated

                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    updateQuery += "Name = @Name, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()))
                {
                    updateQuery += "Gender = @Gender, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                {
                    updateQuery += "DateOfBirth = @DateOfBirth, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    updateQuery += "Email = @Email, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox2.Text)) // Password
                {
                    updateQuery += "Password = @Password, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    updateQuery += "PhoneNumber = @PhoneNumber, ";
                    hasUpdateFields = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    updateQuery += "Address = @Address, ";
                    hasUpdateFields = true;
                }

                // Remove the trailing comma and space
                if (hasUpdateFields)
                {
                    updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE StudentID = @StudentID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentID);

                            if (!string.IsNullOrWhiteSpace(textBox3.Text))
                                cmd.Parameters.AddWithValue("@Name", textBox3.Text);

                            if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()))
                                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());

                            if (!string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);

                            if (!string.IsNullOrWhiteSpace(textBox5.Text))
                                cmd.Parameters.AddWithValue("@Email", textBox5.Text);

                            if (!string.IsNullOrWhiteSpace(textBox2.Text)) // Password
                                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                            if (!string.IsNullOrWhiteSpace(textBox4.Text))
                                cmd.Parameters.AddWithValue("@PhoneNumber", textBox4.Text);

                            if (!string.IsNullOrWhiteSpace(textBox7.Text))
                                cmd.Parameters.AddWithValue("@Address", textBox7.Text);

                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Student updated successfully! Student ID: {studentID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView(); // Call the method to bind data to GridView
                                ResetControl(); // Call the method to reset controls
                            }
                            else
                            {
                                MessageBox.Show($"No student found with Student ID: {studentID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No fields to update. Please provide at least one field to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Email
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Password
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Phone Number
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //Date of birth
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //Address
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
