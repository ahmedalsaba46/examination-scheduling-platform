
namespace Organizing_dates_examinationsV2.Teacher
{
    partial class addTeacher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxclass = new System.Windows.Forms.ListBox();
            this.checkclass = new System.Windows.Forms.CheckBox();
            this.comboclass = new System.Windows.Forms.ComboBox();
            this.labelclass = new System.Windows.Forms.Label();
            this.combodgree = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labeldep = new System.Windows.Forms.Label();
            this.combosem = new System.Windows.Forms.ComboBox();
            this.combodep = new System.Windows.Forms.ComboBox();
            this.labelsem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.user_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.sign_in = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxclass
            // 
            this.listBoxclass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listBoxclass.FormattingEnabled = true;
            this.listBoxclass.ItemHeight = 19;
            this.listBoxclass.Location = new System.Drawing.Point(56, 383);
            this.listBoxclass.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxclass.Name = "listBoxclass";
            this.listBoxclass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxclass.Size = new System.Drawing.Size(332, 175);
            this.listBoxclass.TabIndex = 57;
            this.listBoxclass.Visible = false;
            // 
            // checkclass
            // 
            this.checkclass.AutoSize = true;
            this.checkclass.BackColor = System.Drawing.Color.Transparent;
            this.checkclass.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.checkclass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkclass.Location = new System.Drawing.Point(433, 310);
            this.checkclass.Margin = new System.Windows.Forms.Padding(4);
            this.checkclass.Name = "checkclass";
            this.checkclass.Size = new System.Drawing.Size(117, 32);
            this.checkclass.TabIndex = 55;
            this.checkclass.Text = "اضافة مواد";
            this.checkclass.UseVisualStyleBackColor = false;
            this.checkclass.CheckedChanged += new System.EventHandler(this.checkclass_CheckedChanged);
            // 
            // comboclass
            // 
            this.comboclass.Enabled = false;
            this.comboclass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboclass.FormattingEnabled = true;
            this.comboclass.Location = new System.Drawing.Point(540, 528);
            this.comboclass.Margin = new System.Windows.Forms.Padding(4);
            this.comboclass.Name = "comboclass";
            this.comboclass.Size = new System.Drawing.Size(230, 27);
            this.comboclass.TabIndex = 54;
            this.comboclass.Visible = false;
            this.comboclass.SelectedIndexChanged += new System.EventHandler(this.comboclass_SelectedIndexChanged);
            // 
            // labelclass
            // 
            this.labelclass.AutoSize = true;
            this.labelclass.BackColor = System.Drawing.Color.Transparent;
            this.labelclass.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelclass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelclass.Location = new System.Drawing.Point(928, 506);
            this.labelclass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelclass.Name = "labelclass";
            this.labelclass.Size = new System.Drawing.Size(72, 68);
            this.labelclass.TabIndex = 53;
            this.labelclass.Text = "المادة";
            this.labelclass.Visible = false;
            // 
            // combodgree
            // 
            this.combodgree.ForeColor = System.Drawing.SystemColors.ControlText;
            this.combodgree.FormattingEnabled = true;
            this.combodgree.Items.AddRange(new object[] {
            "دكتور",
            "محاضر",
            "متعاون"});
            this.combodgree.Location = new System.Drawing.Point(568, 310);
            this.combodgree.Margin = new System.Windows.Forms.Padding(4);
            this.combodgree.Name = "combodgree";
            this.combodgree.Size = new System.Drawing.Size(208, 27);
            this.combodgree.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(855, 293);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 68);
            this.label6.TabIndex = 51;
            this.label6.Text = "الرتبة العلمية";
            // 
            // labeldep
            // 
            this.labeldep.AutoSize = true;
            this.labeldep.BackColor = System.Drawing.Color.Transparent;
            this.labeldep.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labeldep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labeldep.Location = new System.Drawing.Point(919, 361);
            this.labeldep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeldep.Name = "labeldep";
            this.labeldep.Size = new System.Drawing.Size(81, 68);
            this.labeldep.TabIndex = 50;
            this.labeldep.Text = "القسم";
            this.labeldep.Visible = false;
            // 
            // combosem
            // 
            this.combosem.Enabled = false;
            this.combosem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.combosem.FormattingEnabled = true;
            this.combosem.Items.AddRange(new object[] {
            "1",
            "2"});
            this.combosem.Location = new System.Drawing.Point(540, 454);
            this.combosem.Margin = new System.Windows.Forms.Padding(4);
            this.combosem.Name = "combosem";
            this.combosem.Size = new System.Drawing.Size(230, 27);
            this.combosem.TabIndex = 49;
            this.combosem.Visible = false;
            this.combosem.SelectedIndexChanged += new System.EventHandler(this.combosem_SelectedIndexChanged);
            // 
            // combodep
            // 
            this.combodep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.combodep.FormattingEnabled = true;
            this.combodep.Items.AddRange(new object[] {
            "البرمجة"});
            this.combodep.Location = new System.Drawing.Point(540, 383);
            this.combodep.Margin = new System.Windows.Forms.Padding(4);
            this.combodep.Name = "combodep";
            this.combodep.Size = new System.Drawing.Size(230, 27);
            this.combodep.TabIndex = 48;
            this.combodep.Visible = false;
            this.combodep.SelectedIndexChanged += new System.EventHandler(this.combodep_SelectedIndexChanged);
            // 
            // labelsem
            // 
            this.labelsem.AutoSize = true;
            this.labelsem.BackColor = System.Drawing.Color.Transparent;
            this.labelsem.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelsem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelsem.Location = new System.Drawing.Point(893, 432);
            this.labelsem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelsem.Name = "labelsem";
            this.labelsem.Size = new System.Drawing.Size(106, 68);
            this.labelsem.TabIndex = 47;
            this.labelsem.Text = "السمستر";
            this.labelsem.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(855, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 68);
            this.label2.TabIndex = 37;
            this.label2.Text = "الرقم الوظيفي";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(924, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 68);
            this.label3.TabIndex = 38;
            this.label3.Text = "الاسم";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.SystemColors.ControlText;
            this.password.Location = new System.Drawing.Point(433, 243);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.password.Size = new System.Drawing.Size(343, 36);
            this.password.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(848, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 68);
            this.label4.TabIndex = 39;
            this.label4.Text = "اسم المستخدم";
            // 
            // user_name
            // 
            this.user_name.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.user_name.Location = new System.Drawing.Point(433, 179);
            this.user_name.Margin = new System.Windows.Forms.Padding(4);
            this.user_name.Name = "user_name";
            this.user_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.user_name.Size = new System.Drawing.Size(343, 36);
            this.user_name.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(869, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 68);
            this.label5.TabIndex = 40;
            this.label5.Text = "الرقم السري";
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.name.Location = new System.Drawing.Point(433, 110);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.Name = "name";
            this.name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name.Size = new System.Drawing.Size(343, 36);
            this.name.TabIndex = 42;
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.SystemColors.ControlText;
            this.id.Location = new System.Drawing.Point(433, 40);
            this.id.Margin = new System.Windows.Forms.Padding(4);
            this.id.Name = "id";
            this.id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.id.Size = new System.Drawing.Size(343, 36);
            this.id.TabIndex = 41;
            // 
            // sign_in
            // 
            this.sign_in.BackColor = System.Drawing.Color.Transparent;
            this.sign_in.BackgroundImage = global::Organizing_dates_examinationsV2.Properties.Resources._1486485588_add_create_new_math_sign_cross_plus_81186;
            this.sign_in.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sign_in.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sign_in.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sign_in.Location = new System.Drawing.Point(67, 273);
            this.sign_in.Margin = new System.Windows.Forms.Padding(4);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(189, 95);
            this.sign_in.TabIndex = 58;
            this.sign_in.UseVisualStyleBackColor = false;
            this.sign_in.Click += new System.EventHandler(this.sign_in_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.Transparent;
            this.clear.BackgroundImage = global::Organizing_dates_examinationsV2.Properties.Resources.Clear_37294;
            this.clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clear.Enabled = false;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear.Font = new System.Drawing.Font("Century Schoolbook", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clear.Location = new System.Drawing.Point(276, 292);
            this.clear.Margin = new System.Windows.Forms.Padding(4);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(93, 60);
            this.clear.TabIndex = 56;
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Visible = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // addTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(108)))), ((int)(((byte)(151)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 732);
            this.Controls.Add(this.sign_in);
            this.Controls.Add(this.listBoxclass);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.checkclass);
            this.Controls.Add(this.comboclass);
            this.Controls.Add(this.labelclass);
            this.Controls.Add(this.combodgree);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labeldep);
            this.Controls.Add(this.combosem);
            this.Controls.Add(this.combodep);
            this.Controls.Add(this.labelsem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.name);
            this.Controls.Add(this.id);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "addTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addTeacher";
            this.Load += new System.EventHandler(this.addTeacher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxclass;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.CheckBox checkclass;
        private System.Windows.Forms.ComboBox comboclass;
        private System.Windows.Forms.Label labelclass;
        private System.Windows.Forms.ComboBox combodgree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labeldep;
        private System.Windows.Forms.ComboBox combosem;
        private System.Windows.Forms.ComboBox combodep;
        private System.Windows.Forms.Label labelsem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button sign_in;
    }
}