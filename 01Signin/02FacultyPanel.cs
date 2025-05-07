using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _02FacultyPanel : Form
    {
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";
        private int loggedInFacultyID;

        public _02FacultyPanel(int facultyID)
        {
            InitializeComponent();

            loggedInFacultyID = facultyID;
            LoadFacultyData(loggedInFacultyID);
            LoadCourseData(); // Load course data initially
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM CoursePanel";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        guna2DataGridView1.DataSource = null;
                        guna2DataGridView1.DataSource = dt;

                        //foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                       // {
                       //     column.Width = 170;
                       // }

                        //guna2DataGridView1.RowTemplate.Height = 90;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadFacultyData(int facultyID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT FacultyID, Name, Gender, Email FROM Faculty WHERE FacultyID = @FacultyID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FacultyID", facultyID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string facultyName = reader["Name"].ToString();
                            string facultyGender = reader["Gender"].ToString();
                            string facultyEmail = reader["Email"].ToString();

                            label9.Text = "ID: " + facultyID;
                            label10.Text = "Name: " + facultyName;
                            label11.Text = "Gender: " + facultyGender;
                            label12.Text = "Email: " + facultyEmail;

                            label2.Text = "Welcome, " + facultyName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void _02FacultyPanel_Load(object sender, EventArgs e)
        {
            label2.Text = "Course List"; // Set label2 text to "Course List"
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            _04FacultyAddResource objre = new _04FacultyAddResource();
            objre.Show();
        }

        private void _02FacultyPanel_Load_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

            //this.Hide();
            Form5 ojb = new Form5();
            ojb.Show();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj3 = new Form1();
            obj3.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Form2 obj32 = new Form2();
            obj32.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            _27FacultyViewStudent obj32 = new _27FacultyViewStudent();
            obj32.Show();
        }

        // ... Other event handlers and methods ...
    }
}
