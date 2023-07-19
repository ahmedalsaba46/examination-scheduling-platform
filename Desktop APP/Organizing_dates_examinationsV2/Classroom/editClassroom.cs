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
    public partial class editClassroom : Form
    {
        public editClassroom()
        {
            InitializeComponent();
        }

        private void editClassroom_Load(object sender, EventArgs e)
        {
            String[] s = { "معمل", "قاعة", "مدرج" };          
            combotype1.Items.Clear();
            combotype1.Items.AddRange(s);           
            combotype1.SelectedIndex = 1;
            alert1.Visible = false;
            sear();
        }

        void sear()
        {
            try
            {
                comboid2.Items.Clear();
                comboid2.ResetText();

                classroom_class room = new classroom_class();
                string command = "SELECT * FROM classroom";
                List<classroom_data> room_da = room.getdepartment(command);
 
                if (room.error == "0")
                {
                    if (room_da.Any())
                    {
                        foreach (classroom_data room_data in room_da)
                        {
                            comboid2.Items.Add(room_data.id_clasrm);
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

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                classroom_class room = new classroom_class();
                string command = "select * from classroom where id_clasrm=" + comboid2.SelectedItem.ToString();
                List<classroom_data> room_da = room.getdepartment(command);

                if (room.error == "0")
                {
                    if (room_da.Any())
                    {
                        foreach (classroom_data room_data in room_da)
                        {
                            if (room_data.state_clasrm == 0)
                            {
                                name1.Text = room_data.name_clasrm;
                                id1.Text = room_data.id_clasrm.ToString();
                                numstd1.Text = room_data.num_clasrm.ToString();
                                combotype1.SelectedItem = room_data.type_clasrm;
                                MessageBox.Show(name1.Text);
                            }
                            else
                            {
                                MessageBox.Show("القاعة في الارشيف");
                            }
                        }
                        if (combotype1.SelectedIndex != 1)
                        {
                            name_11.Visible = false;
                            name1.Visible = false;
                        }
                        else
                        {
                            name_11.Visible = true;
                            name1.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("هنالك خطا في البيانات");
                }
                else
                    MessageBox.Show(room.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combotype1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combotype1.SelectedIndex != 1)
            {
                name_11.Visible = false;
                name1.Visible = false;
            }
            else
            {
                name_11.Visible = true;
                name1.Visible = true;
                name1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (name1.Text.Length != 0 && id1.Text.Length != 0 && numstd1.Text.Length != 0)
                {
                    classroom_class room = new classroom_class();
                    string command = "update classroom set id_clasrm='" + id1.Text + "',name_clasrm='" + name1.Text + "',num_clasrm='" + numstd1.Text + "',type_clasrm='" + combotype1.SelectedItem.ToString() + "' where id_clasrm='" + comboid2.SelectedItem.ToString() + "'";

                    string room_d = room.data_room(command);

                    if (room_d == "0")
                    {
                        MessageBox.Show("تمت تعديل القسم  في النظام");
                        id1.Clear();
                        name1.Clear();
                        numstd1.Clear();
                        combotype1.ResetText();
                        comboid2.ResetText();
                        sear();
                    }
                    else
                        MessageBox.Show(room_d);

                }
                else
                    MessageBox.Show("خطأ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (char.IsDigit(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 3)
                    e.Handled = true;
            }
        }

        private void id1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (id1.Text != "")
                {
                    string s = id1.Text;
                    if (s[0] == '1' || s[0] == '2' || s[0] == '3' || s[0] == '4')
                    {
                        alert1.Visible = false;
                    }
                    else
                    {
                        alert1.Visible = true;
                        id1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numstd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (char.IsDigit(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 3)
                    e.Handled = true;
            }
        }

        private void name1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
