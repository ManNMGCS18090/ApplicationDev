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
    public partial class ManageCourse : Form
    {
        public ManageCourse()
        {
            InitializeComponent();
        }

        COURSE course = new COURSE();

        private void ManageCourse_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = course.TopicList();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox2.DataSource = course.CourseCategoryList();
            comboBox2.DisplayMember = "category_name";
            comboBox2.ValueMember = "category_id";

            dataGridView1.DataSource = course.getCourse();
        }

        //Add button
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string des = textBox2.Text;
            string topic = comboBox1.SelectedValue.ToString();
            string cat = comboBox2.SelectedValue.ToString();

            if (name.Trim().Equals("") || des.Trim().Equals(""))
            {
                MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean addCourse = course.addCourse(name, des, cat, topic);

                if (addCourse)
                {
                    dataGridView1.DataSource = course.getCourse();
                    button4.PerformClick();
                    MessageBox.Show("New Course has been added successfully!", "Course Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Course not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Clear button
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
        }

        //Update button
        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string name = textBox1.Text;
            string des = textBox2.Text;
            string topic = comboBox1.SelectedValue.ToString();
            string category = comboBox2.SelectedValue.ToString();

            try
            {
                id = Convert.ToInt32(textBox10.Text);

                if (name.Trim().Equals("") || des.Trim().Equals(""))
                {
                    MessageBox.Show("Please select a row or do not let anything field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean editCourse = course.editCourse(id, name, des, topic, category);

                    if (editCourse)
                    {
                        dataGridView1.DataSource = course.getCourse();
                        button4.PerformClick();
                        MessageBox.Show("Course has been updated successfully!", "Edit Trainee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //display the selected data from datagridview to the textboxes
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);

                if (course.deleteCourse(id))
                {
                    dataGridView1.DataSource = course.getCourse();
                    MessageBox.Show("Course has been deleted successfully!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //you can clear all text boxes after the deletion
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
