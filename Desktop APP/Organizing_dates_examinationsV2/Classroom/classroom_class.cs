using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace Organizing_dates_examinationsV2.Classroom
{
    public class classroom_data
    {
        public int id_clasrm { get; set; }
        public string name_clasrm { get; set; }
        public int num_clasrm { get; set; }
        public string type_clasrm { get; set; }
        public short state_clasrm { get; set; }

    }
    class classroom_class
    {

        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;

        public classroom_class()
        {
            error = "0";
        }

        public List<classroom_data> getdepartment(string query)
        {

            List<classroom_data> li = new List<classroom_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);

            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    classroom_data depart = new classroom_data();
                    depart.id_clasrm = dr.GetInt16("id_clasrm");
                    depart.name_clasrm = dr.GetString("name_clasrm");
                    depart.num_clasrm = dr.GetInt16("num_clasrm");
                    depart.type_clasrm = dr.GetString("type_clasrm");
                    depart.state_clasrm = dr.GetInt16("state_clasrm");

                    li.Add(depart);
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


        public string data_room(string command)
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
                return "لم يتم الرجاء التاكد من البيانات";
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
