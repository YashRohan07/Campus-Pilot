using System;
using System.Windows.Forms;

namespace _01Signin
{
    public partial class _22UploadAssignment : Form
    {
        private int studentID; // Field to store the student ID

        public _22UploadAssignment(int studentID)
        {
            InitializeComponent();
            this.studentID = studentID; // Store the student ID
        }

        private void _22UploadAssignment_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _05StudentPanel objsp = new _05StudentPanel(studentID); // Pass the student ID
            objsp.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objlog = new Form1();
            objlog.Show();
        }
    }
}
