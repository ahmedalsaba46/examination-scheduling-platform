using Microsoft.Reporting.WinForms;
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
    public partial class print : Form
    {
        Report.DataSet_Test.TestDataTable _print_data;
        string dat;
        public print()
        {
            InitializeComponent();
        }

       
        public print(Report.DataSet_Test.TestDataTable pri, string dates)
        {
            InitializeComponent();
            dat = dates;
            this._print_data = pri;
        }

        private void print_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            try
            {
                Report.DataSet_Test.TestDataTable vl;
                vl = _print_data;
                ReportDataSource re = new ReportDataSource();
                re.Name = "DataSet1";
                re.Value = vl;
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(re);

                ReportParameter parameters = new ReportParameter();
                parameters = new ReportParameter("ReportParameter1", dat.ToString());

                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("  مشكلة طباعة\n" + ex.ToString());
            }
        }
    }
}
