
namespace Organizing_dates_examinationsV2.Group
{
    partial class stateGroup
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
            this.combogrp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combosem = new System.Windows.Forms.ComboBox();
            this.combodep = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // combogrp
            // 
            this.combogrp.Enabled = false;
            this.combogrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combogrp.FormattingEnabled = true;
            this.combogrp.Location = new System.Drawing.Point(249, 394);
            this.combogrp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combogrp.Name = "combogrp";
            this.combogrp.Size = new System.Drawing.Size(338, 37);
            this.combogrp.TabIndex = 63;
            this.combogrp.SelectedIndexChanged += new System.EventHandler(this.combogrp_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(656, 376);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 68);
            this.label1.TabIndex = 62;
            this.label1.Text = "اسم المجموعة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(714, 233);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 68);
            this.label6.TabIndex = 61;
            this.label6.Text = "القسم";
            // 
            // combosem
            // 
            this.combosem.Enabled = false;
            this.combosem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combosem.FormattingEnabled = true;
            this.combosem.Location = new System.Drawing.Point(249, 322);
            this.combosem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combosem.Name = "combosem";
            this.combosem.Size = new System.Drawing.Size(338, 37);
            this.combosem.TabIndex = 60;
            this.combosem.SelectedIndexChanged += new System.EventHandler(this.combosem_SelectedIndexChanged);
            // 
            // combodep
            // 
            this.combodep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combodep.FormattingEnabled = true;
            this.combodep.Location = new System.Drawing.Point(249, 249);
            this.combodep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combodep.Name = "combodep";
            this.combodep.Size = new System.Drawing.Size(338, 37);
            this.combodep.TabIndex = 59;
            this.combodep.SelectedIndexChanged += new System.EventHandler(this.combodep_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(689, 308);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 68);
            this.label5.TabIndex = 58;
            this.label5.Text = "السمستر";
            // 
            // state
            // 
            this.state.BackColor = System.Drawing.Color.Transparent;
            this.state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.state.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.state.Font = new System.Drawing.Font("DecoType Naskh Special", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.state.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.state.Location = new System.Drawing.Point(308, 461);
            this.state.Margin = new System.Windows.Forms.Padding(4);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(190, 76);
            this.state.TabIndex = 64;
            this.state.Text = "تغير الحالة";
            this.state.UseVisualStyleBackColor = false;
            this.state.Visible = false;
            this.state.Click += new System.EventHandler(this.state_Click);
            // 
            // stateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(108)))), ((int)(((byte)(151)))));
            this.ClientSize = new System.Drawing.Size(1089, 726);
            this.Controls.Add(this.state);
            this.Controls.Add(this.combogrp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combosem);
            this.Controls.Add(this.combodep);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "stateGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "stateGroup";
            this.Load += new System.EventHandler(this.stateGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combogrp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combosem;
        private System.Windows.Forms.ComboBox combodep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button state;
    }
}