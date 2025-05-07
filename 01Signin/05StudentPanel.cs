using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _05StudentPanel : Form
    {
        // Define a connection string to connect to your database
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";
        private int loggedInStudentID; // Field to store logged-in student's ID

        public _05StudentPanel(int studentID)
        {
            InitializeComponent();
            loggedInStudentID = studentID;
            LoadCourseData();
            LoadStudentData(loggedInStudentID);
        }

        // Event handler for the "View" button
        private void button1_Click(object sender, EventArgs e)
        {
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            try
            {
                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define your SQL query to retrieve all courses
                    string query = "SELECT * FROM CoursePanel";

                    // Create a SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Create a SqlDataReader to fetch the data
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Create a new DataTable and load data row-wise
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Clear any existing data in the DataGridView
                        guna2DataGridView1.DataSource = null;

                        // Bind the DataTable to the DataGridView
                        guna2DataGridView1.DataSource = dt;

                        //foreach (DataGridViewColumn column in dataGridView1.Columns)
                        // {
                        //     column.Width = 170;
                        // }

                        // dataGridView1.RowTemplate.Height = 90;

                        guna2DataGridView1.ColumnHeadersVisible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStudentData(int studentID)
        {
            try
            {
                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define your SQL query to retrieve student data based on StudentID
                    string query = "SELECT StudentID, Name, Gender, Email FROM StudentPanel WHERE StudentID = @StudentID";

                    // Create a SqlCommand with parameters
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add the studentID parameter
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        // Create a SqlDataReader to fetch the data
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Check if there is data to read
                        if (reader.Read())
                        {
                            // Retrieve student information
                            string studentName = reader["Name"].ToString();
                            string studentGender = reader["Gender"].ToString();
                            string studentEmail = reader["Email"].ToString();

                            // Update the labels with student information
                            label9.Text = "ID: " + studentID;
                            label10.Text = "Name: " + studentName;
                            label11.Text = "Gender: " + studentGender;
                            label12.Text = "Email: " + studentEmail;

                            // Set the label8's text with "Welcome" and the student's name
                            label8.Text = "Welcome, " + studentName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void _05StudentPanel_Load(object sender, EventArgs e)
        {
            // Set the label8 (Welcome label) with a default text
            //label8.Text = "Welcome, Student";
        }

        // Code in Form5 where Form6 is opened with the logged-in student's ID
        private void OpenForm6WithStudentID(int studentID)
        {
            Form6 form6 = new Form6(this.loggedInStudentID);
            form6.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Add Course":
                    // Open the Add Course page or perform the corresponding action
                    _06AddCourse addCoursePage = new _06AddCourse(1);
                    addCoursePage.Show();
                    break;

                case "Drop Course":
                    // Open the Drop Course page or perform the corresponding action
                    _07StudentDropCourse dropCoursePage = new _07StudentDropCourse(1);
                    dropCoursePage.Show();
                    break;

                case "Registered Course":
                    // Open the Registered Courses page or perform the corresponding action
                    _08StudentShowAllCourse registeredCoursesPage = new _08StudentShowAllCourse(1);
                    registeredCoursesPage.Show();
                    break;

                default:
                    break;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form4 objdown = new Form4();
            objdown.Show();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            OpenForm6WithStudentID(this.loggedInStudentID);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form3 objnot = new Form3(0);
            objnot.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objnot = new Form1();
            objnot.Show();
        }

        // ... Other event handlers and methods ...
    }
}
