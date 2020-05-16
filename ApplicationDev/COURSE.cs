using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    class COURSE
    {
        CONNECT conn = new CONNECT();

        //create a function to get category list 
        public DataTable CourseCategoryList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `course_category`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //create a function to get topic list 
        public DataTable TopicList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `topic`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Add new course
        public bool addCourse(string name, string description, string category, string topic)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `course`(`Course Name`, `description`, `topic_id`, `category_id`) VALUES (@name,@des,@topic,@cat)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            //@name,@des,@topic,@cat
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@des", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@topic", MySqlDbType.Int32).Value = topic;
            command.Parameters.Add("@cat", MySqlDbType.Int32).Value = category;

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

        //create a function to get a list of course 
        public DataTable getCourse()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `course`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Update course 
        public bool editCourse(int id, string name, string des, string topic, string category)
        {
            MySqlCommand command = new MySqlCommand();

            string editQuery = "UPDATE `course` SET `Course Name`=@name,`description`=@des,`topic_id`=@topic,`category_id`=@cat WHERE `id`=@id";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            //@name,@des,@topic,@cat
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@des", MySqlDbType.VarChar).Value = des;
            command.Parameters.Add("@topic", MySqlDbType.Int32).Value = topic;
            command.Parameters.Add("@cat", MySqlDbType.Int32).Value = category;

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
        public bool deleteCourse(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `course` WHERE `id`=@id";
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
