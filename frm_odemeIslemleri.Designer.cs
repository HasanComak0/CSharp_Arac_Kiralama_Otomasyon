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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_odemeTurTemizle = new System.Windows.Forms.Button();
            this.btn_odemeTurGuncelle = new System.Windows.Forms.Button();
            this.btn_odemeTurSil = new System.Windows.Forms.Button();
            this.btn_odemeTurEkle = new System.Windows.Forms.Button();
            this.txt_odemeTuru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_odemeTurIslemleri = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_odemeTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmb_odemeTuru = new System.Windows.Forms.ComboBox();
            this.cmb_kiralayanMusteri = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tutar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_odemebilgisiTemizle = new System.Windows.Forms.Button();
            this.btn_odemeBilgisiGuncelle = new System.Windows.Forms.Button();
            this.btn_odemeBilgisiSil = new System.Windows.Forms.Button();
            this.btn_odemebilgisiEkle = new System.Windows.Forms.Button();
            this.dgv_odemeBilgileriIslemleri = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ödemeYöntemiİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeYöntemiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeYöntemiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeYöntemiGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeYöntemiTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeBilgisiİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeBilgisiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeBilgisiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeBilgisiGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeBilgisiTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeTurIslemleri)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeBilgileriIslemleri)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(11, 472);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(524, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ödeme Yöntemi Ekleme";
            // 
            // btn_odemeTurTemizle
            // 
            this.btn_odemeTurTemizle.Location = new System.Drawing.Point(185, 148);
            this.btn_odemeTurTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeTurTemizle.Name = "btn_odemeTurTemizle";
            this.btn_odemeTurTemizle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeTurTemizle.TabIndex = 6;
            this.btn_odemeTurTemizle.Text = "Temizle";
            this.btn_odemeTurTemizle.UseVisualStyleBackColor = true;
            this.btn_odemeTurTemizle.Click += new System.EventHandler(this.btn_odemeTurTemizle_Click);
            // 
            // btn_odemeTurGuncelle
            // 
            this.btn_odemeTurGuncelle.Location = new System.Drawing.Point(18, 148);
            this.btn_odemeTurGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeTurGuncelle.Name = "btn_odemeTurGuncelle";
            this.btn_odemeTurGuncelle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeTurGuncelle.TabIndex = 5;
            this.btn_odemeTurGuncelle.Text = "Güncelle";
            this.btn_odemeTurGuncelle.UseVisualStyleBackColor = true;
            this.btn_odemeTurGuncelle.Click += new System.EventHandler(this.btn_odemeTurGuncelle_Click);
            // 
            // btn_odemeTurSil
            // 
            this.btn_odemeTurSil.Location = new System.Drawing.Point(185, 89);
            this.btn_odemeTurSil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeTurSil.Name = "btn_odemeTurSil";
            this.btn_odemeTurSil.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeTurSil.TabIndex = 4;
            this.btn_odemeTurSil.Text = "Sil";
            this.btn_odemeTurSil.UseVisualStyleBackColor = true;
            this.btn_odemeTurSil.Click += new System.EventHandler(this.btn_odemeTurSil_Click);
            // 
            // btn_odemeTurEkle
            // 
            this.btn_odemeTurEkle.Location = new System.Drawing.Point(18, 89);
            this.btn_odemeTurEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeTurEkle.Name = "btn_odemeTurEkle";
            this.btn_odemeTurEkle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeTurEkle.TabIndex = 3;
            this.btn_odemeTurEkle.Text = "Ekle";
            this.btn_odemeTurEkle.UseVisualStyleBackColor = true;
            this.btn_odemeTurEkle.Click += new System.EventHandler(this.btn_odemeTurEkle_Click);
            // 
            // txt_odemeTuru
            // 
            this.txt_odemeTuru.Location = new System.Drawing.Point(16, 58);
            this.txt_odemeTuru.Margin = new System.Windows.Forms.Padding(2);
            this.txt_odemeTuru.Name = "txt_odemeTuru";
            this.txt_odemeTuru.Size = new System.Drawing.Size(322, 27);
            this.txt_odemeTuru.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ödeme Türü";
            // 
            // dgv_odemeTurIslemleri
            // 
            this.dgv_odemeTurIslemleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_odemeTurIslemleri.Location = new System.Drawing.Point(342, 23);
            this.dgv_odemeTurIslemleri.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_odemeTurIslemleri.Name = "dgv_odemeTurIslemleri";
            this.dgv_odemeTurIslemleri.RowHeadersWidth = 51;
            this.dgv_odemeTurIslemleri.RowTemplate.Height = 24;
            this.dgv_odemeTurIslemleri.Size = new System.Drawing.Size(170, 179);
            this.dgv_odemeTurIslemleri.TabIndex = 0;
            this.dgv_odemeTurIslemleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_odemeTurIslemleri_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_odemeTarihi);
            this.groupBox2.Controls.Add(this.cmb_odemeTuru);
            this.groupBox2.Controls.Add(this.cmb_kiralayanMusteri);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_tutar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_odemebilgisiTemizle);
            this.groupBox2.Controls.Add(this.btn_odemeBilgisiGuncelle);
            this.groupBox2.Controls.Add(this.btn_odemeBilgisiSil);
            this.groupBox2.Controls.Add(this.btn_odemebilgisiEkle);
            this.groupBox2.Controls.Add(this.dgv_odemeBilgileriIslemleri);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1221, 440);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ödeme Bilgileri";
            // 
            // dtp_odemeTarihi
            // 
            this.dtp_odemeTarihi.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtp_odemeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_odemeTarihi.Location = new System.Drawing.Point(10, 197);
            this.dtp_odemeTarihi.Name = "dtp_odemeTarihi";
            this.dtp_odemeTarihi.Size = new System.Drawing.Size(322, 27);
            this.dtp_odemeTarihi.TabIndex = 23;
            // 
            // cmb_odemeTuru
            // 
            this.cmb_odemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_odemeTuru.FormattingEnabled = true;
            this.cmb_odemeTuru.Location = new System.Drawing.Point(15, 267);
            this.cmb_odemeTuru.Name = "cmb_odemeTuru";
            this.cmb_odemeTuru.Size = new System.Drawing.Size(317, 33);
            this.cmb_odemeTuru.TabIndex = 22;
            // 
            // cmb_kiralayanMusteri
            // 
            this.cmb_kiralayanMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_kiralayanMusteri.FormattingEnabled = true;
            this.cmb_kiralayanMusteri.Location = new System.Drawing.Point(10, 64);
            this.cmb_kiralayanMusteri.Name = "cmb_kiralayanMusteri";
            this.cmb_kiralayanMusteri.Size = new System.Drawing.Size(322, 33);
            this.cmb_kiralayanMusteri.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(5, 239);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ödeme Türü";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(5, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ödeme Tarihi";
            // 
            // txt_tutar
            // 
            this.txt_tutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_tutar.Location = new System.Drawing.Point(10, 122);
            this.txt_tutar.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tutar.Name = "txt_tutar";
            this.txt_tutar.Size = new System.Drawing.Size(322, 30);
            this.txt_tutar.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(5, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tutar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kiralama Açıklaması";
            // 
            // btn_odemebilgisiTemizle
            // 
            this.btn_odemebilgisiTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_odemebilgisiTemizle.Location = new System.Drawing.Point(198, 374);
            this.btn_odemebilgisiTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemebilgisiTemizle.Name = "btn_odemebilgisiTemizle";
            this.btn_odemebilgisiTemizle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemebilgisiTemizle.TabIndex = 12;
            this.btn_odemebilgisiTemizle.Text = "Temizle";
            this.btn_odemebilgisiTemizle.UseVisualStyleBackColor = true;
            this.btn_odemebilgisiTemizle.Click += new System.EventHandler(this.btn_odemebilgisiTemizle_Click);
            // 
            // btn_odemeBilgisiGuncelle
            // 
            this.btn_odemeBilgisiGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_odemeBilgisiGuncelle.Location = new System.Drawing.Point(31, 374);
            this.btn_odemeBilgisiGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeBilgisiGuncelle.Name = "btn_odemeBilgisiGuncelle";
            this.btn_odemeBilgisiGuncelle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeBilgisiGuncelle.TabIndex = 11;
            this.btn_odemeBilgisiGuncelle.Text = "Güncelle";
            this.btn_odemeBilgisiGuncelle.UseVisualStyleBackColor = true;
            this.btn_odemeBilgisiGuncelle.Click += new System.EventHandler(this.btn_odemeBilgisiGuncelle_Click);
            // 
            // btn_odemeBilgisiSil
            // 
            this.btn_odemeBilgisiSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_odemeBilgisiSil.Location = new System.Drawing.Point(198, 315);
            this.btn_odemeBilgisiSil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemeBilgisiSil.Name = "btn_odemeBilgisiSil";
            this.btn_odemeBilgisiSil.Size = new System.Drawing.Size(153, 54);
            this.btn_odemeBilgisiSil.TabIndex = 10;
            this.btn_odemeBilgisiSil.Text = "Sil";
            this.btn_odemeBilgisiSil.UseVisualStyleBackColor = true;
            this.btn_odemeBilgisiSil.Click += new System.EventHandler(this.btn_odemeBilgisiSil_Click);
            // 
            // btn_odemebilgisiEkle
            // 
            this.btn_odemebilgisiEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_odemebilgisiEkle.Location = new System.Drawing.Point(31, 315);
            this.btn_odemebilgisiEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_odemebilgisiEkle.Name = "btn_odemebilgisiEkle";
            this.btn_odemebilgisiEkle.Size = new System.Drawing.Size(153, 54);
            this.btn_odemebilgisiEkle.TabIndex = 9;
            this.btn_odemebilgisiEkle.Text = "Ekle";
            this.btn_odemebilgisiEkle.UseVisualStyleBackColor = true;
            this.btn_odemebilgisiEkle.Click += new System.EventHandler(this.btn_odemebilgisiEkle_Click);
            // 
            // dgv_odemeBilgileriIslemleri
            // 
            this.dgv_odemeBilgileriIslemleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_odemeBilgileriIslemleri.Location = new System.Drawing.Point(508, 23);
            this.dgv_odemeBilgileriIslemleri.Name = "dgv_odemeBilgileriIslemleri";
            this.dgv_odemeBilgileriIslemleri.RowHeadersWidth = 51;
            this.dgv_odemeBilgileriIslemleri.RowTemplate.Height = 24;
            this.dgv_odemeBilgileriIslemleri.Size = new System.Drawing.Size(707, 405);
            this.dgv_odemeBilgileriIslemleri.TabIndex = 0;
            this.dgv_odemeBilgileriIslemleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_odemeBilgileriIslemleri_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödemeYöntemiİşlemleriToolStripMenuItem,
            this.ödemeBilgisiİşlemleriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 52);
            // 
            // ödemeYöntemiİşlemleriToolStripMenuItem
            // 
            this.ödemeYöntemiİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödemeYöntemiEkleToolStripMenuItem,
            this.ödemeYöntemiSilToolStripMenuItem,
            this.ödemeYöntemiGüncelleToolStripMenuItem,
            this.ödemeYöntemiTemizleToolStripMenuItem});
            this.ödemeYöntemiİşlemleriToolStripMenuItem.Name = "ödemeYöntemiİşlemleriToolStripMenuItem";
            this.ödemeYöntemiİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(245, 24);
            this.ödemeYöntemiİşlemleriToolStripMenuItem.Text = "Ödeme Yöntemi İşlemleri";
            // 
            // ödemeYöntemiEkleToolStripMenuItem
            // 
            this.ödemeYöntemiEkleToolStripMenuItem.Name = "ödemeYöntemiEkleToolStripMenuItem";
            this.ödemeYöntemiEkleToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.ödemeYöntemiEkleToolStripMenuItem.Text = "Ödeme Yöntemi Ekle";
            this.ödemeYöntemiEkleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeTurEkle_Click);
            // 
            // ödemeYöntemiSilToolStripMenuItem
            // 
            this.ödemeYöntemiSilToolStripMenuItem.Name = "ödemeYöntemiSilToolStripMenuItem";
            this.ödemeYöntemiSilToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.ödemeYöntemiSilToolStripMenuItem.Text = "Ödeme Yöntemi Sil";
            this.ödemeYöntemiSilToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeTurSil_Click);
            // 
            // ödemeYöntemiGüncelleToolStripMenuItem
            // 
            this.ödemeYöntemiGüncelleToolStripMenuItem.Name = "ödemeYöntemiGüncelleToolStripMenuItem";
            this.ödemeYöntemiGüncelleToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.ödemeYöntemiGüncelleToolStripMenuItem.Text = "Ödeme Yöntemi Güncelle";
            this.ödemeYöntemiGüncelleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeTurGuncelle_Click);
            // 
            // ödemeYöntemiTemizleToolStripMenuItem
            // 
            this.ödemeYöntemiTemizleToolStripMenuItem.Name = "ödemeYöntemiTemizleToolStripMenuItem";
            this.ödemeYöntemiTemizleToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.ödemeYöntemiTemizleToolStripMenuItem.Text = "Ödeme Yöntemi Temizle";
            this.ödemeYöntemiTemizleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeTurTemizle_Click);
            // 
            // ödemeBilgisiİşlemleriToolStripMenuItem
            // 
            this.ödemeBilgisiİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödemeBilgisiEkleToolStripMenuItem,
            this.ödemeBilgisiSilToolStripMenuItem,
            this.ödemeBilgisiGüncelleToolStripMenuItem,
            this.ödemeBilgisiTemizleToolStripMenuItem});
            this.ödemeBilgisiİşlemleriToolStripMenuItem.Name = "ödemeBilgisiİşlemleriToolStripMenuItem";
            this.ödemeBilgisiİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(245, 24);
            this.ödemeBilgisiİşlemleriToolStripMenuItem.Text = "Ödeme Bilgisi İşlemleri";
            // 
            // ödemeBilgisiEkleToolStripMenuItem
            // 
            this.ödemeBilgisiEkleToolStripMenuItem.Name = "ödemeBilgisiEkleToolStripMenuItem";
            this.ödemeBilgisiEkleToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.ödemeBilgisiEkleToolStripMenuItem.Text = "Ödeme Bilgisi Ekle";
            this.ödemeBilgisiEkleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemebilgisiEkle_Click);
            // 
            // ödemeBilgisiSilToolStripMenuItem
            // 
            this.ödemeBilgisiSilToolStripMenuItem.Name = "ödemeBilgisiSilToolStripMenuItem";
            this.ödemeBilgisiSilToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.ödemeBilgisiSilToolStripMenuItem.Text = "Ödeme Bilgisi Sil";
            this.ödemeBilgisiSilToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeBilgisiSil_Click);
            // 
            // ödemeBilgisiGüncelleToolStripMenuItem
            // 
            this.ödemeBilgisiGüncelleToolStripMenuItem.Name = "ödemeBilgisiGüncelleToolStripMenuItem";
            this.ödemeBilgisiGüncelleToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.ödemeBilgisiGüncelleToolStripMenuItem.Text = "Ödeme Bilgisi Güncelle";
            this.ödemeBilgisiGüncelleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemeBilgisiGuncelle_Click);
            // 
            // ödemeBilgisiTemizleToolStripMenuItem
            // 
            this.ödemeBilgisiTemizleToolStripMenuItem.Name = "ödemeBilgisiTemizleToolStripMenuItem";
            this.ödemeBilgisiTemizleToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.ödemeBilgisiTemizleToolStripMenuItem.Text = "Ödeme Bilgisi Temizle";
            this.ödemeBilgisiTemizleToolStripMenuItem.Click += new System.EventHandler(this.btn_odemebilgisiTemizle_Click);
            // 
            // frm_odemeIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 844);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_odemeIslemleri";
            this.Text = "frm_odemeIslemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_odemeIslemleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_odemeIslemleri_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeTurIslemleri)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_odemeBilgileriIslemleri)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_odemeBilgileriIslemleri;
        private System.Windows.Forms.Button btn_odemebilgisiTemizle;
        private System.Windows.Forms.Button btn_odemeBilgisiGuncelle;
        private System.Windows.Forms.Button btn_odemeBilgisiSil;
        private System.Windows.Forms.Button btn_odemebilgisiEkle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tutar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_odemeTarihi;
        private System.Windows.Forms.ComboBox cmb_odemeTuru;
        private System.Windows.Forms.ComboBox cmb_kiralayanMusteri;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ödemeYöntemiİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeYöntemiEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeYöntemiSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeYöntemiGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeYöntemiTemizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeBilgisiİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeBilgisiEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeBilgisiSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeBilgisiGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeBilgisiTemizleToolStripMenuItem;
    }
}