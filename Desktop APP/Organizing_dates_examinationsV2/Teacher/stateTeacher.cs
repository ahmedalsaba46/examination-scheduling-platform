using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Teacher
{
    public partial class stateTeacher : Form
    {
        void combo()
        {
            try
            {
                comboBox1.Items.Clear();

                teacher_Class teacher = new teacher_Class();
                string command = "SELECT* FROM teacher";
                List<teacher_data> teacher_da = teacher.getTeacher(command);

                //Check if there is an error in the class  or not 
                if (teacher.error == "0")
                {
                    if (teacher_da.Any())

                    {
                        foreach (teacher_data teacher_data in teacher_da)
                        {

                            comboBox1.Items.Add(teacher_data.name);
                        }
                    }

                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(teacher.error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public stateTeacher()
        {
            InitializeComponent();
        }

        private void state_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تغيير حالة القسم من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    teacher_Class tes = new teacher_Class();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update teacher set state=1 where name='" + comboBox1.SelectedItem.ToString() + "'";
                    else
                        command = "update teacher set state=0 where name='" + comboBox1.SelectedItem.ToString() + "'";

                    string upda_te = tes.data_Teacher(command);
                    //Check if there is an error in the class or not
                    if (upda_te == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        comboBox1.Items.Clear();
                        comboBox1.ResetText();
                        combo();
                        state.Visible = false;

                        id.Text = "";
                        name.Text = "";
                        user_name.Text = "";
                        dgree.Text = "";
                    }
                    else
                        MessageBox.Show(upda_te);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
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
            {
                teacher_Class tea = new teacher_Class();
                string command = "select * from teacher where name='" + comboBox1.SelectedItem.ToString() + "'";
                List<teacher_data> te_da = tea.getTeacher(command);
                if (tea.error == "0")
                {

                    if (te_da.Any())
                    {

                        foreach (teacher_data t_data in te_da)
                        {
                            if (t_data.state == 0)
                            {
                                state.Text = "الغاء التفعيل";
                            }
                            else
                            {
                                state.Text = " التفعيل";

                            }
                            id.Text = t_data.id_teacher.ToString();
                            name.Text = t_data.name;
                            user_name.Text = t_data.user_name;
                            dgree.Text = t_data.teacher_degree;
                        }
                    }

                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(tea.error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void stateTeacher_Load(object sender, EventArgs e)
        {
            combo(); 
        }
    }
}
