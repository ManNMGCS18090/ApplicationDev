using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDev
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTrainee manageTrainee = new ManageTrainee();
            manageTrainee.ShowDialog();
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourse manageCourse = new ManageCourse();
            manageCourse.ShowDialog();
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageTopic manageTopic = new ManageTopic();
            manageTopic.ShowDialog();
        }

        private void manageCourseCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourseCategory manageCategory = new ManageCourseCategory();
            manageCategory.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + Form1.username;
        }
    }
}
