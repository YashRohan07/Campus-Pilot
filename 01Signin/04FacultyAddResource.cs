using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _04FacultyAddResource : Form
    {
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True"; // Replace with your actual database connection string

        public _04FacultyAddResource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Read the selected file
                    byte[] fileData = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);
                    string contentType = GetContentType(fileName);
                    DateTime uploadDate = DateTime.Now;

                    // Insert the file into the database
                    InsertFileIntoDatabase(fileName, contentType, fileData, uploadDate);

                    MessageBox.Show("File uploaded successfully.");

                    // After uploading, refresh the list of uploaded files
                    LoadUploadedFiles();
                }
            }
        }

        private void InsertFileIntoDatabase(string fileName, string contentType, byte[] fileData, DateTime uploadDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Files (FileName, ContentType, FileData, UploadDate) VALUES (@FileName, @ContentType, @FileData, @UploadDate)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@ContentType", contentType);
                    command.Parameters.AddWithValue("@FileData", fileData);
                    command.Parameters.AddWithValue("@UploadDate", uploadDate);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadUploadedFiles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FileName FROM Files";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear the current items in listBoxUploadedFiles
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string fileName = reader["FileName"].ToString();
                        listBox1.Items.Add(fileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private string GetContentType(string fileName)
        {
            string extension = Path.GetExtension(fileName)?.ToLower();
            switch (extension)
            {
                case ".txt":
                    return "text/plain";
                case ".pdf":
                    return "application/pdf";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }


        private void _04FacultyAddResource_Load(object sender, EventArgs e)
        {
            // Load the list of uploaded files when the form is initially loaded
            LoadUploadedFiles();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _04FacultyAddResource_Load_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form5 ojb = new Form5();
            ojb.Show();
        }
    }
}
