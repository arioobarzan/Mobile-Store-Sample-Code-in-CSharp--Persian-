namespace Mobile_Store
{
    partial class Rpt_View_Gozaresh_Forosh
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
            this.ForoshBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Store = new Mobile_Store.DataSet_Store();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ForoshBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Store)).BeginInit();
            this.SuspendLayout();
            // 
            // ForoshBindingSource
            // 
            this.ForoshBindingSource.DataMember = "Forosh";
            this.ForoshBindingSource.DataSource = this.DataSet_Store;
            // 
            // DataSet_Store
            // 
            this.DataSet_Store.DataSetName = "DataSet_Store";
            this.DataSet_Store.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Forosh";
            reportDataSource1.Value = this.ForoshBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mobile_Store.Rpt_Ghozaresh_Forosh.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(741, 465);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // Rpt_View_Gozaresh_Forosh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 465);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Rpt_View_Gozaresh_Forosh";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   گزارش فروش";
            this.Load += new System.EventHandler(this.Frm_View_Gozaresh_Forosh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ForoshBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Store)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ForoshBindingSource;
        private DataSet_Store DataSet_Store;
    }
}