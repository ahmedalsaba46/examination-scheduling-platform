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
    public partial class stateUser : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        void show()
        {
            con.Open();
            MySqlCommand com = new MySqlCommand("select * from user where position ='User'", con);
            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());
            if (dt.Rows.Count > 0)
                dataGridView2.DataSource = dt;
            con.Close();
        }

        public stateUser()
        {
            InitializeComponent();
        }

        private void search2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تغيير حالة المشرف من النظام", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    Admin.admin adm = new Admin.admin();
                    string command;
                    if (state.Text == "الغاء التفعيل")
                        command = "update user set state=1 where id_user=" + int.Parse(id2.Text) + "";
                    else
                        command = "update user set state=0 where id_user=" + int.Parse(id2.Text) + "";

                    string state_user = adm.data_user(command);
                    if (state_user == "0")
                    {
                        MessageBox.Show(string.Format("تم {0} في النظام", state.Text));
                        id2.Clear();
                        state.Visible = false;
                        show();
                    }
                    else
                        MessageBox.Show(state_user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
    }

        private void state_Click(object sender, EventArgs e)
        {
            try
            {
                Admin.admin adm = new Admin.admin();
                string command = "select * from user where id_user=" + int.Parse(id2.Text) + "";
                List<Admin.user_data> user_da = adm.getuser(command);
                if (adm.error == "0")
                {
                    if (user_da.Any())
                    {
                        if (user_da[0].state == 0)
                        {
                            state.Text = "الغاء التفعيل";
                        }
                        else
                        {
                            state.Text = " التفعيل";
                        }
                        state.Visible = true;
                    }
                }
                else
                    MessageBox.Show(adm.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stateUser_Load(object sender, EventArgs e)
        {
            show();
        }

        private void id2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
