using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    class ACCOUNT
    {
        CONNECT conn = new CONNECT();

        //Create new account
        public bool createAccount(string username, string password, string role)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `user`(`username`, `password`, `role`) VALUES (@usn,@pass,@role)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

        //Return data to the datagridview table 
        public DataTable getAccount()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `role`='training staff'OR`role`='trainer'", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Update account
        public bool editAccount(string username, string password, string role)
        {
            MySqlCommand command = new MySqlCommand();

            string editQuery = "UPDATE `user` SET `password`=@pass,`role`=@role  WHERE `username`=@usn";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

        //Delete account
        public bool deleteAccount(string username)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `user` WHERE `username`=@usn";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

    }
}
