using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace _01Signin
{
    public partial class Form5 : Form
    {
        private SqlConnection connection; // Database connection

        public Form5()
        {
            InitializeComponent();
            InitializeDatabaseConnection(); // Initialize database connection

            // Load data from the Result table when the form is initialized
            LoadDataFromResultTable();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True"; // Replace with your actual database connection string
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //MessageBox.Show("Database Connection Established");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values entered by the faculty
                int studentID = int.Parse(textBox4.Text);
                string courseCode = textBox6.Text;
                int marks = int.Parse(textBox5.Text);

                // Calculate the grade based on the marks
                string grade = CalculateGrade(marks);

                // Insert the grade into the database
                InsertGradeIntoDatabase(studentID, courseCode, marks, grade); // Pass 0 as resultID for insertion

                // Provide feedback to the faculty user
                MessageBox.Show("Grade submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

                // Reload data from the Result table to refresh the DataGridView
                LoadDataFromResultTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private string CalculateGrade(int marks)
        {
            // Implement your logic to convert marks into grades
            // This is a simple example; adjust it to your grading criteria
            if (marks >= 90)
            {
                return "A";
            }
            else if (marks >= 80)
            {
                return "B";
            }
            else if (marks >= 70)
            {
                return "C";
            }
            else if (marks >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        private void InsertGradeIntoDatabase(int studentID, string courseCode, int marks, string grade)
        {
            try
            {
                // Implement the code to insert the grade into your Result table
                string insertQuery = "INSERT INTO Result (StudentID, CourseCode, Marks, Grade) VALUES (@StudentID, @CourseCode, @Marks, @Grade)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    cmd.Parameters.AddWithValue("@Marks", marks);
                    cmd.Parameters.AddWithValue("@Grade", grade);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data into the database: " + ex.Message);
            }
        }

        // Load data from the Result table
        private void LoadDataFromResultTable()
        {
            try
            {
                string query = "SELECT * FROM Result"; // Query to select all data from the Result table
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from the database: " + ex.Message);
            }
        }

        // Don't forget to close the database connection when the form is closed
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values entered by the faculty for update
                int studentID = int.Parse(textBox4.Text);
                string courseCode = textBox6.Text;
                int marks = int.Parse(textBox5.Text);

                // Calculate the grade based on the marks
                string grade = CalculateGrade(marks);

                // Update the grade in the database for the specified Result ID
                UpdateGradeInDatabase(studentID, courseCode, marks, grade); // Pass the correct resultID

                // Provide feedback to the faculty user
                MessageBox.Show("Grade updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

                // Reload data from the Result table to refresh the DataGridView
                LoadDataFromResultTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UpdateGradeInDatabase(int studentID, string courseCode, int marks, string grade)
        {
            try
            {
                // Implement the code to update the grade in your Result table
                string updateQuery = "UPDATE Result SET Marks = @Marks, Grade = @Grade WHERE StudentID = @StudentID AND CourseCode = @CourseCode";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    cmd.Parameters.AddWithValue("@Marks", marks);
                    cmd.Parameters.AddWithValue("@Grade", grade);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data in the database: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
