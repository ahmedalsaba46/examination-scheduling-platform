using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace Organizing_dates_examinationsV2.Test
{
    public class test_data
    {

        public int id_test { get; set; }
        public int teacher_id { get; set; }
        public string class_id { get; set; }
        public int group_id { get; set; }
        public short clasrm_id { get; set; }
        public string day { get; set; }
        public DateTime date_test { get; set; }
        public string time_first { get; set; }
        public string time_end { get; set; }
        public string note { get; set; }
    }

    class test_class
    {


        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True ;Convert Zero Datetime=True");
        public string error;
        public test_class()
        {
            error = "0";
        }



        public List<test_data> getTest(string query)
        {
            List<test_data> li = new List<test_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    test_data tes = new test_data();
                    tes.id_test = dr.GetInt16("id_test");
                    tes.teacher_id= dr.GetInt16("teacher_id");
                    tes.class_id = dr.GetString("class_id");
                    tes.group_id = dr.GetInt16("group_id");
                    tes.clasrm_id = dr.GetInt16("clasrm_id");
                    tes.day = dr.GetString("day");
                    // ((DateTime)dr["open_date"]).ToString("MM/dd/yyyy")
                    //tes.date_test = ((DateTime)dr["date_test"]).ToString("Y/m/d");
                    tes.date_test = DateTime.Parse(dr["date_test"].ToString());
                    tes.time_first = dr.GetString("time_first");
                    tes.time_end = dr.GetString("time_end");
                    tes.note = dr.GetString("note");
                    li.Add(tes);
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
                return "لم يتم الاجراء ، الرجاء التاكد من البيانات";
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
