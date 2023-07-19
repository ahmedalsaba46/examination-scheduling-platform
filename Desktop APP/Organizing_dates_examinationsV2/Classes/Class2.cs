using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Classes
{
    public class class_data
    {
        public string id_class { get; set; }
        public string name_class { get; set; }
        public string req_id { get; set; }
        public int num_unit { get; set; }
        public string type_class { get; set; }
        public short state { get; set; }
    }
    public class classes_semster_department
    {
        public int department_id { get; set; }
        public int semster_id { get; set; }
        public string class_id { get; set; }       
    }


    class Class2
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;
        public Class2()
        {
            error = "0";
        }


        public List<class_data> getclass(string query)
        {
            List<class_data> li = new List<class_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    class_data cla = new class_data();
                    cla.id_class = dr.GetString("id_class");
                    cla.name_class = dr.GetString("name_class");
                    cla.req_id = dr.GetString("req_id");
                    cla.num_unit = dr.GetInt16("num_unit");
                    cla.type_class = dr.GetString("type_class");
                    cla.state = dr.GetInt16("state");

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



        public List<classes_semster_department> get_C_S_D(string query)
        {
            List<classes_semster_department> li = new List<classes_semster_department>();
            
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {

                    classes_semster_department cla = new classes_semster_department();
                    cla.department_id = dr.GetInt32("department_id");
                    cla.semster_id = dr.GetInt32("semster_id");
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
