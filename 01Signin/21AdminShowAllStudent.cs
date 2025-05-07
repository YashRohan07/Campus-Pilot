using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _21AdminShowAllCourse : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _21AdminShowAllCourse()
        {
            InitializeComponent();
            LoadStudentData();
        }

        // This method is triggered when the form is loaded
        private void _21AdminShowAllCourse_Load(object sender, EventArgs e)
        {
            // You can keep any other initialization code here if needed
            // Removed LoadStudentData() from here
        }

        // Method to load student data
        private void LoadStudentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Open the connection

                    // Create the SQL query to select all data from the StudentPanel table
                    string selectQuery = "SELECT * FROM StudentPanel";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Assuming you have a DataGridView named dataGridView1 on your form
                        // Bind the DataTable to the DataGridView
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }

                // Display a message to indicate successful data loading
                //MessageBox.Show("Student data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message and log the error
                string errorMessage = $"Error: {ex.Message}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log the error for further debugging
                Console.WriteLine(errorMessage);
            }
        }

        // Event handler for the button click
        private void button5_Click(object sender, EventArgs e)
        {
            // Call the LoadStudentData method when the "Show All" button is clicked
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
