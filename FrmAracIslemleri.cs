using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama
{
    public partial class FrmAracIslemleri : Form
    {
        public FrmAracIslemleri()
        {
            InitializeComponent();
        }
        AnaMenu ana = new AnaMenu();

        VTI.Veritabani vt = new VTI.Veritabani();


        int kullaniciGorev_id;
        private void FrmAracIslemleri_Load(object sender, EventArgs e)
        {
            kullaniciGorev_id = ana.kullaniciGorevID;

            //MARKA DOLDURMA
            DataTable dt = vt.Select($@"select marka_id,marka_ad from tbl_aracMarka");
            dgv_MarkaIslemleri.DataSource = dt;
            dgv_MarkaIslemleri.Columns["marka_id"].Visible = false;

            cmb_markaSec.DataSource = dt;
            cmb_markaSec.ValueMember = "marka_id";
            cmb_markaSec.DisplayMember = "marka_ad";

            //MODEL DOLDURMA

            dgv_ModelIslemleri.DataSource = vt.Select($@"select 
                                                        mdl.model_id,
                                                        mrk.marka_ad,
                                                        mdl.model_ad
                                                    from tbl_aracMarka mrk
                                                    join tbl_aracModel mdl on mrk.marka_id = mdl.marka_id");
            dgv_ModelIslemleri.Columns["model_id"].Visible = false;

            //RENK DOLDURMA

            dgv_renkIslemleri.DataSource = vt.Select($@"select renk_id,renkAd from tbl_renk");
            dgv_renkIslemleri.Columns["renk_id"].Visible = false;

            //VİTES DOLDURMA
            dgv_vitesIslemleri.DataSource = vt.Select($@"select vites_tur_id,vites_tur from tbl_vitesTur");
            dgv_vitesIslemleri.Columns["vites_tur_id"].Visible = false;

            //YAKIT DOLDURMA
            dgv_yakitIslemleri.DataSource = vt.Select($@"select yakit_tur_id,yakit_tur from tbl_yakitTur");
            dgv_yakitIslemleri.Columns["yakit_tur_id"].Visible = false;

            //DURUM DOLDURMA
            dgv_durumIslemleri.DataSource = vt.Select($@"select durum_id,durum from tbl_durum");
            dgv_durumIslemleri.Columns["durum_id"].Visible = false;

            //ARAÇ TAMİR DURUM DOLDURMA
            dgv_aracTDIslemleri.DataSource = vt.Select($@"select tamirDurum_id,tamirDurum from tbl_AracTamirDurum");
            dgv_aracTDIslemleri.Columns["tamirDurum_id"].Visible = false;

            //ARAÇ BAKIM DOLDURMA
            dgv_aracBakimIslemleri.DataSource = vt.Select($@"select bakim_id,aciklama,maliyet,bakim_tarihi from tbl_aracBakim");
            dgv_aracBakimIslemleri.Columns["bakim_id"].Visible = false;


            //KASKO EKLEME
            dgv_kaskoIslmeleri.DataSource = vt.Select($@"select kasko_id,police_No,baslangic_Tarihi,bitis_Tarihi,kaskoSirketi from tbl_kasko");
            dgv_kaskoIslmeleri.Columns["kasko_id"].Visible = false;

            //SİGORTA EKLEME
            dgv_sigortaIslemleri.DataSource = vt.Select($@"select sigorta_id,police_No,baslangicTarihi,bitis_Tarihi,sigortaSirketi from tbl_sigorta");
            dgv_sigortaIslemleri.Columns["sigorta_id"].Visible = false;
        }


        #region Arac Islemleri
        private void tbpg_AracIslemleri_Enter(object sender, EventArgs e)
        {
            /* ÇALIŞAN KODLAR
             
            DataTable dt = vt.Select($@"select arm.marka_ad,am.model_ad,a.plaka,r.renkAd, a.gunluk_fiyat,a.eklenme_tarihi,vt.vites_tur,yt.yakit_tur,d.durum,a.mevcut_Km from tbl_arac a
                                                    join tbl_aracModel am on am.model_id = a.model_id
                                                    join tbl_aracMarka arm on arm.marka_id = am.marka_id
                                                    join tbl_renk r on r.renk_id = a.renk_id
                                                    join tbl_yakitTur yt on yt.yakit_tur_id = a.yakit_tur_id
                                                    join tbl_vitesTur vt on vt.vites_tur_id = a.vites_tur_id
                                                    join tbl_durum d on d.durum_id = a.durum_id
                                                    ");
            dataGridView1.DataSource = dt;
            */


            //EN SON ÇALIŞAN
            //DataTable dt = vt.Select($@"select arm.marka_id,arm.marka_ad,am.model_id,am.model_ad,a.arac_id, a.plaka,r.renk_id, r.renkAd, a.gunluk_fiyat,a.eklenme_tarihi,vt.vites_tur_id, vt.vites_tur,yt.yakit_tur_id,yt.yakit_tur,d.durum_id, d.durum,a.mevcut_Km from tbl_arac a
            //                                        join tbl_aracModel am on am.model_id = a.model_id
            //                                        join tbl_aracMarka arm on arm.marka_id = am.marka_id
            //                                        join tbl_renk r on r.renk_id = a.renk_id
            //                                        join tbl_yakitTur yt on yt.yakit_tur_id = a.yakit_tur_id
            //                                        join tbl_vitesTur vt on vt.vites_tur_id = a.vites_tur_id
            //                                        join tbl_durum d on d.durum_id = a.durum_id");

            DataTable dt = vt.Select($@"select arm.marka_id,arm.marka_ad,
                                        am.model_id,am.model_ad,
                                        a.arac_id, a.plaka,
                                        r.renk_id, r.renkAd, 
                                        a.gunluk_fiyat,a.eklenme_tarihi,
                                        vt.vites_tur_id, vt.vites_tur,
                                        yt.yakit_tur_id,yt.yakit_tur,
                                        d.durum_id,d.durum,
                                        a.mevcut_Km ,
                                        s.sigorta_id,s.police_No AS sigorta_police_no,
                                        k.kasko_id,k.police_No AS kasko_police_no,
                                        ab.bakim_id,ab.aciklama 
                                        from tbl_arac a
                                        join tbl_aracModel am on am.model_id = a.model_id
                                        join tbl_aracMarka arm on arm.marka_id = am.marka_id
                                        join tbl_renk r on r.renk_id = a.renk_id
                                        join tbl_yakitTur yt on yt.yakit_tur_id = a.yakit_tur_id
                                        join tbl_vitesTur vt on vt.vites_tur_id = a.vites_tur_id
                                        join tbl_durum d on d.durum_id = a.durum_id
                                        join tbl_sigorta s on s.sigorta_id = a.sigorta_id
                                        join tbl_kasko k on k.kasko_id = a.kasko_id
                                        join tbl_aracBakim ab on ab.bakim_id = a.bakim_id");

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["marka_id"].Visible = false;
            dataGridView1.Columns["model_id"].Visible = false;
            dataGridView1.Columns["arac_id"].Visible = false;
            dataGridView1.Columns["renk_id"].Visible = false;
            dataGridView1.Columns["vites_tur_id"].Visible = false;
            dataGridView1.Columns["yakit_tur_id"].Visible = false;
            dataGridView1.Columns["durum_id"].Visible = false;
            dataGridView1.Columns["sigorta_id"].Visible = false;
            dataGridView1.Columns["kasko_id"].Visible = false;
            dataGridView1.Columns["bakim_id"].Visible = false;

            DataTable dt2 = vt.Select($@"select ma.marka_id,ma.marka_ad,mo.model_id,mo.model_ad from tbl_aracModel mo join tbl_aracMarka ma on ma.marka_id = mo.marka_id");

            cmb_marka.DataSource = dt2;
            cmb_marka.ValueMember = "marka_id";
            cmb_marka.DisplayMember = "marka_ad";

            cmb_model.DataSource = dt2;
            cmb_model.ValueMember = "model_id";
            cmb_model.DisplayMember = "model_ad";

            DataTable dt3 = vt.Select("Select renk_id,renkAd from tbl_renk");

            cmb_renk.DataSource = dt3;
            cmb_renk.ValueMember = "renk_id";
            cmb_renk.DisplayMember = "renkAd";

            DataTable dt4 = vt.Select("Select vites_tur_id,vites_tur from tbl_vitesTur");
            cmb_vitesTur.DataSource = dt4;
            cmb_vitesTur.ValueMember = "vites_tur_id";
            cmb_vitesTur.DisplayMember = "vites_tur";

            DataTable dt5 = vt.Select("Select yakit_tur_id,yakit_tur from tbl_yakitTur");
            cmb_yakitTur.DataSource = dt5;
            cmb_yakitTur.ValueMember = "yakit_tur_id";
            cmb_yakitTur.DisplayMember = "yakit_tur";

            DataTable dt6 = vt.Select("Select durum_id,durum from tbl_durum");
            cmb_Durum.DataSource = dt6;
            cmb_Durum.ValueMember = "durum_id";
            cmb_Durum.DisplayMember = "durum";

            DataTable dt7 = vt.Select("Select bakim_id,aciklama from tbl_aracBakim");
            cmb_bakim.DataSource = dt7;
            cmb_bakim.ValueMember = "bakim_id";
            cmb_bakim.DisplayMember = "aciklama";

            DataTable dt8 = vt.Select("Select sigorta_id,police_No from tbl_sigorta");
            cmb_sigorta.DataSource = dt8;
            cmb_sigorta.ValueMember = "sigorta_id";
            cmb_sigorta.DisplayMember = "police_No";

            DataTable dt9 = vt.Select("Select kasko_id,police_No from tbl_kasko");
            cmb_kasko.DataSource = dt9;
            cmb_kasko.ValueMember = "kasko_id";
            cmb_kasko.DisplayMember = "police_No";


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            cmb_marka.Text = dataGridView1.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();
            cmb_model.Text = dataGridView1.Rows[e.RowIndex].Cells["model_ad"].Value.ToString();
            txt_plaka.Text = dataGridView1.Rows[e.RowIndex].Cells["plaka"].Value.ToString();
            cmb_renk.Text = dataGridView1.Rows[e.RowIndex].Cells["renkAd"].Value.ToString();
            txt_gunlukFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["gunluk_fiyat"].Value.ToString();

            if (DateTime.TryParse(dataGridView1.SelectedRows[0].Cells["eklenme_tarihi"].Value.ToString(), out DateTime dogum))
                dtp_eklenmeTarihi.Value = dogum;
            else
                dtp_eklenmeTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

            //dtp_eklenmeTarihi.Value = dataGridView1.Rows[e.RowIndex].Cells["eklenme_tarihi"].Value.ToString("yyyy-MM-dd");
            cmb_vitesTur.Text = dataGridView1.Rows[e.RowIndex].Cells["vites_tur"].Value.ToString();
            cmb_yakitTur.Text = dataGridView1.Rows[e.RowIndex].Cells["yakit_tur"].Value.ToString();
            cmb_Durum.Text = dataGridView1.Rows[e.RowIndex].Cells["durum"].Value.ToString();
            txt_mevcutKM.Text = dataGridView1.Rows[e.RowIndex].Cells["mevcut_Km"].Value.ToString();

            //AAAAAAAAAAAAAAAAAAAAAAAAAAa
            cmb_bakim.Text = dataGridView1.Rows[e.RowIndex].Cells["aciklama"].Value.ToString();
            cmb_sigorta.Text = dataGridView1.Rows[e.RowIndex].Cells["sigorta_police_no"].Value.ToString();
            cmb_kasko.Text = dataGridView1.Rows[e.RowIndex].Cells["kasko_police_no"].Value.ToString();

            //txt_plaka.Enabled = false;
        }

        //ARAÇ EKLE SİL GÜNCELLE İŞLEMLERİ
        private void btn_AracEkle_Click(object sender, EventArgs e)
        {
            if(cmb_marka.SelectedIndex== -1)
            {
                MessageBox.Show("Lütfen bir Marka Seçiniz.");
                return;
            }
            if (cmb_model.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Model Seçiniz.");
                return;
            }
            if (txt_plaka.Text =="")
            {
                MessageBox.Show("Lütfen bir Plaka Giriniz.");
                return;
            }
            DataTable dt = vt.Select(@"select plaka from tbl_arac");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["plaka"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_plaka.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Plaka Listede Zaten Mevcut");
                return;
            }
            if (cmb_renk.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Renk Seçiniz.");
                return;
            }
            if (txt_gunlukFiyat.Text =="")
            {
                MessageBox.Show("Lütfen Günlük Fiyat Seçiniz.");
                return;
            }
            double gunlukFiyat;
            if (!double.TryParse(
                txt_gunlukFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out gunlukFiyat))
            {
                MessageBox.Show("Günlük fiyat geçerli bir sayı olmalıdır (örn: 250 veya 250.50)");
                return;
            }
            //if(dtp_eklenmeTarihi.Text == "")
            //{
            //    MessageBox.Show("Lütfen Bir Tarih Seçiniz.");
            //}
            if (cmb_vitesTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Vites Türü Seçiniz.");
                return;
            }
            if (cmb_yakitTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Yakıt Türü Seçiniz.");
                return;
            }
            if (cmb_Durum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Durum Seçiniz.");
                return;
            }
            if(txt_mevcutKM.Text =="")
            {
                MessageBox.Show("Mevcut Kilometre Boş Kalamaz.");
                return;
            }
            int mevcutKm;
            if (!int.TryParse(txt_mevcutKM.Text, out mevcutKm))
            {
                MessageBox.Show("Mevcut Km sadece tam sayı olmalıdır");
                return;
            }
            if (cmb_bakim.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_sigorta.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_kasko.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }


            vt.Insert($@"Insert into tbl_arac( model_id,plaka,renk_id,gunluk_fiyat,eklenme_tarihi,yakit_tur_id,vites_tur_id,durum_id,sigorta_id,kasko_id,mevcut_Km,bakim_id)
                        values({cmb_model.SelectedValue},'{txt_plaka.Text.Replace("'","''")}',{cmb_renk.SelectedValue},{gunlukFiyat},GETDATE(),{cmb_yakitTur.SelectedValue},{cmb_vitesTur.SelectedValue},{cmb_Durum.SelectedValue},{cmb_sigorta.SelectedValue},{cmb_kasko.SelectedValue},{mevcutKm},{cmb_bakim.SelectedValue})");

            MessageBox.Show("Araç Başarıyla Eklendi");
            tbpg_AracIslemleri_Enter(null, null);

        }

        private void btn_AracSil_Click(object sender, EventArgs e)
        {
            if (cmb_marka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Marka Seçiniz.");
                return;
            }
            if (cmb_model.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Model Seçiniz.");
                return;
            }
            if (txt_plaka.Text == "")
            {
                MessageBox.Show("Lütfen bir Plaka Giriniz.");
                return;
            }
            //DataTable dt = vt.Select(@"select plaka from tbl_arac");

            //List<string> list = new List<string>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    list.Add(row["plaka"].ToString().ToUpper().Trim());
            //}

            //if (list.Contains(txt_plaka.Text.Trim().ToUpper()))
            //{
            //    MessageBox.Show("Bu Plaka Listede Zaten Mevcut");
            //    return;
            //}
            if (cmb_renk.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Renk Seçiniz.");
                return;
            }
            if (txt_gunlukFiyat.Text == "")
            {
                MessageBox.Show("Lütfen Günlük Fiyat Seçiniz.");
                return;
            }
            double gunlukFiyat;
            if (!double.TryParse(
                txt_gunlukFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out gunlukFiyat))
            {
                MessageBox.Show("Günlük fiyat geçerli bir sayı olmalıdır (örn: 250 veya 250.50)");
                return;
            }
            //if(dtp_eklenmeTarihi.Text == "")
            //{
            //    MessageBox.Show("Lütfen Bir Tarih Seçiniz.");
            //}
            if (cmb_vitesTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Vites Türü Seçiniz.");
                return;
            }
            if (cmb_yakitTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Yakıt Türü Seçiniz.");
                return;
            }
            if (cmb_Durum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Durum Seçiniz.");
                return;
            }
            if (txt_mevcutKM.Text == "")
            {
                MessageBox.Show("Mevcut Kilometre Boş Kalamaz.");
                return;
            }
            int mevcutKm;
            if (!int.TryParse(txt_mevcutKM.Text, out mevcutKm))
            {
                MessageBox.Show("Mevcut Km sadece tam sayı olmalıdır");
                return;
            }
            if (cmb_bakim.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_sigorta.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_kasko.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_arac where arac_id = '{dataGridView1.SelectedRows[0].Cells["arac_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                MessageBox.Show("Araç Başarıyla Silindi");
                tbpg_AracIslemleri_Enter(null, null);
            }
        }
        private void btn_AracGuncelle_MouseEnter(object sender, EventArgs e)
        {
            txt_plaka.Enabled = false;
        }

        private void btn_AracGuncelle_MouseLeave(object sender, EventArgs e)
        {
            txt_plaka.Enabled = true;
        }

        private void btn_AracGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek aracı tablodan seçiniz.");
                return;
            }
            if (cmb_marka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Marka Seçiniz.");
                return;
            }
            if (cmb_model.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Model Seçiniz.");
                return;
            }
            if (txt_plaka.Text == "")
            {
                MessageBox.Show("Lütfen bir Plaka Giriniz.");
                return;
            }
            //DataTable dt = vt.Select(@"select plaka from tbl_arac");

            //List<string> list = new List<string>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    list.Add(row["plaka"].ToString().ToUpper().Trim());
            //}

            //if (list.Contains(txt_plaka.Text.Trim().ToUpper()))
            //{
            //    MessageBox.Show("Bu Plaka Listede Zaten Mevcut");
            //    return;
            //}

            string eskiPlaka = dataGridView1.SelectedRows[0].Cells["plaka"].Value.ToString();

            if (txt_plaka.Text.Trim() != eskiPlaka)
            {
                MessageBox.Show("Plaka değiştirilemez.");
                txt_plaka.Text = eskiPlaka;
                return;
            }


            if (cmb_renk.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Renk Seçiniz.");
                return;
            }
            if (txt_gunlukFiyat.Text == "")
            {
                MessageBox.Show("Lütfen Günlük Fiyat Seçiniz.");
                return;
            }
            double gunlukFiyat;
            if (!double.TryParse(
                txt_gunlukFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out gunlukFiyat))
            {
                MessageBox.Show("Günlük fiyat geçerli bir sayı olmalıdır (örn: 250 veya 250.50)");
                return;
            }
            //if(dtp_eklenmeTarihi.Text == "")
            //{
            //    MessageBox.Show("Lütfen Bir Tarih Seçiniz.");
            //}
            if (cmb_vitesTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Vites Türü Seçiniz.");
                return;
            }
            if (cmb_yakitTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Yakıt Türü Seçiniz.");
                return;
            }
            if (cmb_Durum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Durum Seçiniz.");
                return;
            }
            if (txt_mevcutKM.Text == "")
            {
                MessageBox.Show("Mevcut Kilometre Boş Kalamaz.");
                return;
            }
            int mevcutKm;
            if (!int.TryParse(txt_mevcutKM.Text, out mevcutKm))
            {
                MessageBox.Show("Mevcut Km sadece tam sayı olmalıdır");
                return;
            }
            if (cmb_bakim.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_sigorta.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            if (cmb_kasko.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Bakım Seçiniz.");
                return;
            }
            try
            {
                vt.UpdateDelete($@"update tbl_arac
                                set model_id = {cmb_model.SelectedValue},
                                plaka = '{txt_plaka.Text.Replace("'", "''")}',
                                renk_id ={cmb_renk.SelectedValue},
                                gunluk_fiyat = {gunlukFiyat},
                                yakit_tur_id = {cmb_yakitTur.SelectedValue},
                                vites_tur_id = {cmb_vitesTur.SelectedValue},
                                durum_id = {cmb_Durum.SelectedValue},
                                sigorta_id = {cmb_sigorta.SelectedValue},
                                kasko_id = {cmb_kasko.SelectedValue},
                                mevcut_Km = {mevcutKm},
                                bakim_id = {cmb_bakim.SelectedValue},
                                eklenme_tarihi = GETDATE()

                                where arac_id = {dataGridView1.SelectedRows[0].Cells["arac_id"].Value.ToString()}");

                MessageBox.Show("Araç Başarıyla Güncellendi.");
                tbpg_AracIslemleri_Enter(null, null);
            }
            catch (Exception ex)
            {
                  MessageBox.Show("Lütfen Kayıtları Tek Tek Seçiniz." +ex.Message);
                return;
            }
           

        }
        private void btn_aracTemizle_Click(object sender, EventArgs e)
        {
            cmb_marka.SelectedIndex = -1;
            cmb_model.SelectedIndex = -1;
            txt_plaka.Text = "";
            cmb_renk.SelectedIndex = -1;
            txt_gunlukFiyat.Text = "";
            cmb_yakitTur.SelectedIndex = -1;
            cmb_vitesTur.SelectedIndex = -1;
            cmb_Durum.SelectedIndex = -1;
            cmb_sigorta.SelectedIndex = -1;
            cmb_kasko.SelectedIndex = -1;
            txt_mevcutKM.Text = "";
            cmb_bakim.SelectedIndex = -1;

            dataGridView1.ClearSelection();
        }
        #endregion



        //DETAYLARRRRRR

        #region DGV Doldurma
        

        
        #endregion

        #region DGV Tıklama
        private void dgv_MarkaIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txt_markaEkle.Text =
                dgv_MarkaIslemleri.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();
        }


        private void dgv_ModelIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cmb_markaSec.Text =
                dgv_ModelIslemleri.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();

            txt_modelEkle.Text =
                dgv_ModelIslemleri.Rows[e.RowIndex].Cells["model_ad"].Value.ToString();
        }
        private void dgv_renkIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_renkEkleme.Text = dgv_renkIslemleri.Rows[e.RowIndex].Cells["renkAd"].Value.ToString();
        }

        private void dgv_vitesIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            if (e.RowIndex < 0)
                return;
            txt_vitesEkleme.Text = dgv_vitesIslemleri.Rows[e.RowIndex].Cells["vites_tur"].Value.ToString();
        }

        private void dgv_yakitIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_yakitEkleme.Text = dgv_yakitIslemleri.Rows[e.RowIndex].Cells["yakit_tur"].Value.ToString();
        }
        private void dgv_durumIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_durumEkleme.Text = dgv_durumIslemleri.Rows[e.RowIndex].Cells["durum"].Value.ToString();
        }

        private void dgv_aracTDIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_aracTDekleme.Text = dgv_aracTDIslemleri.Rows[e.RowIndex].Cells["tamirDurum"].Value.ToString();
        }

        //ARAÇ DETAY TABLOSU
        private void dgv_aracBakimIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_aciklamaEkle.Text = dgv_aracBakimIslemleri.Rows[e.RowIndex].Cells["aciklama"].Value.ToString();
            txt_maliyetEkle.Text = dgv_aracBakimIslemleri.Rows[e.RowIndex].Cells["maliyet"].Value.ToString();

            if (DateTime.TryParse(dgv_aracBakimIslemleri.SelectedRows[0].Cells["bakim_tarihi"].Value.ToString(), out DateTime dogum))
                dtp_BakimTarihiekle.Value = dogum;
            else
                dtp_BakimTarihiekle.Value = DateTime.Now; // hata olursa bugüne set edelim
        }

        private void dgv_kaskoIslmeleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_policeNoEkleme.Text = dgv_kaskoIslmeleri.Rows[e.RowIndex].Cells["police_No"].Value.ToString();
            txt_kaskoSirketiEkleme.Text = dgv_kaskoIslmeleri.Rows[e.RowIndex].Cells["kaskoSirketi"].Value.ToString();

            if (DateTime.TryParse(dgv_kaskoIslmeleri.SelectedRows[0].Cells["baslangic_Tarihi"].Value.ToString(), out DateTime baslangicT))
                dtp_baslangicTarihiEkleme.Value = baslangicT;
            else
                dtp_baslangicTarihiEkleme.Value = DateTime.Now; // hata olursa bugüne set edelim

            if (DateTime.TryParse(dgv_kaskoIslmeleri.SelectedRows[0].Cells["bitis_Tarihi"].Value.ToString(), out DateTime bitisT))
                dtp_bitisTarihiEkleme.Value = bitisT;
            else
                dtp_bitisTarihiEkleme.Value = DateTime.Now; // hata olursa bugüne set edelim
        }

        private void dgv_sigortaIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_sigortaPoliceNo.Text = dgv_sigortaIslemleri.Rows[e.RowIndex].Cells["police_No"].Value.ToString();
            txt_sigortaSirketi.Text = dgv_sigortaIslemleri.Rows[e.RowIndex].Cells["sigortaSirketi"].Value.ToString();

            if (DateTime.TryParse(dgv_sigortaIslemleri.SelectedRows[0].Cells["baslangicTarihi"].Value.ToString(), out DateTime baslangicT))
                dtp_baslangicTarihiEkleme.Value = baslangicT;
            else
                dtp_sigortaBaslangicTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

            if (DateTime.TryParse(dgv_sigortaIslemleri.SelectedRows[0].Cells["bitis_Tarihi"].Value.ToString(), out DateTime bitisT))
                dtp_bitisTarihiEkleme.Value = bitisT;
            else
                dtp_sigortaBitisTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim
        }
        #endregion

        #region Marka Ekle Sil Güncelle

        private void btn_markaEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select marka_ad from tbl_aracMarka");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["marka_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_markaEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Marka Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"
                        insert into tbl_aracMarka (marka_ad)
                        values ('{txt_markaEkle.Text.Replace("'", "''")}')
                    ");

            MessageBox.Show("Marka Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_markaSil_Click(object sender, EventArgs e)
        {
            if (dgv_MarkaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_aracMarka where marka_ad = '{dgv_MarkaIslemleri.SelectedRows[0].Cells["marka_ad"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);

                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_markaGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select marka_ad from tbl_aracMarka");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["marka_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_markaEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Marka Listede Zaten Mevcut");
                return;
            }

            if (dgv_MarkaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            vt.UpdateDelete($@"update tbl_aracMarka
                                set marka_ad ='{txt_markaEkle.Text.Replace("'", "''")}'
                                where marka_ad ='{dgv_MarkaIslemleri.SelectedRows[0].Cells["marka_ad"].Value.ToString()}'");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);

        }

        private void btn_markaTemizle_Click(object sender, EventArgs e)
        {
            txt_markaEkle.Text = "";
        }

        #endregion

        #region Model Ekle Sil Güncelle
        private void btn_modelEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select model_ad from tbl_aracModel");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["model_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_modelEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Model Listede Zaten Mevcut");
                return;
            }



            vt.Insert($@"insert into tbl_aracModel (marka_id,model_ad)
                            values ({cmb_markaSec.SelectedValue},'{txt_modelEkle.Text.Replace("'", "''")}')");

            MessageBox.Show("Model Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);

        }
        private void btn_modelSil_Click(object sender, EventArgs e)
        {
            if (dgv_ModelIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_aracModel where model_id = '{dgv_ModelIslemleri.SelectedRows[0].Cells["model_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_modelGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select model_ad from tbl_aracModel");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["model_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_modelEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Model Listede Zaten Mevcut");
                return;
            }

            if (dgv_ModelIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            vt.UpdateDelete($@"
                                update tbl_aracModel
                                set 
                                    marka_id = {cmb_markaSec.SelectedValue},
                                    model_ad = '{txt_modelEkle.Text.Replace("'", "''")}'
                                where model_id = {Convert.ToInt32(dgv_ModelIslemleri.SelectedRows[0].Cells["model_id"].Value.ToString())}
                            ");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }
        private void btn_modelTemizle_Click(object sender, EventArgs e)
        {
            cmb_markaSec.SelectedIndex = -1;
            txt_modelEkle.Text = "";
        }



        #endregion

        #region Renk Ekle Sil Güncelle
        private void btn_renkEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select renkAd from tbl_renk");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["renkAd"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_renkEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Renk Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_renk (renkAd)
                                values('{txt_renkEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Renk Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_renkSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where renk_id = {Convert.ToInt32(dgv_renkIslemleri.SelectedRows[0].Cells["renk_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu renk araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_renkIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_renk
                                            where renkAd = '{dgv_renkIslemleri.SelectedRows[0].Cells["renkAd"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_renkGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select renkAd from tbl_renk");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["renkAd"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_renkEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Renk Listede Zaten Mevcut");
                return;
            }

            if (dgv_renkIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_renk
                                set renkAd ='{txt_renkEkleme.Text.Replace("'", "''").ToUpper()}'
                                where renk_id = {Convert.ToInt32(dgv_renkIslemleri.SelectedRows[0].Cells["renk_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_renkTemizle_Click(object sender, EventArgs e)
        {
            txt_renkEkleme.Text = "";
        }
        #endregion

        #region Vites Ekle Sil Güncelle
        private void btn_vitesEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select vites_tur from tbl_vitesTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["vites_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_vitesEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Vites Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_vitesTur (vites_tur)
                                values('{txt_vitesEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Vites Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }
        private void btn_vitesSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where vites_tur_id = {Convert.ToInt32(dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu vites araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_vitesTur
                                            where vites_tur = '{dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_vitesGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select vites_tur from tbl_vitesTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["vites_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_vitesEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Vites Listede Zaten Mevcut");
                return;
            }

            if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_vitesTur
                                set vites_tur ='{txt_vitesEkleme.Text.Replace("'", "''").ToUpper()}'
                                where renk_id = {Convert.ToInt32(dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_vitesTemizle_Click(object sender, EventArgs e)
        {
            txt_vitesEkleme.Text = "";
        }


        #endregion

        #region Yakıt Ekle Sil Güncelle
        private void btn_yakitEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select yakit_tur from tbl_yakitTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["yakit_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_yakitEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Yakıt Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_yakitTur (yakit_tur)
                                values('{txt_yakitEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Yakıt Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_yakitSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where yakit_tur_id = {Convert.ToInt32(dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu yakıt araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_yakitIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_yakitTur
                                            where yakit_tur_id = '{dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_yakitGuncelle_Click(object sender, EventArgs e)
        {

            DataTable dt = vt.Select(@"select yakit_tur from tbl_yakitTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["yakit_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_yakitEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Yakıt Listede Zaten Mevcut");
                return;
            }

            if (dgv_yakitIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_yakitTur
                                set yakit_tur ='{txt_yakitEkleme.Text.Replace("'", "''").ToUpper()}'
                                where yakit_tur_id = {Convert.ToInt32(dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_yakitTemizle_Click(object sender, EventArgs e)
        {
            txt_yakitEkleme.Text = "";
        }

        #endregion

        #region Durum Ekle Sil Güncelle
        private void btn_durumEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select durum from tbl_durum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["durum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_durumEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_durum (durum)
                                values('{txt_durumEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Durum Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_durumSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where durum_id = {Convert.ToInt32(dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu durum araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_durumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_durum
                                            where durum_id = '{dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Durum Başarıyla Silindi");
            }
        }

        private void btn_durumGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select durum from tbl_durum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["durum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_durumEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (dgv_durumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_durum
                                set durum ='{txt_durumEkleme.Text.Replace("'", "''").ToUpper()}'
                                where durum_id = {Convert.ToInt32(dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_durumTemizle_Click(object sender, EventArgs e)
        {
            txt_durumEkleme.Text = "";
        }

        #endregion

        #region Arac Tamir Durum Ekle Sil Güncelle
        private void btn_aracTDekle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_aracTDekleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_AracTamirDurum (tamirDurum)
                                values('{txt_aracTDekleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Durum Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_aracTDsil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_AracHasar where tamirDurum_id = {Convert.ToInt32(dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu durum araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_aracTDIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_AracTamirDurum
                                            where tamirDurum_id = '{dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Durum Başarıyla Silindi");
            }
        }

        private void btn_aracTDGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_aracTDekleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (dgv_aracTDIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_AracTamirDurum
                                set tamirDurum ='{txt_aracTDekleme.Text.Replace("'", "''").ToUpper()}'
                                where tamirDurum_id = {Convert.ToInt32(dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_aracTDtemizle_Click(object sender, EventArgs e)
        {
            txt_aracTDekleme.Text = "";
        }

        #endregion


        //ARAÇ DETAY EKLE SİL GÜNCELLE İŞLEMLERİ
        #region Araç Bakım Ekle Sil Güncelle
        private void btn_aracbakimEkle_Click(object sender, EventArgs e)
        {
           if(txt_aciklamaEkle.Text=="")
            {
                MessageBox.Show("Açıklama Boş Bırakılamaz.");
                return;
            }
           if(txt_maliyetEkle.Text=="")
            {
                MessageBox.Show("Maliyet Boş Bırakılamaz");
                return;
            }
           if(dtp_BakimTarihiekle.Text=="")
            {
                MessageBox.Show("Bakım Tarihi Boş Bırakılamaz.");
                return;
            }
            double maliyet;
            if (!double.TryParse(txt_maliyetEkle.Text.Replace(",", "."),
                     System.Globalization.NumberStyles.Any,//sayının içinde ondalık eksi boşluk falan olabilir hepsini kabul et
                     System.Globalization.CultureInfo.InvariantCulture,//sqldeki . ondalık belirtmek için c#ta , olduğu için (. ONDALIK KABUL EDİLİYO)
                     out maliyet))
            {
                MessageBox.Show("Maliyet geçerli bir sayı değil");
                return;
            }

            vt.Insert($@"
                        insert into tbl_aracBakim (aciklama, maliyet, bakim_tarihi)
                        values (
                            '{txt_aciklamaEkle.Text.Replace("'", "''")}',
                            {maliyet.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                            '{dtp_BakimTarihiekle.Value.ToString("yyyy-MM-dd")}'
                        )
                    ");

            MessageBox.Show("Durum Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_aracBakimSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where bakim_id = {Convert.ToInt32(dgv_aracBakimIslemleri.SelectedRows[0].Cells["bakim_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu Bakım araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_aracBakimIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            
            int kayitSay = vt.UpdateDelete($@"delete from tbl_aracBakim 
                                                where bakim_id={dgv_aracBakimIslemleri.SelectedRows[0].Cells["bakim_id"].Value.ToString()}");

            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Bakım Başarıyla Silindi");
            }
        }

        private void btn_aracBakimGuncelle_Click(object sender, EventArgs e)
        {
            if (dgv_aracBakimIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }
            double maliyet;
            if (!double.TryParse(txt_maliyetEkle.Text.Replace(",", "."),
                     System.Globalization.NumberStyles.Any,//sayının içinde ondalık eksi boşluk falan olabilir hepsini kabul et
                     System.Globalization.CultureInfo.InvariantCulture,//sqldeki . ondalık belirtmek için c#ta , olduğu için (. ONDALIK KABUL EDİLİYO)
                     out maliyet))
            {
                MessageBox.Show("Maliyet geçerli bir sayı değil");
                return;
            }
                        
            vt.UpdateDelete($@"
                                update tbl_aracBakim
                                set aciklama = '{txt_aciklamaEkle.Text.Replace("'","''")}',
                                maliyet ={maliyet.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                                bakim_tarihi= '{dtp_BakimTarihiekle.Value.ToString("yyyy-MM-dd")}'
                                where bakim_id = {Convert.ToInt32(dgv_aracBakimIslemleri.SelectedRows[0].Cells["bakim_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_aracBakimTemizle_Click(object sender, EventArgs e)
        {
            txt_aciklamaEkle.Text = "";
            txt_maliyetEkle.Text = "";
            dtp_BakimTarihiekle.Text = "";
        }

        #endregion

        #region Kasko Ekle Sil Güncelle
        private void btn_KaskoEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select police_No from tbl_kasko");

            List<string> listPolice = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                listPolice.Add(row["police_No"].ToString().ToUpper().Trim());
            }

            if (listPolice.Contains(txt_policeNoEkleme.Text.Trim()))
            {
                MessageBox.Show("Bu Poliçe No Listede Zaten Mevcut");
                return;
            }

            if (txt_policeNoEkleme.Text == "")
            {
                MessageBox.Show("Poliçe No Boş Bırakılamaz.");
                return;
            }
            if (txt_kaskoSirketiEkleme.Text == "")
            {
                MessageBox.Show("Kasko Şirketi Boş Bırakılamaz");
                return;
            }
            if (dtp_baslangicTarihiEkleme.Text == "")
            {
                MessageBox.Show("Başlangıç Tarihi Boş Bırakılamaz.");
                return;
            }
            if(dtp_bitisTarihiEkleme.Text =="")
            {
                MessageBox.Show("Bitiş Tarihi Boş Bırakılamaz.");
                return;
            }

            vt.Insert($@"insert into tbl_kasko(police_No,baslangic_Tarihi,bitis_Tarihi,kaskoSirketi)
                        values ('{txt_policeNoEkleme.Text.Replace("'", "''")}','{dtp_baslangicTarihiEkleme.Value.ToString("yyyy-MM-dd")}','{dtp_bitisTarihiEkleme.Value.ToString("yyyy-MM-dd")}','{txt_kaskoSirketiEkleme.Text.Replace("'", "''")}')");

            MessageBox.Show("Kasko Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_kaskoSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where kasko_id = {Convert.ToInt32(dgv_kaskoIslmeleri.SelectedRows[0].Cells["kasko_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu Kasko araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_kaskoIslmeleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }


            int kayitSay = vt.UpdateDelete($@"delete from tbl_kasko 
                                                where kasko_id={dgv_kaskoIslmeleri.SelectedRows[0].Cells["kasko_id"].Value.ToString()}");

            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Kasko Başarıyla Silindi");
            }
        }
        private void btn_kaskoGuncelle_Click(object sender, EventArgs e)
        {
            //DataTable dt = vt.Select(@"select police_No from tbl_kasko");

            //List<string> listPolice = new List<string>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    listPolice.Add(row["police_No"].ToString().ToUpper().Trim());
            //}

            //if (listPolice.Contains(txt_policeNoEkleme.Text.Trim()))
            //{
            //    MessageBox.Show("Bu Poliçe No Listede Zaten Mevcut");
            //    return;
            //}

            if (dgv_kaskoIslmeleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }
            
            vt.UpdateDelete($@"update tbl_kasko
                                set police_No ='{txt_policeNoEkleme.Text.Replace("'", "''")}',
                                baslangic_Tarihi='{dtp_baslangicTarihiEkleme.Value.ToString("yyyy-MM-dd")}',
                                bitis_Tarihi='{dtp_bitisTarihiEkleme.Value.ToString("yyyy-MM-dd")}',
                                kaskoSirketi='{txt_kaskoSirketiEkleme.Text.Replace("'", "''")}'
                                where kasko_id = {Convert.ToInt32(dgv_kaskoIslmeleri.SelectedRows[0].Cells["kasko_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_kaskoTemizle_Click(object sender, EventArgs e)
        {
            txt_policeNoEkleme.Text = "";
            txt_kaskoSirketiEkleme.Text = "";
            dtp_baslangicTarihiEkleme.Text = "";
            dtp_bitisTarihiEkleme.Text = "";
        }


        #endregion

        #region Sigorta Ekle Sil Güncelle

        private void btn_sigortaEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select police_No from tbl_sigorta");

            List<string> listPolice = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                listPolice.Add(row["police_No"].ToString().ToUpper().Trim());
            }

            if (listPolice.Contains(txt_sigortaPoliceNo.Text.Trim()))
            {
                MessageBox.Show("Bu Poliçe No Listede Zaten Mevcut");
                return;
            }

            if (txt_sigortaPoliceNo.Text == "")
            {
                MessageBox.Show("Poliçe No Boş Bırakılamaz.");
                return;
            }
            if (txt_sigortaSirketi.Text == "")
            {
                MessageBox.Show("Sigorta Şirketi Boş Bırakılamaz");
                return;
            }
            if (dtp_sigortaBaslangicTarihi.Text == "")
            {
                MessageBox.Show("Başlangıç Tarihi Boş Bırakılamaz.");
                return;
            }
            if (dtp_sigortaBitisTarihi.Text == "")
            {
                MessageBox.Show("Bitiş Tarihi Boş Bırakılamaz.");
                return;
            }

            vt.Insert($@"insert into tbl_sigorta (police_No,baslangicTarihi,bitis_Tarihi,sigortaSirketi)
                        values ('{txt_sigortaPoliceNo.Text.Replace("'", "''")}','{dtp_sigortaBaslangicTarihi.Value.ToString("yyyy-MM-dd")}','{dtp_sigortaBitisTarihi.Value.ToString("yyyy-MM-dd")}','{txt_sigortaSirketi.Text.Replace("'", "''")}')");

            MessageBox.Show("Sigorta Başarıyla Eklendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_sigortaSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where sigorta_id = {Convert.ToInt32(dgv_sigortaIslemleri.SelectedRows[0].Cells["sigorta_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu Sigorta araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_sigortaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }


            int kayitSay = vt.UpdateDelete($@"delete from tbl_sigorta 
                                                where sigorta_id={dgv_kaskoIslmeleri.SelectedRows[0].Cells["kasko_id"].Value.ToString()}");

            if (kayitSay > 0)
            {
                FrmAracIslemleri_Load(null, null);
                MessageBox.Show("Sigorta Başarıyla Silindi");
            }
        }

        private void btn_sigortaGuncelle_Click(object sender, EventArgs e)
        {
            if (dgv_sigortaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_sigorta
                                set police_No ='{txt_sigortaPoliceNo.Text.Replace("'", "''")}',
                                baslangicTarihi='{dtp_sigortaBaslangicTarihi.Value.ToString("yyyy-MM-dd")}',
                                bitis_Tarihi='{dtp_sigortaBitisTarihi.Value.ToString("yyyy-MM-dd")}',
                                sigortaSirketi='{txt_sigortaSirketi.Text.Replace("'", "''")}'
                                where sigorta_id = {Convert.ToInt32(dgv_sigortaIslemleri.SelectedRows[0].Cells["sigorta_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            FrmAracIslemleri_Load(null, null);
        }

        private void btn_sigortaTemizle_Click(object sender, EventArgs e)
        {
            txt_sigortaPoliceNo.Text = "";
            txt_sigortaSirketi.Text = "";
            dtp_sigortaBaslangicTarihi.Text = "";
            dtp_sigortaBitisTarihi.Text = "";
        }









        #endregion

        private void FrmAracIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_AracEkle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_AracSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                btn_AracGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.T)
                btn_aracTemizle_Click(sender, e);
        }

        
    }






}

