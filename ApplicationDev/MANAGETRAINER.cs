using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApplicationDev
{
    class MANAGETRAINER
    {
        CONNECT conn = new CONNECT();

        //create a function to get a list of trainer's information  
        public DataTable getInformation()
        {
            MySqlCommand command = new MySqlCommand("SELECT `id`, `name`, `type`, `working place`, `telephone`, `email`, `topic_id` FROM `trainer` WHERE `username`=@usn", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Form1.username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //create a function to get a list of topic
        public DataTable TopicList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `topic`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //create a function to get a list of course for each trainer(chưa làm xong)
        public DataTable getCourse()
        {
            MySqlCommand command = new MySqlCommand("SELECT course.`Course Name` FROM COURSE INNER JOIN TRAINER ON course.topic_id = trainer.topic_id WHERE trainer.username=@usn", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Form1.username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //Add info
        public bool addInfo(string name, string type, string workplace, string telephone, string email, string topic, string username)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `trainer`(`name`, `type`, `working place`, `telephone`, `email`, `topic_id`,`username`) VALUES (@name,@type,@workplace,@tel,@email,@topic,@usn)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            //@name,@des,@topic,@cat
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@workplace", MySqlDbType.VarChar).Value = workplace;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@topic", MySqlDbType.Int32).Value = topic;
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

        //Update info 
        public bool editInfo(int id, string name, string type, string workplace, string telephone, string email, string topic)
        {
            MySqlCommand command = new MySqlCommand();

            string editQuery = "UPDATE `trainer` SET `name`=@name,`type`=@type,`working place`=@workplace,`telephone`=@tel, `email`=@email, `topic_id`=@topic WHERE `id`=@id";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@workplace", MySqlDbType.VarChar).Value = workplace;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@topic", MySqlDbType.Int32).Value = topic;

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

        //Delete trainer 
        public bool deleteInfo(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `trainer` WHERE `id`=@id";
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
