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
    public partial class TrainerInfo : Form
    {
        MANAGETRAINER m = new MANAGETRAINER();

        public TrainerInfo()
        {
            InitializeComponent();
        }

        //update button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                 int id;
                 string name = textBox1.Text;
                 string type = comboBox1.SelectedItem.ToString();
                 string workplace = textBox2.Text;
                 string telephone = textBox3.Text;
                 string email = textBox4.Text;
                string topic = comboBox2.SelectedValue.ToString();
        
                 id = Convert.ToInt32(textBox5.Text);

                if (name.Trim().Equals("") || type.Trim().Equals("") || workplace.Trim().Equals("") || telephone.Trim().Equals("") || email.Trim().Equals(""))
                {
                    MessageBox.Show("Please select a row or do not let any field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean editCourse = m.editInfo(id, name, type, workplace, telephone,email, topic);

                    if (editCourse)
                    {
                        dataGridView1.DataSource = m.getInformation();
                        button4.PerformClick();
                        MessageBox.Show("Info has been updated successfully!", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please select a row or do not let any field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //create button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string type = comboBox1.SelectedItem.ToString();
                string workplace = textBox2.Text;
                string telephone = textBox3.Text;
                string email = textBox4.Text;
                string topic = comboBox2.SelectedValue.ToString();
                string username = Form1.username;

                if (name.Trim().Equals("") || workplace.Trim().Equals("") || telephone.Trim().Equals("") || email.Trim().Equals("") || topic.Trim().Equals(""))
                {
                    MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean createinfo = m.addInfo(name, type, workplace, telephone, email, topic, username);

                    if (createinfo)
                    {
                        dataGridView1.DataSource = m.getInformation();
                        button4.PerformClick();
                        MessageBox.Show("New Account has been added successfully!", "Account Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Account not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dataGridView1.Rows.Count > 0)
            {
                button1.Enabled = false;
            }
        }

        //delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox5.Text);

                if (m.deleteInfo(id))
                {
                    dataGridView1.DataSource = m.getInformation();
                    MessageBox.Show("Info has been deleted successfully!", "Delete Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //you can clear all text boxes after the deletion
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error", "Delete Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dataGridView1.Rows.Count == 0)
            {
                button1.Enabled = true;
            }
        }

        private void TrainerInfo_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = m.TopicList();
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";
            dataGridView1.DataSource = m.getInformation();
            if (dataGridView1.Rows.Count > 0)
            {
                button1.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
        }
    }
}
