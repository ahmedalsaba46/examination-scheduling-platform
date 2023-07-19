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

namespace Organizing_dates_examinationsV2.Classes
{
    public partial class editClass : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        List<Department.deprtment_data> deprtment_da;
        List<class_data> class_da;
        List<classes_semster_department> all;
        Class2 clas = new Class2();
        string id_cl = "";
        void combo()
        {
            try
            {
                comboid3.Items.Clear();
                comboreq.Items.Clear();
                
                comboreq.Items.Add("none");
                string command = "SELECT * FROM classes";
                class_da = clas.getclass(command);

                if (clas.error == "0")
                {
                    if (class_da.Any())
                    {
                        foreach (class_data class_Data in class_da)
                        {
                            if (class_Data.state == 0)
                            {
                                comboid3.Items.Add(class_Data.name_class);
                                comboreq.Items.Add(class_Data.name_class);
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

        void viewclass()
        {
            try
            {
                if (clas.error == "0")
                {
                    string sem="", sem1="",sem0="";                    
                    if (class_da.Any())
                    {
                        foreach (class_data class_Data in class_da)
                        {
                            if (class_Data.name_class == comboid3.SelectedItem.ToString())
                            {
                                id_cl = class_Data.id_class;
                                string[] s = class_Data.id_class.Split(' ');
                                id.Text = s[1];
                                comboid.SelectedItem = s[0];
                                name.Text = class_Data.name_class;
                                combounit.SelectedItem = class_Data.num_unit.ToString();
                                combotype.SelectedItem = class_Data.type_class;
                                foreach (class_data class_Dat in class_da)
                                    if (class_Dat.id_class == class_Data.req_id)
                                    {
                                        comboreq.SelectedItem = class_Dat.name_class;
                                        break;
                                    }                           
                                break;
                            }
                        }
                        string command = "select * from classes_semster_department where class_id='" + id_cl + "'";
                        all = clas.get_C_S_D(command);
                        if (clas.error == "0")
                        {

                            if (class_da.Any())
                            {
                                int x = 0;
                                foreach (classes_semster_department cl in all)
                                {

                                    if (x == 0)
                                    {
                                        checkdep2.Checked = false;
                                        sem0 = cl.semster_id.ToString();
                                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                                        {
                                            if (deprtment_data.id_deprtment == cl.department_id)
                                            {
                                                combodep.SelectedItem = deprtment_data.name_department;
                                                break;
                                            }
                                        }
                                    }
                                    else if (x == 1)
                                    {
                                        checkdep2.Checked = true;
                                        checkdep3.Checked = false;

                                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                                        {
                                            if (deprtment_data.id_deprtment == cl.department_id)
                                            {
                                                combodep1.SelectedItem = deprtment_data.name_department;
                                                sem = cl.semster_id.ToString();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        checkdep3.Checked = true;

                                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                                        {
                                            if (deprtment_data.id_deprtment == cl.department_id)
                                            {
                                                combodep2.SelectedItem = deprtment_data.name_department;
                                                sem1 = cl.semster_id.ToString();
                                                break;
                                            }
                                        }
                                    }
                                    x++;
                                }
                                combodep.Enabled = true;
                                id.Enabled = true;
                                name.Enabled = true;
                                comboid.Enabled = true;
                                comboreq.Enabled = true;
                                combounit.Enabled = true;
                                combotype.Enabled = true;
                                checkdep2.Enabled = true;
                            }
                            else
                                MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                        }
                        else
                            MessageBox.Show(clas.error);

                        combosem.SelectedItem = sem0;
                        combosem1.SelectedItem = sem;
                        combosem2.SelectedItem = sem1;
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
        void enableof()
        {
            combodep.Enabled = false;
            id.Enabled = false;
            name.Enabled = false;
            comboid.Enabled = false;
            comboreq.Enabled = false;
            combounit.Enabled = false;
            combotype.Enabled = false;
            checkdep2.Enabled = false;
        }
        void sem()
        {
            try
            {
                combosem.Items.Clear();
                combosem1.Items.Clear();
                combosem2.Items.Clear();

                con.Open();
                MySqlCommand com = new MySqlCommand("select * from semster", con);

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    combosem.Items.Add(dr["num_semster"].ToString());
                    combosem1.Items.Add(dr["num_semster"].ToString());
                    combosem2.Items.Add(dr["num_semster"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        void dep()
        {
            try
            {
                combodep2.Items.Clear();
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
        
        void dataclear()
        {
            combodep.SelectedIndex = -1;
            id.Clear();
            name.Clear();
            comboid.SelectedIndex = -1;
            comboreq.SelectedIndex = -1;
            combounit.SelectedIndex = -1;
            combotype.SelectedIndex = -1;
            checkdep2.Checked = false; 
        }

        void update()
        {
            try
            {
                Class2 cl = new Class2();
                string idreq = "none";
                if (comboreq.SelectedItem.ToString() != idreq)
                {
                    foreach (class_data class_Dat in class_da)
                        if (class_Dat.name_class == comboreq.SelectedItem.ToString())
                        {
                            idreq = class_Dat.id_class;
                        }
                }
                string command = "UPDATE `classes` SET `id_class`='" + comboid.SelectedItem.ToString() + " " + id.Text + "',`name_class`='" + name.Text + "',`req_id`='" + idreq + "',`num_unit`='" + combounit.SelectedItem.ToString() + "',`type_class`='" + combotype.SelectedItem.ToString() + "' WHERE `id_class`='" + id_cl + "'";
                string chak = cl.data(command);

                if (chak == "0")
                {
                    MessageBox.Show("تم تعديل بيانات في النظام");
                }
                else
                    MessageBox.Show(chak);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public editClass()
        {
            InitializeComponent();

            String[] s = { "EN", "MA", "IT", "NT", "CT" };
            String[] x = { "1", "2", "3", "4", "5", "6" };
            String[] z = { "نظرية", "معملية" };

            comboid.Items.AddRange(s);
            combounit.Items.AddRange(x);
            combotype.Items.AddRange(z);
        }

        void add_C_D_S(string department_name, string semster_id, string class_id)
        {
            try
            {
                int id_d = 0;
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
                    
                    string comm = "INSERT INTO `classes_semster_department`(`department_id`, `semster_id`, `class_id`) VALUES ('" + id_d + "','" + semster_id + "','" + class_id + "')";
                    string chakk = cla.data(comm);

                    if (chakk == "0")
                    {
                        MessageBox.Show("تم تعديل بيانات مادة في النظام");
                    }
                    else
                        MessageBox.Show(chakk);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void editClass_Load(object sender, EventArgs e)
        {
            combo();
            dep();
            sem();
            enableof();
        }

        private void comboid3_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewclass();
        }

        private void combodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combodep.SelectedIndex != -1)
            {
                sem();
                if (combodep.SelectedItem.ToString() != "العام")
                {
                    combosem.Items.Remove("1");
                    combosem.Items.Remove("2");
                    combosem1.Items.Remove("1");
                    combosem1.Items.Remove("2");
                    combosem2.Items.Remove("1");
                    combosem2.Items.Remove("2");
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
                    checkdep2.Enabled = true;
                    checkdep2.Checked = false;
                    combodep1.SelectedIndex = 0;
                    combodep1.Visible = false;
                    combosem1.Visible = false;
                    checkdep3.Visible = false;
                    combodep2.Visible = false;
                    combosem2.Visible = false;
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
                    checkdep2.Enabled = false;
                    combodep1.Visible = false;
                    combosem1.Visible = false;
                    checkdep3.Visible = false;
                    checkdep2.Checked = false;
                    combodep2.Visible = false;
                    combosem2.Visible = false;
                }
            }
        }

        private void combodep1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkdep3.Checked = false;

            if (deprtment_da.Any())
            {
                combodep2.Items.Clear();
                combodep2.ResetText();
                foreach (Department.deprtment_data deprtment_data in deprtment_da)
                {
                    if (deprtment_data.state == 0 && deprtment_data.name_department != "العام" && deprtment_data.name_department != combodep.SelectedItem.ToString())
                    {
                        combodep2.Items.Add(deprtment_data.name_department);
                    }
                }
            }
        }

        private void checkdep2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkdep2.Checked)
            {
                if (combodep.SelectedIndex != -1)
                {
                    combodep1.SelectedIndex = 1;
                    string s = combodep.SelectedItem.ToString();
                    combodep.SelectedItem = s;
                    combodep1.Items.Remove(s);
                    combodep2.Items.Remove(s);
                    combodep2.Items.Remove("العام");
                    combodep1.Items.Remove("العام");
                    combodep1.Visible = true;
                    combosem1.Visible = true;
                    checkdep3.Visible = true;

                }
                else
                {
                    MessageBox.Show("الرجاء اختيار القسم");
                    checkdep2.Checked = false;
                }
            }
            else
            {
                checkdep3.Checked = false;
                combodep1.Visible = false;
                checkdep3.Visible = false;
                combodep2.Visible = false;
                combosem2.Visible = false;
                combosem1.Visible = false;
            }
        }

        private void checkdep3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkdep3.Checked)
            {

                string s = combodep.SelectedItem.ToString()
               , s1 = combodep1.SelectedItem.ToString();
                combodep.SelectedItem = s;
                combodep1.SelectedItem = s1;
                combodep2.Items.Remove(s1);
                combodep2.Items.Remove(s);
                combodep2.Items.Remove("العام");
                combodep1.Items.Remove("العام");
                combodep2.Visible = true;
                combosem2.Visible = true;
            }
            else
            {
                combodep2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت تريد تعديل بيانات المادة من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                {
                    if (name.Text.Length != 0 && id.Text.Length != 0 && comboreq.SelectedIndex != -1 && comboid.SelectedIndex != -1 && combodep.SelectedIndex != -1 && combosem.SelectedIndex != -1 && combounit.SelectedIndex != -1 && combotype.SelectedIndex != -1)
                    {
                        update();
                        if (checkdep2.Checked == true && checkdep3.Checked == true)
                        {
                            Class2 cla = new Class2();
                            string com = "delete FROM `classes_semster_department` WHERE `class_id`= '" + id_cl + "'";
                            string chak = cla.data(com);
                            if (chak == "0")
                            {
                                add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                                add_C_D_S(combodep1.SelectedItem.ToString(), combosem1.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                                add_C_D_S(combodep2.SelectedItem.ToString(), combosem2.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                            }
                            else
                                MessageBox.Show(chak);

                        }
                        else if (checkdep2.Checked == true)
                        {
                            Class2 cla = new Class2();
                            string com = "delete FROM `classes_semster_department` WHERE `class_id`= '" + id_cl + "'";
                            string chak = cla.data(com);
                            if (chak == "0")
                            {
                                add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                                add_C_D_S(combodep1.SelectedItem.ToString(), combosem1.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                            }
                            else MessageBox.Show(chak);
                        }
                        else
                        {
                            Class2 cla = new Class2();
                            string com = "delete FROM `classes_semster_department` WHERE `class_id`= '" + id_cl + "'";
                            string chak = cla.data(com);
                            if (chak == "0")
                            {
                                add_C_D_S(combodep.SelectedItem.ToString(), combosem.SelectedItem.ToString(), comboid.SelectedItem.ToString() + " " + id.Text);
                            }
                            else MessageBox.Show("");
                        }
                        dataclear();
                        combo();
                        enableof();
                    }
                    else
                        MessageBox.Show("يرجى ملئ البيانات");
                }
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
                        alert1.Visible = false;
                    }
                    else
                    {
                        alert1.Visible = true;
                        id.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
