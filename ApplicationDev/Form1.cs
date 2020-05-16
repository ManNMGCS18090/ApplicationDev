using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    public partial class Form1 : Form
    {
        public static string username;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            CONNECT conn = new CONNECT();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM `user` WHERE `username`=@usn AND `password`=@pass AND `role`=@role";

            command.CommandText = query;
            command.Connection = conn.getConnection();
            
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;
            try
            {
                command.Parameters.Add("@role", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
            }
            catch { }

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //if the username and the password exist or match
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("You are logged in as " + comboBox1.SelectedItem.ToString());
                if (comboBox1.SelectedIndex == 0)
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.Show();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    this.Hide();
                    Staff staff = new Staff();
                    staff.Show();
                }
                else
                {
                    this.Hide();
                    Trainer trainer = new Trainer();
                    trainer.Show();
                }
            }
            else
            {
                if (textBox1.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Please enter Username!", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Please enter Password!", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select a role to login", "Empty Role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No username or password matches for this role", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
