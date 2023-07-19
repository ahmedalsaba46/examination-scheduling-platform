using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Classroom
{
    public partial class stateClassroom : Form
    {
        public stateClassroom()
        {
            InitializeComponent();
        }

        private void stateClassroom_Load(object sender, EventArgs e)
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
                classroom_class room = new classroom_class();
                string command = "SELECT* FROM classroom";
                List<classroom_data> room_da = room.getdepartment(command);

                if (room.error == "0")
                {
                    if (room_da.Any())
                    {
                        foreach (classroom_data rom_data in room_da)
                        {
                            comboBox1.Items.Add(rom_data.id_clasrm);
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(room.error);
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
                    classroom_class room = new classroom_class();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update classroom set state_clasrm=1 where id_clasrm='" + comboBox1.SelectedItem.ToString() + "'";
                    else
                        command = "update classroom set state_clasrm=0 where id_clasrm='" + comboBox1.SelectedItem.ToString() + "'";

                    string upda_room = room.data_room(command);
                    if (upda_room == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        comboBox1.Items.Clear();
                        comboBox1.ResetText();
                        combo();
                        state.Visible = false;
                        type.Text="";
                        number.Text = "";
                        name.Text = "";
                        num_st.Text = "";
                    }
                    else
                        MessageBox.Show(upda_room);
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
                classroom_class room = new classroom_class();
                string command = "select * from classroom where id_clasrm='" + comboBox1.SelectedItem.ToString() + "'";
                List<classroom_data> room_da = room.getdepartment(command);
                if (room.error == "0")
                {
                    if (room_da.Any())
                    {
                        foreach (classroom_data room_data in room_da)
                        {
                            if (room_data.state_clasrm == 0)
                            {
                                state.Text = "الغاء التفعيل";
                            }
                            else
                            {
                                state.Text = " التفعيل";
                            }
                            type.Text = room_data.type_clasrm;
                            number.Text = room_data.num_clasrm.ToString();
                            name.Text = room_data.name_clasrm;
                            num_st.Text = room_data.num_clasrm.ToString();
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(room.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
