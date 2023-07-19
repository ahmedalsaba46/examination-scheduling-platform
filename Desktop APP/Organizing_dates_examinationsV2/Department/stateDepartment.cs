using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Department
{
    public partial class stateDepartment : Form
    {
        public stateDepartment()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                state.Visible = false;
            }
            else
            {
                state.Visible = true;
            }

            try
            { departments_class dep = new departments_class();
                string command = "select * from department where name_department='" + comboBox1.SelectedItem.ToString() + "'";
                List<deprtment_data> deprtment_da = dep.getdepartment(command);
                if (dep.error == "0")
                {
                    if (deprtment_da.Any())
                    {
                        foreach (deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.state == 0)
                            {
                                state.Text = "الغاء التفعيل";
                            }
                            else
                            {
                                state.Text = " التفعيل";
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

        private void stateDepartment_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            combo();
        }
        void combo()
        {
            try
            {
                comboBox1.Items.Clear();

                departments_class dep = new departments_class();
                string command = "SELECT* FROM department";
                List<deprtment_data> deprtment_da = dep.getdepartment(command);

                //Check if there is an error in the class  or not 
                if (dep.error == "0")
                {
                    if (deprtment_da.Any())
                    {
                        foreach (deprtment_data deprtment_data in deprtment_da)
                        {
                            
                                comboBox1.Items.Add(deprtment_data.name_department);
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

        private void state_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تغيير حالة القسم من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    departments_class dep = new departments_class();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update department set state=1 where name_department='" + comboBox1.SelectedItem.ToString() + "'";
                    else
                        command = "update department set state=0 where name_department='" + comboBox1.SelectedItem.ToString() + "'";

                    string add_dep = dep.data_departments(command);
                    //Check if there is an error in the class or not
                    if (add_dep == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        comboBox1.Items.Clear();
                        comboBox1.ResetText();
                        combo();
                        state.Visible = false;
                    }
                    else
                        MessageBox.Show(add_dep);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                   
                }
            }
        }
    }
}
