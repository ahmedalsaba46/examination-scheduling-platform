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
    public partial class addClassroom : Form
    {
        public addClassroom()
        {
            InitializeComponent();
        }

        private void addClassroom_Load(object sender, EventArgs e)
        {
            String[] s = { "معمل", "قاعة", "مدرج" };
            combotype.Items.Clear();
            combotype.Items.AddRange(s);
            combotype.SelectedIndex = 1;
        }
        void add_data(string com)
        {
            try
            {
                classroom_class room = new classroom_class();
                string add_room = room.data_room(com);

                if (add_room == "0")
                {
                    MessageBox.Show("تمت اضافة فصل جديد في النظام");
                    id.Clear();
                    name.Clear();
                }

                else
                    MessageBox.Show(add_room);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
        private void combotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combotype.SelectedIndex != 1)
           {
               name_1.Visible = true;
               name.Visible = true;
           }
           else
           {
               name_1.Visible = false;
               name.Visible = false;
           }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string command;
            if (combotype.SelectedIndex != 1)
            {
                if (name.Text.Length != 0 && id.Text.Length != 0 && numstd.Text.Length != 0)
                {
                     command = "INSERT INTO `classroom`(`id_clasrm`, `name_clasrm`, `num_clasrm`, `type_clasrm`, `state_clasrm`) VALUES ('" + int.Parse(id.Text) + "','" + name.Text + "','" + int.Parse(numstd.Text) + "','" + combotype.SelectedItem.ToString() + "','0')";
                    add_data(command);
                    name_1.Visible = false;
                    name.Visible = false;
                }
                else
                    MessageBox.Show("خطأ");
            }
            else if (numstd.Text.Length != 0 && id.Text.Length != 0)
            {
                command = "INSERT INTO `classroom`(`id_clasrm`, `name_clasrm`,`num_clasrm`, `type_clasrm`, `state_clasrm`) VALUES ('" + int.Parse(id.Text) + "','','" + int.Parse(numstd.Text) + "','" + combotype.SelectedItem.ToString() + "','0')";
                add_data(command);
                name_1.Visible = false;
                name.Visible = false;
            }
            else
                MessageBox.Show("ادخال البيانات");
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (id.Text != "")
                {
                    string s = id.Text;
                    if (s[0] == '1' || s[0] == '2' || s[0] == '3' || s[0] == '4')
                    {
                        alert.Visible = false;
                    }
                    else
                    {
                        alert.Visible = true;
                        id.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (char.IsDigit(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 3)
                    e.Handled = true;
            }
        }

        private void numstd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (char.IsDigit(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 3)
                    e.Handled = true;
            }
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
