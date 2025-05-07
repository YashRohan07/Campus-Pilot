using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=DESKTOP-MM6V62D\\SQLEXPRESS;Initial Catalog=Portal;Integrated Security=True"; // Replace with your actual database connection string

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Load the list of available files when the form is initially loaded
            LoadFileList();
        }

        private void LoadFileList()
        {
            checkedListBox1.Items.Clear(); // Clear existing items

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FileName FROM Files";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string fileName = reader["FileName"].ToString();
                        checkedListBox1.Items.Add(fileName);
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if any items are checked in checkedListBox1
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select a folder to save the downloaded files.";
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string saveFolderPath = folderBrowserDialog.SelectedPath;

                        // Download each selected file
                        foreach (var item in checkedListBox1.CheckedItems)
                        {
                            string selectedFileName = item.ToString();
                            string saveFilePath = Path.Combine(saveFolderPath, selectedFileName);

                            // Retrieve the selected file from the database and save it to the chosen location
                            if (DownloadFileFromDatabase(selectedFileName, saveFilePath))
                            {
                                MessageBox.Show($"File '{selectedFileName}' downloaded successfully.");
                            }
                            else
                            {
                                MessageBox.Show($"File '{selectedFileName}' not found in the database.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select files from the list to download.");
            }
        }

        private bool DownloadFileFromDatabase(string fileName, string savePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FileData FROM Files WHERE FileName = @FileName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileName", fileName);

                    // Read the file data from the database
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] fileData = (byte[])reader["FileData"];

                        // Save the file data to the chosen location
                        System.IO.File.WriteAllBytes(savePath, fileData);
                        return true;
                    }
                    else
                    {
                        return false; // File not found in the database
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // View/display button for showing all uploaded files in checkedListBox1
            LoadFileList();
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
