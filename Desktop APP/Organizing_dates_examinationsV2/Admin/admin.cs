using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Admin
{
    public class user_data
    {
        public int id_user { get; set; }
        public string name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string position { get; set; }
        public short state { get; set; }

    }
    class admin
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;

        public admin()
        {
            error = "0";
        }

        public List<user_data> getuser(string query)
        {
            List<user_data> li = new List<user_data>();
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    user_data depart = new user_data();
                    depart.id_user = dr.GetInt32("id_user");
                    depart.name = dr.GetString("name");
                    depart.user_name = dr.GetString("username");
                    depart.password = dr.GetString("password");
                    depart.position = dr.GetString("position");
                    depart.state = dr.GetInt16("state");

                    li.Add(depart);
                }
                dr.Close();
                error = "0";
                return li;
            }
            catch (Exception ex)
            {
                //deprtment_data depart = new deprtment_data();
                // li[3] = ex.Message;
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return li;
        }
        public string data_user(string command)
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
        public string check_user(string command)
        {
            try
            {
                List<user_data> user_da = getuser(command);

                //Check if there is an error in the class  or not 
                if (error == "0")
                {
                    if (user_da.Any())
                    {
                        /*foreach (user_data user_data in user_da)
                            if (user_name == user_data.user_name)*/
                        return ("اسم المستخدم موجود مسبقا");
                    }
                    return "0";
                }
                else
                    return error;
            }
            catch (Exception ex)
            {
                con.Close();
                return ex.Message;
            }


        }
    }
}
