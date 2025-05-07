using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _18AdminStudentAdd : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _18AdminStudentAdd()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values from the form
                int studentID = int.Parse(textBox1.Text); // Assuming the StudentID is an integer
                string name = textBox3.Text;
                string gender = comboBox1.SelectedItem?.ToString();
                DateTime dateOfBirth = dateTimePicker1.Value;
                string email = textBox5.Text;
                string password = textBox2.Text; // Consider hashing this password
                string phoneNumber = textBox4.Text;
                string address = textBox7.Text;

                // Create SQL query for inserting a new student
                string insertQuery = @"INSERT INTO StudentPanel (StudentID, Name, Gender, DateOfBirth, Email, Password, PhoneNumber, Address) 
                                       VALUES (@StudentID, @Name, @Gender, @DateOfBirth, @Email, @Password, @PhoneNumber, @Address)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        // Assign parameters to query
                        cmd.Parameters.AddWithValue("@StudentID", studentID);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Remember to hash passwords in real applications
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Address", address);

                        // Open the connection and execute the query
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the insert was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Student registered successfully! Student ID: {studentID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Assuming you've removed or properly defined the label2_Click and panel1_Paint methods
        // If they are necessary for your application, you can define them like so:

        private void label2_Click(object sender, EventArgs e)
        {
            // Add code for what should happen when label2 is clicked
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Add code for any custom painting on panel1
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _18AdminStudentAdd_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
