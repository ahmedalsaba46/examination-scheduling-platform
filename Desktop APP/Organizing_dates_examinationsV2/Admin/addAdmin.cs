using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Admin
{
    public partial class addAdmin : Form
    {
        public addAdmin()
        {
            InitializeComponent();
        }
        private void sign_in_Click(object sender, EventArgs e)
        {
            try
            {
                admin adm = new admin();
                if ((name.Text.Length != 0) && (id.Text.Length != 0) && (user_name.Text.Length != 0) && (password.Text.Length != 0))
                {
                    string commandcheck = "SELECT * FROM user where username='" + user_name.Text + "'";
                    string check = adm.check_user(commandcheck);
                    if (check == "0")
                    {
                        string command = "INSERT INTO `user`(`id_user`, `name`, `username`, `password`, `position`, `state`) VALUES ("+int.Parse(id.Text.ToString())+",'"+name.Text+"','"+user_name.Text+"','"+password.Text+"','Admin',0)";
                        MessageBox.Show(command);
                        string add_user = adm.data_user(command);

                        if (add_user == "0")
                        {
                            MessageBox.Show("تمت اضافة مسؤول جديد في النظام");
                            id.Clear();
                            name.Clear();
                            password.Clear();
                            user_name.Clear();
                        }

                        else
                            MessageBox.Show(add_user);
                    }
                    else
                        MessageBox.Show(check);
                }
                else
                    MessageBox.Show("الرجاء تعبئة البيانات");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
