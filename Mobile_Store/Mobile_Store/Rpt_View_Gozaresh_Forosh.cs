using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Mobile_Store
{
    public partial class Rpt_View_Gozaresh_Forosh : Form
    {
        ContextContainer context = new ContextContainer();
        List<ForoshNaghdi> lst_forosh = new List<ForoshNaghdi>();
        string Tarikh_start, Tarikh_end; int  jamhe_tehdad;long jamhe_mablagh;
        public Rpt_View_Gozaresh_Forosh(List<ForoshNaghdi > list_forosh,string date_start,string date_end,int  tedad,long mablagh)
        {
            this.lst_forosh = list_forosh;
            this.Tarikh_start = date_start;
            this.Tarikh_end = date_end;
            this.jamhe_tehdad = tedad;
            this.jamhe_mablagh = mablagh;
            InitializeComponent();
        }
        private void Rpt_Gozaresh_Forosh()
        {
            int number = 0; long jamh;
           
            foreach (var item in lst_forosh)
            {
                number++;
                jamh = (item.Count * item.Ghimat_vahed);
                DataSet_Store.Tables["Forosh"].Rows.Add(new object[] { number.ToString(), item.Name_kala, item.Model_kala, item.Count.ToString(), item.Ghimat_vahed.ToString (), jamh.ToString(),item.Name_Moshtari ,item.Date_Forosh  });
            }
        }
        private List<ReportParameter> Load_Parameter()
        {
            List<ReportParameter> lst_param = new List<ReportParameter>();
            ReportParameter p_start = new ReportParameter("p_start_tarikh",Tarikh_start);
            ReportParameter p_end = new ReportParameter("p_end_tarikh", Tarikh_end );
            ReportParameter p_tehdad = new ReportParameter("p_jamhe_tehdad", jamhe_tehdad.ToString () );
            ReportParameter p_mablagh = new ReportParameter("p_jamhe_mablagh", jamhe_mablagh .ToString ());

            lst_param.Add(p_start);
            lst_param.Add(p_end);
            lst_param.Add(p_tehdad);
            lst_param.Add(p_mablagh);

            return lst_param;
        }
        private void Frm_View_Gozaresh_Forosh_Load(object sender, EventArgs e)
        {
            Rpt_Gozaresh_Forosh();
            List<ReportParameter> lst_param = Load_Parameter();
            reportViewer1.LocalReport.SetParameters(lst_param);
            this.reportViewer1.RefreshReport();
        }
    }
}
