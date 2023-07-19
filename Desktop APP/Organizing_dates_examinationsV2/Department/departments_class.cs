using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Department
{
    public class deprtment_data
    {
        public int id_deprtment { get; set; }
        public string name_department { get; set; }
        public string sub_department { get; set; }
        public short state { get; set; }

    }

    class departments_class
    {

        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        public string error;

        public departments_class()
        {
            error = "0";
        }

        public List<deprtment_data> getdepartment(string query)
        {

            List<deprtment_data> li = new List<deprtment_data>();
            //string query = "SELECT * FROM department";
            MySqlCommand com = new MySqlCommand(query, con);

            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    deprtment_data depart = new deprtment_data();
                    depart.id_deprtment = dr.GetInt16("id_deprtment");
                    depart.name_department = dr.GetString("name_department");
                    depart.sub_department = dr.GetString("sub_department");
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


        public string data_departments(string command)
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

        public string check_departments(string name_department, string sub_department , string command)
        {
            try
            {
               List<deprtment_data> deprtment_da = getdepartment(command);

                //Check if there is an error in the class  or not 
                if (error == "0")
                {
                    if (deprtment_da.Any())

                    {
                        foreach (deprtment_data deprtment_data in deprtment_da)
                            if(name_department == deprtment_data.name_department)
                         return string.Format("موجود مسبقا {0}", deprtment_data.name_department );
                        else
                                return string.Format("موجود مسبقا {0}", deprtment_data.sub_department);
                    }
                        return "0";   
                }
                else
                    return error;
            }
            catch (Exception ex)
            { con.Close();
                return ex.Message;
            }


        }

    }




}
