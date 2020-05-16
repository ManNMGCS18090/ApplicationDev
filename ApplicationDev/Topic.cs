using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    class Topic
    {
        CONNECT conn = new CONNECT();

        //Add method
        public bool addTopic(string name, string description)
        { 
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `topic`(`name`, `description`) VALUES (@name,@des)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            //@name,@age,@dob,@edu,@pro,@toeic,@exp,@dept,@loc
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@des", MySqlDbType.VarChar).Value = description;


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

        //create a function to get the topic list
        public DataTable getTopic()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `topic`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Edit function
        public bool editTopic(int id, string name, string description)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `topic` SET `name`=@name,`description`=@des WHERE `id`=@id";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@des", MySqlDbType.VarChar).Value = description;

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

        //Delete function
        public bool deleteTopic(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `topic` WHERE `id`=@id";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

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
