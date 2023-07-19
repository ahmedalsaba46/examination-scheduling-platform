using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace Organizing_dates_examinationsV2.test
{
    public partial class addTest : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        int month, year;

        List<Group.groups_data> listgroup;
        List<Department.deprtment_data> listdepartment;

        public static int Depart_id, grou_id, sems_id;
        public static string Depart, sems, grou;

        public static int s_month, s_year;
        public addTest()
        {
            InitializeComponent();
        }

        void combo()
        {
            try
            {
                combodep.Items.Clear();

                Department.departments_class dep = new Department.departments_class();
                string command = "SELECT* FROM department";
                listdepartment = dep.getdepartment(command);

                //Check if there is an error in the class  or not 
                if (dep.error == "0")
                {
                    if (listdepartment.Any())
                    {
                        foreach (Department.deprtment_data deprtment_data in listdepartment)
                        {
                            if (deprtment_data.state == 0)
                            {
                                combodep.Items.Add(deprtment_data.name_department);
                            }
                        }
                    }

                    else
                        MessageBox.Show("لايوجود بيانات ");
                }
                else
                    MessageBox.Show(dep.error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void sem()
        {
            try
            {
                combosem.Items.Clear();


                con.Open();
                MySqlCommand com = new MySqlCommand("select * from semster", con);

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    combosem.Items.Add(dr["num_semster"].ToString());
                    combosem.ResetText();
                    combosem.Enabled = true;

                }

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        void gro()
        {
            try
            {
                comgroup.Items.Clear();

                int id_d = -2;
                foreach (Department.deprtment_data deprtment_data in listdepartment)
                {
                    if (deprtment_data.name_department == combodep.SelectedItem.ToString())
                    {
                        id_d = deprtment_data.id_deprtment;
                        Depart_id = id_d;
                        break;
                    }
                }
                if (id_d != -2)
                {

                    Group.groups gr = new Group.groups();
                    string command = "SELECT* FROM groups where department_id='" + id_d + "' and semster_id='" + combosem.SelectedItem.ToString() + "'";
                    listgroup = gr.getgroups(command);

                    //Check if there is an error in the class  or not 
                    if (gr.error == "0")
                    {
                        if (listgroup.Any())
                        {
                            foreach (Group.groups_data gro_data in listgroup)
                            {
                                if (gro_data.state == 0)
                                {
                                    comgroup.Items.Add(gro_data.name_group);
                                }
                            }
                            comgroup.ResetText();
                            comgroup.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("لايوجود بيانات ");
                            comgroup.ResetText();
                            comgroup.Enabled = false;
                            daycon.Controls.Clear();
                        }
                    }
                    else
                        MessageBox.Show(gr.error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            sem();
            if (combodep.SelectedItem.ToString() != "العام")
            {
                Depart = combodep.SelectedItem.ToString();
                combosem.Items.Remove("1");
                combosem.Items.Remove("2");
            }
            else
            {
                combosem.Items.Remove("3");
                combosem.Items.Remove("4");
                combosem.Items.Remove("5");
                combosem.Items.Remove("6");
                combosem.Items.Remove("7");
                combosem.Items.Remove("8");
            }
            daycon.Controls.Clear();
            comgroup.ResetText();
            comgroup.Enabled = false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Report.print_test f = new Report.print_test();
            f.Show();

        }

        private void combosem_SelectedIndexChanged(object sender, EventArgs e)
        {
            daycon.Controls.Clear();
            if (combosem.SelectedIndex != -1)
            {
                gro();
                //sems = combosem.SelectedItem.ToString();
                sems_id = int.Parse(combosem.SelectedItem.ToString());
                sems = combosem.SelectedItem.ToString();

            }
            else
            {

                comgroup.ResetText();
                comgroup.Enabled = false;
            }
        }

        private void comgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            daycon.Controls.Clear();
            grou = comgroup.SelectedItem.ToString();
            foreach (Group.groups_data gr_data in listgroup)
            {
                if (gr_data.name_group == comgroup.SelectedItem.ToString())
                {
                    //id_gro = gr_data.id_group;
                    grou_id = gr_data.id_group;
                    break;
                }
            }

            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daycon.Controls.Clear();
            month++;
            if (month == 13)
            {
                month = 1;
                year++;
            }
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            daycon.Controls.Clear();
            month--;
            if (month == 0)
            {
                month = 12;
                year--;

            }
            display();
        }

        void addTest_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;


            combosem.Enabled = false;
            comgroup.Enabled = false;
            combo();
        }

        void display()
        {


            label8.Text = month + "   " + year;
            s_month = month;
            s_year = year;


            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            // MessageBox.Show(dayoftheweek.ToString());


            for (int i = 1; i < dayoftheweek; i++)
            {
                Test.ControlBlunk unb = new Test.ControlBlunk();
                daycon.Controls.Add(unb);
            }
            for (int i = 1; i <= days; i++)
            {

                DateTime date = new DateTime(year, month, i);
                string dayName = date.ToString("dddd");

                if (dayName == "Friday" || dayName == "الجمعة")
                {
                    Test.ControlBlunk unb = new Test.ControlBlunk(i, month, year);
                    daycon.Controls.Add(unb);

                }
                else
                {
                    Test.UserControldays d = new Test.UserControldays();
                    d.days(i, month, year);
                    // d.disp();
                    daycon.Controls.Add(d);
                }

            }
        }

    }
}
