using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class Form1 : Form
    {
        // Database connection string
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Disable error icon at form load
            errorProvider1.Icon = null;
            errorProvider2.Icon = null;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // This method is empty, you may remove it if not needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Validate username
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please enter username");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Please enter password");
            }
            else
            {
                errorProvider2.SetError(textBox2, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if both username and password fields are filled
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                // Create a new SqlConnection using the connection string
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True");

                try
                {
                    // Open the database connection
                    con.Open();

                    // SQL query to check if the provided username and password exist in the database
                    String queryStudent = "SELECT * FROM StudentPanel WHERE StudentID=@StudentID AND Password=@Password";
                    String queryTeacher = "SELECT * FROM Faculty WHERE FacultyID=@FacultyID AND Password=@Password";
                    String queryAdmin = "SELECT * FROM Admins WHERE Id=@Id AND password=@password";

                    // Create a SqlCommand with the query and SqlConnection
                    SqlCommand sqlCmdStudent = new SqlCommand(queryStudent, con);
                    sqlCmdStudent.CommandType = CommandType.Text;
                    sqlCmdStudent.Parameters.AddWithValue("@StudentID", textBox1.Text);
                    sqlCmdStudent.Parameters.AddWithValue("@Password", textBox2.Text);
                    int student = Convert.ToInt32(sqlCmdStudent.ExecuteScalar());

                    SqlCommand sqlCmdTeachers = new SqlCommand(queryTeacher, con);
                    sqlCmdTeachers.CommandType = CommandType.Text;
                    sqlCmdTeachers.Parameters.AddWithValue("@FacultyID", textBox1.Text);
                    sqlCmdTeachers.Parameters.AddWithValue("@Password", textBox2.Text);
                    int teacher = Convert.ToInt32(sqlCmdTeachers.ExecuteScalar());

                    SqlCommand sqlCmdAdmin = new SqlCommand(queryAdmin, con);
                    sqlCmdAdmin.CommandType = CommandType.Text;
                    sqlCmdAdmin.Parameters.AddWithValue("@Id", textBox1.Text);
                    sqlCmdAdmin.Parameters.AddWithValue("@password", textBox2.Text);
                    int admin = Convert.ToInt32(sqlCmdAdmin.ExecuteScalar());

                    // Check the login result
                    if (student > 0)
                    {
                        // Student login successful
                        this.Hide();
                        _05StudentPanel obj1 = new _05StudentPanel(student); // Pass the student ID
                        obj1.Show();
                    }
                    else if (teacher > 0)
                    {
                        // Teacher login successful
                        this.Hide();
                        _02FacultyPanel obj2 = new _02FacultyPanel(teacher); // Pass the faculty ID
                        obj2.Show();
                    }
                    else if (admin > 0)
                    {
                        // Admin login successful
                        this.Hide();
                        _09AdminPanel obj3 = new _09AdminPanel(admin);
                        obj3.Show();
                    }
                    else
                    {
                        // Login failed
                        MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions if any
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the database connection in the finally block to ensure it's always closed
                    con.Close();
                }
            }
            else
            {
                // Display a message box to indicate that both fields are required
                MessageBox.Show("Both fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the visibility of the password characters based on checkbox state
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false; // Show password characters
                    break;

                default:
                    textBox2.UseSystemPasswordChar = true; // Hide password characters
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
