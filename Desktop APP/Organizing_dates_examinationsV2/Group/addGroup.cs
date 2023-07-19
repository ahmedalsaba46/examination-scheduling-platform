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

namespace Organizing_dates_examinationsV2.Group
{
    public partial class addGroup : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        List<Department.deprtment_data> deprtment_da;
        int id_d;
        void dataclear()
        {
            combodep.SelectedIndex = -1;
            combosem.SelectedIndex = -1;
            numgrp.Clear();
            treeView1.Nodes.Clear();
        }
        void combo()
        {
            try
            {
                //comboBox2.Items.Clear();
                Department.departments_class dep = new Department.departments_class();
                string command = "SELECT* FROM department";
                deprtment_da = dep.getdepartment(command);

                //Check if there is an error in the class  or not 
                if (dep.error == "0")
                {
                    if (deprtment_da.Any())
                    {
                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.state == 0)
                            {
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
                con.Open();
                MySqlCommand com = new MySqlCommand("select * from semster", con);

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    combosem.Items.Add(dr["num_semster"].ToString());
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
            try
            {
                treeView1.Nodes.Clear();
                Classes.Class2 clas = new Classes.Class2();
                string command0 = "SELECT * FROM classes";
                List<Classes.class_data> class_da = clas.getclass(command0);

                id_d = -2;
                foreach (Department.deprtment_data deprtment_data in deprtment_da)
                {
                    if (combodep.SelectedIndex != -1)
                    {
                        if (deprtment_data.name_department == combodep.SelectedItem.ToString())
                        {
                            id_d = deprtment_data.id_deprtment;
                            break;
                        }
                    }
                }

                if (id_d != -2)
                {
                    Classes.Class2 cls = new Classes.Class2();
                    string command = "SELECT* FROM classes_semster_department where department_id='" + id_d + "' and semster_id='" + combosem.SelectedItem.ToString() + "'";
                    List<Classes.classes_semster_department> cls_da = cls.get_C_S_D(command);
                    List<Classes.class_data> cls_da1;

                    if (cls.error == "0")
                    {
                        if (cls_da.Any())
                        {
                            int x = 0;
                            foreach (Classes.classes_semster_department cl in cls_da)
                            {
                                command = "SELECT* FROM classes where id_class='" + cl.class_id + "'";
                                cls_da1 = cls.getclass(command);
                                foreach (Classes.class_data c_dat1 in cls_da1)
                                {
                                    treeView1.Nodes.Add(c_dat1.name_class);
                                    Teacher.teacher_Class t = new Teacher.teacher_Class();
                                    string command1 = "SELECT * FROM `techer_classes` where class_id='" + c_dat1.id_class + "'";
                                    List<Teacher.teacher_class_data> listclteview = t.getTeacher_class(command1);


                                    foreach (Teacher.teacher_class_data te in listclteview) {
                                        string command2 = "SELECT * FROM `teacher` where id_teacher=" + te.id_teacher + "";
                                        List<Teacher.teacher_data> listteacher = t.getTeacher(command2);
                                        treeView1.Nodes[x].Nodes.Add(listteacher[0].name);

                                    }
                                    x++;
                                }

                            }
                        }
                        else
                            MessageBox.Show("لايوجود بيانات  ");
                    }
                    else
                        MessageBox.Show(cls.error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void add()
        {
            try {
                

                    int id_d = 0;
                    if (deprtment_da.Any())
                    {
                        foreach (Department.deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.name_department == combodep.SelectedItem.ToString())
                            {
                                id_d = deprtment_data.id_deprtment;
                                break;
                            }
                        }
                    }

                    groups cla = new groups();
                    // string com = "INSERT INTO `groups`(` `name_group`, `department_id`, `semster_id`, `state`) VALUES ('" + int.Parse(numgrp.Text) + "','" + id_d + "','" + int.Parse(combosem.SelectedItem.ToString())  + "','0')";
                    string com = "INSERT INTO `groups`( `name_group`, `department_id`, `semster_id`, `state`) VALUES ('" + numgrp.Text + "','" + id_d + "','" + int.Parse(combosem.SelectedItem.ToString()) + "','0')";
                    string chak = cla.data(com);

                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        MessageBox.Show("تمت اضافة مجموعة جديدة في النظام");
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
        void add_g_t_c(string class_id, int id_teacher, int id_group)
        {
            try
            {
                other_classes cla = new other_classes();
                string com = "INSERT INTO `teacher_classes_groups`(`group_id`, `teacher_id`, `class_id`) VALUES (" + id_group + "," + id_teacher + ",'" + class_id + "')";
                //  MessageBox.Show(com);
                cla.data(com);
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public addGroup()
        {
            InitializeComponent();
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            int count = 0;

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Checked)
                {
                    count = 0;
                    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Checked)
                        {
                            count++;
                            if (count == 2)
                            {
                                goto Home;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        goto Home;
                    }
                }
            }
        Home:
            if (numgrp.Text.Length != 0 && combodep.SelectedIndex != -1 && combosem.SelectedIndex != -1)
            {
                groups g = new groups();
                string command3 = "select * from groups where name_group='" + numgrp.Text + "' and department_id=" + id_d + " and semster_id=" + combosem.SelectedItem + "";
                List<groups_data> grpact = g.getgroups(command3);
                if (grpact.Any())
                {
                    MessageBox.Show(string.Format("المجموعة {0} موجودة مسبقا يرجى تغيير الاسم",numgrp.Text));
                }
                else
                {
                    if (count > 1 || count == 0)
                    {
                        if (count > 1)
                            MessageBox.Show("يمكن اختيار عضو هيئة تدريس واحد للمادة");
                        else
                            MessageBox.Show("يجب ان يتضمن الاختيار عضو هيئة تدريس لكل مادة");
                    }
                    else
                    {
                        add();
                        string command = "select * from groups where name_group='" + numgrp.Text + "' and department_id=" + id_d + " and semster_id=" + combosem.SelectedItem + "";
                        List<groups_data> grp = g.getgroups(command);
                        for (int i = 0; i < treeView1.Nodes.Count; i++)
                        {
                            if (treeView1.Nodes[i].Checked)
                            {
                                Classes.Class2 cl = new Classes.Class2();
                                string command1 = "select * from classes where name_class='" + treeView1.Nodes[i].Text + "'";
                                List<Classes.class_data> cla = cl.getclass(command1);
                                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                                {
                                    if (treeView1.Nodes[i].Nodes[j].Checked)
                                    {
                                        Teacher.teacher_Class t = new Teacher.teacher_Class();
                                        string command2 = "SELECT * FROM `teacher` where name='" + treeView1.Nodes[i].Nodes[j].Text + "'";
                                        List<Teacher.teacher_data> te = t.getTeacher(command2);
                                        add_g_t_c(cla[0].id_class, te[0].id_teacher, grp[0].id_group);
                                        break;
                                    }
                                }
                            }
                        }
                        dataclear();
                    }
                }
            }
            else
                MessageBox.Show("الرجاء ملئ الحقول");
        }

        private void addGroup_Load(object sender, EventArgs e)
        {
            combo();          
        }

        private void combodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            combosem.ResetText();
            if (combodep.SelectedIndex != -1)
            {
                sem();
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
            }
        }

        private void combosem_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void numgrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
