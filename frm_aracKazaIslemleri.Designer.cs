namespace Arac_Kiralama
{
    partial class frm_aracKazaIslemleri
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.araçTamirDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamirDurumEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamirDurumSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamirDurumGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamirDurumTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araçHasarDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasarDurumuEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasarDurumuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasarDurumuGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasarDurumuTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_hasarTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmb_tamirDurumu = new System.Windows.Forms.ComboBox();
            this.cmb_kiraAciklama = new System.Windows.Forms.ComboBox();
            this.cmb_aracPlaka = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_hasarUcret = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_hasarAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_aracHasarTemizle = new System.Windows.Forms.Button();
            this.btn_aracHasarGuncelle = new System.Windows.Forms.Button();
            this.btn_aracHasarSil = new System.Windows.Forms.Button();
            this.btn_aracHasarEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_aracHasarIslemleri = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_tamirDurumTemizle = new System.Windows.Forms.Button();
            this.btn_tamirDurumGuncelle = new System.Windows.Forms.Button();
            this.btn_tamirDurumSil = new System.Windows.Forms.Button();
            this.btn_tamirDurumEkle = new System.Windows.Forms.Button();
            this.txt_tamirDurum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_tamirDurumIslemleri = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_aracHasarIslemleri)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tamirDurumIslemleri)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.araçTamirDurumuToolStripMenuItem,
            this.araçHasarDurumuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 52);
            // 
            // araçTamirDurumuToolStripMenuItem
            // 
            this.araçTamirDurumuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tamirDurumEkleToolStripMenuItem,
            this.tamirDurumSilToolStripMenuItem,
            this.tamirDurumGüncelleToolStripMenuItem,
            this.tamirDurumTemizleToolStripMenuItem});
            this.araçTamirDurumuToolStripMenuItem.Name = "araçTamirDurumuToolStripMenuItem";
            this.araçTamirDurumuToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.araçTamirDurumuToolStripMenuItem.Text = "Araç Tamir Durumu";
            // 
            // tamirDurumEkleToolStripMenuItem
            // 
            this.tamirDurumEkleToolStripMenuItem.Name = "tamirDurumEkleToolStripMenuItem";
            this.tamirDurumEkleToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.tamirDurumEkleToolStripMenuItem.Text = "Tamir Durum Ekle";
            this.tamirDurumEkleToolStripMenuItem.Click += new System.EventHandler(this.btn_tamirDurumEkle_Click);
            // 
            // tamirDurumSilToolStripMenuItem
            // 
            this.tamirDurumSilToolStripMenuItem.Name = "tamirDurumSilToolStripMenuItem";
            this.tamirDurumSilToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.tamirDurumSilToolStripMenuItem.Text = "Tamir Durum Sil";
            this.tamirDurumSilToolStripMenuItem.Click += new System.EventHandler(this.btn_tamirDurumSil_Click);
            // 
            // tamirDurumGüncelleToolStripMenuItem
            // 
            this.tamirDurumGüncelleToolStripMenuItem.Name = "tamirDurumGüncelleToolStripMenuItem";
            this.tamirDurumGüncelleToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.tamirDurumGüncelleToolStripMenuItem.Text = "Tamir Durum Güncelle";
            this.tamirDurumGüncelleToolStripMenuItem.Click += new System.EventHandler(this.btn_tamirDurumGuncelle_Click);
            // 
            // tamirDurumTemizleToolStripMenuItem
            // 
            this.tamirDurumTemizleToolStripMenuItem.Name = "tamirDurumTemizleToolStripMenuItem";
            this.tamirDurumTemizleToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.tamirDurumTemizleToolStripMenuItem.Text = "Tamir Durum Temizle";
            this.tamirDurumTemizleToolStripMenuItem.Click += new System.EventHandler(this.btn_tamirDurumTemizle_Click);
            // 
            // araçHasarDurumuToolStripMenuItem
            // 
            this.araçHasarDurumuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hasarDurumuEkleToolStripMenuItem,
            this.hasarDurumuSilToolStripMenuItem,
            this.hasarDurumuGüncelleToolStripMenuItem,
            this.hasarDurumuTemizleToolStripMenuItem});
            this.araçHasarDurumuToolStripMenuItem.Name = "araçHasarDurumuToolStripMenuItem";
            this.araçHasarDurumuToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.araçHasarDurumuToolStripMenuItem.Text = "Araç Hasar Durumu";
            // 
            // hasarDurumuEkleToolStripMenuItem
            // 
            this.hasarDurumuEkleToolStripMenuItem.Name = "hasarDurumuEkleToolStripMenuItem";
            this.hasarDurumuEkleToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.hasarDurumuEkleToolStripMenuItem.Text = "Hasar Durumu Ekle";
            this.hasarDurumuEkleToolStripMenuItem.Click += new System.EventHandler(this.btn_aracHasarEkle_Click);
            // 
            // hasarDurumuSilToolStripMenuItem
            // 
            this.hasarDurumuSilToolStripMenuItem.Name = "hasarDurumuSilToolStripMenuItem";
            this.hasarDurumuSilToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.hasarDurumuSilToolStripMenuItem.Text = "Hasar Durumu Sil";
            this.hasarDurumuSilToolStripMenuItem.Click += new System.EventHandler(this.btn_aracHasarSil_Click);
            // 
            // hasarDurumuGüncelleToolStripMenuItem
            // 
            this.hasarDurumuGüncelleToolStripMenuItem.Name = "hasarDurumuGüncelleToolStripMenuItem";
            this.hasarDurumuGüncelleToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.hasarDurumuGüncelleToolStripMenuItem.Text = "Hasar Durumu Güncelle";
            this.hasarDurumuGüncelleToolStripMenuItem.Click += new System.EventHandler(this.btn_aracHasarGuncelle_Click);
            // 
            // hasarDurumuTemizleToolStripMenuItem
            // 
            this.hasarDurumuTemizleToolStripMenuItem.Name = "hasarDurumuTemizleToolStripMenuItem";
            this.hasarDurumuTemizleToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.hasarDurumuTemizleToolStripMenuItem.Text = "Hasar Durumu Temizle";
            this.hasarDurumuTemizleToolStripMenuItem.Click += new System.EventHandler(this.btn_aracHasarTemizle_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1924, 1055);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1916, 1022);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hasar İşlemleri";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_hasarTarihi);
            this.groupBox1.Controls.Add(this.cmb_tamirDurumu);
            this.groupBox1.Controls.Add(this.cmb_kiraAciklama);
            this.groupBox1.Controls.Add(this.cmb_aracPlaka);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_hasarUcret);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_hasarAciklama);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_aracHasarTemizle);
            this.groupBox1.Controls.Add(this.btn_aracHasarGuncelle);
            this.groupBox1.Controls.Add(this.btn_aracHasarSil);
            this.groupBox1.Controls.Add(this.btn_aracHasarEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgv_aracHasarIslemleri);
            this.groupBox1.Location = new System.Drawing.Point(326, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 516);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Araç Hasar İşlemleri";
            // 
            // dtp_hasarTarihi
            // 
            this.dtp_hasarTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hasarTarihi.Location = new System.Drawing.Point(9, 212);
            this.dtp_hasarTarihi.Name = "dtp_hasarTarihi";
            this.dtp_hasarTarihi.Size = new System.Drawing.Size(321, 27);
            this.dtp_hasarTarihi.TabIndex = 2;
            // 
            // cmb_tamirDurumu
            // 
            this.cmb_tamirDurumu.FormattingEnabled = true;
            this.cmb_tamirDurumu.Location = new System.Drawing.Point(14, 314);
            this.cmb_tamirDurumu.Name = "cmb_tamirDurumu";
            this.cmb_tamirDurumu.Size = new System.Drawing.Size(321, 28);
            this.cmb_tamirDurumu.TabIndex = 24;
            // 
            // cmb_kiraAciklama
            // 
            this.cmb_kiraAciklama.FormattingEnabled = true;
            this.cmb_kiraAciklama.Location = new System.Drawing.Point(9, 107);
            this.cmb_kiraAciklama.Name = "cmb_kiraAciklama";
            this.cmb_kiraAciklama.Size = new System.Drawing.Size(321, 28);
            this.cmb_kiraAciklama.TabIndex = 23;
            // 
            // cmb_aracPlaka
            // 
            this.cmb_aracPlaka.FormattingEnabled = true;
            this.cmb_aracPlaka.Location = new System.Drawing.Point(9, 56);
            this.cmb_aracPlaka.Name = "cmb_aracPlaka";
            this.cmb_aracPlaka.Size = new System.Drawing.Size(321, 28);
            this.cmb_aracPlaka.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 291);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tamir Durumu";
            // 
            // txt_hasarUcret
            // 
            this.txt_hasarUcret.Location = new System.Drawing.Point(11, 262);
            this.txt_hasarUcret.Margin = new System.Windows.Forms.Padding(2);
            this.txt_hasarUcret.Name = "txt_hasarUcret";
            this.txt_hasarUcret.Size = new System.Drawing.Size(322, 27);
            this.txt_hasarUcret.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hasar Ücreti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Hasar Tarihi";
            // 
            // txt_hasarAciklama
            // 
            this.txt_hasarAciklama.Location = new System.Drawing.Point(10, 160);
            this.txt_hasarAciklama.Margin = new System.Windows.Forms.Padding(2);
            this.txt_hasarAciklama.Name = "txt_hasarAciklama";
            this.txt_hasarAciklama.Size = new System.Drawing.Size(322, 27);
            this.txt_hasarAciklama.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Hasar Açıklaması";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kira Açıklaması";
            // 
            // btn_aracHasarTemizle
            // 
            this.btn_aracHasarTemizle.Location = new System.Drawing.Point(177, 445);
            this.btn_aracHasarTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_aracHasarTemizle.Name = "btn_aracHasarTemizle";
            this.btn_aracHasarTemizle.Size = new System.Drawing.Size(153, 54);
            this.btn_aracHasarTemizle.TabIndex = 12;
            this.btn_aracHasarTemizle.Text = "Temizle";
            this.btn_aracHasarTemizle.UseVisualStyleBackColor = true;
            this.btn_aracHasarTemizle.Click += new System.EventHandler(this.btn_aracHasarTemizle_Click);
            // 
            // btn_aracHasarGuncelle
            // 
            this.btn_aracHasarGuncelle.Location = new System.Drawing.Point(10, 445);
            this.btn_aracHasarGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_aracHasarGuncelle.Name = "btn_aracHasarGuncelle";
            this.btn_aracHasarGuncelle.Size = new System.Drawing.Size(153, 54);
            this.btn_aracHasarGuncelle.TabIndex = 11;
            this.btn_aracHasarGuncelle.Text = "Güncelle";
            this.btn_aracHasarGuncelle.UseVisualStyleBackColor = true;
            this.btn_aracHasarGuncelle.Click += new System.EventHandler(this.btn_aracHasarGuncelle_Click);
            // 
            // btn_aracHasarSil
            // 
            this.btn_aracHasarSil.Location = new System.Drawing.Point(177, 386);
            this.btn_aracHasarSil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_aracHasarSil.Name = "btn_aracHasarSil";
            this.btn_aracHasarSil.Size = new System.Drawing.Size(153, 54);
            this.btn_aracHasarSil.TabIndex = 10;
            this.btn_aracHasarSil.Text = "Sil";
            this.btn_aracHasarSil.UseVisualStyleBackColor = true;
            this.btn_aracHasarSil.Click += new System.EventHandler(this.btn_aracHasarSil_Click);
            // 
            // btn_aracHasarEkle
            // 
            this.btn_aracHasarEkle.Location = new System.Drawing.Point(10, 386);
            this.btn_aracHasarEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_aracHasarEkle.Name = "btn_aracHasarEkle";
            this.btn_aracHasarEkle.Size = new System.Drawing.Size(153, 54);
            this.btn_aracHasarEkle.TabIndex = 9;
            this.btn_aracHasarEkle.Text = "Ekle";
            this.btn_aracHasarEkle.UseVisualStyleBackColor = true;
            this.btn_aracHasarEkle.Click += new System.EventHandler(this.btn_aracHasarEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Araç Plakası";
            // 
            // dgv_aracHasarIslemleri
            // 
            this.dgv_aracHasarIslemleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_aracHasarIslemleri.Location = new System.Drawing.Point(341, 15);
            this.dgv_aracHasarIslemleri.Name = "dgv_aracHasarIslemleri";
            this.dgv_aracHasarIslemleri.RowHeadersWidth = 51;
            this.dgv_aracHasarIslemleri.RowTemplate.Height = 24;
            this.dgv_aracHasarIslemleri.Size = new System.Drawing.Size(745, 495);
            this.dgv_aracHasarIslemleri.TabIndex = 0;
            this.dgv_aracHasarIslemleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_aracHasarIslemleri_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1916, 1022);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Araç Tamir Durumu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_tamirDurumTemizle);
            this.groupBox2.Controls.Add(this.btn_tamirDurumGuncelle);
            this.groupBox2.Controls.Add(this.btn_tamirDurumSil);
            this.groupBox2.Controls.Add(this.btn_tamirDurumEkle);
            this.groupBox2.Controls.Add(this.txt_tamirDurum);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgv_tamirDurumIslemleri);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(459, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(524, 209);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Araç Tamir Durumu";
            // 
            // btn_tamirDurumTemizle
            // 
            this.btn_tamirDurumTemizle.Location = new System.Drawing.Point(185, 148);
            this.btn_tamirDurumTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_tamirDurumTemizle.Name = "btn_tamirDurumTemizle";
            this.btn_tamirDurumTemizle.Size = new System.Drawing.Size(153, 54);
            this.btn_tamirDurumTemizle.TabIndex = 6;
            this.btn_tamirDurumTemizle.Text = "Temizle";
            this.btn_tamirDurumTemizle.UseVisualStyleBackColor = true;
            this.btn_tamirDurumTemizle.Click += new System.EventHandler(this.btn_tamirDurumTemizle_Click);
            // 
            // btn_tamirDurumGuncelle
            // 
            this.btn_tamirDurumGuncelle.Location = new System.Drawing.Point(18, 148);
            this.btn_tamirDurumGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_tamirDurumGuncelle.Name = "btn_tamirDurumGuncelle";
            this.btn_tamirDurumGuncelle.Size = new System.Drawing.Size(153, 54);
            this.btn_tamirDurumGuncelle.TabIndex = 5;
            this.btn_tamirDurumGuncelle.Text = "Güncelle";
            this.btn_tamirDurumGuncelle.UseVisualStyleBackColor = true;
            this.btn_tamirDurumGuncelle.Click += new System.EventHandler(this.btn_tamirDurumGuncelle_Click);
            // 
            // btn_tamirDurumSil
            // 
            this.btn_tamirDurumSil.Location = new System.Drawing.Point(185, 89);
            this.btn_tamirDurumSil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_tamirDurumSil.Name = "btn_tamirDurumSil";
            this.btn_tamirDurumSil.Size = new System.Drawing.Size(153, 54);
            this.btn_tamirDurumSil.TabIndex = 4;
            this.btn_tamirDurumSil.Text = "Sil";
            this.btn_tamirDurumSil.UseVisualStyleBackColor = true;
            this.btn_tamirDurumSil.Click += new System.EventHandler(this.btn_tamirDurumSil_Click);
            // 
            // btn_tamirDurumEkle
            // 
            this.btn_tamirDurumEkle.Location = new System.Drawing.Point(18, 89);
            this.btn_tamirDurumEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_tamirDurumEkle.Name = "btn_tamirDurumEkle";
            this.btn_tamirDurumEkle.Size = new System.Drawing.Size(153, 54);
            this.btn_tamirDurumEkle.TabIndex = 3;
            this.btn_tamirDurumEkle.Text = "Ekle";
            this.btn_tamirDurumEkle.UseVisualStyleBackColor = true;
            this.btn_tamirDurumEkle.Click += new System.EventHandler(this.btn_tamirDurumEkle_Click);
            // 
            // txt_tamirDurum
            // 
            this.txt_tamirDurum.Location = new System.Drawing.Point(16, 58);
            this.txt_tamirDurum.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tamirDurum.Name = "txt_tamirDurum";
            this.txt_tamirDurum.Size = new System.Drawing.Size(322, 27);
            this.txt_tamirDurum.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tamir Durumu";
            // 
            // dgv_tamirDurumIslemleri
            // 
            this.dgv_tamirDurumIslemleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tamirDurumIslemleri.Location = new System.Drawing.Point(342, 23);
            this.dgv_tamirDurumIslemleri.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_tamirDurumIslemleri.Name = "dgv_tamirDurumIslemleri";
            this.dgv_tamirDurumIslemleri.RowHeadersWidth = 51;
            this.dgv_tamirDurumIslemleri.RowTemplate.Height = 24;
            this.dgv_tamirDurumIslemleri.Size = new System.Drawing.Size(170, 179);
            this.dgv_tamirDurumIslemleri.TabIndex = 0;
            this.dgv_tamirDurumIslemleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tamirDurumIslemleri_CellClick);
            // 
            // frm_aracKazaIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_aracKazaIslemleri";
            this.Text = "frm_aracKazaIslemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_aracKazaIslemleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_aracKazaIslemleri_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_aracHasarIslemleri)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tamirDurumIslemleri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem araçTamirDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamirDurumEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamirDurumSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamirDurumGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamirDurumTemizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem araçHasarDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasarDurumuEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasarDurumuSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasarDurumuGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasarDurumuTemizleToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_hasarTarihi;
        private System.Windows.Forms.ComboBox cmb_tamirDurumu;
        private System.Windows.Forms.ComboBox cmb_kiraAciklama;
        private System.Windows.Forms.ComboBox cmb_aracPlaka;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_hasarUcret;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_hasarAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_aracHasarTemizle;
        private System.Windows.Forms.Button btn_aracHasarGuncelle;
        private System.Windows.Forms.Button btn_aracHasarSil;
        private System.Windows.Forms.Button btn_aracHasarEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_aracHasarIslemleri;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_tamirDurumTemizle;
        private System.Windows.Forms.Button btn_tamirDurumGuncelle;
        private System.Windows.Forms.Button btn_tamirDurumSil;
        private System.Windows.Forms.Button btn_tamirDurumEkle;
        private System.Windows.Forms.TextBox txt_tamirDurum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_tamirDurumIslemleri;
    }
}