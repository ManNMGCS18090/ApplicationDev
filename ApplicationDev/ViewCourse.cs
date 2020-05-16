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
    public partial class ViewCourse : Form
    {
        MANAGETRAINER m = new MANAGETRAINER();

        public ViewCourse()
        {
            InitializeComponent();
        }

        private void ViewCourse_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = m.getCourse();
        }
    }
}
