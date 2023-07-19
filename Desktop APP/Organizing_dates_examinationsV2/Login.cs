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

namespace Organizing_dates_examinationsV2
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");
        String user, pass, position;

        public Login()
        {
            InitializeComponent();
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
                try
                {
                    MySqlCommand com = new MySqlCommand("select * from User where username = @us and state =0", con);
                    com.Parameters.AddWithValue("@us", name.Text);

                    con.Open();
                    MySqlDataReader dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        user = dr["name"].ToString();
                        pass = dr["password"].ToString();
                        position = dr["position"].ToString();

                        if (passwod.Text == pass)
                        {
                            Home control = new Home(position, user);
                            this.Hide();
                            control.Show();
                        }
                        else
                            MessageBox.Show("خطأ في بيانات المسنخدم");
                    }
                    else
                        MessageBox.Show("خطأ في بيانات المستخدم");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            
        }

        private void show_password_CheckedChanged(object sender, EventArgs e)
        {
            passwod.PasswordChar = show_password.Checked ? '\0' : '*';
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sign_in.PerformClick();
        }

        private void passwod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sign_in.PerformClick();
        }

        private void show_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sign_in.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand("select * from User where username= @us and password=@p", con);
                com.Parameters.AddWithValue("@us", name.Text);
                com.Parameters.AddWithValue("@p", passwod.Text);

                con.Open();
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                   if(dr["position"].ToString() == "Admin")
                    {
                        if (MessageBox.Show("هل انت تريد تريد فتح فصل دراسي جديد", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                        {
                            MessageBox.Show("سيتم حذف بيانات المجموعات والطلاب والامتحانات والجداول الددراسية");
                            if (MessageBox.Show("هل انت متأكد من الحذف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                            {
                                string command = "DELETE FROM groups";
                                Group.groups g = new Group.groups();
                                g.data(command);

                                string command2 = "DELETE FROM Schedule";
                                Schedule.class_Schedule sc = new Schedule.class_Schedule();
                                sc.data(command2);

                                string command3 = "DELETE FROM test";
                                Test.test_class t = new Test.test_class();
                                t.data(command3);

                                string command4 = "DELETE FROM `student_classes`";
                                string command5 = "DELETE FROM `teacher_classes_groups`";
                                t.data(command4);
                                t.data(command5);

                                MessageBox.Show("تم فتح فصل دراسي جديد");
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sign_in.PerformClick();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
