using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Classes
{
    public partial class stateClass : Form
    {    
        void combo()
        {
            try
            {
                comboid1.Items.Clear();

                Class2 cls = new Class2();
                string command = "SELECT* FROM classes";
                List<class_data> cls_da = cls.getclass(command);

                //Check if there is an error in the class  or not 
                if (cls.error == "0")
                {
                    if (cls_da.Any())
                    {
                        foreach (class_data c_data in cls_da)
                        {
                            comboid1.Items.Add(c_data.name_class);
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(cls.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public stateClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تغيير حالة المادة من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    Class2 cl = new Class2();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update classes set state=1 where name_class='" + comboid1.SelectedItem.ToString() + "'";
                    else
                        command = "update classes set state=0 where name_class='" + comboid1.SelectedItem.ToString() + "'";

                    string chak = cl.data(command);
                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        comboid1.Items.Clear();
                        comboid1.ResetText();
                        combo();
                        state.Visible = false;
                    }
                    else
                        MessageBox.Show(chak);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void stateClass_Load(object sender, EventArgs e)
        {
            combo();
        }

        private void comboid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboid1.SelectedIndex == -1)
            {
                state.Visible = false;
            }
            else
            {
                state.Visible = true;
            }

            try
            {
                Class2 cl= new Class2();
                string command = "select * from classes where name_class='" + comboid1.SelectedItem.ToString() + "'";
                List<class_data> class_da = cl.getclass(command);
                if (cl.error == "0")
                {

                    if (class_da.Any())
                    {

                        foreach (class_data c_data in class_da)
                        {
                            if (c_data.state == 0)
                            {
                                state.Text = "الغاء التفعيل";
                            }
                            else
                            {
                                state.Text = " التفعيل";

                            }

                            name1.Text = c_data.name_class;
                            num_unit.Text = c_data.num_unit.ToString();
                            type_class.Text = c_data.type_class;
                            req_id.Text = c_data.req_id;

                        }
                    }

                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(cl.error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

    }
}

