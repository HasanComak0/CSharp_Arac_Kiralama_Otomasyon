namespace Arac_Kiralama
{
    partial class GirisYap
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Yenile = new System.Windows.Forms.Button();
            this.btn_GirisYap = new System.Windows.Forms.Button();
            this.txt_Kod = new System.Windows.Forms.TextBox();
            this.txt_kodOnay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.btn_SifremiUnuttum = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(469, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(644, 425);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SifremiUnuttum);
            this.groupBox1.Controls.Add(this.btn_Yenile);
            this.groupBox1.Controls.Add(this.btn_GirisYap);
            this.groupBox1.Controls.Add(this.txt_Kod);
            this.groupBox1.Controls.Add(this.txt_kodOnay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_sifre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_kullaniciAdi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 425);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Yenile
            // 
            this.btn_Yenile.Location = new System.Drawing.Point(320, 148);
            this.btn_Yenile.Name = "btn_Yenile";
            this.btn_Yenile.Size = new System.Drawing.Size(72, 28);
            this.btn_Yenile.TabIndex = 10;
            this.btn_Yenile.Text = "Yenile";
            this.btn_Yenile.UseVisualStyleBackColor = true;
            this.btn_Yenile.Click += new System.EventHandler(this.btn_Yenile_Click);
            // 
            // btn_GirisYap
            // 
            this.btn_GirisYap.Location = new System.Drawing.Point(91, 190);
            this.btn_GirisYap.Name = "btn_GirisYap";
            this.btn_GirisYap.Size = new System.Drawing.Size(111, 48);
            this.btn_GirisYap.TabIndex = 9;
            this.btn_GirisYap.Text = "Giriş Yap";
            this.btn_GirisYap.UseVisualStyleBackColor = true;
            this.btn_GirisYap.Click += new System.EventHandler(this.btn_GirisYap_Click);
            // 
            // txt_Kod
            // 
            this.txt_Kod.Enabled = false;
            this.txt_Kod.Location = new System.Drawing.Point(218, 151);
            this.txt_Kod.Name = "txt_Kod";
            this.txt_Kod.Size = new System.Drawing.Size(84, 22);
            this.txt_Kod.TabIndex = 8;
            // 
            // txt_kodOnay
            // 
            this.txt_kodOnay.Location = new System.Drawing.Point(112, 151);
            this.txt_kodOnay.Name = "txt_kodOnay";
            this.txt_kodOnay.Size = new System.Drawing.Size(86, 22);
            this.txt_kodOnay.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre:";
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(112, 114);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(190, 22);
            this.txt_sifre.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(112, 86);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(190, 22);
            this.txt_kullaniciAdi.TabIndex = 1;
            // 
            // btn_SifremiUnuttum
            // 
            this.btn_SifremiUnuttum.Location = new System.Drawing.Point(208, 190);
            this.btn_SifremiUnuttum.Name = "btn_SifremiUnuttum";
            this.btn_SifremiUnuttum.Size = new System.Drawing.Size(111, 48);
            this.btn_SifremiUnuttum.TabIndex = 11;
            this.btn_SifremiUnuttum.Text = "Şifremi Unuttum";
            this.btn_SifremiUnuttum.UseVisualStyleBackColor = true;
            this.btn_SifremiUnuttum.Click += new System.EventHandler(this.btn_SifremiUnuttum_Click);
            // 
            // GirisYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GirisYap";
            this.Text = "GirisYap";
            this.Load += new System.EventHandler(this.GirisYap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_kullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Kod;
        private System.Windows.Forms.TextBox txt_kodOnay;
        private System.Windows.Forms.Button btn_Yenile;
        private System.Windows.Forms.Button btn_GirisYap;
        private System.Windows.Forms.Button btn_SifremiUnuttum;
    }
}