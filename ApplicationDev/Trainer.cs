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
    public partial class Trainer : Form
    {
        public Trainer()
        {
            InitializeComponent();
        }

        private void manageDsfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrainerInfo t = new TrainerInfo();
            t.ShowDialog();
        }

        private void viewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCourse v = new ViewCourse();
            v.ShowDialog();
        }

        private void Trainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }

        private void Trainer_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + Form1.username;
        }
    }
}
