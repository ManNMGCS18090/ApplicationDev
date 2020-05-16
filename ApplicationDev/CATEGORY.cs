using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    class CATEGORY
    {
        CONNECT conn = new CONNECT();

        //Add method
        public bool addCategory(string name, string description)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `course_category`(`category_name`, `category_description`) VALUES (@name,@des)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

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

        //create a function to get the category list
        public DataTable getCategory()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `course_category`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Edit function
        public bool editCategory(int id, string name, string description)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `course_category` SET `category_name`=@name,`category_description`=@des WHERE `category_id`=@id";
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
        public bool deleteCategory(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `course_category` WHERE `category_id`=@id";
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
