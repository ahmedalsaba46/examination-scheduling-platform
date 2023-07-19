using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace Organizing_dates_examinationsV2.Schedule
{
    public class Schedule_data
    {
        public int id_schedule { get; set; }
        public string class_id { get; set; }
        public int clasrm_id { get; set; }
        public int group_id { get; set; }
        public string day { get; set; }
        public short time_first { get; set; }
        public short time_end { get; set; }
    }
    class class_Schedule
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;
        public class_Schedule()
        {
            error = "0";
        }
        public List<Schedule_data> getSchedule(string query)
        {
            List<Schedule_data> li = new List<Schedule_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Schedule_data Schedule = new Schedule_data();
                    Schedule.id_schedule = dr.GetInt16("id_schedule");
                    Schedule.class_id = dr.GetString("class_id");
                    Schedule.clasrm_id = dr.GetInt16("clasrm_id");
                    Schedule.group_id = dr.GetInt16("group_id");
                    Schedule.day = dr.GetString("day");
                    Schedule.time_first = dr.GetInt16("time_first");
                    Schedule.time_end = dr.GetInt16("time_end");
                    li.Add(Schedule);
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
