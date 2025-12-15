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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_sifreGizleGoster = new System.Windows.Forms.Button();
            this.btn_SifremiUnuttum = new System.Windows.Forms.Button();
            this.btn_Yenile = new System.Windows.Forms.Button();
            this.btn_GirisYap = new System.Windows.Forms.Button();
            this.txt_Kod = new System.Windows.Forms.TextBox();
            this.txt_kodOnay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.cbx_beniHatirla = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.girişYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifremiUnuttumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kodYenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.groupBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.groupBox1.Controls.Add(this.cbx_beniHatirla);
            this.groupBox1.Controls.Add(this.btn_sifreGizleGoster);
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
            // btn_sifreGizleGoster
            // 
            this.btn_sifreGizleGoster.Location = new System.Drawing.Point(320, 111);
            this.btn_sifreGizleGoster.Name = "btn_sifreGizleGoster";
            this.btn_sifreGizleGoster.Size = new System.Drawing.Size(110, 28);
            this.btn_sifreGizleGoster.TabIndex = 12;
            this.btn_sifreGizleGoster.Text = "Şifre Göster";
            this.btn_sifreGizleGoster.UseVisualStyleBackColor = true;
            this.btn_sifreGizleGoster.Click += new System.EventHandler(this.btn_sifreGizleGoster_Click);
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
            // btn_Yenile
            // 
            this.btn_Yenile.Location = new System.Drawing.Point(320, 148);
            this.btn_Yenile.Name = "btn_Yenile";
            this.btn_Yenile.Size = new System.Drawing.Size(110, 28);
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
            // cbx_beniHatirla
            // 
            this.cbx_beniHatirla.AutoSize = true;
            this.cbx_beniHatirla.Location = new System.Drawing.Point(335, 190);
            this.cbx_beniHatirla.Name = "cbx_beniHatirla";
            this.cbx_beniHatirla.Size = new System.Drawing.Size(98, 20);
            this.cbx_beniHatirla.TabIndex = 13;
            this.cbx_beniHatirla.Text = "Beni Hatırla";
            this.cbx_beniHatirla.UseVisualStyleBackColor = true;
            this.cbx_beniHatirla.CheckedChanged += new System.EventHandler(this.cbx_beniHatirla_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.girişYapToolStripMenuItem,
            this.şifremiUnuttumToolStripMenuItem,
            this.kodYenileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 76);
            // 
            // girişYapToolStripMenuItem
            // 
            this.girişYapToolStripMenuItem.Name = "girişYapToolStripMenuItem";
            this.girişYapToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.girişYapToolStripMenuItem.Text = "Giriş Yap";
            this.girişYapToolStripMenuItem.Click += new System.EventHandler(this.btn_GirisYap_Click);
            // 
            // şifremiUnuttumToolStripMenuItem
            // 
            this.şifremiUnuttumToolStripMenuItem.Name = "şifremiUnuttumToolStripMenuItem";
            this.şifremiUnuttumToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.şifremiUnuttumToolStripMenuItem.Text = "Şifremi Unuttum";
            this.şifremiUnuttumToolStripMenuItem.Click += new System.EventHandler(this.btn_SifremiUnuttum_Click);
            // 
            // kodYenileToolStripMenuItem
            // 
            this.kodYenileToolStripMenuItem.Name = "kodYenileToolStripMenuItem";
            this.kodYenileToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.kodYenileToolStripMenuItem.Text = "Kod Yenile";
            this.kodYenileToolStripMenuItem.Click += new System.EventHandler(this.btn_sifreGizleGoster_Click);
            // 
            // GirisYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "GirisYap";
            this.Text = "GirisYap";
            this.Load += new System.EventHandler(this.GirisYap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GirisYap_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_sifreGizleGoster;
        private System.Windows.Forms.CheckBox cbx_beniHatirla;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem girişYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifremiUnuttumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kodYenileToolStripMenuItem;
    }
}