using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2.Report
{
    public partial class print_test : Form
    {
        List<Classes.class_data> listclass;
        List<Classroom.classroom_data> room_da;
        List<Department.deprtment_data> dep;
        List<Teacher.teacher_data> tea_da;
        List<Test.test_data> tess;
        List<Group.groups_data> listgroup;
        public print_test()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            using (print frm = new print(this.dataSet_Test1.Test, dateTimePicker1.Text))
            {
                frm.ShowDialog();
            }
        }


        private void show()
        {
            string command1;
            try
            {


                dataSet_Test1.Test.Clear();
                Test.test_class tes = new Test.test_class();
                command1 = "select * from test  ";
                tess = tes.getTest(command1);
                if (tes.error == "0")
                {
                    foreach (Test.test_data tss in tess)
                    {
                        if (tss.date_test == DateTime.Parse(dateTimePicker1.Text))
                        {
                            Classes.Class2 cl = new Classes.Class2();
                            command1 = "select * from classes where id_class='" + tss.class_id + "'";
                            listclass = cl.getclass(command1);

                            if (cl.error == "0")
                            {
                                if (listclass.Any())
                                {
                                    Teacher.teacher_Class te = new Teacher.teacher_Class();
                                    command1 = "select * from teacher where id_teacher='" + tss.teacher_id + "'";
                                    tea_da = te.getTeacher(command1);

                                    if (te.error == "0")
                                    {
                                        if (tea_da.Any())
                                        {
                                            Classroom.classroom_class classr = new Classroom.classroom_class();
                                            command1 = "select * from classroom where id_clasrm=" + tss.clasrm_id + "";
                                            room_da = classr.getdepartment(command1);

                                            if (classr.error == "0")
                                            {
                                                if (room_da.Any())
                                                {
                                                    Group.groups gr = new Group.groups();
                                                    string command = "SELECT* FROM groups where id_group=" + tss.group_id;
                                                    listgroup = gr.getgroups(command);

                                                    if (gr.error == "0")
                                                    {
                                                        if (listgroup.Any())
                                                        {
                                                            Department.departments_class depar = new Department.departments_class();
                                                            command1 = "select * from department where id_deprtment='" + listgroup[0].department_id + "'";

                                                            dep = depar.getdepartment(command1);

                                                            if (depar.error == "0")
                                                            {
                                                                if (dep.Any())
                                                                {
                                                                    //   MessageBox.Show(""+ tss.id_test.ToString() + "\n" + listgroup[0].name_group + "\n" + dep[0].name_department + "\n" + listclass[0].name_class + "\n" + tss.time_first+ tss.time_end+"\n"+ tss.note + "\n" + tea_da[0].name + "\n" + listgroup[0].semster_id.ToString());
                                                                    this.dataSet_Test1.Test.AddTestRow(tss.id_test.ToString(), listgroup[0].name_group, dep[0].name_department, listclass[0].name_class, tss.time_first, tss.time_end, tss.note, tea_da[0].name, listgroup[0].semster_id.ToString());
                                                                }
                                                                else
                                                                    MessageBox.Show("هناك مشكلة في القسم");
                                                            }
                                                            else
                                                                MessageBox.Show(depar.error);
                                                        }
                                                        else
                                                            MessageBox.Show("هناك مشكلة في المجموعة");
                                                    }
                                                    else
                                                        MessageBox.Show(gr.error);
                                                }
                                                else
                                                    MessageBox.Show("هناك مشكلة في المواد القاعة");
                                            }
                                            else
                                                MessageBox.Show(classr.error);
                                        }
                                        else
                                            MessageBox.Show("هناك مشكلة في دكتور");
                                    }
                                    else
                                        MessageBox.Show(te.error);
                                }
                                else
                                    MessageBox.Show("هناك مشكلة في المواد");
                            }
                            else
                                MessageBox.Show(cl.error);
                        }
                    }
                   
                    dataGridView1.DataSource = dataSet_Test1.Test;

                }
                else
                    MessageBox.Show(tes.error);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void print_test_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         
            show();
        }
    }
}
