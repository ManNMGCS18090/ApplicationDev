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
    public partial class ManageTrainee : Form
    {
        TRAINEE trainee = new TRAINEE();
       
        public ManageTrainee()
        {
            InitializeComponent();
        }

        //clear field button
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        //add button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string age = textBox2.Text;
                string DoB = textBox3.Text;
                string education = textBox4.Text;
                string proLanguage = textBox5.Text;
                string TOEIC = textBox6.Text;
                string expDetail = textBox7.Text;
                string department = textBox8.Text;
                string location = textBox9.Text;
                string course_id = textBox11.Text;

                if (name.Trim().Equals("") || age.Trim().Equals("") || DoB.Trim().Equals("") || education.Trim().Equals("") || proLanguage.Trim().Equals("") || TOEIC.Trim().Equals("") || expDetail.Trim().Equals("") || department.Trim().Equals("") || location.Trim().Equals("") || course_id.Trim().Equals(""))
                {
                    MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean addTrainee = trainee.addTrainee(name, age, DoB, education, proLanguage, TOEIC, expDetail, department, location, course_id);

                    if (addTrainee)
                    {
                        dataGridView1.DataSource = trainee.getTrainee();
                        button4.PerformClick();
                        MessageBox.Show("New Trainee has been added successfully!", "Trainee Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Trainee not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Non-existing course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageTrainee_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = trainee.getTrainee();
        }


        //Update button
        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string name = textBox1.Text;
            string age = textBox2.Text;
            string DoB = textBox3.Text;
            string education = textBox4.Text;
            string proLanguage = textBox5.Text;
            string TOEIC = textBox6.Text;
            string expDetail = textBox7.Text;
            string department = textBox8.Text;
            string location = textBox9.Text;
            string course_id = textBox11.Text;

            try
            {
                id = Convert.ToInt32(textBox10.Text);

                if (name.Trim().Equals("") || age.Trim().Equals("") || DoB.Trim().Equals("") || education.Trim().Equals("") || proLanguage.Trim().Equals("") || TOEIC.Trim().Equals("") || expDetail.Trim().Equals("") || department.Trim().Equals("") || location.Trim().Equals("") || course_id.Trim().Equals(""))
                {
                    MessageBox.Show("Please select a row or do not let anything field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean addTrainee = trainee.editTrainee(id, name, age, DoB, education, proLanguage, TOEIC, expDetail, department, location, course_id);

                    if (addTrainee)
                    {
                        dataGridView1.DataSource = trainee.getTrainee();
                        button4.PerformClick();
                        MessageBox.Show("Trainee has been updated successfully!", "Edit Trainee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Trainee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //display the selected data from datagridview to the textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox10.Text);

                if (trainee.deleteTrainee(id))
                {
                    dataGridView1.DataSource = trainee.getTrainee();
                    MessageBox.Show("Trainee has been deleted successfully!", "Edit Trainee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //you can clear all text boxes after the deletion
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error", "Delete Trainee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = trainee.getTrainee();
            DataView search = new DataView(table);
            switch (comboBox1.Text)
            {
                case "Name":
                    search.RowFilter = string.Format("name LIKE '%{0}%'", textBox12.Text);
                    dataGridView1.DataSource = search.ToTable();
                    break;
                case "Education":
                    search.RowFilter = string.Format("education LIKE '%{0}%'", textBox12.Text);
                    dataGridView1.DataSource = search.ToTable();
                    break;
            }
        }
    }
}
