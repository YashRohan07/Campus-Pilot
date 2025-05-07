using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _11AdminCourseRemove : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _11AdminCourseRemove()
        {
            InitializeComponent();
            // Load course data into the DataGridView when the form is loaded
            LoadCourseData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string courseCodeToRemove = textBox3.Text;

            if (string.IsNullOrWhiteSpace(courseCodeToRemove))
            {
                MessageBox.Show("Please enter a valid course code to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the course with the entered course code exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM CoursePanel WHERE CourseCode = @CourseCode", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@CourseCode", courseCodeToRemove);
                        int courseCount = (int)checkCmd.ExecuteScalar();

                        if (courseCount == 0)
                        {
                            MessageBox.Show("No course found with the entered course code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Remove the course with the entered course code
                    using (SqlCommand removeCmd = new SqlCommand("DELETE FROM CoursePanel WHERE CourseCode = @CourseCode", connection))
                    {
                        removeCmd.Parameters.AddWithValue("@CourseCode", courseCodeToRemove);

                        int rowsAffected = removeCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the input field after successful removal
                            textBox3.Clear();

                            // Reload course data into the DataGridView
                            LoadCourseData();
                        }
                        else
                        {
                            MessageBox.Show("Course could not be removed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourseData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM CoursePanel";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _11AdminCourseRemove_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
