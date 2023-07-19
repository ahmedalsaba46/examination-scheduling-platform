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
    public partial class view_test : Form
    {
        UserControldays fom;

        List<Classroom.classroom_data> room_da;
        List<Classes.class_data> cls_da1;
        List<Classes.class_data> listclass;
        List<Classes.classes_semster_department> cls_da;
        List<Schedule.Schedule_data> Schedule_da;
        int id_Sched;
        int id_classroom, id_test_update;
        string id_classes, dat;
        string id_class = "";
        test_class test_update = new test_class();
        List<test_data> listtest_update;
        public view_test()
        {
            InitializeComponent();
        }

        void dataclear()
        {
            comtest.SelectedIndex = -1;
            comclass.SelectedIndex = -1;
            combclassroom.SelectedIndex = -1;
            combotype1.SelectedIndex = -1;
            nots.Clear();
        }
        private void clas()
        {
            try
            {
                comclass.Items.Clear();

                Classes.Class2 cls = new Classes.Class2();
                Classes.Class2 classr = new Classes.Class2();
                string command = "SELECT* FROM classes_semster_department where department_id='" + test.addTest.Depart_id + "' and semster_id='" + label9.Text + "'";
                cls_da = cls.get_C_S_D(command);
                command = "SELECT* FROM classes ";
                cls_da1 = classr.getclass(command);
                if (cls.error == "0" && classr.error == "0")
                {
                    if (cls_da.Any())
                    {
                        foreach (Classes.classes_semster_department cl in cls_da)
                        {
                            foreach (Classes.class_data c_dat1 in cls_da1)
                            {
                                if (cl.class_id == c_dat1.id_class)
                                {//  treeView1.Nodes.Add(c_data.id_class + " " + c_data.name_class);
                                    comclass.Items.Add(c_dat1.name_class);
                                }
                            }

                        }
                    }
                    else
                        MessageBox.Show("لايوجود بيانات  ");
                }
                else
                    MessageBox.Show(cls.error + "\n" + classr.error);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void classroom()
        {
            try
            {
                combclassroom.Items.Clear();
                Classroom.classroom_class room = new Classroom.classroom_class();
                string command = "select * from classroom where type_clasrm != 'مدرج' ";
                room_da = room.getdepartment(command);
                //Check if there is an error in the class or not
                if (room.error == "0")
                {
                    if (room_da.Any())
                    {
                        foreach (Classroom.classroom_data room_data in room_da)
                        {
                            if (room_data.state_clasrm == 0)
                            {
                                combclassroom.Items.Add(room_data.id_clasrm);

                            }
                        }

                        disp();

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

        public void disp()
        {
            try
            {
                Schedule.class_Schedule room = new Schedule.class_Schedule();
                string command = "select * from schedule where day = '" + label6.Text + "' AND time_first = " + int.Parse(label7.Text) + "";
                //string command = "select * from schedule ";
                Schedule_da = room.getSchedule(command);


                if (room.error == "0")
                {
                    if (Schedule_da.Any())

                    {
                        foreach (Schedule.Schedule_data sc_data in Schedule_da)
                        {
                            //  MessageBox.Show(command);
                            if (sc_data.class_id != id_classes)
                                combclassroom.Items.Remove(sc_data.clasrm_id);
                        }

                    }


                }
                else
                    MessageBox.Show(room.error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void add()
        {

            try
            {
                if (comclass.SelectedIndex != -1 && combotype1.SelectedIndex != -1 && combclassroom.SelectedIndex != -1)
                {
                    int id_tec = -2;
                    other_classes cl_s_t = new other_classes();
                    string command = "SELECT* FROM teacher_classes_groups where group_id=" + test.addTest.grou_id + " ";
                    List<teacher_classes_groups> cls_da1 = cl_s_t.getteacher_classes_groups(command);
                    foreach (teacher_classes_groups chak_d in cls_da1)
                    {
                        if (chak_d.class_id == id_classes)
                        {
                            id_tec = chak_d.teacher_id;
                            break;
                        }


                    }

                    string[] x = dat.Split('/');
                    DateTime da = new DateTime(int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]));
                    string dayName = da.ToString("dddd");


                    test_class tes = new test_class();

                    string com = "INSERT INTO `test`( `teacher_id`, `class_id`, `group_id`, `clasrm_id`, `day`, `date_test`, `time_first`, `time_end`, `note`) VALUES (" + id_tec + ",'" + id_classes + "','" + test.addTest.grou_id + "','" + combclassroom.SelectedItem + "','" + dayName + "','" + dat + "','" + dateTimePickertime.Value.Hour.ToString() + ":" + dateTimePickertime.Value.Minute.ToString() + "','" + dateTimePicker1.Value.Hour.ToString() + ":" + dateTimePicker1.Value.Minute.ToString() + "','" + nots.Text + "')";
                    // MessageBox.Show(com);
                    string chak = tes.data(com);


                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {

                        MessageBox.Show("تمت اضافة مادة جديدة في جدول");

                    }

                    else
                        MessageBox.Show(chak + "خطا :");
                }
                else
                    MessageBox.Show("الرجاء ملئ الحقول");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        void show_test()
        {
            try
            {

                string command;
                Classes.Class2 classclass = new Classes.Class2();
                command = "select * from classes ";
                listclass = classclass.getclass(command);

                command = "select * from test where group_id =" + test.addTest.grou_id;// + "and date_test='" + DateTime.Parse(label1.Text) +"'";
                listtest_update = test_update.getTest(command);
                //MessageBox.Show(command);

                if (test_update.error == "0")
                {
                    if (listtest_update.Any())
                    {
                        comtest.Items.Add("جديد");
                        foreach (test_data tes_data in listtest_update)
                        {
                            foreach (Classes.class_data cla in listclass)
                            {
                              //MessageBox.Show(tes_data.date_test);
                                if (cla.id_class == tes_data.class_id && tes_data.date_test == DateTime.Parse(dat))
                                {
                                    comtest.Items.Add(cla.name_class);
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show(test_update.error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void updatas()
        {

            try
            {
                if (combotype1.SelectedIndex != -1 && combclassroom.SelectedIndex != -1)
                {

                    string id_d = "";
                    if (cls_da.Any())
                    {
                        Classes.Class2 cls = new Classes.Class2();
                        string command = "SELECT* FROM classes ";
                        cls_da1 = cls.getclass(command);
                        foreach (Classes.class_data cla_data in cls_da1)
                        {
                            if (cla_data.name_class == comtest.SelectedItem.ToString())
                            {
                                id_d = cla_data.id_class;

                            }


                        }
                    }

                    if (id_d == "")
                    { MessageBox.Show(" خطا في مواد"); }
                    // int t_end = int.Parse(label7.Text) + int.Parse(combotimend.SelectedItem.ToString());

                    test_class tes = new test_class();
                    string com = "UPDATE `test` SET `clasrm_id`=" + combclassroom.SelectedItem + ",`time_first`='" + dateTimePickertime.Value.Hour.ToString() + ":" + dateTimePickertime.Value.Minute.ToString() + "',`time_end`='" + dateTimePicker1.Value.Hour.ToString() + ":" + dateTimePicker1.Value.Minute.ToString() + "',`note`='" + nots.Text + "' WHERE id_test=" + id_test_update + " ";
                    MessageBox.Show(com);

                    string chak = tes.data(com);


                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        /* fom.label2Value = comclass.SelectedItem.ToString();
                         fom.label3Value = combclassroom.SelectedItem.ToString();
                         fom.label4Value = combotimend.SelectedItem.ToString();*/
                        MessageBox.Show("تمت تعديل مجموعة جديدة في النظام");

                    }

                    else
                        MessageBox.Show(chak + "خطا :");
                }
                else
                    MessageBox.Show("الرجاء ملئ الحقول");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void label14_Click(object sender, EventArgs e)
        {

        }


        public view_test(string date, UserControldays b, int ch)
        {

            try
            {
                InitializeComponent();
                string[] x = date.Split('/');
                label6.Text = x[2];
                label7.Text = x[1];
                fom = b;
                dat = date;
                if (ch == 0)
                {
                    button1.Text = "اضافة";

                }
                else
                {
                    classroom();
                    show_test();

                    button1.Text = "تعديل";
                    button2.Visible = true;
                    combclassroom.Enabled = true;
                    combotype1.Enabled = true;
                    comclass.Enabled = false;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void view_test_Load(object sender, EventArgs e)
        {
            label1.Text = test.addTest.Depart;
            label9.Text = test.addTest.sems;
            label3.Text = test.addTest.grou;

            String[] s = { "معمل", "قاعة", "مدرج" };
            combotype1.Items.Clear();
            combotype1.Items.AddRange(s);
            // combotype1.SelectedIndex = 1;

            clas();

            /* for (int i = 1; i <= 18 - int.Parse(label7.Text); i++)
             {
                 combotimend.Items.Add(i);
             }

             clas();
             if (button1.Text != "اضافة")
                 updatas_comclass();
            */
        }

        private void combotype1_SelectedIndexChanged(object sender, EventArgs e)
        {
            classroom();
            combclassroom.Enabled = true;
            combclassroom.SelectedItem = -1;
            combclassroom.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "اضافة")
                    add();
                else if (button1.Text == "تعديل")
                    updatas();
                else
                    MessageBox.Show("خطا في جلب بيانات");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comtest.SelectedIndex != -1)
            {
                if (comtest.SelectedIndex != 0)
                {
                    button1.Text = "تعديل";
                    button2.Visible = true;
                    combclassroom.Enabled = true;
                    combotype1.Enabled = true;
                    comclass.Enabled = false;
                    comclass.ResetText();
                    if (listtest_update.Any())
                    {

                        int id_classroom = -2;
                        foreach (Classes.class_data cla in listclass)
                        {

                            //MessageBox.Show(tes_data.date_test);
                            if (cla.name_class == comtest.SelectedItem.ToString())
                            {
                                id_class = cla.id_class;
                            }


                        }

                        foreach (test_data tes_data in listtest_update)
                        {
                            if (tes_data.class_id == id_class)
                            {
                                string[] first = tes_data.time_first.Split(':');
                                string[] end = tes_data.time_end.Split(':');
                                id_classroom = tes_data.clasrm_id;
                                dateTimePickertime.Value = DateTime.Today.AddHours(int.Parse(first[0])).AddMinutes(int.Parse(first[1]));
                                dateTimePicker1.Value = DateTime.Today.AddHours(int.Parse(end[0])).AddMinutes(int.Parse(end[1]));
                                // dateTimePickertime.Value = dateTimePickertime.Value.AddHours(int.Parse(c[0]));
                                nots.Text = tes_data.note;
                                id_test_update = tes_data.id_test;
                             //   combclassroom.SelectedItem = tes_data.clasrm_id;

                            }

                            foreach (Classroom.classroom_data room_data in room_da)
                            {
                                if (room_data.id_clasrm == id_classroom)
                                {
                                    combotype1.SelectedItem = room_data.type_clasrm;
                                    combclassroom.SelectedItem = room_data.id_clasrm;
                                   
                                }
                            }



                        }

                    }
                }
                else
                {
                    button1.Text = "اضافة";
                    button2.Visible = false;
                    combclassroom.Enabled = true;
                    combotype1.Enabled = true;
                    comclass.Enabled = true;
                    combclassroom.SelectedItem = -1;
                    combclassroom.ResetText();

                    combotype1.SelectedItem = -1;
                    combotype1.ResetText();
                    
                    nots.Clear();
                        
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد حدف مادة من الجدول", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {


                    test_class cla = new test_class();
                    string com = "delete from test WHERE id_test=" + id_test_update + "";


                    string chak = cla.data(com);


                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        MessageBox.Show("تمت عملية الحذف بنجاح");
                        dataclear();
                    }

                    else
                        MessageBox.Show(chak + "خطا :");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void combclassroom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Classes.class_data c_dat1 in cls_da1)
            {
                if (comclass.SelectedItem.ToString() == c_dat1.name_class)
                {
                    id_classes = c_dat1.id_class;
                }
            }

            combotype1.Enabled = true;
            combotype1.SelectedItem = -1;
            combotype1.ResetText();

        }
    }
}
