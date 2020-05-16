using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApplicationDev
{
    //This class is used to add,edit, delete trainee
    class TRAINEE
    {
        CONNECT conn = new CONNECT();

        //Add method
        public bool addTrainee(string name, string age, string DoB, string education, string proLanguage, string TOEIC, string expDetail, string department, string location, string course_id)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `trainee`(`name`, `age`, `DoB`, `education`, `proLanguage`, `TOEIC`, `expDetail`, `department`, `location`,`course_id`) VALUES (@name,@age,@dob,@edu,@pro,@toeic,@exp,@dept,@loc,@crsid)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            //@name,@age,@dob,@edu,@pro,@toeic,@exp,@dept,@loc
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@dob", MySqlDbType.VarChar).Value = DoB;
            command.Parameters.Add("@edu", MySqlDbType.VarChar).Value = education;
            command.Parameters.Add("@pro", MySqlDbType.VarChar).Value = proLanguage;
            command.Parameters.Add("@toeic", MySqlDbType.VarChar).Value = TOEIC;
            command.Parameters.Add("@exp", MySqlDbType.VarChar).Value = expDetail;
            command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = department;
            command.Parameters.Add("@loc", MySqlDbType.VarChar).Value = location;
            command.Parameters.Add("@crsid", MySqlDbType.VarChar).Value = course_id;


            conn.openConnection();

            if(command.ExecuteNonQuery() == 1)
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

        //create a function to get the trainee list
        public DataTable getTrainee()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `trainee`",conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //Edit function
        public bool editTrainee(int id, string name, string age, string DoB, string education, string proLanguage, string TOEIC, string expDetail, string department, string location, string course_id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `trainee` SET `name`=@name,`age`=@age,`DoB`=@dob,`education`=@edu,`proLanguage`=@pro,`TOEIC`=@toeic,`expDetail`=@exp,`department`=@dept,`location`=@loc,`course_id`=@crsid WHERE `id`=@id";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            //@name,@age,@dob,@edu,@pro,@toeic,@exp,@dept,@loc
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@dob", MySqlDbType.VarChar).Value = DoB;
            command.Parameters.Add("@edu", MySqlDbType.VarChar).Value = education;
            command.Parameters.Add("@pro", MySqlDbType.VarChar).Value = proLanguage;
            command.Parameters.Add("@toeic", MySqlDbType.VarChar).Value = TOEIC;
            command.Parameters.Add("@exp", MySqlDbType.VarChar).Value = expDetail;
            command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = department;
            command.Parameters.Add("@loc", MySqlDbType.VarChar).Value = location;
            command.Parameters.Add("@crsid", MySqlDbType.VarChar).Value = course_id;

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
        public bool deleteTrainee(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM `trainee` WHERE `id`=@id";
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
