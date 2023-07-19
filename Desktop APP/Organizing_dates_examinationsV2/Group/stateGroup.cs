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
    public partial class stateGroup : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        int id_d;
        List<Department.deprtment_data> deprtment_da;
        List<groups_data> listgroup;
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
        void gro()
        {
            try
            {
                combogrp.Items.Clear();

                id_d = -2;
                foreach (Department.deprtment_data deprtment_data in deprtment_da)
                {
                    if (deprtment_data.name_department == combodep.SelectedItem.ToString())
                    {
                        id_d = deprtment_data.id_deprtment;
                        break;
                    }
                }
                if (id_d != -2)
                {
                    Group.groups gr = new Group.groups();
                    string command = "SELECT* FROM groups where department_id='" + id_d + "' and semster_id='" + combosem.SelectedItem.ToString() + "'";
                    List<groups_data> listgroup = gr.getgroups(command);

                    if (gr.error == "0")
                    {
                        if (listgroup.Any())
                        {
                            foreach (Group.groups_data gro_data in listgroup)
                            {  
                                    combogrp.Items.Add(gro_data.name_group);
                            }
                            combogrp.ResetText();
                            combogrp.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("لايوجود بيانات ");
                            combogrp.ResetText();
                            combogrp.Enabled = false;
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
        void view()
        {
            string command = "select * from groups where name_group='" + combogrp.SelectedItem.ToString() + "' and department_id =" + id_d + " and semster_id=" + combosem.SelectedItem + "";
            groups gr = new groups();
            listgroup = gr.getgroups(command);
            if (listgroup.Any())
            {
                if(listgroup[0].state ==0)
                {
                    state.Text = "الغاء التفعيل";
                }
                else
                {
                    state.Text = "تفعيل";
                }
            }
        }
        public stateGroup()
        {
            InitializeComponent();
        }
        private void stateGroup_Load(object sender, EventArgs e)
        {
            combo();
        }

        private void combodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combodep.SelectedIndex != -1)
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
                    combosem.Enabled = true;;
                    state.Visible = false;
                }
            }
        }

        private void combosem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosem.SelectedIndex != -1)
            {
                combogrp.Enabled = true;
                gro();
                state.Visible = false;
            }
            else
            {
                combogrp.ResetText();
                combogrp.Enabled = false;
                state.Visible = false;
            }
        }

        private void combogrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combogrp.SelectedIndex != -1)
            {
                view();
                state.Visible = true;
            }
        }

        private void state_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تغيير حالة المجموعة من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    groups gr = new groups();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update groups set state=1 where id_group='" + listgroup[0].id_group + "'";
                    else
                        command = "update groups set state=0 where id_group='" + listgroup[0].id_group + "'";

                    string add_gr = gr.data(command);
                    //Check if there is an error in the class or not
                    if (add_gr == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        combodep.SelectedIndex = -1;
                        combosem.SelectedIndex = -1;
                        combogrp.SelectedIndex = -1;
                        state.Visible = false;
                    }
                    else
                        MessageBox.Show(add_gr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
