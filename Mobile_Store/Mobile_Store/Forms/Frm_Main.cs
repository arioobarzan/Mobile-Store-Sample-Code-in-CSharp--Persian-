using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Mobile_Store.Forms
{
    public partial class Frm_Main : Form
    {
        string Type_user;

        int day, month, year; string str_day_of_week, str_month_of_year;
        PersianCalendar pc = new PersianCalendar();
        public Frm_Main(string type)
        {
            this.Type_user = type;
            InitializeComponent();
        }

        private void Date()
        {
            DateTime dt = DateTime.Today;
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);
            int mah_sal = pc.GetMonth(dt);
            DayOfWeek roz_hafte = pc.GetDayOfWeek(dt);
          //  lab_roze_hafte.Text =Day_Of_Week( Convert.ToInt32(roz_hafte));
          //  lab_mah_sal.Text =Month_Of_Year ( mah_sal);
            lab1_date.Text = Day_Of_Week(Convert.ToInt32(roz_hafte)) + "  " + day.ToString() + " " + Month_Of_Year(mah_sal) + " " + "ماه";
            lab2_date.Text = "سال" + " " + year.ToString() +" "+ "شمسی";
        }

        private string Day_Of_Week(int number_roz_hafteh)
        {
            
            switch (number_roz_hafteh)
            {
                case 1:
                    str_day_of_week = "دوشنبه";
                    break;
                case 2:
                    str_day_of_week = "سه شنبه";
                    break;
                case 3:
                    str_day_of_week = "چهار شنبه";
                    break;
                case 4:
                    str_day_of_week = "پنج شنبه";
                    break;
                case 5:
                    str_day_of_week = "جمعه";
                    break;
                case 6:
                    str_day_of_week = "شنبه";
                    break;
                case 0:
                    str_day_of_week = "یکشنبه";
                    break;
           
            }
            return str_day_of_week;
        }
        private string Month_Of_Year(int number_mah_sal)
        {
            switch (number_mah_sal)
            {
                case 1:
                    str_month_of_year = "فروردین";
                    break;
                case 2:
                    str_month_of_year = "اردیبهشت";
                    break;
                case 3:
                    str_month_of_year = "خرداد";
                    break;
                case 4:
                    str_month_of_year = "تیر";
                    break;
                case 5:
                    str_month_of_year = "مرداد";
                    break;
                case 6:
                    str_month_of_year = "شهریور";
                    break;
                case 7:
                    str_month_of_year = "مهر";
                    break;
                case 8:
                    str_month_of_year = "آبان";
                    break;
                case 9:
                    str_month_of_year = "آذر";
                    break;
                case 10:
                    str_month_of_year = "دی";
                    break;
                case 11:
                    str_month_of_year = "بهمن";
                    break;
                case 12:
                    str_month_of_year = "اسفند";
                    break;

            }
            return str_month_of_year ;
        }
        private void ettelahat_kala_Click(object sender, EventArgs e)
        {
            Frm_Nkala fk = new Frm_Nkala();
            fk.ShowDialog();
        }

        private void m_model_kala_Click(object sender, EventArgs e)
        {
            Frm_Kala f = new Frm_Kala();
            f.ShowDialog();
        }

        private void meno_foroshandeghan_Click(object sender, EventArgs e)
        {
            Frm_Foroshandeghan f = new Frm_Foroshandeghan();
            f.ShowDialog();
        }

        private void meno_moshtari_Click(object sender, EventArgs e)
        {
            Frm_Moshtariha f = new Frm_Moshtariha();
            f.ShowDialog();

        }

        private void meno_bank_Click(object sender, EventArgs e)
        {
            Frm_Banks f = new Frm_Banks();
            f.ShowDialog();
        }

        private void meno_kharid_Click(object sender, EventArgs e)
        {
            Frm_kharid f = new Frm_kharid();
            f.ShowDialog();
        }

        private void meno_esterdad_Click(object sender, EventArgs e)
        {
            Frm_Esterdad f = new Frm_Esterdad();
            f.ShowDialog();
        }

        private void meno_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void meno_pardakhtha_Click(object sender, EventArgs e)
        {
            Frm_Pardakht f = new Frm_Pardakht();
            f.ShowDialog();
        }

        private void meno_del_kharid_Click(object sender, EventArgs e)
        {
            Frm_delete_kharid f = new Frm_delete_kharid();
            f.ShowDialog();
        }

        private void meno_del_esterdad_Click(object sender, EventArgs e)
        {
            Frm_delete_Esterdad f = new Frm_delete_Esterdad();
            f.ShowDialog();
        }

        private void meno_sar_checkha_Click(object sender, EventArgs e)
        {
            Frm_rasid_check_sadereh f = new Frm_rasid_check_sadereh();
            f.ShowDialog();
        }

        private void meno_forosh_Click(object sender, EventArgs e)
        {
            Frm_forosh f = new Frm_forosh();
            f.ShowDialog();
        }

        private void meno_back_forosh_Click(object sender, EventArgs e)
        {
            Frm_back_forosh f = new Frm_back_forosh();
            f.ShowDialog();
        }

        private void meno_daryaft_Click(object sender, EventArgs e)
        {
            Frm_Daryaft f = new Frm_Daryaft();
            f.ShowDialog();
        }

        private void meno_eshterak_Click(object sender, EventArgs e)
        {
            Frm_Eshterak f = new Frm_Eshterak();
            f.ShowDialog();
        }

        private void meno_forosh_aghsat_Click(object sender, EventArgs e)
        {
            Frm_forosh_aghsat f = new Frm_forosh_aghsat();
            f.ShowDialog();
        }

        private void meno_ghest_bandi_Click(object sender, EventArgs e)
        {
            Frm_Ghest_bandi f = new Frm_Ghest_bandi();
            f.ShowDialog();
        }

        private void meno_daryaft_ghest_Click(object sender, EventArgs e)
        {
            Frm_daryaft_ghest f = new Frm_daryaft_ghest();
            f.ShowDialog();
        }

        private void meno_sar_resid_aghsat_Click(object sender, EventArgs e)
        {
            Frm_sar_resid_aghsat f = new Frm_sar_resid_aghsat();
            f.ShowDialog();
        }

        private void meno_delete_rasid_check_vosoli_Click(object sender, EventArgs e)
        {
            Frm_rasid_check_vosoli f = new Frm_rasid_check_vosoli();
            f.ShowDialog();
        }

        private void meno_delete_bar_forosh_Click(object sender, EventArgs e)
        {
            Frm_delete_bar_forosh f = new Frm_delete_bar_forosh();
            f.ShowDialog();
        }

        private void meno_delete_forosh_Click(object sender, EventArgs e)
        {
            Frm_delete_forosh f = new Frm_delete_forosh();
            f.ShowDialog();
        }

        private void meno_sabte_check_pass_shode_Click(object sender, EventArgs e)
        {
            Frm_sabt_Check_pas_shode f = new Frm_sabt_Check_pas_shode();
            f.ShowDialog();
        }

        private void meno_rpt_check_vosoli_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Check_Vosoli f = new Reports.Rpt_Check_Vosoli();
            f.ShowDialog();
        }

        private void meno_rpt_check_sadereh_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Check_Sadereh f = new Reports.Rpt_Check_Sadereh();
            f.ShowDialog();
        }

        private void meno_bardasht_Click(object sender, EventArgs e)
        {
            Frm_bardasht_bank f = new Frm_bardasht_bank();
            f.ShowDialog();
        }

        private void meno_variz_Click(object sender, EventArgs e)
        {
            Frm_Variz_bank f = new Frm_Variz_bank();
            f.ShowDialog();
        }

        private void meno_Sabt_Froshandegan_Click(object sender, EventArgs e)
        {
            Frm_Sabt_Sanad_Froshandeghan f = new Frm_Sabt_Sanad_Froshandeghan();
            f.ShowDialog();
        }

        private void meno_sabt_Moshtari_Click(object sender, EventArgs e)
        {
            Frm_Sanad_Moshteri f = new Frm_Sanad_Moshteri();
            f.ShowDialog();
        }

        private void meno_sodor_check_mot_Click(object sender, EventArgs e)
        {
            Frm_Sodoore_Check_Mot f = new Frm_Sodoore_Check_Mot();
            f.ShowDialog();
        }

        private void meno_daryaft_check_mot_Click(object sender, EventArgs e)
        {
            Frm_Daryaft_Check_Mot f = new Frm_Daryaft_Check_Mot();
            f.ShowDialog();
        }

        private void meno_par_dar_mot_Click(object sender, EventArgs e)
        {
            Frm_Pardakht_Daryaft_Mot f = new Frm_Pardakht_Daryaft_Mot();
            f.ShowDialog();
        }

        private void meno_gozaresh_par_dar_mot_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Par_Dar_Mot r = new Reports.Rpt_Par_Dar_Mot();
            r.ShowDialog();
        }

        private void meno_sabt_bardasht_mot_Click(object sender, EventArgs e)
        {
            Frm_Bardasht_Mot f = new Frm_Bardasht_Mot();
            f.ShowDialog();
        }

        private void meno_gozaresh_bardasht_mot_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Bardasht_Mot r = new Reports.Rpt_Bardasht_Mot();
            r.ShowDialog();
        }

        private void meno_dafteri_Click(object sender, EventArgs e)
        {
            Frm_Daftar f = new Frm_Daftar();
            f.ShowDialog();
        }

        private void meno_report_kala_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kala r = new Reports.Rpt_Kala();
            r.ShowDialog();
        }

        private void meno_mojodi_anbar_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Mojodi_Kala r = new Reports.Rpt_Mojodi_Kala();
            r.ShowDialog();
        }

        private void meno_report_kharid_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kharid r = new Reports.Rpt_Kharid();
            r.ShowDialog();
        }

        private void meno_report_forosh_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Forosh r = new Reports.Rpt_Forosh();
            r.ShowDialog();
        }

        private void meno_forosh_aghsati_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Forosh_Aghsati r = new Reports.Rpt_Forosh_Aghsati();
            r.ShowDialog();
        }

        private void meno_max_min_forosh_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Max_Min_Forosh r = new Reports.Rpt_Max_Min_Forosh();
            r.ShowDialog();
        }

        private void meno_ajnase_kam_anbar_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kala_Kame_Anbar r = new Reports.Rpt_Kala_Kame_Anbar();
            r.ShowDialog();
        }

        private void meno_rpt_foroshandeghan_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Foroshandegan r = new Reports.Rpt_Foroshandegan();
            r.ShowDialog();
        }

        private void meno_rpt_moshterian_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Coustomer r = new Reports.Rpt_Coustomer();
            r.ShowDialog();
        }

        private void meno_register_user_Click(object sender, EventArgs e)
        {
            Forms_User.Frm_Register_User f = new Forms_User.Frm_Register_User();
            f.ShowDialog();
        }

        private void meno_cheange_user_Click(object sender, EventArgs e)
        {
            Forms_User.Frm_Cheangh_Password f = new Forms_User.Frm_Cheangh_Password();
            f.ShowDialog();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Date();
            //-----------------------------مدیر سیستم--------------------//
            if (Type_user == "0")
            {
                meno_register_user.Enabled = true;
                meno_bank.Enabled = true;
                meno_sar_checkha.Enabled = true;
                meno_rpt_check_sadereh.Enabled = true;
                meno_rasid_check_vosoli.Enabled = true;
                meno_rpt_check_vosoli.Enabled = true;
                meno_variz.Enabled = true;
                meno_bardasht.Enabled = true;
                meno_sodor_check_mot.Enabled = true;
                meno_daryaft_check_mot.Enabled = true;
                meno_par_dar_mot.Enabled = true;
                meno_gozaresh_par_dar_mot.Enabled = true;
                meno_sabt_bardasht_mot.Enabled = true;
                meno_gozaresh_bardasht_mot.Enabled = true;
                meno_rpt_foroshandeghan.Enabled = true;
                meno_rpt_moshterian.Enabled = true;

                pic_gozaresh_check_sadereh.Enabled = true;
                pic_gozaresh_check_vosoli.Enabled = true;
                pic_gozaresh_foroshandeghan.Enabled = true;
                pic_gozaresh_moshterian.Enabled = true;

            }
            else
            {
                //----------------------------------کاربر عادی-------------------------//
                meno_register_user.Enabled = false ;
                meno_bank.Enabled = false ;
                meno_sar_checkha.Enabled = false ;
                meno_rpt_check_sadereh.Enabled = false ;
                meno_rasid_check_vosoli.Enabled = false ;
                meno_rpt_check_vosoli.Enabled = false ;
                meno_variz.Enabled = false ;
                meno_bardasht.Enabled = false ;
                meno_sodor_check_mot.Enabled = false ;
                meno_daryaft_check_mot.Enabled = false ;
                meno_par_dar_mot.Enabled = false ;
                meno_gozaresh_par_dar_mot.Enabled = false ;
                meno_sabt_bardasht_mot.Enabled = false ;
                meno_gozaresh_bardasht_mot.Enabled = false ;
                meno_rpt_foroshandeghan.Enabled = false ;
                meno_rpt_moshterian.Enabled = false ;

                pic_gozaresh_check_sadereh.Enabled = false ;
                pic_gozaresh_check_vosoli.Enabled = false ;
                pic_gozaresh_foroshandeghan.Enabled = false ;
                pic_gozaresh_moshterian.Enabled = false ;
            }
        }

        private void meno_backup_Click(object sender, EventArgs e)
        {
            Forms_User.Frm_Backup f = new Forms_User.Frm_Backup();
            f.ShowDialog();
        }

        private void meno_restore_Click(object sender, EventArgs e)
        {
            Forms_User.Frm_Restore f = new Forms_User.Frm_Restore();
            f.ShowDialog();
        }

        private void pic_kharid_Click(object sender, EventArgs e)
        {
            Forms.Frm_kharid f = new Frm_kharid();
            f.ShowDialog();
        }

        private void pic_esterdad_Click(object sender, EventArgs e)
        {
            Forms.Frm_Esterdad f = new Frm_Esterdad();
            f.ShowDialog();

        }

        private void pic_forosh_Click(object sender, EventArgs e)
        {
            Forms.Frm_forosh f = new Frm_forosh();
            f.ShowDialog();
        }

        private void pic_bar_forosh_Click(object sender, EventArgs e)
        {
            Forms.Frm_back_forosh f = new Frm_back_forosh();
            f.ShowDialog();
        }

        private void pic_sabt_pardakht_Click(object sender, EventArgs e)
        {
            Forms.Frm_Pardakht f = new Frm_Pardakht();
            f.ShowDialog();
        }

        private void pic_daryaft_Click(object sender, EventArgs e)
        {
            Forms.Frm_Daryaft f = new Frm_Daryaft();
            f.ShowDialog();
        }

        private void pic_Aghsat_Click(object sender, EventArgs e)
        {
            Forms.Frm_forosh_aghsat f = new Frm_forosh_aghsat();
            f.ShowDialog();
        }

        private void pic_ghest_bandi_Click(object sender, EventArgs e)
        {
            Forms.Frm_Ghest_bandi f = new Frm_Ghest_bandi();
            f.ShowDialog();
        }

        private void pic_daryaft_ghest_Click(object sender, EventArgs e)
        {
            Forms.Frm_daryaft_ghest f = new Frm_daryaft_ghest();
            f.ShowDialog();
        }

        private void pic_moshterekin_Click(object sender, EventArgs e)
        {
            Forms.Frm_Eshterak f = new Frm_Eshterak();
            f.ShowDialog();
        }

        private void pic_dafteri_Click(object sender, EventArgs e)
        {
            Forms.Frm_Daftar f = new Frm_Daftar();
            f.ShowDialog();
        }

        private void pic_gozaresh_check_sadereh_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Check_Sadereh f = new Reports.Rpt_Check_Sadereh();
            f.ShowDialog();
        }

        private void pic_gozaresh_check_vosoli_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Check_Vosoli f = new Reports.Rpt_Check_Vosoli();
            f.ShowDialog();
        }

        private void pic_sar_resid_aghsat_Click(object sender, EventArgs e)
        {
            Forms.Frm_sar_resid_aghsat f = new Frm_sar_resid_aghsat();
            f.ShowDialog();
        }

        private void pic_gozaresh_kala_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kala f = new Reports.Rpt_Kala();
            f.ShowDialog();
        }

        private void pic_mojodi_anbar_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Mojodi_Kala f = new Reports.Rpt_Mojodi_Kala();
            f.ShowDialog();
        }

        private void pic_gozaresh_kharid_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kharid f = new Reports.Rpt_Kharid();
            f.ShowDialog();
        }

        private void pic_gozaresh_forosh_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Forosh f = new Reports.Rpt_Forosh();
            f.ShowDialog();
        }

        private void pic_forosh_aghsat_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Forosh_Aghsati f = new Reports.Rpt_Forosh_Aghsati();
            f.ShowDialog();
        }

        private void pic_max_min_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Max_Min_Forosh f = new Reports.Rpt_Max_Min_Forosh();
            f.ShowDialog();
        }

        private void pic_kala_kam_mojod_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Kala_Kame_Anbar f = new Reports.Rpt_Kala_Kame_Anbar();
            f.ShowDialog();
        }

        private void pic_gozaresh_foroshandeghan_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Foroshandegan f = new Reports.Rpt_Foroshandegan();
            f.ShowDialog();
        }

        private void pic_gozaresh_moshterian_Click(object sender, EventArgs e)
        {
            Reports.Rpt_Coustomer f = new Reports.Rpt_Coustomer();
            f.ShowDialog();
        }




        
         ///////////////////////////////////////////////////////////////////////////////
     
        private void pic_kharid_MouseHover(object sender, EventArgs e)
        {
         
            pic_kharid.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_kharid_MouseLeave(object sender, EventArgs e)
        {
            pic_kharid.BorderStyle = BorderStyle.None;
        }

        private void pic_esterdad_MouseHover(object sender, EventArgs e)
        {
            pic_esterdad .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_esterdad_MouseLeave(object sender, EventArgs e)
        {
            pic_esterdad .BorderStyle = BorderStyle.None;
        }

        private void pic_forosh_MouseHover(object sender, EventArgs e)
        {
            pic_forosh .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_forosh_MouseLeave(object sender, EventArgs e)
        {
            pic_forosh.BorderStyle = BorderStyle.None;
        }

        private void pic_bar_forosh_MouseHover(object sender, EventArgs e)
        {
            pic_bar_forosh .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_bar_forosh_MouseLeave(object sender, EventArgs e)
        {
            pic_bar_forosh.BorderStyle = BorderStyle.None ;
        }

        private void pic_sabt_pardakht_MouseHover(object sender, EventArgs e)
        {
            pic_sabt_pardakht .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_sabt_pardakht_MouseLeave(object sender, EventArgs e)
        {
            pic_sabt_pardakht.BorderStyle = BorderStyle.None ;
        }

        private void pic_daryaft_MouseHover(object sender, EventArgs e)
        {
            pic_daryaft.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_daryaft_MouseLeave(object sender, EventArgs e)
        {
            pic_daryaft.BorderStyle = BorderStyle.None;
        }

        private void pic_Aghsat_MouseHover(object sender, EventArgs e)
        {
            pic_Aghsat .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_Aghsat_MouseLeave(object sender, EventArgs e)
        {
            pic_Aghsat.BorderStyle = BorderStyle.None;
        }

        private void pic_ghest_bandi_MouseHover(object sender, EventArgs e)
        {
            pic_ghest_bandi.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_ghest_bandi_MouseLeave(object sender, EventArgs e)
        {
            pic_ghest_bandi.BorderStyle = BorderStyle.None ;
        }

        private void pic_daryaft_ghest_MouseHover(object sender, EventArgs e)
        {
            pic_daryaft_ghest .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_daryaft_ghest_MouseLeave(object sender, EventArgs e)
        {
            pic_daryaft_ghest.BorderStyle = BorderStyle.None ;
        }

        private void pic_moshterekin_MouseHover(object sender, EventArgs e)
        {
            pic_moshterekin .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_moshterekin_MouseLeave(object sender, EventArgs e)
        {
            pic_moshterekin.BorderStyle = BorderStyle.None ;
        }

        private void pic_dafteri_MouseHover(object sender, EventArgs e)
        {
            pic_dafteri .BorderStyle = BorderStyle.FixedSingle;
        }

        private void pic_dafteri_MouseLeave(object sender, EventArgs e)
        {
            pic_dafteri.BorderStyle = BorderStyle.None ;
        }



   

 









        









    }
}
