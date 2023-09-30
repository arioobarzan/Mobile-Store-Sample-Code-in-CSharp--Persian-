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
    public partial class Rpt_View_Forosh : Form
    {
        ContextContainer context = new ContextContainer();
        List<ForoshNaghdi> lst_forosh = new List<ForoshNaghdi>();
        int Factor; long Takhfif_factor, Mablegh_kol; string tarikh, Moshteri;
        public Rpt_View_Forosh(int factor,long takhfif,long mablegh_kol)
        {
            this.Factor = factor;
            this.Takhfif_factor = takhfif;
            this.Mablegh_kol = mablegh_kol;
            InitializeComponent();
        }
        private List<ReportParameter> Load_Parameter()
        {
            List<ReportParameter> lst_param = new List<ReportParameter>();
            ReportParameter p_takhfif = new ReportParameter("p_takhfif", Takhfif_factor.ToString());
            ReportParameter p_mablagh_kol = new ReportParameter("p_mablagh", Mablegh_kol.ToString());
            ReportParameter p_tarikh = new ReportParameter("p_tarikh", tarikh );
            ReportParameter p_moshteri = new ReportParameter("p_moshteri", Moshteri);

            lst_param.Add(p_takhfif);
            lst_param.Add(p_mablagh_kol);
            lst_param.Add(p_tarikh);
            lst_param.Add(p_moshteri);

            return lst_param;
        }
        private void Rpt_Factor_Forosh()
        {
            int number = 0;long jamh;
            var q_factor = context.Foroshes.Where(k => k.Factor == Factor).OfType <ForoshNaghdi >();
            foreach (var item in q_factor)
            {
                number++;
                jamh =(item .Count * item .Ghimat_vahed );
                DataSet_Store.Tables["Forosh"].Rows.Add(new object[] { number.ToString() , item.Name_kala, item.Model_kala, item.Count.ToString(), item.Ghimat_vahed.ToString (), jamh.ToString(),item.Name_Moshtari ,item .Date_Forosh  });
            }
            foreach (var item in q_factor)
            {
                tarikh = item.Date_Forosh;
                Moshteri = item.Name_Moshtari;
            }
        }
        private void Rpt_View_Forosh_Load(object sender, EventArgs e)
        {
            Rpt_Factor_Forosh();
            List<ReportParameter> lst_param = Load_Parameter();
            reportViewer1.LocalReport.SetParameters(lst_param);
            this.reportViewer1.RefreshReport();
        }
    }
}
