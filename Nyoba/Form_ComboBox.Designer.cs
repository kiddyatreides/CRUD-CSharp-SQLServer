﻿namespace Nyoba
{
    partial class Form_ComboBox
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
            this.tb_nama = new System.Windows.Forms.TextBox();
            this.cb_gaji = new System.Windows.Forms.ComboBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_nama
            // 
            this.tb_nama.Location = new System.Drawing.Point(237, 71);
            this.tb_nama.Name = "tb_nama";
            this.tb_nama.Size = new System.Drawing.Size(223, 20);
            this.tb_nama.TabIndex = 0;
            // 
            // cb_gaji
            // 
            this.cb_gaji.FormattingEnabled = true;
            this.cb_gaji.Items.AddRange(new object[] {
            "< 1.000.000",
            "1.000.000 - 2.000.000",
            "2.000.000 - 5.000.000",
            "> 5.000.000"});
            this.cb_gaji.Location = new System.Drawing.Point(237, 121);
            this.cb_gaji.Name = "cb_gaji";
            this.cb_gaji.Size = new System.Drawing.Size(289, 21);
            this.cb_gaji.TabIndex = 1;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(237, 183);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(156, 23);
            this.btn_submit.TabIndex = 2;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gaji";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_ComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 286);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.cb_gaji);
            this.Controls.Add(this.tb_nama);
            this.Name = "Form_ComboBox";
            this.Text = "Form_ComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_nama;
        private System.Windows.Forms.ComboBox cb_gaji;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}