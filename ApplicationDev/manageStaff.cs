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
    public partial class manageStaff : Form
    {
        ACCOUNT account = new ACCOUNT();

        public manageStaff()
        {
            InitializeComponent();
        }

        //clear field
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        //Add button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string role = comboBox1.SelectedItem.ToString();

                if (username.Trim().Equals("") || password.Trim().Equals(""))
                {
                    MessageBox.Show("Please fill out all the fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean addTrainee = account.createAccount(username, password, role);

                    if (addTrainee)
                    {
                        dataGridView1.DataSource = account.getAccount();
                        button4.PerformClick();
                        MessageBox.Show("New Account has been added successfully!", "Account Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Account not inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        //Delete button
        private void button3_Click(object sender, EventArgs e)
        {    
            string username = textBox1.Text;
         
            if (account.deleteAccount(username))
            {
                dataGridView1.DataSource = account.getAccount();
                MessageBox.Show("Account has been deleted successfully!", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //you can clear all text boxes after the deletion
                button4.PerformClick();
            }
            else
            {
                MessageBox.Show("Please select an existing username to delete", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        //Update button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string role = comboBox1.SelectedItem.ToString();

                if (username.Trim().Equals("") || password.Trim().Equals(""))
                {
                    MessageBox.Show("Please select a row or do not let anything field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean editAccount = account.editAccount(username, password, role);

                    if (editAccount)
                    {
                        dataGridView1.DataSource = account.getAccount();
                        button4.PerformClick();
                        MessageBox.Show("Account has been updated successfully!", "Edit Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("Please select a row or do not let anything field blank", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void manageStaff_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = account.getAccount();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
