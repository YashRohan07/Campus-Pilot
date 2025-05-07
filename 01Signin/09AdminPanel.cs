using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _09AdminPanel : Form
    {
        // Store the admin's ID
        private int adminId;

        public _09AdminPanel(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;

            // Display admin information when the form is loaded
            DisplayAdminInformation(adminId);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {

            string selectedOption = comboBox1.SelectedItem.ToString();

            switch (selectedOption)

            {

                case "Add Course":

                    _10AdminCourseAdd CoursePage = new _10AdminCourseAdd();

                    CoursePage.Show();

                    break;

                case "Remove Course":

                    _11AdminCourseRemove RemovePage = new _11AdminCourseRemove();

                    RemovePage.Show();

                    break;

               /* case "Update Course":

                    _12AdminUpdateCourse updatepage = new _12AdminUpdateCourse();

                    updatepage.Show();

                    break;
               */

                case "Show All Course":

                    _13AdminShowAllCourse showpage = new _13AdminShowAllCourse();

                    showpage.Show();

                    break;

                default:

                    break;

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)

        {

            string selectedOption = comboBox2.SelectedItem.ToString();

            switch (selectedOption)

            {

                case "Add Student":

                    _18AdminStudentAdd staddPage = new _18AdminStudentAdd();

                    staddPage.Show();

                    break;

                case "Terminate Student":

                    _19AdminStudentTerminate stRemovePage = new _19AdminStudentTerminate();

                    stRemovePage.Show();

                    break;

                case "Update Information":

                    _20AdminStudentUpdate stupdatepage = new _20AdminStudentUpdate();

                    stupdatepage.Show();

                    break;


                case "Show All Student":

                    _21AdminShowAllCourse stshowpage = new _21AdminShowAllCourse();

                    stshowpage.Show();

                    break;

                default:

                    break;

            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)

        {

            string selectedOption = comboBox3.SelectedItem.ToString();

            switch (selectedOption)

            {

                case "Add Faculty":

                    _14AdminAddFaculty RegPage = new _14AdminAddFaculty();

                    RegPage.Show();

                    break;

                case "Terminate Faculty":

                    _15AdminFacultyTerminate RmvPage = new _15AdminFacultyTerminate();

                    RmvPage.Show();

                    break;

                case "Update Information":

                    _16AdminFacultyUpdate updaPage = new _16AdminFacultyUpdate();

                    updaPage.Show();

                    break;


                case "View All Faculty":

                    _17AdminFaculryViewAll showPage = new _17AdminFaculryViewAll();

                    showPage.Show();

                    break;

                default:

                    break;

            }

        }


        private void label7_Click(object sender, EventArgs e)
        {
            // Log out and return to the login form
            this.Hide();
            Form1 fobj6 = new Form1();
            fobj6.Show();
        }

        private void DisplayAdminInformation(int adminId)
        {
            // Create a SqlConnection using the connection string
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True");

            try
            {
                // Open the database connection
                con.Open();

                // Define a SQL query to retrieve admin information based on the adminId
                string query = "SELECT ID, Name, Designation, Email, Address FROM Admins WHERE ID = @AdminID";

                // Create a SqlCommand with the query and SqlConnection
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AdminID", adminId);

                // Execute the query
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string AdminName = reader["Name"].ToString();
                    string AdminDesignation = reader["Designation"].ToString();
                    string AdminEmail = reader["Email"].ToString();
                    string AdminAddress = reader["Address"].ToString();

                    label2.Text = "ID: " + adminId;
                    label3.Text = "Name: " + AdminName;
                    label4.Text = "Designation: " + AdminDesignation;
                    label5.Text = "Email: " + AdminEmail;
                    label8.Text = "Address: " + AdminAddress;
                    label9.Text = "Welcome, " + AdminName;
                }

                else
                {
                    // Handle the case where no admin with the specified ID is found
                    MessageBox.Show("Admin not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if any
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the database connection
                con.Close();
            }
        }

        private void _09AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void _09AdminPanel_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}