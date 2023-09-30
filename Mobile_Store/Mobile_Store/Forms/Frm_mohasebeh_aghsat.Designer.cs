namespace Mobile_Store.Forms
{
    partial class Frm_mohasebeh_aghsat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_count_ghest = new System.Windows.Forms.Label();
            this.lab_mablegh_ghest = new System.Windows.Forms.Label();
            this.lab_aghsat = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_aghsat);
            this.groupBox1.Controls.Add(this.lab_mablegh_ghest);
            this.groupBox1.Controls.Add(this.lab_count_ghest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "جمع اقساط";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "مبلغ قسط";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "تعداد قسط";
            // 
            // lab_count_ghest
            // 
            this.lab_count_ghest.AutoSize = true;
            this.lab_count_ghest.ForeColor = System.Drawing.Color.Red;
            this.lab_count_ghest.Location = new System.Drawing.Point(110, 28);
            this.lab_count_ghest.Name = "lab_count_ghest";
            this.lab_count_ghest.Size = new System.Drawing.Size(38, 14);
            this.lab_count_ghest.TabIndex = 6;
            this.lab_count_ghest.Text = "label4";
            // 
            // lab_mablegh_ghest
            // 
            this.lab_mablegh_ghest.AutoSize = true;
            this.lab_mablegh_ghest.ForeColor = System.Drawing.Color.Red;
            this.lab_mablegh_ghest.Location = new System.Drawing.Point(110, 80);
            this.lab_mablegh_ghest.Name = "lab_mablegh_ghest";
            this.lab_mablegh_ghest.Size = new System.Drawing.Size(38, 14);
            this.lab_mablegh_ghest.TabIndex = 7;
            this.lab_mablegh_ghest.Text = "label5";
            // 
            // lab_aghsat
            // 
            this.lab_aghsat.AutoSize = true;
            this.lab_aghsat.ForeColor = System.Drawing.Color.Blue;
            this.lab_aghsat.Location = new System.Drawing.Point(110, 134);
            this.lab_aghsat.Name = "lab_aghsat";
            this.lab_aghsat.Size = new System.Drawing.Size(38, 14);
            this.lab_aghsat.TabIndex = 8;
            this.lab_aghsat.Text = "label6";
            // 
            // Frm_mohasebeh_aghsat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 187);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_mohasebeh_aghsat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "   محاسبه اقساط";
            this.Load += new System.EventHandler(this.Frm_mohasebeh_aghsat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_aghsat;
        private System.Windows.Forms.Label lab_mablegh_ghest;
        private System.Windows.Forms.Label lab_count_ghest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}