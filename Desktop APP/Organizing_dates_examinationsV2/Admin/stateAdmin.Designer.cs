
namespace Organizing_dates_examinationsV2.Admin
{
    partial class stateAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stateAdmin));
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.search2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.id2 = new System.Windows.Forms.TextBox();
            this.state = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Font = new System.Drawing.Font("Century Schoolbook", 8F);
            this.panel4.Location = new System.Drawing.Point(94, 283);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(714, 335);
            this.panel4.TabIndex = 19;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(4, 5);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(703, 325);
            this.dataGridView2.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.search2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.id2);
            this.panel2.Location = new System.Drawing.Point(94, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 122);
            this.panel2.TabIndex = 18;
            // 
            // search2
            // 
            this.search2.BackgroundImage = global::Organizing_dates_examinationsV2.Properties.Resources.Search_icon;
            this.search2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search2.Location = new System.Drawing.Point(24, 27);
            this.search2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search2.Name = "search2";
            this.search2.Size = new System.Drawing.Size(129, 65);
            this.search2.TabIndex = 14;
            this.search2.UseVisualStyleBackColor = true;
            this.search2.Click += new System.EventHandler(this.search2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("DecoType Naskh Special", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(523, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 68);
            this.label6.TabIndex = 14;
            this.label6.Text = "الرقم الوظيفي";
            // 
            // id2
            // 
            this.id2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id2.Location = new System.Drawing.Point(162, 43);
            this.id2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.id2.MaxLength = 11;
            this.id2.Name = "id2";
            this.id2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.id2.Size = new System.Drawing.Size(350, 36);
            this.id2.TabIndex = 14;
            this.id2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id2_KeyPress);
            // 
            // state
            // 
            this.state.BackColor = System.Drawing.Color.Transparent;
            this.state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.state.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.state.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.state.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.state.Location = new System.Drawing.Point(98, 636);
            this.state.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(218, 69);
            this.state.TabIndex = 17;
            this.state.Text = "تفعيل";
            this.state.UseVisualStyleBackColor = false;
            this.state.Click += new System.EventHandler(this.button1_Click);
            // 
            // stateAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(108)))), ((int)(((byte)(151)))));
            this.ClientSize = new System.Drawing.Size(866, 782);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.state);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "stateAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الصلاحيات";
            this.Load += new System.EventHandler(this.stateAdmin_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button state;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button search2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox id2;
    }
}