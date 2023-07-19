using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Test
{
    public partial class UserControldays : UserControl
    {
        List<Classes.class_data> listclass;

        public UserControldays()
        {
            InitializeComponent();
        }
        public void days(int nub, int month, int year)
        {
            label2.Text = "";
            label1.Text = year + "/" + month + "/" + nub;

        }

        private void UserControldays_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void UserControldays_Click(object sender, EventArgs e)
        {


            if (label2.Text.Length != 0)
            {
                view_test v = new view_test(label1.Text, this, 1);//insert data
                v.Show();
            }
            else
            {
                view_test v = new view_test(label1.Text, this, 0);//update data
                v.Show();
            }
        }



        public void disp()
        {
            try
            {

                test_class tes = new test_class();
                string command;
                Classes.Class2 classclass = new Classes.Class2();
                command = "select * from classes ";
                listclass = classclass.getclass(command);

                command = "select * from test where group_id =" + test.addTest.grou_id;// + "and date_test='" + DateTime.Parse(label1.Text) +"'";
                List<test_data> listtest = tes.getTest(command);
               // MessageBox.Show(command);

                if (tes.error == "0")
                {

                    if (listtest.Any())
                    {

                        foreach (test_data tes_data in listtest)
                        {
                            foreach (Classes.class_data cla in listclass)
                            {
                                if (cla.id_class == tes_data.class_id && tes_data.date_test == DateTime.Parse(label1.Text))
                                {
                                    label2.Text = label2.Text + "\n" + cla.name_class.ToString();
                                }


                            }
                        }
                    }
                }
                else
                    MessageBox.Show(tes.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
