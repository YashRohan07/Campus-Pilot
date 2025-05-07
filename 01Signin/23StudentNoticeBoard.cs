using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class Form3 : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True"; // Replace with your actual connection string
        private int studentID; // Field to store the student ID

        public Form3(int studentID)
        {
            InitializeComponent();
            this.studentID = studentID; // Store the student ID

            // Initialize database connection and load messages from the database
            InitializeDatabaseConnection();
            LoadMessagesFromDatabase();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                // MessageBox.Show("Connected to the database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void LoadMessagesFromDatabase()
        {
            try
            {
                // Adjust the query to match your table structure
                string selectQuery = "SELECT * FROM Messages";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading messages from the database: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _05StudentPanel obje = new _05StudentPanel(studentID); // Pass the student ID
            obje.Show();
        }

        // You can handle DataGridView cell content click event if needed
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle DataGridView cell content click event if needed
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
