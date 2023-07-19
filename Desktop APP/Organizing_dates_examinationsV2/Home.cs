using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizing_dates_examinationsV2
{
    public partial class Home : Form
    {
        string pos, name1;
        public Home(String position,String name)
        {
            InitializeComponent();
            hideSubMenu();
            pos = position;
            name1 = name;



         
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if(pos == "User")
            {
                btnMedia.Visible = false;
                btnPlaylist.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            // panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            panelChildForm.Controls.Add(childForm);

            if (childForm.Name == "addSchedule")
            {
                childForm.Dock = DockStyle.None;
                this.Size = new Size(childForm.Width + 200, childForm.Height+100);
            }
            else if (childForm.Name == "addTest")
            {
                childForm.Dock = DockStyle.None;
                this.Size = new Size(childForm.Width + 200, childForm.Height+20);
            }
            else
            {
                childForm.Dock = DockStyle.None;
                this.Size = new Size(1080, 650);
                childForm.Location = new Point((panelChildForm.Width - childForm.Width - 50)/ 2, 50);
            }

            panelChildForm.Tag = childForm;
            childForm.BringToFront();
             this.StartPosition = FormStartPosition.CenterParent;
            childForm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Admin.editAdmin());          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Admin.stateAdmin());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new addUser());
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Admin.addAdmin() );
            hideSubMenu();
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        { 
            hideSubMenu();
            openChildForm(new User.editUser());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new User.stateUser());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classroom.addClassroom());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classroom.editClassroom());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classroom.stateClassroom());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classes.addClass());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classes.editClass());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Classes.stateClass());
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Schedules.addSchedule());
            hideSubMenu();
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new test.addTest());
        }

        private void button31_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Group.addGroup());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Group.editGroup());
        }

        private void button14_Click(object sender, EventArgs e)
        {

            hideSubMenu();
            openChildForm(new Group.stateGroup());
        }

        private void button27_Click(object sender, EventArgs e)
        {
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            openChildForm(new Schedules.addSchedule());
            hideSubMenu();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            openChildForm(new test.addTest());
            hideSubMenu();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            openChildForm(new Teacher.addTeacher());
            hideSubMenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            openChildForm(new Teacher.editTeacher());
            hideSubMenu();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            openChildForm(new Teacher.stateTeacher());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Department.addDepartment());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Department.editDepartment());
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Department.stateDepartment());
            hideSubMenu();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت تريد تريد فتح فصل دراسي جديد", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
            {
                MessageBox.Show("سيتم حذف بيانات المجموعات والطلاب والامتحانات والجداول الددراسية");
                if (MessageBox.Show("هل انت متأكد من الحذف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                {

                }
            }
        }
    }
}
