using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace Organizing_dates_examinationsV2.Classes
{
    public partial class addClass : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        List<Department.deprtment_data> deprtment_da;
        List<class_data> class_da;
        string id_cl;

        void dataclear()
        {
            combodep.SelectedIndex = -1;
            id.Clear();
            name.Clear();
            comboid.SelectedIndex = -1;
            comborequ.ResetText();
            combosem.ResetText();
            combosem1.ResetText();
            combosem3.ResetText();
            combounit.SelectedIndex = -1;
            combotype.SelectedIndex = -1;
            checkdep.Checked = false;
        }
        void dep()
        {
            try
            {
                combodep3.Items.Clear();
                combodep1.Items.Clear();
                combodep.Items.Clear();
                Department.departments_class dep = new Department.departments_class();
                string command = "SELECT* FROM department";
                deprtment_da = dep.getdepartment(command);

                if (dep.error == "0")
                {
                    if (deprtment_da.Any())
                    {
                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.state == 0)
                            {
                              //  combodep3.Items.Add(deprtment_data.name_department);
                              // combodep1.Items.Add(deprtment_data.name_department);
                                combodep.Items.Add(deprtment_data.name_department);
                            }
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
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
                combosem1.Items.Clear();
                combosem3.Items.Clear();

                con.Open();
                MySqlCommand com = new MySqlCommand("select * from semster", con);

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    combosem.Items.Add(dr["num_semster"].ToString());
                    combosem1.Items.Add(dr["num_semster"].ToString());
                    combosem3.Items.Add(dr["num_semster"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        void req()
        {
            try
            {
                comborequ.Items.Clear();

                comborequ.Items.Add("none");
                string command = "SELECT * FROM classes where state=0";
                Class2 clas = new Class2();
                class_da = clas.getclass(command);

                if (clas.error == "0")
                {
                    if (class_da.Any())
                    {
                        foreach (class_data class_Data in class_da)
                        {
                            if (class_Data.state == 0)
                            {
                                comborequ.Items.Add(class_Data.name_class);
                            }
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(clas.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void add()
        {
            id_cl = comboid.SelectedItem.ToString() + " " + id.Text;

            Class2 cla = new Class2();
            string idreq = "none";
            if (comborequ.SelectedItem.ToString() != idreq)
            {
                foreach (class_data class_Dat in class_da)
                    if (class_Dat.name_class == comborequ.SelectedItem.ToString())
                    {
                        idreq = class_Dat.id_class;
                    }
            }
            string com = "INSERT INTO `classes`(`id_class`, `name_class`, `req_id`, `num_unit`, `type_class`, `state`) VALUES ('" + id_cl + "','" + name.Text + "','" + idreq + "','" + combounit.SelectedItem.ToString() + "','" + combotype.SelectedItem.ToString() + "','0')";
            string chak = cla.data(com);
            //Check if there is an error in the class or not
            if (chak == "0")
            {
                MessageBox.Show("تمت اضافة مادة جديدة في النظام");
                if (checkdep.Checked == true && checkdep1.Checked == true)
                {
                    add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), id_cl);
                    add_C_D_S(combodep1.SelectedItem.ToString(), combosem1.SelectedItem.ToString(), id_cl);
                    add_C_D_S(combodep3.SelectedItem.ToString(), combosem3.SelectedItem.ToString(), id_cl);
                }
                else if (checkdep.Checked == true)
                {
                    add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), id_cl);
                    add_C_D_S(combodep1.SelectedItem.ToString(), combosem1.SelectedItem.ToString(), id_cl);
                }
                else
                {
                    add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), id_cl);
                }
                req();
                dataclear();
            }
            else
                MessageBox.Show(chak);
        }
        void add_C_D_S(string department_name ,string semster_id ,string class_id)
        {
            try { 
            int id_d=0;
            if (deprtment_da.Any())
            {
                foreach (Department.deprtment_data deprtment_data in deprtment_da)
                {
                    if (deprtment_data.name_department == department_name)
                    {
                        id_d = deprtment_data.id_deprtment;
                        break;
                    }
                }
            }

                if (department_name.Length != 0 && semster_id.Length != 0 && id_d != 0)
                {
                    Class2 cla = new Class2();
                    string com = "INSERT INTO `classes_semster_department`(`department_id`, `semster_id`, `class_id`) VALUES ('" + id_d + "','" + semster_id + "','" + class_id + "')";
                    //  MessageBox.Show(com);
                    string chak = cla.data(com);
                    //Check if there is an error in the class or not
                    if (chak != "0")
                        MessageBox.Show(chak);
                }
             }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public addClass()
        {
            InitializeComponent();

            String[] s = { "EN", "MA", "IT", "NT", "CT" };
            String[] x = { "1", "2", "3", "4", "5", "6" };
            String[] z = { "نظرية", "معملية" };

            comboid.Items.AddRange(s);
            combounit.Items.AddRange(x);
            combotype.Items.AddRange(z);
        }

        private void addClass_Load(object sender, EventArgs e)
        {
            dep();
            sem();
            req();
        }

        private void checkdep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkdep.Checked)
            {
                if (combodep.SelectedIndex != -1)
                {
                    string s = combodep.SelectedItem.ToString();
                    combodep.SelectedItem = s;
                    combodep1.Items.Remove(s);
                    combodep3.Items.Remove(s);
                    combodep3.Items.Remove("العام");
                    combodep1.Items.Remove("العام");
                    combodep1.Visible = true;
                    combosem1.Visible = true;
                    checkdep1.Visible = true;                    
                }
                else
                {
                    MessageBox.Show("الرجاء اختيار القسم");
                    checkdep1.Checked = false;
                }
            }
            else
            {
                checkdep1.Checked = false;
                combodep1.Visible = false;
                checkdep1.Visible = false;
                combodep3.Visible = false;
                combosem3.Visible = false;
                combosem1.Visible = false;
            }
        }

        private void checkdep1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkdep1.Checked)
            {
                   string s = combodep.SelectedItem.ToString()
                   , s1 = combodep1.SelectedItem.ToString();
                    combodep.SelectedItem = s;
                    combodep1.SelectedItem = s1;
                    combodep3.Items.Remove(s1);
                    combodep3.Items.Remove(s);
                    combodep3.Items.Remove("العام");
                    combodep1.Items.Remove("العام");
                    combodep3.Visible = true;
                    combosem3.Visible = true;
                    
            }
            else
            {
                combodep3.Visible = false;
            }
        }

        private void sign_in_Click(object sender, EventArgs e)
        {            
            try
            {
                if (name.Text.Length != 0 && id.Text.Length != 0 && comborequ.SelectedIndex != -1 && comboid.SelectedIndex != -1 && combodep.SelectedIndex != -1 && combosem.SelectedIndex != -1 && combounit.SelectedIndex != -1 && combotype.SelectedIndex != -1)
                {
                    add();                    
                }
                else
                    MessageBox.Show("يرجى ملئ البيانات");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (id.Text != "")
                {
                    string s = id.Text;
                    if (s[0] == '1' || s[0] == '2' || s[0] == '3' || s[0] == '4')
                    {
                        alert.Visible = false;
                    }
                    else
                    {
                        alert.Visible = true;
                        id.Text = "";
                    }
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
            if (combodep.SelectedIndex != -1)
            {
                if (combodep.SelectedItem.ToString() != "العام")
                {
                    combosem.Items.Remove("1");
                    combosem.Items.Remove("2");
                    combosem1.Items.Remove("1");
                    combosem1.Items.Remove("2");
                    combosem3.Items.Remove("1");
                    combosem3.Items.Remove("2");
                    combosem.SelectedIndex = 0;
                    if (deprtment_da.Any())
                    {
                        combodep1.Items.Clear();
                        combodep1.ResetText();
                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.state == 0 && deprtment_data.name_department != "العام" && deprtment_data.name_department != combodep.SelectedItem.ToString())
                            {
                                combodep1.Items.Add(deprtment_data.name_department);

                            }
                        }
                    }
                    checkdep.Enabled = true;
                    checkdep1.Enabled = false;
                    checkdep.Checked = false;
                    combodep1.Visible = false;
                    combosem1.Visible = false;
                    checkdep1.Visible = false;
                    combodep3.Visible = false;
                    combosem3.Visible = false;
                }
                else
                {
                    combosem.Items.Remove("3");
                    combosem.Items.Remove("4");
                    combosem.Items.Remove("5");
                    combosem.Items.Remove("6");
                    combosem.Items.Remove("7");
                    combosem.Items.Remove("8");
                    combosem.SelectedIndex = 0;
                    checkdep.Enabled = false;
                    combodep1.Visible = false;
                    combosem1.Visible = false;
                    checkdep1.Visible = false;
                    checkdep.Checked = false;
                    combodep3.Visible = false;
                    combosem3.Visible = false;
                }
            }
        }

        private void combodep1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkdep1.Checked = false;
            checkdep1.Enabled = true;
            if (deprtment_da.Any())
            {
                combodep3.Items.Clear();
                combodep3.ResetText();
                foreach (Department.deprtment_data deprtment_data in deprtment_da)
                {
                    if (deprtment_data.state == 0 && deprtment_data.name_department != "العام" && deprtment_data.name_department != combodep.SelectedItem.ToString())
                    {
                        combodep3.Items.Add(deprtment_data.name_department);
                    }
                }
            }
        }
    }
}
