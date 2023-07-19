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
    public partial class addDepartment : Form
    {
        public addDepartment()
        {
            InitializeComponent();
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            try
            {
                departments_class dep = new departments_class();

                if ((name.Text.Length != 0) && (id.Text.Length != 0))
                {
                    string comChak = "SELECT* FROM department where name_department='" + name.Text + "' or sub_department='" + id.Text + "'";
                    string chak = dep.check_departments(name.Text, id.Text, comChak);
                    if (chak == "0")
                    {  string command = "INSERT INTO department(`name_department`, `sub_department`, `state`) VALUES ('" + name.Text + "','" + id.Text + "','0')";
                        string add_dep = dep.data_departments(command);

                        if (add_dep == "0")
                        {
                            MessageBox.Show("تمت اضافة قسم جديد في النظام");
                            id.Clear();
                            name.Clear();
                        }
                        else
                            MessageBox.Show(add_dep);
                    }
                    else
                        MessageBox.Show(chak);
                }
                else
                    MessageBox.Show("الرجاء ادخال الاسم و رمز المادة");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);             
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
