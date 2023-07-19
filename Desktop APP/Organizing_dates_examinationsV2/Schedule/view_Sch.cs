using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Schedule
{
    public partial class view_Sch : Form
    {
        List<Classroom.classroom_data> room_da;
        List<Classes.class_data> cls_da1;
        List<Classes.classes_semster_department> cls_da;
        List<Schedule_data> Schedule_da;
        int id_Sched;
        int id_classroom;
        back_class fom;
        public view_Sch()
        {
            InitializeComponent();
        }

        public view_Sch(string day, string time_first, back_class b, int ch)
        {
            try
            {
                InitializeComponent();
                label6.Text = day;
                label7.Text = time_first.ToString();
                fom = b;
                if (ch == 0)
                {
                    button1.Text = "اضافة";
                }
                else
                {
                    button1.Text = "تعديل";
                    button2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clas()
        {
            try
            {
                comclass.Items.Clear();

                Classes.Class2 cls = new Classes.Class2();
                Classes.Class2 classr = new Classes.Class2();
                string command = "SELECT* FROM classes_semster_department where department_id='" + Schedules.addSchedule.Depart_id + "' and semster_id='" + label9.Text + "'";
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
                                {
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
        void add()
        {
            try
            {
                if (comclass.SelectedIndex != -1 && combotype1.SelectedIndex != -1 && combclassroom.SelectedIndex != -1 && combotimend.SelectedIndex != -1)
                {
                    string id_d = "";
                    if (cls_da1.Any())
                    {
                        Classes.Class2 cls = new Classes.Class2();
                        string command = "SELECT* FROM classes ";
                        cls_da1 = cls.getclass(command);
                        foreach (Classes.class_data cla_data in cls_da1)
                        {
                            if (cla_data.name_class == comclass.SelectedItem.ToString())
                            {
                                id_d = cla_data.id_class;
                                break;
                            }
                        }
                    }
                    int t_end = int.Parse(label7.Text) + int.Parse(combotimend.SelectedItem.ToString());

                    class_Schedule cla = new class_Schedule();
                    string com = "INSERT INTO `schedule`(`class_id`, `clasrm_id`, `group_id`, `day`, `time_first`, `time_end`) VALUES ('" + id_d + "','" + id_classroom + "','" + Schedules.addSchedule.grou_id + "','" + label6.Text + "','" + int.Parse(label7.Text) + "','" + t_end + "')";
                    string chak = cla.data(com);

                    if (chak == "0")
                    {
                        fom.label2Value = comclass.SelectedItem.ToString();
                        fom.label3Value = combclassroom.SelectedItem.ToString();
                        other_classes oo = new other_classes();
                        string command = "SELECT * FROM `teacher_classes_groups` where class_id='"+ id_d + "' and group_id="+ Schedules.addSchedule.grou_id + "";
                        List<teacher_classes_groups> tee = oo.getteacher_classes_groups(command);
                        Teacher.teacher_Class t = new Teacher.teacher_Class();
                        string command1 = "select * from teacher where id_teacher=" + tee[0].teacher_id + "";
                        List<Teacher.teacher_data> listt = t.getTeacher(command1);
                        fom.label4Value = listt[0].name.ToString();
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
        public void disp()
        {
            try
            {
                Schedule.class_Schedule room = new Schedule.class_Schedule();
                string command = "select * from schedule where day = '" + label6.Text + "' AND time_first = " + int.Parse(label7.Text) + "";
                Schedule_da = room.getSchedule(command);

                if (room.error == "0")
                {
                    if (Schedule_da.Any())
                    {
                        foreach (Schedule_data sc_data in Schedule_da)
                        {
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

        public void updatas_comclass()
        {
            try
            {
                Schedule.class_Schedule room = new Schedule.class_Schedule();
                string command = "select * from schedule where day = '" + label6.Text + "' AND time_first = " + int.Parse(label7.Text) + "";
                Schedule_da = room.getSchedule(command);

                if (room.error == "0")
                {
                    if (Schedule_da.Any())
                    {
                        foreach (Schedule_data sc_data in Schedule_da)
                        {
                            combclassroom.Items.Add(sc_data.clasrm_id);
                            combclassroom.SelectedItem = sc_data.clasrm_id;

                            combotimend.SelectedItem = sc_data.time_end - int.Parse(label7.Text);
                            id_Sched = sc_data.id_schedule;

                            foreach (Classes.class_data cla_data in cls_da1)
                            {
                                if (cla_data.id_class == sc_data.class_id)
                                {
                                    comclass.SelectedItem = cla_data.name_class;
                                }
                            }
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

        void updatas()
        {
            try
            {
                if (comclass.SelectedIndex != -1 && combotype1.SelectedIndex != -1 && combclassroom.SelectedIndex != -1 && combotimend.SelectedIndex != -1)
                {
                    string id_d = "";
                    if (cls_da.Any())
                    {
                        Classes.Class2 cls = new Classes.Class2();
                        string command = "SELECT* FROM classes ";
                        cls_da1 = cls.getclass(command);
                        foreach (Classes.class_data cla_data in cls_da1)
                        {
                            if (cla_data.name_class == comclass.SelectedItem.ToString())
                            {
                                id_d = cla_data.id_class;
                            }
                        }
                    }

                    if (id_d == "")
                    { MessageBox.Show(" خطا في مواد"); }
                    int t_end = int.Parse(label7.Text) + int.Parse(combotimend.SelectedItem.ToString());

                    class_Schedule cla = new class_Schedule();
                    string com = "UPDATE `schedule` SET `class_id`='" + id_d + "',`clasrm_id`='" + id_classroom + "',`group_id`='" + Schedules.addSchedule.grou_id + "',`day`='" + label6.Text + "',`time_first`='" + int.Parse(label7.Text) + "',`time_end`='" + t_end + "' WHERE id_schedule=" + id_Sched + "";

                    string chak = cla.data(com);

                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        fom.label2Value = comclass.SelectedItem.ToString();
                        fom.label3Value = combclassroom.SelectedItem.ToString();
                        fom.label4Value = combotimend.SelectedItem.ToString();
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

        private void view_Load(object sender, EventArgs e)
        {
            label1.Text = Schedules.addSchedule.Depart;
            label9.Text = Schedules.addSchedule.sems;
            label3.Text = Schedules.addSchedule.grou;

            String[] s = { "معمل", "قاعة", "مدرج" };
            combotype1.Items.Clear();
            combotype1.Items.AddRange(s);
            combotype1.SelectedIndex = 1;

            for (int i = 1; i <= 18 - int.Parse(label7.Text); i++)
            {
                combotimend.Items.Add(i);
            }

            clas();
            if (button1.Text != "اضافة")
                updatas_comclass();
        }

        private void combotype1_SelectedIndexChanged(object sender, EventArgs e)
        {
            classroom();
        }

        private void combclassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            label14.Text = "عدد طلبة " + combotype1.SelectedItem;
            if (room_da.Any())
            {
                foreach (Classroom.classroom_data room_data in room_da)
                {
                    if (room_data.state_clasrm == 0)
                    {
                        if (room_data.id_clasrm.ToString() == combclassroom.SelectedItem.ToString())
                        {
                            label13.Text = room_data.num_clasrm.ToString();
                            id_classroom = room_data.id_clasrm;
                        }
                    }
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد حدف مادة من الجدول", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                try
                {
                    class_Schedule cla = new class_Schedule();
                    string com = "delete from schedule WHERE id_schedule=" + id_Sched + "";
                    string chak = cla.data(com);
                    //Check if there is an error in the class or not
                    if (chak == "0")
                    {
                        MessageBox.Show("تمت عملية الحذف بنجاح");
                        fom.label2Value = "";
                        fom.label3Value = "";
                        fom.label4Value = "";
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
    }
}
