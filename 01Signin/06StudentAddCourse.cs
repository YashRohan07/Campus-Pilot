using System;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _06AddCourse : Form
    {
        private int studentID; // Field to store the student ID

        public _06AddCourse(int studentID)
        {
            InitializeComponent();
            this.studentID = studentID; // Store the student ID
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            _05StudentPanel obj2 = new _05StudentPanel(studentID); // Pass the student ID
            obj2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Handle checkbox change event
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle combobox selection change event
        }

        private void _06AddCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
