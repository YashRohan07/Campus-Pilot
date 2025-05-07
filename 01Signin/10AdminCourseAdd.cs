using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _10AdminCourseAdd : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _10AdminCourseAdd()
        {
            InitializeComponent();
            // Load course data into the DataGridView when the form is loaded
            LoadCourseData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string courseCode = textBox3.Text;
            string courseName = textBox2.Text;
            int courseCredit;

            if (string.IsNullOrWhiteSpace(courseCode) || string.IsNullOrWhiteSpace(courseName) || !int.TryParse(textBox1.Text, out courseCredit))
            {
                MessageBox.Show("Please enter valid course information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert the course information into the database
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO CoursePanel (CourseCode, CourseName, CourseCredit) VALUES (@CourseCode, @CourseName, @CourseCredit)", connection))
                    {
                        cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                        cmd.Parameters.AddWithValue("@CourseName", courseName);
                        cmd.Parameters.AddWithValue("@CourseCredit", courseCredit);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the input fields after successful insertion
                            textBox3.Clear();
                            textBox2.Clear();
                            textBox1.Clear();

                            // Load the course data into the DataGridView
                            LoadCourseData();
                        }
                        else
                        {
                            MessageBox.Show("Course could not be added. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void _10AdminCourseAdd_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
