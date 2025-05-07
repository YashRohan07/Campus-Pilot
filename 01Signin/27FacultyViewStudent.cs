using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _27FacultyViewStudent : Form
    {
        private SqlConnection connection; // Database connection
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public _27FacultyViewStudent()
        {
            InitializeComponent();
            InitializeDatabaseConnection(); // Initialize database connection
            InitializeDataGridView();
            LoadDataFromDatabase(); // Load data automatically when the form is created
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True"; // Replace with your actual database connection string
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                // MessageBox.Show("Database Connection Established");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void InitializeDataGridView()
        {
            // Create a new DataTable and set it as the DataSource for the DataGridView
            dataTable = new DataTable();
            guna2DataGridView1.DataSource = dataTable;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                // Query to retrieve selected columns from the StudentPanel table
                string query = "SELECT StudentID, Name, Gender, Email, PhoneNumber FROM StudentPanel";

                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable.Clear(); // Clear the existing data
                dataAdapter.Fill(dataTable); // Fill the DataTable with data from the database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from the database: " + ex.Message);
            }
        }

        // Remember to close the database connection when the form is closed
        private void _27FacultyViewStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }

        // Label click event handlers
        private void label8_Click(object sender, EventArgs e)
        {
            // Your label8_Click code here
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your label1_Click code here
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Your label3_Click code here
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Your label4_Click code here
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Your label5_Click code here
        }

        private void label14_Click(object sender, EventArgs e)
        {
            // Your label14_Click code here
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Your label7_Click code here
        }

        private void label25_Click(object sender, EventArgs e)
        {
            // Your label25_Click code here
        }

        private void _27FacultyViewStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
