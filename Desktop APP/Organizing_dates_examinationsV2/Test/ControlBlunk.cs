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
    public partial class ControlBlunk : UserControl
    {
        public ControlBlunk()
        {
            InitializeComponent();
            label1.Text = "";
        }

        public ControlBlunk(int lab ,int month, int year)
        {
            InitializeComponent();
            label1.Text = lab + "/" + month + "/" + year;
        }
    }
}
