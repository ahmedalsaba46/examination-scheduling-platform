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
    public partial class editDepartment : Form
    {
        public editDepartment()
        {
            InitializeComponent();
        }

        private void editDepartment_Load(object sender, EventArgs e)
        {
            id1.Clear();
            name1.Clear();
            comboBox2.Items.Clear();
            combo();
        }

        void combo()
        {
            try
            {
                comboBox2.Items.Clear();
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
                            if (deprtment_data.state == 0)
                                    comboBox2.Items.Add(deprtment_data.name_department);                           
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id1.Clear();
                name1.Clear();
                departments_class dep = new departments_class();
                string command = "select * from department where name_department='" + comboBox2.SelectedItem.ToString() + "'";
                List<deprtment_data> deprtment_da = dep.getdepartment(command);
                //Check if there is an error in the class or not
                if (dep.error == "0")
                {
                    if (deprtment_da.Any())
                    {
                        foreach (deprtment_data deprtment_data in deprtment_da)
                        {
                            if (deprtment_data.state == 0)
                            {
                                id1.Text = deprtment_data.sub_department.ToString();
                                name1.Text = deprtment_data.name_department.ToString();
                            }
                            else
                            {
                                MessageBox.Show("القسم في الارشيف");
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

        private void edit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تعديل بيانات هذا القسم", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                { if ((name1.Text.Length != 0) && (id1.Text.Length != 0))
                    {
                        departments_class dep = new departments_class();
                        string command = "update department set name_department='" + name1.Text + "',sub_department='" + id1.Text + "' where name_department='" + comboBox2.SelectedItem.ToString() + "'";

                        string update_dep = dep.data_departments(command);
                        //Check if there is an error in the class or not
                        if (update_dep == "0")
                        {
                            MessageBox.Show("تمت تعديل القسم  في النظام");
                            id1.Clear();
                            name1.Clear();
                            comboBox2.Items.Clear();
                            combo();
                            comboBox2.ResetText();
                        }
                        else
                            MessageBox.Show(update_dep);
                    }
                    else
                        MessageBox.Show("الرجاء ادخال الاسم و رمز المادة");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                
                }
            }
        }

        private void id1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void name1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }
    }
}
