using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace _01Signin
{
    public partial class _19AdminStudentTerminate : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _19AdminStudentTerminate()
        {
            InitializeComponent();
        }

        private void LoadStudentData()
        {
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

        private void button7_Click(object sender, EventArgs e)
        {
            // Get the StudentID to delete from the TextBox (you may use any other input method)
            if (int.TryParse(textBox1.Text, out int studentIDToDelete))
            {
                RemoveStudent(studentIDToDelete);
                // Do not reload data here, we will refresh the DataGridView in RemoveStudent method
            }
            else
            {
                MessageBox.Show("Invalid Student ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveStudent(int studentIDToDelete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM StudentPanel WHERE StudentID = @StudentID", connection))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentIDToDelete);

                        connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Student with Student ID {studentIDToDelete} removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the DataGridView after deletion
                            LoadStudentData();
                        }
                        else
                        {
                            MessageBox.Show($"No student found with Student ID {studentIDToDelete}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void _19AdminStudentTerminate_Load(object sender, EventArgs e)
        {
            // Load student data into the DataGridView when the form is loaded
            LoadStudentData();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _19AdminStudentTerminate_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}