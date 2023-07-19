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

namespace Organizing_dates_examinationsV2.User
{
    public partial class editUser : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        void show()
        {
            con.Open();
            MySqlCommand com = new MySqlCommand("select * from user where state =0 and position='User'", con);
            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            con.Close();
        }
        public editUser()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                name1.Clear();
                password1.Clear();
                user_name1.Clear();
                Admin.admin adm = new Admin.admin();
                string command = "select * from user where id_user=" + int.Parse(id1.Text) + "";
                List<Admin.user_data> user_da = adm.getuser(command);
                //Check if there is an error in the class or not
                if (adm.error == "0")
                {
                    if (user_da.Any())
                    {
                        foreach (Admin.user_data user_data in user_da)
                        {
                            if (user_data.state == 0)
                            {
                                name1.Text = user_data.name.ToString();
                                user_name1.Text = user_data.user_name.ToString();
                                password1.Text = user_data.password.ToString();
                            }
                            else
                            {
                                MessageBox.Show("المشرف في الارشيف");
                            }
                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات تحتاج تعديل");
                }
                else
                    MessageBox.Show(adm.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editUser_Load(object sender, EventArgs e)
        {
            show();
            id1.Clear();
            name1.Clear();
            password1.Clear();
            user_name1.Clear();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((name1.Text.Length != 0) && (id1.Text.Length != 0) && (user_name1.Text.Length != 0) && (password1.Text.Length != 0))
                {
                    if (MessageBox.Show("هل انت تريد تعديل بيانات المشرف في النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                    {
                        Admin.admin adm = new Admin.admin();
                        string commandcheck = "SELECT * FROM user where username ='" + user_name1.Text + "' and id_user !=" + int.Parse(id1.Text) + "";
                        string check = adm.check_user(commandcheck);
                        if (check == "0")
                        {
                            string command = "update user set name='" + name1.Text + "',username='" + user_name1.Text + "',password='" + password1.Text.ToString() + "' where id_user='" + id1.Text.ToString() + "'";

                            string update_user = adm.data_user(command);
                            //Check if there is an error in the class or not
                            if (update_user == "0")
                            {
                                MessageBox.Show("تمت تعديل بيانات المسؤول في النظام");
                                id1.Clear();
                                name1.Clear();
                                password1.Clear();
                                user_name1.Clear();
                                show();
                            }
                            else
                                MessageBox.Show(update_user);
                        }
                        else
                            MessageBox.Show(check);
                    }
                }
                else
                    MessageBox.Show("الرجاء تعبئة البيانات");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void id1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void name1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
