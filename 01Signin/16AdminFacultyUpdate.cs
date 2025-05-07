using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _16AdminFacultyUpdate : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _16AdminFacultyUpdate()
        {
            InitializeComponent();
        }

        private void ResetControl()
        {
            // Clear all the relevant textboxes and controls
            textBox1.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
          //  dateTimePicker1.Value = DateTime.Now; // Set the date picker to the current date
            textBox5.Clear();
            textBox11.Clear();
            textBox4.Clear();
            textBox7.Clear();
            // Add more controls as needed
        }

        private void BindGridView()
        {
            // Implement your logic to bind data to the GridView here
            // For example, reload data into DataGridView
            LoadFacultyData();
        }

        private void LoadFacultyData()
        {
            // Implement your logic to load data into the DataGridView
            // This method should be similar to the one in _17AdminFaculryViewAll form
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM Faculty";
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get input values from the form
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Faculty ID cannot be empty. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int facultyID))
                {
                    MessageBox.Show("Invalid Faculty ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create SQL query for updating selected fields of an existing faculty member
                string updateQuery = "UPDATE Faculty SET ";

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

                if (!string.IsNullOrWhiteSpace(textBox11.Text))
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
                    updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE FacultyID = @FacultyID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@FacultyID", facultyID);

                            if (!string.IsNullOrWhiteSpace(textBox3.Text))
                                cmd.Parameters.AddWithValue("@Name", textBox3.Text);

                            if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()))
                                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());

                            if (!string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);

                            if (!string.IsNullOrWhiteSpace(textBox5.Text))
                                cmd.Parameters.AddWithValue("@Email", textBox5.Text);

                            if (!string.IsNullOrWhiteSpace(textBox11.Text))
                                cmd.Parameters.AddWithValue("@Password", textBox11.Text);

                            if (!string.IsNullOrWhiteSpace(textBox4.Text))
                                cmd.Parameters.AddWithValue("@PhoneNumber", textBox4.Text);

                            if (!string.IsNullOrWhiteSpace(textBox7.Text))
                                cmd.Parameters.AddWithValue("@Address", textBox7.Text);

                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Faculty member updated successfully! Faculty ID: {facultyID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView(); // Call the method to bind data to GridView
                                ResetControl(); // Call the method to reset controls
                            }
                            else
                            {
                                MessageBox.Show($"No faculty member found with Faculty ID: {facultyID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void _16AdminFacultyUpdate_Load(object sender, EventArgs e)
        {
            // Load faculty data into the DataGridView when the form is loaded
            LoadFacultyData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Date
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //Email
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Password
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        //Phone Number
        private void textBox4_TextChanged(object sender, EventArgs e)
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
