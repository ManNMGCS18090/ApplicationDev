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
    public partial class ManageCourseCategory : Form
    {
        CATEGORY category = new CATEGORY();

        public ManageCourseCategory()
        {
            InitializeComponent();
        }

        //Add button
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;

            if (name.Trim().Equals("") || description.Trim().Equals(""))
            {
                MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean addCategory = category.addCategory(name, description);

                if (addCategory)
                {
                    dataGridView1.DataSource = category.getCategory();
                    button4.PerformClick();
                    MessageBox.Show("New Course Category has been added successfully!", "Course Category Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Course Category not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Update button
        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string name = textBox1.Text;
            string description = textBox2.Text;

            try
            {
                id = Convert.ToInt32(textBox10.Text);

                if (name.Trim().Equals("") || description.Trim().Equals(""))
                {
                    MessageBox.Show("Please select a row or do not let anything field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean editCategory = category.editCategory(id, name, description);

                    if (editCategory)
                    {
                        dataGridView1.DataSource = category.getCategory();
                        button4.PerformClick();
                        MessageBox.Show("Course Category has been updated successfully!", "Edit Course Category" +
                            "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Course Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);

                if (category.deleteCategory(id))
                {
                    dataGridView1.DataSource = category.getCategory();
                    MessageBox.Show("Course Category has been deleted successfully!", "Delete Course Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //you can clear all text boxes after the deletion
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error", "Delete Course Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //clear field button
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
        }

        //display the info from table to textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void ManageCourseCategory_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = category.getCategory();
        }
    }
}
