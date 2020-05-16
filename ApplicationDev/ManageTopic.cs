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
    public partial class ManageTopic : Form
    {

        Topic topic = new Topic();

        public ManageTopic()
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
                Boolean addTopic = topic.addTopic(name, description);

                if (addTopic)
                {
                    dataGridView1.DataSource = topic.getTopic();
                    button4.PerformClick();
                    MessageBox.Show("New Topic has been added successfully!", "Topic Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Topic not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Edit button
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
                    Boolean editTopic = topic.editTopic(id, name, description);

                    if (editTopic)
                    {
                        dataGridView1.DataSource = topic.getTopic();
                        button4.PerformClick();
                        MessageBox.Show("Topic has been updated successfully!", "Edit Topic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Topic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageTopic_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = topic.getTopic();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        //Clear field button 
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);

                if (topic.deleteTopic(id))
                {
                    dataGridView1.DataSource = topic.getTopic();
                    MessageBox.Show("Topic has been deleted successfully!", "Delete Topic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //you can clear all text boxes after the deletion
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error", "Delete Topic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
