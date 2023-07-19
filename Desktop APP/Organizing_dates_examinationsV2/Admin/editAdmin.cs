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

namespace Organizing_dates_examinationsV2.Admin
{
    public partial class editAdmin : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        void show()
        {
            con.Open();
            MySqlCommand com = new MySqlCommand("select * from user where state = 0 and position='Admin'",con);
            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            con.Close();
        }
        public editAdmin()
        {
            InitializeComponent();
        }

        private void editAdmin_Load(object sender, EventArgs e)
        {
            show();
            id.Clear();
            name.Clear();
            password.Clear();
            user_name.Clear();
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                name.Clear();
                password.Clear();
                user_name.Clear();
                admin adm = new admin();
                string command = "select * from user where id_user=" + int.Parse(id.Text)+ "";
                List<user_data> user_da = adm.getuser(command);
                //Check if there is an error in the class or not
                if (adm.error == "0")
                {
                    if (user_da.Any())
                    {
                        foreach (user_data user_data in user_da)
                        {
                            if (user_data.state == 0)
                            {
                                name.Text = user_data.name.ToString();
                                user_name.Text = user_data.user_name.ToString();
                                password.Text = user_data.password.ToString();
                            }
                            else
                            {
                                MessageBox.Show("المسؤول في الارشيف");
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

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((name.Text.Length != 0) && (id.Text.Length != 0) && (user_name.Text.Length != 0) && (password.Text.Length != 0))
                {
                    if (MessageBox.Show("هل انت تريد تعديل بيانات المسؤول من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                    {
                        admin adm = new admin();
                        string commandcheck = "SELECT * FROM user where username ='" + user_name.Text + "' and id_user !=" + int.Parse(id.Text) + "";
                        string check = adm.check_user(commandcheck);
                        if (check == "0")
                        {
                            string command = "update user set name='" + name.Text + "',username='" + user_name.Text + "',password='" + password.Text.ToString() + "' where id_user='" + id.Text.ToString() + "'";

                            string update_user = adm.data_user(command);
                            //Check if there is an error in the class or not
                            if (update_user == "0")
                            {
                                MessageBox.Show("تمت تعديل بيانات المسؤول في النظام");
                                id.Clear();
                                name.Clear();
                                password.Clear();
                                user_name.Clear();
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
