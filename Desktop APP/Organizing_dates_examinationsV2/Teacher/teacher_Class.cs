using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Teacher
{
    public class teacher_data
    {
        public int id_teacher { get; set; }
        public string name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string teacher_degree { get; set; }
        public short state { get; set; }
    }
    public class teacher_class_data
    {
        public int id_teacher { get; set; }
        public string id_class { get; set; }    }

    class teacher_Class
    {

        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;

        public teacher_Class()
        {
            error = "0";
        }
        public List<teacher_data> getTeacher(string query)
        {
            List<teacher_data> li = new List<teacher_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);

            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    teacher_data teacher = new teacher_data();
                    teacher.id_teacher = dr.GetInt16("id_teacher");
                    teacher.name = dr.GetString("name");
                    teacher.user_name = dr.GetString("user_name");
                    teacher.password = dr.GetString("password");
                    teacher.teacher_degree = dr.GetString("teacher_degree");
                    teacher.state = dr.GetInt16("state");
                    li.Add(teacher);
                }
                dr.Close();
                error = "0";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return li;
        }

        public List<teacher_class_data> getTeacher_class(string query)
        {
            List<teacher_class_data> li = new List<teacher_class_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);

            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    teacher_class_data teacher = new teacher_class_data();
                    teacher.id_teacher = dr.GetInt16("teacher_id");
                    teacher.id_class = dr.GetString("class_id");
                    li.Add(teacher);
                }
                dr.Close();
                error = "0";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return li;
        }
        public string data_Teacher(string command)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(command, con);

                if (com.ExecuteNonQuery() != 0)
                {
                    con.Close();
                    error = "0";
                    return error;

                }
                else

                    con.Close();
                return "لم يتم الاضافة الرجاء التاكد من البيانات";
            }
            catch (Exception ex)
            {

                con.Close();
                error = ex.Message;
                return error;
            }
        }
    }
}
