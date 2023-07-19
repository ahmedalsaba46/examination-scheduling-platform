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
    public partial class editTeacher : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        List<Department.deprtment_data> listdepartment;
        List<Classes.class_data> class_da;
        List<Classes.classes_semster_department> cla_sem;
        Classes.Class2 clas = new Classes.Class2();

        int id_d;
        void enabledOf()
        {
            name1.Enabled = false;
            user_name1.Enabled = false;
            password1.Enabled = false;
            comboclass1.Enabled = false;
            combodep1.Enabled = false;
            combodgree1.Enabled = false;
            combosem1.Enabled = false;       
            listBoxclass1.Enabled = false;
            checkclass1.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
        }
        void search()
        {
            listBoxclass1.Items.Clear();
            teacher_Class te = new teacher_Class();
            string command = "select * from teacher where id_teacher='" + idsearch.Text + "'";
            string ser_te = te.data_Teacher(command);
            List<teacher_data> teacher_da = te.getTeacher(command);
            if (ser_te == "0")
            {
                if (teacher_da.Any())
                {
                    foreach (teacher_data tea in teacher_da)
                    {
                        if (tea.state == 0)
                        {
                            name1.Text = tea.name.ToString();
                            user_name1.Text = tea.user_name.ToString();
                            password1.Text = tea.password.ToString();
                            combodgree1.SelectedItem = tea.teacher_degree.ToString();

                            string command1 = "SELECT * FROM `techer_classes` where teacher_id=" + idsearch.Text + "";
                            string ser_te1 = te.data_Teacher(command);
                            List<teacher_class_data> listteclview = te.getTeacher_class(command1);
                            if (ser_te1 == "0")
                            {
                                if (listteclview.Any())
                                {
                                    checkclass1.Checked = true;
                                    foreach (teacher_class_data clas in listteclview)
                                        foreach (Classes.class_data cla in class_da)
                                            if (clas.id_class == cla.id_class)
                                                listBoxclass1.Items.Add(cla.name_class);
                                }
                            }
                            else
                                MessageBox.Show(ser_te1);
                            name1.Enabled = true;
                            user_name1.Enabled = true;
                            password1.Enabled = true;
                            combodep1.Enabled = true;
                            combodgree1.Enabled = true;
                            listBoxclass1.Enabled = true;
                            checkclass1.Enabled = true;
                            button3.Enabled = true;
                            button5.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("عضو هيئة التدريس في الارشيف");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("رقم الوظيفي [0] ليس موجود", idsearch.Text);
                }
            }
            else
                MessageBox.Show(ser_te);
        }
        void dataclear()
        {
            idsearch.Clear();
            user_name1.Clear();
            name1.Clear();
            password1.Clear();
            combodgree1.SelectedIndex = -1;
            listBoxclass1.Items.Clear();
            checkclass1.Checked = false;
            combodep1.SelectedIndex = -1;
            comboclass1.SelectedIndex = -1;
            combosem1.Enabled = false;
            comboclass1.Enabled = false;
        }
        void update()
        {
            try
            {
                teacher_Class teacher = new teacher_Class();
                string command = "update teacher set name='" + name1.Text + "',user_name='" + user_name1.Text + "',password='" + password1.Text + "',teacher_degree='" + combodgree1.SelectedItem.ToString() + "' where id_teacher='" + idsearch.Text + "'";

                string room_d = teacher.data_Teacher(command);
                //Check if there is an error in the class or not
                if (room_d == "0")
                {
                    MessageBox.Show("تمت تعديل  في النظام");
                }
                else
                    MessageBox.Show(room_d);

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
                combodep1.Items.Clear();

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
                                combodep1.Items.Add(deprtment_data.name_department);
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
                combosem1.Items.Clear();
                con.Open();
                MySqlCommand com = new MySqlCommand("select * from semster", con);
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    combosem1.Items.Add(dr["num_semster"].ToString());
                    combosem1.ResetText();
                    combosem1.Enabled = true;
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
            comboclass1.Items.Clear();

            id_d = -2;
            foreach (Department.deprtment_data deprtment_data in listdepartment)
            {
                if (deprtment_data.name_department == combodep1.SelectedItem.ToString())
                {
                    id_d = deprtment_data.id_deprtment;
                    break;
                }
            }

            string command = "select * from classes_semster_department where department_id=" + id_d + " and semster_id=" + combosem1.SelectedItem + "";
            cla_sem = clas.get_C_S_D(command);

            foreach (Classes.classes_semster_department clas in cla_sem)
                foreach (Classes.class_data cla in class_da)
                    if (clas.class_id == cla.id_class)
                        comboclass1.Items.Add(cla.name_class);
        }
        void add_t_c(int id, string class_id)
        {
            try
            {
                teacher_Class cla = new teacher_Class();
                string com = "INSERT INTO `techer_classes`(`teacher_id`, `class_id`) VALUES (" + id + ",'" + class_id + "')";
                //  MessageBox.Show(com);
                string chak = cla.data_Teacher(com);
                //Check if there is an error in the class or not
                if (chak == "0")
                {
                    MessageBox.Show("تمت تعديل بيانات عضو هيئة تدريس جديدة في النظام");
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

        public editTeacher()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (idsearch.Text.Length != 0)
                {
                    search();
                }
                else
                    MessageBox.Show("من فضلك ادخل الرقم الوظيفي");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void editTeacher_Load(object sender, EventArgs e)
        {
            string command = "select * from classes";
            class_da = clas.getclass(command);
            enabledOf();
            dep();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تعديل بيانات عضو هيئة التدريس", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    if (name1.Text.Length != 0 && user_name1.Text.Length != 0 && password1.Text.Length != 0 && combodgree1.SelectedIndex != -1 )
                    {
                        update();
                        if (checkclass1.Checked)
                        {
                            teacher_Class cla = new teacher_Class();
                            string com = "DELETE FROM `techer_classes` WHERE teacher_id=" + idsearch.Text + "";
                            // MessageBox.Show(com);
                            string chak = cla.data_Teacher(com);
                            for (int i = 0; i < listBoxclass1.Items.Count; i++)
                            {
                                foreach (Classes.class_data cl in class_da)
                                    if (listBoxclass1.Items[i].ToString() == cl.name_class)
                                        add_t_c(int.Parse(idsearch.Text), cl.id_class);
                            }
                        }
                        dataclear();
                    }
                    else MessageBox.Show("من فضلك املئ البيانات");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkclass1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkclass1.Checked)
            {
                button5.Visible = true;
                listBoxclass1.Visible = true;
                comboclass1.Visible = true;
                combodep1.Visible = true;
                combosem1.Visible = true;
                labelclass1.Visible = true;
                labeldep1.Visible = true;
                labelsem1.Visible = true;
            }
            else
            {
                button5.Visible = false;
                listBoxclass1.Visible = false;
                comboclass1.Visible = false;
                combodep1.Visible = false;
                combosem1.Visible = false;
                labelclass1.Visible = false;
                labeldep1.Visible = false;
                labelsem1.Visible = false;
            }
        }

        private void combodep1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sem();
            if (combodep1.SelectedIndex != -1)
            {
                if (combodep1.SelectedItem.ToString() != "العام")
                {
                    combosem1.Items.Remove("1");
                    combosem1.Items.Remove("2");
                }
                else
                {
                    combosem1.Items.Remove("3");
                    combosem1.Items.Remove("4");
                    combosem1.Items.Remove("5");
                    combosem1.Items.Remove("6");
                    combosem1.Items.Remove("7");
                    combosem1.Items.Remove("8");
                }
                comboclass1.ResetText();
                combosem1.Enabled = true;
                comboclass1.Enabled = false;
                comboclass1.Enabled = false;
            }
        }

        private void combosem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosem1.SelectedIndex != -1)
            {
                fill();
                comboclass1.Enabled = true;
            }
        }

        private void comboclass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboclass1.SelectedIndex != -1)
            {
                int i = 0;
                for (; i < listBoxclass1.Items.Count; i++)
                {
                    if (listBoxclass1.Items[i].ToString() == comboclass1.SelectedItem.ToString())
                        break;
                }
                if (i == listBoxclass1.Items.Count)
                    listBoxclass1.Items.Add(comboclass1.SelectedItem.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBoxclass1.Items.Clear();
        }
    }
}
