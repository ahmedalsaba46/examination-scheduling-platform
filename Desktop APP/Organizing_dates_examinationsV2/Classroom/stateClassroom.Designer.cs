
namespace Organizing_dates_examinationsV2.Classroom
{
    partial class stateClassroom
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.state = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.name_11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            this.num_st = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(232, 170);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 41);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // state
            // 
            this.state.BackColor = System.Drawing.Color.Transparent;
            this.state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.state.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.state.Font = new System.Drawing.Font("DecoType Naskh Special", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.state.ForeColor = System.Drawing.Color.Lime;
            this.state.Location = new System.Drawing.Point(199, 522);
            this.state.Margin = new System.Windows.Forms.Padding(4);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(189, 101);
            this.state.TabIndex = 25;
            this.state.Text = "تغير الحالة";
            this.state.UseVisualStyleBackColor = false;
            this.state.Visible = false;
            this.state.Click += new System.EventHandler(this.state_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(511, 221);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 68);
            this.label7.TabIndex = 34;
            this.label7.Text = "النوع";
            // 
            // name_11
            // 
            this.name_11.AutoSize = true;
            this.name_11.BackColor = System.Drawing.Color.Transparent;
            this.name_11.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.name_11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.name_11.Location = new System.Drawing.Point(511, 356);
            this.name_11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_11.Name = "name_11";
            this.name_11.Size = new System.Drawing.Size(78, 68);
            this.name_11.TabIndex = 31;
            this.name_11.Text = "الاسم";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(516, 288);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 68);
            this.label9.TabIndex = 32;
            this.label9.Text = "الرقم";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(460, 420);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 68);
            this.label10.TabIndex = 33;
            this.label10.Text = "عدد الطلبة";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.BackColor = System.Drawing.Color.Transparent;
            this.type.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.type.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.type.Location = new System.Drawing.Point(292, 221);
            this.type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(68, 68);
            this.type.TabIndex = 38;
            this.type.Text = "النوع";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.name.Location = new System.Drawing.Point(290, 356);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(78, 68);
            this.name.TabIndex = 35;
            this.name.Text = "الاسم";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.BackColor = System.Drawing.Color.Transparent;
            this.number.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.number.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.number.Location = new System.Drawing.Point(295, 288);
            this.number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(71, 68);
            this.number.TabIndex = 36;
            this.number.Text = "الرقم";
            // 
            // num_st
            // 
            this.num_st.AutoSize = true;
            this.num_st.BackColor = System.Drawing.Color.Transparent;
            this.num_st.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.num_st.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.num_st.Location = new System.Drawing.Point(240, 420);
            this.num_st.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.num_st.Name = "num_st";
            this.num_st.Size = new System.Drawing.Size(127, 68);
            this.num_st.TabIndex = 37;
            this.num_st.Text = "عدد الطلبة";
            this.num_st.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stateClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(108)))), ((int)(((byte)(151)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(827, 729);
            this.Controls.Add(this.type);
            this.Controls.Add(this.name);
            this.Controls.Add(this.number);
            this.Controls.Add(this.num_st);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.name_11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.state);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "stateClassroom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "stateClassroom";
            this.Load += new System.EventHandler(this.stateClassroom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button state;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label name_11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Label num_st;
    }
}