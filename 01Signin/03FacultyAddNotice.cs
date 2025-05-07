using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class Form2 : Form
    {
        // Define your connection string to connect to the database
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }
        
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the user inputs from TextBox controls
            
            string Notices = textBox1.Text;

            // Validate input (you may add more validation as needed)
            if (string.IsNullOrWhiteSpace(Notices))
            {
                MessageBox.Show("Both Message Title and Message Text are required.");
                return;
            }

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Create a SQL command to insert data into the Messages table
                    string insertQuery = "INSERT INTO Messages (Notices) VALUES (@Notices)";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@Notices", Notices);
                   

                    // Execute the SQL command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Notice inserted successfully.");
                        // Clear the TextBox controls after successful insertion
                       
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Message insertion failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form5 ojb = new Form5();
            ojb.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
