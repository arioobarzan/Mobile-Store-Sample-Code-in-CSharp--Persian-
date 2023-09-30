namespace Mobile_Store
{
    partial class Rpt_View_Gozaresh_Kharid
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KharidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Store = new Mobile_Store.DataSet_Store();
            ((System.ComponentModel.ISupportInitialize)(this.KharidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Store)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Kharid";
            reportDataSource1.Value = this.KharidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mobile_Store.Rpt_Gozaresh_Kharid.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(721, 452);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // KharidBindingSource
            // 
            this.KharidBindingSource.DataMember = "Kharid";
            this.KharidBindingSource.DataSource = this.DataSet_Store;
            // 
            // DataSet_Store
            // 
            this.DataSet_Store.DataSetName = "DataSet_Store";
            this.DataSet_Store.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Rpt_View_Gozaresh_Kharid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 452);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Rpt_View_Gozaresh_Kharid";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   گزارش خرید";
            this.Load += new System.EventHandler(this.Rpt_View_Gozaresh_Kharid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KharidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Store)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KharidBindingSource;
        private DataSet_Store DataSet_Store;
    }
}