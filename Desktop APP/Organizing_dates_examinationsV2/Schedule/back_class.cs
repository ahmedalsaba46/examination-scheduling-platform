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

namespace Organizing_dates_examinationsV2.Schedule
{
    public  partial class back_class : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Database=organizing_dates_examinationsv2;UserId=root;Allow User Variables=True");

        List<Schedule_data> listschedule;
        List<Classes.class_data> listclass;
        List<teacher_classes_groups> listteacher_classes_groups;
        List<Teacher.teacher_data> listteacher;
        void cla()
        {
            string command;
            Classes.Class2 classclass = new Classes.Class2();
            command = "select * from classes ";
            listclass = classclass.getclass(command);

            other_classes other = new other_classes();
             command = "select * from teacher_classes_groups";
            listteacher_classes_groups = other.getteacher_classes_groups(command);

            Teacher.teacher_Class te = new Teacher.teacher_Class();
           command = "select * from teacher";
            listteacher = te.getTeacher(command);
        }
        public back_class()
        {
            InitializeComponent();
             label2.Text = "";
             label3.Text = "";
            label4.Text = "";
            cla();

        }

        public void lab(string nub)
        {
            label1.Text = nub.ToString();
        }
     

        private void back_class_Click(object sender, EventArgs e)
        {
            string[] x = label1.Text.Split('-');

            if (label2.Text.Length != 0)
            {
                view_Sch v = new view_Sch(x[1], x[0], this,1);//insert data
                v.Show();
            }
            else
            {
                view_Sch v = new view_Sch(x[1], x[0], this,0);//update data
                v.Show();
            }

        }


        public void disp()
        {
            try
            {
                string[] x = label1.Text.Split('-');
                Schedule.class_Schedule room = new Schedule.class_Schedule();
                string command = "select * from schedule where group_id =" + Schedules.addSchedule.grou_id + "";
                listschedule = room.getSchedule(command);
                //  MessageBox.Show(command);

                
                if (room.error == "0")
                {
                    if (listschedule.Any())
                    {
                        foreach (Schedule_data sc_data in listschedule)
                        {
                            int w = 2;
                            if (sc_data.day == x[1] && sc_data.time_first == int.Parse(x[0]))
                            {                                
                                    foreach (Classes.class_data cla in listclass)
                                        if (cla.id_class == sc_data.class_id)
                                            label2.Text = cla.name_class;
                                    label3.Text = sc_data.clasrm_id.ToString();
                                    foreach (teacher_classes_groups te in listteacher_classes_groups)
                                        if (te.class_id == sc_data.class_id)
                                            if (te.group_id == sc_data.group_id)
                                                foreach (Teacher.teacher_data teg in listteacher)
                                                    if (teg.id_teacher == te.teacher_id)
                                                        label4.Text = teg.name.ToString();
                                if (sc_data.time_first + w == sc_data.time_end)
                                {
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
        

      

     

        public string label2Value
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        public string label3Value
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }
        public string label4Value
        {
            get { return label4.Text; }
            set { label4.Text = value; }
        }

        private void back_class_Load(object sender, EventArgs e)
        {

        }
    }
}
