
namespace Organizing_dates_examinationsV2.Classroom
{
    partial class addClassroom
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
            this.alert = new System.Windows.Forms.Label();
            this.numstd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combotype = new System.Windows.Forms.ComboBox();
            this.name_1 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // alert
            // 
            this.alert.AutoSize = true;
            this.alert.BackColor = System.Drawing.Color.Transparent;
            this.alert.Font = new System.Drawing.Font("Century Schoolbook", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alert.ForeColor = System.Drawing.Color.Red;
            this.alert.Location = new System.Drawing.Point(424, 373);
            this.alert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(182, 20);
            this.alert.TabIndex = 31;
            this.alert.Text = "الرقم يجب ان يبدأ من 1 الى 4 فقط";
            // 
            // numstd
            // 
            this.numstd.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numstd.Location = new System.Drawing.Point(429, 439);
            this.numstd.Margin = new System.Windows.Forms.Padding(4);
            this.numstd.MaxLength = 3;
            this.numstd.Name = "numstd";
            this.numstd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numstd.Size = new System.Drawing.Size(230, 36);
            this.numstd.TabIndex = 30;
            this.numstd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numstd_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(734, 227);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 68);
            this.label6.TabIndex = 29;
            this.label6.Text = "النوع";
            // 
            // combotype
            // 
            this.combotype.FormattingEnabled = true;
            this.combotype.Location = new System.Drawing.Point(429, 249);
            this.combotype.Margin = new System.Windows.Forms.Padding(4);
            this.combotype.Name = "combotype";
            this.combotype.Size = new System.Drawing.Size(230, 27);
            this.combotype.TabIndex = 27;
            this.combotype.SelectedIndexChanged += new System.EventHandler(this.combotype_SelectedIndexChanged);
            // 
            // name_1
            // 
            this.name_1.AutoSize = true;
            this.name_1.BackColor = System.Drawing.Color.Transparent;
            this.name_1.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.name_1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.name_1.Location = new System.Drawing.Point(328, 314);
            this.name_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_1.Name = "name_1";
            this.name_1.Size = new System.Drawing.Size(78, 68);
            this.name_1.TabIndex = 20;
            this.name_1.Text = "الاسم";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.BackgroundImage = global::Organizing_dates_examinationsV2.Properties.Resources._1486485588_add_create_new_math_sign_cross_plus_81186;
            this.add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(66, 544);
            this.add.Margin = new System.Windows.Forms.Padding(4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(156, 98);
            this.add.TabIndex = 26;
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(732, 314);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 68);
            this.label3.TabIndex = 21;
            this.label3.Text = "الرقم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(670, 424);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 68);
            this.label4.TabIndex = 22;
            this.label4.Text = "عدد الطلبة";
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(429, 329);
            this.id.Margin = new System.Windows.Forms.Padding(4);
            this.id.Name = "id";
            this.id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.id.Size = new System.Drawing.Size(230, 36);
            this.id.TabIndex = 25;
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_KeyPress);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(66, 329);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.MaxLength = 20;
            this.name.Name = "name";
            this.name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name.Size = new System.Drawing.Size(252, 36);
            this.name.TabIndex = 24;
            this.name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.name_KeyPress);
            // 
            // addClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(108)))), ((int)(((byte)(151)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(953, 720);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.numstd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combotype);
            this.Controls.Add(this.name_1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id);
            this.Controls.Add(this.name);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "addClassroom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addClassroom";
            this.Load += new System.EventHandler(this.addClassroom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label alert;
        private System.Windows.Forms.TextBox numstd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combotype;
        private System.Windows.Forms.Label name_1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox name;
    }
}