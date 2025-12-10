namespace Arac_Kiralama
{
    partial class SifreDegistirme
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SifreDegistirOnay = new System.Windows.Forms.Button();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ePosta = new System.Windows.Forms.TextBox();
            this.txt_tcNo = new System.Windows.Forms.TextBox();
            this.txt_sifreTekrar = new System.Windows.Forms.TextBox();
            this.txt_yeniSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_KodGonder = new System.Windows.Forms.Button();
            this.rbtn_Musteri = new System.Windows.Forms.RadioButton();
            this.rbtn_Personel = new System.Windows.Forms.RadioButton();
            this.txt_onayKodu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // btn_SifreDegistirOnay
            // 
            this.btn_SifreDegistirOnay.Location = new System.Drawing.Point(88, 238);
            this.btn_SifreDegistirOnay.Name = "btn_SifreDegistirOnay";
            this.btn_SifreDegistirOnay.Size = new System.Drawing.Size(129, 49);
            this.btn_SifreDegistirOnay.TabIndex = 1;
            this.btn_SifreDegistirOnay.Text = "Şifreyi Değiştir";
            this.btn_SifreDegistirOnay.UseVisualStyleBackColor = true;
            this.btn_SifreDegistirOnay.Click += new System.EventHandler(this.btn_SifreDegistirOnay_Click);
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(94, 11);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(258, 22);
            this.txt_kullaniciAdi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "TC No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "E-Posta:";
            // 
            // txt_ePosta
            // 
            this.txt_ePosta.Location = new System.Drawing.Point(94, 86);
            this.txt_ePosta.Name = "txt_ePosta";
            this.txt_ePosta.Size = new System.Drawing.Size(258, 22);
            this.txt_ePosta.TabIndex = 10;
            // 
            // txt_tcNo
            // 
            this.txt_tcNo.Location = new System.Drawing.Point(94, 49);
            this.txt_tcNo.Name = "txt_tcNo";
            this.txt_tcNo.Size = new System.Drawing.Size(258, 22);
            this.txt_tcNo.TabIndex = 9;
            // 
            // txt_sifreTekrar
            // 
            this.txt_sifreTekrar.Location = new System.Drawing.Point(94, 160);
            this.txt_sifreTekrar.Name = "txt_sifreTekrar";
            this.txt_sifreTekrar.Size = new System.Drawing.Size(258, 22);
            this.txt_sifreTekrar.TabIndex = 14;
            // 
            // txt_yeniSifre
            // 
            this.txt_yeniSifre.Location = new System.Drawing.Point(94, 123);
            this.txt_yeniSifre.Name = "txt_yeniSifre";
            this.txt_yeniSifre.Size = new System.Drawing.Size(258, 22);
            this.txt_yeniSifre.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Şifre Tekrar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Yeni Şifre:";
            // 
            // btn_KodGonder
            // 
            this.btn_KodGonder.Location = new System.Drawing.Point(223, 238);
            this.btn_KodGonder.Name = "btn_KodGonder";
            this.btn_KodGonder.Size = new System.Drawing.Size(129, 49);
            this.btn_KodGonder.TabIndex = 15;
            this.btn_KodGonder.Text = "Kod Gönder";
            this.btn_KodGonder.UseVisualStyleBackColor = true;
            this.btn_KodGonder.Click += new System.EventHandler(this.btn_KodGonder_Click);
            // 
            // rbtn_Musteri
            // 
            this.rbtn_Musteri.AutoSize = true;
            this.rbtn_Musteri.Location = new System.Drawing.Point(370, 11);
            this.rbtn_Musteri.Name = "rbtn_Musteri";
            this.rbtn_Musteri.Size = new System.Drawing.Size(71, 20);
            this.rbtn_Musteri.TabIndex = 16;
            this.rbtn_Musteri.TabStop = true;
            this.rbtn_Musteri.Text = "Müşteri";
            this.rbtn_Musteri.UseVisualStyleBackColor = true;
            // 
            // rbtn_Personel
            // 
            this.rbtn_Personel.AutoSize = true;
            this.rbtn_Personel.Location = new System.Drawing.Point(370, 37);
            this.rbtn_Personel.Name = "rbtn_Personel";
            this.rbtn_Personel.Size = new System.Drawing.Size(82, 20);
            this.rbtn_Personel.TabIndex = 17;
            this.rbtn_Personel.TabStop = true;
            this.rbtn_Personel.Text = "Personel";
            this.rbtn_Personel.UseVisualStyleBackColor = true;
            // 
            // txt_onayKodu
            // 
            this.txt_onayKodu.Location = new System.Drawing.Point(94, 197);
            this.txt_onayKodu.Name = "txt_onayKodu";
            this.txt_onayKodu.Size = new System.Drawing.Size(258, 22);
            this.txt_onayKodu.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Onay Kodu:";
            // 
            // SifreDegistirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 299);
            this.Controls.Add(this.txt_onayKodu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbtn_Personel);
            this.Controls.Add(this.rbtn_Musteri);
            this.Controls.Add(this.btn_KodGonder);
            this.Controls.Add(this.txt_sifreTekrar);
            this.Controls.Add(this.txt_yeniSifre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ePosta);
            this.Controls.Add(this.txt_tcNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_kullaniciAdi);
            this.Controls.Add(this.btn_SifreDegistirOnay);
            this.Controls.Add(this.label1);
            this.Name = "SifreDegistirme";
            this.Text = "SifreDegistirme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SifreDegistirOnay;
        private System.Windows.Forms.TextBox txt_kullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ePosta;
        private System.Windows.Forms.TextBox txt_tcNo;
        private System.Windows.Forms.TextBox txt_sifreTekrar;
        private System.Windows.Forms.TextBox txt_yeniSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_KodGonder;
        private System.Windows.Forms.RadioButton rbtn_Musteri;
        private System.Windows.Forms.RadioButton rbtn_Personel;
        private System.Windows.Forms.TextBox txt_onayKodu;
        private System.Windows.Forms.Label label8;
    }
}