using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2
{
    public class teacher_classes_groups
    {
        public int teacher_id { get; set; }
        public int group_id { get; set; }
        public string class_id { get; set; }
    }

    class other_classes
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;
        public other_classes()
        {
            error = "0";
        }

        public List<teacher_classes_groups> getteacher_classes_groups(string query)
        {
            List<teacher_classes_groups> li = new List<teacher_classes_groups>();

            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {

                    teacher_classes_groups cla = new teacher_classes_groups();
                    cla.group_id = dr.GetInt32("group_id");
                    cla.teacher_id = dr.GetInt32("teacher_id");
                    cla.class_id = dr.GetString("class_id");

                    li.Add(cla);
                }
                dr.Close();
                error = "0";
                return li;
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
        public string data(string command)
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
                con.Close();
                return "خطأ";
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
