using System;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _08StudentShowAllCourse : Form
    {
        private int studentID; // Field to store the student ID

        public _08StudentShowAllCourse(int studentID)
        {
            InitializeComponent();
            this.studentID = studentID; // Store the student ID
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            _05StudentPanel objsp = new _05StudentPanel(studentID); // Pass the student ID
            objsp.Show();
        }
    }
}
