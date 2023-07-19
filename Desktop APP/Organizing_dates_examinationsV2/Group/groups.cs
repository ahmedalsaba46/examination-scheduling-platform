using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Group
{
    public class groups_data
    {
        public int id_group { get; set; }
        public string name_group { get; set; }
        public int department_id { get; set; }
        public int semster_id { get; set; }
        public short state { get; set; }
    }
    class groups
    {


        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;
        public groups()
        {
            error = "0";
        }


        public List<groups_data> getgroups(string query)
        {
            List<groups_data> li = new List<groups_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    groups_data group = new groups_data();
                    group.id_group = dr.GetInt16("id_group");
                    group.name_group = dr.GetString("name_group");
                    group.department_id = dr.GetInt16("department_id");
                    group.semster_id = dr.GetInt16("semster_id");
                    group.state = dr.GetInt16("state");
                    li.Add(group);
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



       /* public List<classes_semster_department> get_C_S_D(string query)
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
                    cla.department_id = dr.Getint("department_id");
                    cla.semster_id = dr.Getint("semster_id");
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

        }*/


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

   