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

namespace Organizing_dates_examinationsV2.Teacher
{
    public partial class addTeacher : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        List<Department.deprtment_data> listdepartment;
        List<Classes.class_data> class_da;
        List<Classes.classes_semster_department> cla_sem;
        Classes.Class2 clas = new Classes.Class2();

        int id_d;
        void dataclear()
        {
            id.Clear();
            user_name.Clear();
            name.Clear();
            password.Clear();
            combodgree.SelectedIndex = -1;
            listBoxclass.Items.Clear();
            checkclass.Checked = false;
            combodep.SelectedIndex = -1;
            comboclass.SelectedIndex = -1;
            combosem.Enabled = false;
            comboclass.Enabled = false;
        }
        void add()
        {
            try
            {
                if (name.Text.Length != 0 && user_name.Text.Length != 0 && id.Text.Length != 0 && password.Text.Length != 0 && combodgree.SelectedIndex != -1)
                {
                    teacher_Class te = new teacher_Class();
                    string command = "INSERT INTO `teacher`( `id_teacher`,`name`, `user_name`, `password`, `teacher_degree`, `state`) VALUES ('" + int.Parse(id.Text) + "','" + name.Text + "','" + user_name.Text + "','" + password.Text + "','" + combodgree.SelectedItem.ToString() + "',0)";
                    string add_te = te.data_Teacher(command);
                    //Check if there is an error in the class or not
                    if (add_te == "0")
                    {
                        MessageBox.Show(string.Format("تمت اضافة {0} جديد في النظام", combodgree.SelectedItem.ToString()));
                    }

                    else
                        MessageBox.Show(add_te);

                }
                else MessageBox.Show("من فضلك املئ البيانات");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        void dep()
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
        void fill()
        {
            comboclass.Items.Clear();

            id_d = -2;
            foreach (Department.deprtment_data deprtment_data in listdepartment)
            {
                if (deprtment_data.name_department == combodep.SelectedItem.ToString())
                {
                    id_d = deprtment_data.id_deprtment;
                    break;
                }
            }
            
            string command = "select * from classes_semster_department where department_id="+id_d+" and semster_id=" + combosem.SelectedItem + "";
            cla_sem = clas.get_C_S_D(command);

            foreach (Classes.classes_semster_department clas in cla_sem)
                foreach (Classes.class_data cla in class_da)
                    if (clas.class_id == cla.id_class)
                        comboclass.Items.Add(cla.name_class);
        }
        void add_t_c(int id, string class_id)
        {
            try
            {
                teacher_Class cla = new teacher_Class();
                string com = "INSERT INTO `techer_classes`(`teacher_id`, `class_id`) VALUES ("+id+",'"+class_id+"')";
                //  MessageBox.Show(com);
                string chak = cla.data_Teacher(com);
                //Check if there is an error in the class or not
                if (chak == "0")
                {
                    MessageBox.Show("تمت اضافة بيانات عضو هيئة تدريس جديدة في النظام");
                }
                else
                    MessageBox.Show(chak);
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public addTeacher()
        {
            InitializeComponent();
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            add();
            if (checkclass.Checked)
            {
                for (int i = 0; i < listBoxclass.Items.Count; i++)
                {
                    foreach (Classes.class_data cl in class_da)
                        if (listBoxclass.Items[i].ToString() == cl.name_class)
                            add_t_c(int.Parse(id.Text), cl.id_class);
                }
            }
            dataclear();
        }

        private void addTeacher_Load(object sender, EventArgs e)
        {
            string command = "select * from classes";
            class_da = clas.getclass(command);
            dep();
        }

        private void checkclass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkclass.Checked == true)
            {
                clear.Visible = true;
                listBoxclass.Visible = true;
                comboclass.Visible = true;
                combodep.Visible = true;
                combosem.Visible = true;
                labelclass.Visible = true;
                labeldep.Visible = true;
                labelsem.Visible = true;
            }
            else
            {
                clear.Visible = false;
                listBoxclass.Visible = false;
                comboclass.Visible = false;
                combodep.Visible = false;
                combosem.Visible = false;
                labelclass.Visible = false;
                labeldep.Visible = false;
                labelsem.Visible = false;
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
                comboclass.ResetText();
                combosem.Enabled = true;
                comboclass.Enabled = false;
                comboclass.Enabled = false;
            }
        }

        private void combosem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosem.SelectedIndex != -1)
            {
                fill();
                comboclass.Enabled = true;
                clear.Enabled = true;
            }
        }

        private void comboclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            for (; i < listBoxclass.Items.Count; i++)
            {
                if (listBoxclass.Items[i].ToString() == comboclass.SelectedItem.ToString())
                    break;
            }
            if (comboclass.SelectedIndex != -1)
                if (i == listBoxclass.Items.Count)
                    listBoxclass.Items.Add(comboclass.SelectedItem.ToString());
        }

        private void clear_Click(object sender, EventArgs e)
        {
            listBoxclass.Items.Clear();
        }
    }
}
