namespace Arac_Kiralama
{
    partial class frm_odemeIslemleri
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
            this.dgv_odemeTurIslemleri = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_odemeTuru = new System.Windows.Forms.TextBox();
            this.btn_odemeTurEkle = new System.Windows.Forms.Button();
            this.btn_odemeTurSil = new System.Windows.Forms.Button();
            this.btn_odemeTurTemizle = new System.Windows.Forms.Button();
            this.btn_odemeTurGuncelle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeTurIslemleri)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_odemeTurTemizle);
            this.groupBox1.Controls.Add(this.btn_odemeTurGuncelle);
            this.groupBox1.Controls.Add(this.btn_odemeTurSil);
            this.groupBox1.Controls.Add(this.btn_odemeTurEkle);
            this.groupBox1.Controls.Add(this.txt_odemeTuru);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgv_odemeTurIslemleri);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ödeme Yöntemi Ekleme";
            // 
            // dgv_odemeTurIslemleri
            // 
            this.dgv_odemeTurIslemleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_odemeTurIslemleri.Location = new System.Drawing.Point(411, 29);
            this.dgv_odemeTurIslemleri.Name = "dgv_odemeTurIslemleri";
            this.dgv_odemeTurIslemleri.RowHeadersWidth = 51;
            this.dgv_odemeTurIslemleri.RowTemplate.Height = 24;
            this.dgv_odemeTurIslemleri.Size = new System.Drawing.Size(461, 308);
            this.dgv_odemeTurIslemleri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ödeme Türü";
            // 
            // txt_odemeTuru
            // 
            this.txt_odemeTuru.Location = new System.Drawing.Point(20, 95);
            this.txt_odemeTuru.Name = "txt_odemeTuru";
            this.txt_odemeTuru.Size = new System.Drawing.Size(385, 30);
            this.txt_odemeTuru.TabIndex = 2;
            // 
            // btn_odemeTurEkle
            // 
            this.btn_odemeTurEkle.Location = new System.Drawing.Point(20, 175);
            this.btn_odemeTurEkle.Name = "btn_odemeTurEkle";
            this.btn_odemeTurEkle.Size = new System.Drawing.Size(184, 68);
            this.btn_odemeTurEkle.TabIndex = 3;
            this.btn_odemeTurEkle.Text = "Ekle";
            this.btn_odemeTurEkle.UseVisualStyleBackColor = true;
            // 
            // btn_odemeTurSil
            // 
            this.btn_odemeTurSil.Location = new System.Drawing.Point(221, 175);
            this.btn_odemeTurSil.Name = "btn_odemeTurSil";
            this.btn_odemeTurSil.Size = new System.Drawing.Size(184, 68);
            this.btn_odemeTurSil.TabIndex = 4;
            this.btn_odemeTurSil.Text = "Sil";
            this.btn_odemeTurSil.UseVisualStyleBackColor = true;
            // 
            // btn_odemeTurTemizle
            // 
            this.btn_odemeTurTemizle.Location = new System.Drawing.Point(221, 249);
            this.btn_odemeTurTemizle.Name = "btn_odemeTurTemizle";
            this.btn_odemeTurTemizle.Size = new System.Drawing.Size(184, 68);
            this.btn_odemeTurTemizle.TabIndex = 6;
            this.btn_odemeTurTemizle.Text = "Temizle";
            this.btn_odemeTurTemizle.UseVisualStyleBackColor = true;
            // 
            // btn_odemeTurGuncelle
            // 
            this.btn_odemeTurGuncelle.Location = new System.Drawing.Point(20, 249);
            this.btn_odemeTurGuncelle.Name = "btn_odemeTurGuncelle";
            this.btn_odemeTurGuncelle.Size = new System.Drawing.Size(184, 68);
            this.btn_odemeTurGuncelle.TabIndex = 5;
            this.btn_odemeTurGuncelle.Text = "Güncelle";
            this.btn_odemeTurGuncelle.UseVisualStyleBackColor = true;
            // 
            // frm_odemeIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_odemeIslemleri";
            this.Text = "frm_odemeIslemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeTurIslemleri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_odemeTurIslemleri;
        private System.Windows.Forms.Button btn_odemeTurTemizle;
        private System.Windows.Forms.Button btn_odemeTurGuncelle;
        private System.Windows.Forms.Button btn_odemeTurSil;
        private System.Windows.Forms.Button btn_odemeTurEkle;
        private System.Windows.Forms.TextBox txt_odemeTuru;
        private System.Windows.Forms.Label label1;
    }
}