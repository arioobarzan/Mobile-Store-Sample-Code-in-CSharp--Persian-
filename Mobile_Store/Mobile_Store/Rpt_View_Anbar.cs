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
    public partial class Rpt_View_Anbar : Form
    {
        ContextContainer context = new ContextContainer();
        List<Anbar> lst_anbar = new List<Anbar>();
        string Tarikh; long jamhe_tehdad, jamhe_mablagh;
        public Rpt_View_Anbar(List<Anbar > list_anbar,string tarikh,long tehdad,long mablagh )
        {
            this.lst_anbar = list_anbar;
            this.Tarikh = tarikh;
            this.jamhe_tehdad = tehdad;
            this.jamhe_mablagh = mablagh;
            InitializeComponent();
        }
        private void Rpt_Mojodi_Anbar()
        {
            int number = 0;
            var q = lst_anbar.OrderBy(o => o.Name_kala).ThenBy(o => o.Count_kala);
            foreach (var item in q)
            {
                number++;
                DataSet_Store.Tables["Mojodi_Anbar"].Rows.Add(new object[] { number.ToString(),item.Name_kala ,item .Model_kala ,item.Count_kala.ToString () ,item.Ghimat_vahed .ToString (),item.Ghimat_forosh .ToString () });
            }
        }
        private List<ReportParameter> Load_Parameter()
        {
            List<ReportParameter> lst_param = new List<ReportParameter>();
            ReportParameter p_date = new ReportParameter("p_tarikh", Tarikh);
            ReportParameter p_tedad = new ReportParameter("p_jamhe_tehdad", jamhe_tehdad.ToString () );
            ReportParameter p_mablagh = new ReportParameter("p_jamhe_mablagh", jamhe_mablagh .ToString ());

            lst_param.Add(p_date);
            lst_param.Add(p_tedad);
            lst_param.Add(p_mablagh);

            return lst_param;
        }
        private void Rpt_View_Anbar_Load(object sender, EventArgs e)
        {
            Rpt_Mojodi_Anbar();
            List<ReportParameter> lst_param = Load_Parameter();
            reportViewer1.LocalReport.SetParameters(lst_param);
            this.reportViewer1.RefreshReport();
        }
    }
}
