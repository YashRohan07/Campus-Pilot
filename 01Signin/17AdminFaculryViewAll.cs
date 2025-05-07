using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _17AdminFaculryViewAll : Form
    {
        // Database connection string
        string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public _17AdminFaculryViewAll()
        {
            InitializeComponent();
            LoadFacultyData();
        }

        /*private void _17AdminFaculryViewAll_Load(object sender, EventArgs e)
        {
            // Call the LoadFacultyData method to load and display faculty data when the form loads
            LoadFacultyData();
        }
        */
        private void LoadFacultyData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create the SQL query to select all data from the Faculty table
                    string selectQuery = "SELECT * FROM Faculty";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }

                // Display a message to indicate successful data loading
                //MessageBox.Show("Faculty data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _17AdminFaculryViewAll_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
        }

        private void _17AdminFaculryViewAll_Load(object sender, EventArgs e)
        {

        }
    }
}