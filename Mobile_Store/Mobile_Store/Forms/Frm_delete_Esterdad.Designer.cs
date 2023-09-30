namespace Mobile_Store.Forms
{
    partial class Frm_delete_Esterdad
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_name_foroshandeh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_factor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_del_factor = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(-24, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 60);
            this.panel2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(201, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "حذف فاکتور استرداد";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_name_foroshandeh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_factor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lab_name_foroshandeh
            // 
            this.lab_name_foroshandeh.AutoSize = true;
            this.lab_name_foroshandeh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_name_foroshandeh.ForeColor = System.Drawing.Color.Red;
            this.lab_name_foroshandeh.Location = new System.Drawing.Point(78, 27);
            this.lab_name_foroshandeh.Name = "lab_name_foroshandeh";
            this.lab_name_foroshandeh.Size = new System.Drawing.Size(2, 15);
            this.lab_name_foroshandeh.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "نام فروشنده";
            // 
            // txt_factor
            // 
            this.txt_factor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_factor.Location = new System.Drawing.Point(378, 21);
            this.txt_factor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_factor.Name = "txt_factor";
            this.txt_factor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_factor.Size = new System.Drawing.Size(97, 21);
            this.txt_factor.TabIndex = 15;
            this.txt_factor.Text = "0";
            this.txt_factor.TextChanged += new System.EventHandler(this.txt_factor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "شماره فاکتور";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_exit);
            this.groupBox2.Controls.Add(this.btn_del_factor);
            this.groupBox2.Location = new System.Drawing.Point(3, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 49);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(6, 13);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(73, 30);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "بستن";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_del_factor
            // 
            this.btn_del_factor.Location = new System.Drawing.Point(495, 13);
            this.btn_del_factor.Name = "btn_del_factor";
            this.btn_del_factor.Size = new System.Drawing.Size(82, 30);
            this.btn_del_factor.TabIndex = 0;
            this.btn_del_factor.Text = "حذف فاکتور";
            this.btn_del_factor.UseVisualStyleBackColor = true;
            this.btn_del_factor.Click += new System.EventHandler(this.btn_del_factor_Click);
            // 
            // Frm_delete_Esterdad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 186);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_delete_Esterdad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "حذف فاکتور استرداد";
            
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_del_factor;
        private System.Windows.Forms.Label lab_name_foroshandeh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_factor;
        private System.Windows.Forms.Label label2;
    }
}