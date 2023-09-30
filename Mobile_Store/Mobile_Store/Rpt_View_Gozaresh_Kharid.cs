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
    public partial class Rpt_View_Gozaresh_Kharid : Form
    {
        ContextContainer context = new ContextContainer();
        List<Kharid> lst_kharid = new List<Kharid>();
        string Tarikh_start, Tarikh_end; int jamhe_tehdad; long jamhe_mablagh;
        public Rpt_View_Gozaresh_Kharid(List <Kharid > list_kharid,string date_start,string date_end,int tehdad,long mablagh)
        {
            this.lst_kharid = list_kharid;
            this.Tarikh_start = date_start;
            this.Tarikh_end = date_end;
            this.jamhe_tehdad = tehdad;
            this.jamhe_mablagh = mablagh;
            InitializeComponent();
        }
        private void Rpt_Gozaresh_Kharid()
        {
            int number = 0; long jamh;

            foreach (var item in lst_kharid)
            {
                number++;
                jamh = (item.Count * item.Ghimat_vahed);
                DataSet_Store.Tables["Kharid"].Rows.Add(new object[] { number.ToString(),item.Name_Foroshandeh , item.Name_kala, item.Model_kala,item.Serial , item.Count.ToString(), item.Ghimat_vahed.ToString(), jamh.ToString(), item.Date_kharid });
            }
        }
        private List<ReportParameter> Load_Parameter()
        {
            List<ReportParameter> lst_param = new List<ReportParameter>();
            ReportParameter p_start = new ReportParameter("p_tarikh_start", Tarikh_start);
            ReportParameter p_end = new ReportParameter("p_tarikh_end", Tarikh_end);
            ReportParameter p_tehdad = new ReportParameter("p_jamhe_tehdad", jamhe_tehdad.ToString());
            ReportParameter p_mablagh = new ReportParameter("p_jamhe_mablagh", jamhe_mablagh.ToString());

            lst_param.Add(p_start);
            lst_param.Add(p_end);
            lst_param.Add(p_tehdad);
            lst_param.Add(p_mablagh);

            return lst_param;
        }
        private void Rpt_View_Gozaresh_Kharid_Load(object sender, EventArgs e)
        {
            List<ReportParameter> lst_param = Load_Parameter();
            reportViewer1.LocalReport.SetParameters(lst_param);
            Rpt_Gozaresh_Kharid();
            this.reportViewer1.RefreshReport();
        }
    }
}
