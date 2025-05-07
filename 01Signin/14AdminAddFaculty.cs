using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _14AdminAddFaculty : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _14AdminAddFaculty()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Get input values from the form
            int facultyID; // Assuming FacultyID is an integer
            if (!int.TryParse(textBox1.Text, out facultyID))
            {
                MessageBox.Show("Invalid Faculty ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = textBox3.Text;
            string gender = comboBox1.SelectedItem?.ToString(); // Assuming you have a ComboBox for gender
            DateTime dateOfBirth = dateTimePicker1.Value;
            string email = textBox5.Text;
            string password = textBox11.Text;
            string phoneNumber = textBox4.Text;
            string address = textBox7.Text;

            // Create SQL query for inserting a new faculty member with a specific ID
            string insertQuery = "INSERT INTO Faculty (FacultyID, Name, Gender, DateOfBirth, Email, Password, PhoneNumber, Address) " +
                                 "VALUES (@FacultyID, @Name, @Gender, @DateOfBirth, @Email,@Password, @PhoneNumber, @Address)";

            try
            {
                // Create SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create SqlCommand
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@FacultyID", facultyID);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Address", address);

                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Faculty member added successfully! Faculty ID: {facultyID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add faculty member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _14AdminAddFaculty_Load(object sender, EventArgs e)
        {

        }
    }
}
