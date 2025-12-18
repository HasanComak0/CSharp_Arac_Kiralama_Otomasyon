using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AracKiralama_HC;

namespace Arac_Kiralama
{
    public partial class AnaMenu : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        GirisYap girisYap = new GirisYap();
        AracKiralama_HC.DigerIslemler dg = new AracKiralama_HC.DigerIslemler();
        public string anamenuKullaniciAdi;
        public AnaMenu(string gelenKullaniciAdi)
        {
            InitializeComponent();
            anamenuKullaniciAdi = gelenKullaniciAdi;
        }
        public AnaMenu()
        {
            InitializeComponent();
        }


        private void tbpg_profil_Enter(object sender, EventArgs e)
        {
           
            DataTable dtKullanici = vt.Select($@"
        SELECT kullanici_id, kullaniciAdi, gorev_id, profil_resim_yolu
        FROM tbl_kullanici
        WHERE kullaniciAdi = '{anamenuKullaniciAdi.Replace("'", "''")}'
    ");

            if (dtKullanici.Rows.Count == 0)
            {
                MessageBox.Show("Kullanıcı bulunamadı");
                return;
            }

            int kullaniciId = Convert.ToInt32(dtKullanici.Rows[0]["kullanici_id"]);
            int gorevId = Convert.ToInt32(dtKullanici.Rows[0]["gorev_id"]);

            txt_kullaniciAdi.Text = dtKullanici.Rows[0]["kullaniciAdi"].ToString();

            
            cbx_pozisyon.DataSource = vt.Select("SELECT gorev_id, gorev_adi FROM tbl_gorev");
            cbx_pozisyon.DisplayMember = "gorev_adi";
            cbx_pozisyon.ValueMember = "gorev_id";
            cbx_pozisyon.SelectedValue = gorevId;

            
            DataTable dtPersonel = vt.Select($@"
                    SELECT personelAd, personelSoyad, tc_No, dogum_Tarihi, ehliyet_no, telefon, email
                    FROM tbl_personel
                    WHERE kullanici_id = {kullaniciId}
                ");

            if (dtPersonel.Rows.Count > 0)
            {
                txt_ad.Text = dtPersonel.Rows[0]["personelAd"].ToString();
                txt_soyad.Text = dtPersonel.Rows[0]["personelSoyad"].ToString();
                txt_tcNo.Text = dtPersonel.Rows[0]["tc_No"].ToString();
                dtp_dogumTarihi.Value = Convert.ToDateTime(dtPersonel.Rows[0]["dogum_Tarihi"]);
                txt_EhliyetNo.Text = dtPersonel.Rows[0]["ehliyet_no"].ToString();
                mtb_telefon.Text = dtPersonel.Rows[0]["telefon"].ToString();
                txt_ePosta.Text = dtPersonel.Rows[0]["email"].ToString();
            }
            else
            {
               
                DataTable dtMusteri = vt.Select($@"
                        SELECT musteriAd, musteriSoyad, telefon, email
                        FROM tbl_musteri
                        WHERE kullanici_id = {kullaniciId}
                    ");

                if (dtMusteri.Rows.Count > 0)
                {
                    txt_ad.Text = dtMusteri.Rows[0]["musteriAd"].ToString();
                    txt_soyad.Text = dtMusteri.Rows[0]["musteriSoyad"].ToString();
                    mtb_telefon.Text = dtMusteri.Rows[0]["telefon"].ToString();
                    txt_ePosta.Text = dtMusteri.Rows[0]["email"].ToString();
                }
            }

            
            if (gorevId == 2) // müşteri
            {
                tbpg_personelEkle.Visible = false;
                tbpg_MusteriEkle.Visible = false;
                tbpg_gorevIslemleri.Visible = false;
                tbpg_kullaniciEkle.Visible = false;

                tsb_odemeIslemleri.Enabled = false;
                tsb_aracIslemleri.Enabled = false;
                tsb_kiraEvraklari.Enabled = false;
            }

        }
        public int kullaniciGorevID;
        private void AnaMenu_Load(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select gorev_id from tbl_kullanici
                            where kullaniciAdi= '{anamenuKullaniciAdi}'");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Kullanıcı Bulunamadı.");
                return;
            }
            else
                kullaniciGorevID = Convert.ToInt32(dt.Rows[0]["gorev_id"]);
            //if(kullaniciGorevID !=4)
            //TabControl.TabPages.Remove(tbpg_personelEkle);


        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tbpg_personelEkle && kullaniciGorevID != 4)
            {
                MessageBox.Show("Bu Sayfaya Yalnızca Admin Erişebilir.");
                e.Cancel = true;
            }

            if (e.TabPage == tbpg_MusteriEkle && kullaniciGorevID != 4)
            {
                MessageBox.Show("Bu Sayfaya Yalnızca Admin Erişebilir.");
                e.Cancel = true;
            }
            if (e.TabPage == tbpg_kullaniciEkle && kullaniciGorevID != 4)
            {
                MessageBox.Show("Bu Sayfaya Yalnızca Admin Erişebilir.");
                e.Cancel = true;
            }
            if (e.TabPage == tbpg_gorevIslemleri && kullaniciGorevID != 4)
            {
                MessageBox.Show("Bu Sayfaya Yalnızca Admin Erişebilir.");
                e.Cancel = true;
            }
        }

        private void btn_kullaniciSifreDegistir_Click(object sender, EventArgs e)
        {
            KullaniciSifreDegistirme kullaniciSifre = new KullaniciSifreDegistirme(txt_kullaniciAdi.Text);
            kullaniciSifre.ShowDialog();
        }
        SifreDegistirme sifreDegistirme = new SifreDegistirme();
        Mail_islemler mail = new Mail_islemler();

        //PERSONEL KISMI
        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            if (txt_pKullaniciAdi.Text == "")
            {

                MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                return;
            }
            DataTable dt2 = vt.Select($@"select k.kullaniciAdi,p.telefon,p.email,p.tc_no from tbl_kullanici as k
                                        join tbl_personel as p on p.kullanici_id= k.kullanici_id where k.kullaniciAdi= '{txt_pKullaniciAdi.Text}'");

            if (dt2.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                return;
            }
            DataTable dt3 = vt.Select($@"
                                        select k.kullaniciAdi,p.telefon,p.email,p.tc_no 
                                        from tbl_kullanici as k
                                        join tbl_personel as p on p.kullanici_id= k.kullanici_id 
                                        where p.tc_no = '{txt_pTcNo.Text}'
                                    ");

            if (dt3.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu TC'ye Sahip Biri Zaten Var";
                return;
            }
            if (txt_pAd.Text == "")
            {
                lbl_Uyarilar.Text = "Ad Boş Bırakılamaz";
                return;
            }
            if ((txt_pAd.Text.Length < 2 || txt_pAd.Text.Length > 30))
            {
                lbl_Uyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (txt_pSoyad.Text == "")
            {
                lbl_Uyarilar.Text = "Soyad Boş Bırakılamaz";
                return;
            }
            if (txt_pSoyad.Text.Length < 2 || txt_pSoyad.Text.Length > 30)
            {
                lbl_Uyarilar.Text = "Soyad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (dtp_pDogumTarihi.Text == "")
            {
                lbl_Uyarilar.Text = "Doğum Tarihi Boş Bırakılamaz.";
                return;
            }
            if (txt_pEhliyetNo.Text == "")
            {
                lbl_Uyarilar.Text = "EhliyetNo Boş Bırakılamaz";
                return;
            }
            if (mtb_pTelefon.Text == "")
            {
                lbl_Uyarilar.Text = "Telefon Numarası Boş Bırakılamaz.";
                return;
            }
            DataTable dt4 = vt.Select($@"
                                        select k.kullaniciAdi,p.telefon,p.email,p.tc_no 
                                        from tbl_kullanici as k
                                        join tbl_personel as p on p.kullanici_id= k.kullanici_id 
                                        where p.telefon = '{mtb_pTelefon.Text}'
                                    ");
            if (dt4.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                return;
            }
            DataTable dt5 = vt.Select($@"
                                        select k.kullaniciAdi,p.telefon,p.email,p.tc_no 
                                        from tbl_kullanici as k
                                        join tbl_personel as p on p.kullanici_id = k.kullanici_id 
                                        where p.email = '{txt_pEposta.Text.Replace("'", "''")}'
                                    ");
            if (dt5.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu E-Posta Sistemde Zaten Kayıtlı... Başka Bir E-Posta Deneyin.";
                return;
            }
            if (sifreDegistirme.buyukHarfVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.kucukHarfVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.sayiVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                return;
            }
            if (sifreDegistirme.sembolVarMi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
                return;
            }
            if (txtpSifre.Text != txt_pSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.");
                return;
            }
            else if (txt_pOnayKodu.Text.ToUpper() != dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama Kodu Hatalı");
                return;
            }
            else
            {
                /// ORTAK: KULLANICI EKLE
                vt.Insert($@"
                                    INSERT INTO tbl_kullanici (kullaniciAdi, sifre, gorev_id, olusturulma_tarihi, profil_resim_yolu)
                                    VALUES(
                                        '{txt_pKullaniciAdi.Text.Replace("'", "''")}',
                                        '{dg.MD5Sifrele(txt_pSifreTekrar.Text)}',
                                            1,
                                        GETDATE(),
                                        'DenemeResimYolu'
                                    )
                                ");

                // YENİ KULLANICI ID'sini al
                DataTable dataT = vt.Select($@"
                                                    SELECT TOP 1 kullanici_id
                                                    FROM tbl_kullanici
                                                    WHERE kullaniciAdi = '{txt_pKullaniciAdi.Text.Replace("'", "''")}'
                                                    ORDER BY kullanici_id DESC
                                                ");

                int yeniKullaniciID = Convert.ToInt32(dataT.Rows[0]["kullanici_id"]);



                
                vt.Insert($@"
                                    INSERT INTO tbl_personel
                                    (kullanici_id, personelAd, personelSoyad, tc_no, dogum_tarihi, ehliyet_no, telefon, email)
                                    VALUES(
                                        {yeniKullaniciID},
                                        '{txt_pAd.Text.Replace("'", "''")}',
                                        '{txt_pSoyad.Text.Replace("'", "''")}',
                                        '{txt_pTcNo.Text.Replace("'", "''")}',
                                        '{dtp_pDogumTarihi.Value.ToString("yyyy-MM-dd")}',
                                        '{txt_pEhliyetNo.Text.Replace("'", "''")}',
                                        '{mtb_pTelefon.Text.Replace("'", "''")}',
                                        '{txt_pEposta.Text.Replace("'", "''")}'
                                    )
                                ");
                MessageBox.Show("Personel Kaydı Başarıyla Oluşturuldu.");
                tbpg_personelEkle_Enter(null, null);

            }


        }
        string dogrulamaKodu;
        private void btn_kodGonder_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = "";
            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_pEposta.Text, dogrulamaKodu);

        }
        private void tbpg_personelEkle_Enter(object sender, EventArgs e)
        {
            dgv_Personeller.DataSource = vt.Select($@"select k.kullaniciAdi, p.personelAd,p.personelSoyad,p.email,p.tc_No,p.telefon,p.dogum_Tarihi,p.ehliyet_no,k.olusturulma_tarihi from tbl_kullanici k
                                                        join tbl_personel p on k.kullanici_id=p.kullanici_id");

        }
        private void dgv_Personeller_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Personeller.SelectedRows.Count == 0)
                return;
            txt_pKullaniciAdi.Text = dgv_Personeller.SelectedRows[0].Cells["kullaniciAdi"].Value.ToString();
            txt_pAd.Text = dgv_Personeller.SelectedRows[0].Cells["personelAd"].Value.ToString();
            txt_pSoyad.Text = dgv_Personeller.SelectedRows[0].Cells["personelSoyad"].Value.ToString();

            if (DateTime.TryParse(dgv_Personeller.SelectedRows[0].Cells["dogum_Tarihi"].Value.ToString(), out DateTime dogum))
                dtp_pDogumTarihi.Value = dogum;
            else
                dtp_pDogumTarihi.Value = DateTime.Now; 

            txt_pTcNo.Text = dgv_Personeller.SelectedRows[0].Cells["tc_No"].Value.ToString();
            mtb_pTelefon.Text = dgv_Personeller.SelectedRows[0].Cells["telefon"].Value.ToString();
            txt_pEhliyetNo.Text = dgv_Personeller.SelectedRows[0].Cells["ehliyet_no"].Value.ToString();
            txt_pEposta.Text = dgv_Personeller.SelectedRows[0].Cells["email"].Value.ToString();
        }

        string KullaniciID;
        private void btn_sil_Click(object sender, EventArgs e)
        {
            KullaniciID = "";
            if (txt_pKullaniciAdi.Text != "")
            {
                try
                {
                    DataTable dt = vt.Select($@"select p.kullanici_id from tbl_personel p
                                                join tbl_kullanici k on k.kullanici_id = p.kullanici_id
                                                where k.kullaniciAdi = '{txt_pKullaniciAdi.Text}'");

                    KullaniciID = dt.Rows[0]["kullanici_id"].ToString();

                    vt.UpdateDelete($@"delete from tbl_personel where kullanici_id = {KullaniciID}");

                    vt.UpdateDelete($@"delete from tbl_kullanici where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı Silinirken Bir Hata Oluştu...\nHata: " + ex.Message);
                }


            }
            else
                MessageBox.Show("Silinecek Kullanıcıyı Tablodan Seçiniz.");

            tbpg_personelEkle_Enter(null, null);
        }

        private void btn_personelGuncelle_Click(object sender, EventArgs e)
        {
            KullaniciID = "";

            DataTable dt = vt.Select($@"select p.kullanici_id from tbl_personel p
                                                join tbl_kullanici k on k.kullanici_id = p.kullanici_id
                                                where k.kullaniciAdi = '{txt_pKullaniciAdi.Text}'");

            KullaniciID = dt.Rows[0]["kullanici_id"].ToString();

            if (txt_pKullaniciAdi.Text == "")
            {

                MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                return;
            }
            
            if(txt_pKullaniciAdi.Text =="")
            {
                lbl_Uyarilar.Text = "Kullanıcı Adı Boş Kalamaz.";
            }
            if(txt_pTcNo.Text=="")
            {
                lbl_Uyarilar.Text = "TcNo Boş Kalamaz.";
            }
            if (txt_pAd.Text == "")
            {
                lbl_Uyarilar.Text = "Ad Boş Bırakılamaz";
                return;
            }
            if ((txt_pAd.Text.Length < 2 || txt_pAd.Text.Length > 30))
            {
                lbl_Uyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (txt_pSoyad.Text == "")
            {
                lbl_Uyarilar.Text = "Soyad Boş Bırakılamaz";
                return;
            }
            if (txt_pSoyad.Text.Length < 2 || txt_pSoyad.Text.Length > 30)
            {
                lbl_Uyarilar.Text = "Soyad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (dtp_pDogumTarihi.Text == "")
            {
                lbl_Uyarilar.Text = "Doğum Tarihi Boş Bırakılamaz.";
                return;
            }
            if (txt_pEhliyetNo.Text == "")
            {
                lbl_Uyarilar.Text = "EhliyetNo Boş Bırakılamaz";
                return;
            }
            if (mtb_pTelefon.Text == "")
            {
                lbl_Uyarilar.Text = "Telefon Numarası Boş Bırakılamaz.";
                return;
            }
            
            if (txt_pEposta.Text=="")
            {
                lbl_Uyarilar.Text = "E Posta Boş Kalamaz";
            }
            if (sifreDegistirme.buyukHarfVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.kucukHarfVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.sayiVarmi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                return;
            }
            if (sifreDegistirme.sembolVarMi(txtpSifre.Text) == false)
            {
                lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
                return;
            }
            if (txtpSifre.Text != txt_pSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.");
                return;
            }
            if (txt_pOnayKodu.Text.ToUpper() != dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama Kodu Hatalı");
                return;
            }
            else
            {
                try
                {
                    vt.UpdateDelete($@"
                                update tbl_personel
                                set personelAd   = '{txt_pAd.Text.Replace("'", "''")}',
                                    personelSoyad = '{txt_pSoyad.Text.Replace("'", "''")}',
                                    tc_No = '{txt_pTcNo.Text.Replace("'", "''")}',
                                    dogum_Tarihi = '{dtp_pDogumTarihi.Value.ToString("yyyy-MM-dd")}',
                                    ehliyet_no = '{txt_pEhliyetNo.Text.Replace("'", "''")}',
                                    telefon = '{mtb_pTelefon.Text.Replace("'", "''")}',
                                    email = '{txt_pEposta.Text.Replace("'", "''")}'
                                    where kullanici_id = {KullaniciID}
                                    ");

                    vt.UpdateDelete($@"
                                    update tbl_kullanici
                                    set  kullaniciAdi = '{txt_pKullaniciAdi.Text.Replace("'", "''")}',
                                        sifre = '{dg.MD5Sifrele(txt_pSifreTekrar.Text)}'
                                         where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Personel Bilgileri Başarıyla Güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Bir Hata Oluştu...\nHata: " + ex.Message);
                }
                tbpg_personelEkle_Enter(null, null);

            }



        }

        private void btn_pTemizle_Click(object sender, EventArgs e)
        {
            txt_pKullaniciAdi.Clear();
            txt_pAd.Clear();
            txt_pSoyad.Clear();
            txt_pTcNo.Clear();
            dtp_pDogumTarihi.Value = DateTime.Now;
            txt_pEhliyetNo.Clear();
            mtb_pTelefon.Clear();
            txt_pEposta.Clear();
        }


        //MÜŞTERİ KISMI
        private void btn_musteriKaydet_Click(object sender, EventArgs e)
        {



            if (txt_mKullaniciAdi.Text == "")
            {

                MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                return;
            }
            DataTable dt2 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= '{txt_mKullaniciAdi.Text}'");

            if (dt2.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                return;
            }
            DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= '{txt_mTcNo.Text}'");

            if (dt3.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu TC'ye Sahip Biri Zaten Var";
                return;
            }
            if (txt_mAd.Text == "")
            {
                lbl_mUyarilar.Text = "Ad Boş Bırakılamaz";
                return;
            }
            if ((txt_mAd.Text.Length < 2 || txt_mAd.Text.Length > 30))
            {
                lbl_mUyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (txt_mSoyad.Text == "")
            {
                lbl_mUyarilar.Text = "Soyad Boş Bırakılamaz";
                return;
            }
            if (txt_mSoyad.Text.Length < 2 || txt_mSoyad.Text.Length > 30)
            {
                lbl_mUyarilar.Text = "Soyad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (dtp_mDogumTarihi.Text == "")
            {
                lbl_mUyarilar.Text = "Doğum Tarihi Boş Bırakılamaz.";
                return;
            }
            if (txt_mEhliyetNo.Text == "")
            {
                lbl_mUyarilar.Text = "EhliyetNo Boş Bırakılamaz";
                return;
            }
            if (mtb_mTelefon.Text == "")
            {
                lbl_mUyarilar.Text = "Telefon Numarası Boş Bırakılamaz.";
                return;
            }
            DataTable dt4 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= '{mtb_mTelefon.Text}'");
            if (dt4.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                return;
            }
            DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= '{txt_mEposta.Text}'");
            if (dt5.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu E-Posta Sistemde Zaten Kayıtlı... Başka Bir E-Posta Deneyin.";
                return;
            }
            if (sifreDegistirme.buyukHarfVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.kucukHarfVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.sayiVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                return;
            }
            if (sifreDegistirme.sembolVarMi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
                return;
            }
            if (txt_mSifre.Text != txt_mSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.");
                return;
            }
            if (txt_mOnayKodu.Text.ToUpper() != dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama Kodu Hatalı");
                return;
            }
            else
            {
                /// ORTAK: KULLANICI EKLE
                vt.Insert($@"
                                    INSERT INTO tbl_kullanici (kullaniciAdi, sifre, gorev_id, olusturulma_tarihi, profil_resim_yolu)
                                    VALUES(
                                        '{txt_mKullaniciAdi.Text.Replace("'", "''")}',
                                        '{dg.MD5Sifrele(txt_mSifreTekrar.Text)}',
                                            2,
                                        GETDATE(),
                                        'DenemeResimYolu'
                                    )
                                ");

                // YENİ KULLANICI ID'sini al
                DataTable dataT = vt.Select($@"
                                                    SELECT TOP 1 kullanici_id
                                                    FROM tbl_kullanici
                                                    WHERE kullaniciAdi = '{txt_mKullaniciAdi.Text.Replace("'", "''")}'
                                                    ORDER BY kullanici_id DESC
                                                ");

                int yeniKullaniciID = Convert.ToInt32(dataT.Rows[0]["kullanici_id"]);

               
                vt.Insert($@"
                                    INSERT INTO tbl_musteri
                                    (kullanici_id, tc_no, dogum_tarihi, ehliyet_no, email, telefon, musteriAd, musteriSoyad)
                                    VALUES(
                                        {yeniKullaniciID},
                                        '{txt_mTcNo.Text.Replace("'", "''")}',
                                        '{dtp_mDogumTarihi.Value.ToString("yyyy-MM-dd")}',
                                        '{txt_mEhliyetNo.Text.Replace("'", "''")}',
                                        '{txt_mEposta.Text.Replace("'", "''")}',
                                        '{mtb_mTelefon.Text.Replace("'", "''")}',
                                        '{txt_mAd.Text.Replace("'", "''")}',
                                        '{txt_mSoyad.Text.Replace("'", "''")}'
                                    )
                                ");
                MessageBox.Show("Müşteri Kaydı Başarıyla Oluşturuldu.");
                tbpg_MusteriEkle_Enter(null, null);
            }
        }

        private void btn_kodGonder2_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = "";
            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_mEposta.Text, dogrulamaKodu);
        }

        private void dgv_Musteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Musteriler.SelectedRows.Count == 0)
                return;
            txt_mKullaniciAdi.Text = dgv_Musteriler.SelectedRows[0].Cells["kullaniciAdi"].Value.ToString();
            txt_mAd.Text = dgv_Musteriler.SelectedRows[0].Cells["musteriAd"].Value.ToString();
            txt_mSoyad.Text = dgv_Musteriler.SelectedRows[0].Cells["musteriSoyad"].Value.ToString();

            if (DateTime.TryParse(dgv_Musteriler.SelectedRows[0].Cells["dogum_Tarihi"].Value.ToString(), out DateTime dogum))
                dtp_mDogumTarihi.Value = dogum;
            else
                dtp_mDogumTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

            txt_mTcNo.Text = dgv_Musteriler.SelectedRows[0].Cells["tc_No"].Value.ToString();
            mtb_mTelefon.Text = dgv_Musteriler.SelectedRows[0].Cells["telefon"].Value.ToString();
            txt_mEhliyetNo.Text = dgv_Musteriler.SelectedRows[0].Cells["ehliyet_no"].Value.ToString();
            txt_mEposta.Text = dgv_Musteriler.SelectedRows[0].Cells["email"].Value.ToString();
        }



        private void tbpg_MusteriEkle_Enter(object sender, EventArgs e)
        {

            dgv_Musteriler.DataSource = vt.Select($@"select k.kullaniciAdi, m.musteriAd,m.musteriSoyad,m.email,m.tc_No,m.ehliyet_no,m.dogum_Tarihi,m.telefon,k.olusturulma_tarihi from tbl_kullanici k
                                                    join tbl_musteri m on k.kullanici_id=m.kullanici_id");
        }

        private void btn_musteriSil_Click(object sender, EventArgs e)
        {
            KullaniciID = "";
            if (txt_mKullaniciAdi.Text != "")
            {
                try
                {
                    DataTable dt = vt.Select($@"select m.kullanici_id from tbl_musteri m
                                                    join tbl_kullanici k on k.kullanici_id = m.kullanici_id
                                                    where k.kullaniciAdi = '{txt_mKullaniciAdi.Text}'");

                    KullaniciID = dt.Rows[0]["kullanici_id"].ToString();

                    vt.UpdateDelete($@"delete from tbl_musteri where kullanici_id = {KullaniciID}");

                    vt.UpdateDelete($@"delete from tbl_kullanici where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı Silinirken Bir Hata Oluştu...\nHata: " + ex.Message);
                }


            }
            else
                MessageBox.Show("Silinecek Kullanıcıyı Tablodan Seçiniz.");
            tbpg_MusteriEkle_Enter(null, null);
        }

        private void btn_musteriGuncelle_Click(object sender, EventArgs e)
        {
            if (txt_mKullaniciAdi.Text == "")
            {

                MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                return;
            }
            KullaniciID = "";

            DataTable dt = vt.Select($@"
                                        select m.kullanici_id 
                                        from tbl_musteri m
                                        join tbl_kullanici k on k.kullanici_id = m.kullanici_id
                                        where k.kullaniciAdi = '{txt_mKullaniciAdi.Text.Replace("'", "''")}'
                                    ");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
                return;
            }
            KullaniciID = dt.Rows[0]["kullanici_id"].ToString();

            
            
            if(txt_mKullaniciAdi.Text=="")
            {
                lbl_mUyarilar.Text = "Kullanıcı Adı Boş Kalamaz.";
            }
            if (txt_mTcNo.Text == "")
            {
                lbl_mUyarilar.Text = "Tc No Boş Kalamaz.";
            }
            if (txt_mAd.Text == "")
            {
                lbl_mUyarilar.Text = "Ad Boş Bırakılamaz";
                return;
            }
            if ((txt_mAd.Text.Length < 2 || txt_mAd.Text.Length > 30))
            {
                lbl_mUyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (txt_mSoyad.Text == "")
            {
                lbl_mUyarilar.Text = "Soyad Boş Bırakılamaz";
                return;
            }
            if (txt_mSoyad.Text.Length < 2 || txt_mSoyad.Text.Length > 30)
            {
                lbl_mUyarilar.Text = "Soyad en az 2 en fazla 30 karakter olabilir.";
                return;
            }
            if (dtp_mDogumTarihi.Text == "")
            {
                lbl_mUyarilar.Text = "Doğum Tarihi Boş Bırakılamaz.";
                return;
            }
            if (txt_mEhliyetNo.Text == "")
            {
                lbl_mUyarilar.Text = "EhliyetNo Boş Bırakılamaz";
                return;
            }
            if (mtb_mTelefon.Text == "")
            {
                lbl_mUyarilar.Text = "Telefon Numarası Boş Bırakılamaz.";
                return;
            }
            
            if (txt_mEposta.Text == "")
            {
                lbl_mUyarilar.Text = "E-Posta Boş Kalamaz.";
            }
            if (sifreDegistirme.buyukHarfVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.kucukHarfVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                return;
            }
            if (sifreDegistirme.sayiVarmi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                return;
            }
            if (sifreDegistirme.sembolVarMi(txt_mSifre.Text) == false)
            {
                lbl_mUyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
                return;
            }
            if (txt_mSifre.Text != txt_mSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.");
                return;
            }
            if (txt_mOnayKodu.Text.ToUpper() != dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama Kodu Hatalı");
                return;
            }
            else
            {
                try
                {


                    vt.UpdateDelete($@"
                                        update tbl_musteri
                                        set musteriAd = '{txt_mAd.Text.Replace("'", "''")}',
                                            musteriSoyad = '{txt_mSoyad.Text.Replace("'", "''")}',
                                            tc_no = '{txt_mTcNo.Text.Replace("'", "''")}',
                                            dogum_tarihi = '{dtp_mDogumTarihi.Value.ToString("yyyy-MM-dd")}',
                                            ehliyet_no = '{txt_mEhliyetNo.Text.Replace("'", "''")}',
                                            email = '{txt_mEposta.Text.Replace("'", "''")}',
                                            telefon = '{mtb_mTelefon.Text.Replace("'", "''")}'
                                            where kullanici_id = {KullaniciID}
                                    ");

                    vt.UpdateDelete($@"
                                    update tbl_kullanici
                                    set  kullaniciAdi = '{txt_mKullaniciAdi.Text.Replace("'", "''")}',
                                        sifre = '{dg.MD5Sifrele(txt_mSifreTekrar.Text)}' 
                                         where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Müşteri Bilgileri Başarıyla Güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Bir Hata Oluştu...\nHata: " + ex.Message);
                }
                tbpg_MusteriEkle_Enter(null, null);
            }

        }

        private void btn_mTemizle_Click(object sender, EventArgs e)
        {
            txt_mKullaniciAdi.Clear();
            txt_mAd.Clear();
            txt_mSoyad.Clear();
            txt_mTcNo.Clear();
            dtp_mDogumTarihi.Value = DateTime.Now;
            txt_mEhliyetNo.Clear();
            mtb_mTelefon.Clear();
            txt_mEposta.Clear();
        }






        //TOOL STRİP BUTTON İŞLEMLERİ
        private void tsb_profil_Islemleri_Click(object sender, EventArgs e)
        {
            if (aktifForm != null)
            {
                aktifForm.Close();
                aktifForm = null;
            }

            panelContainer.Controls.Clear();
            TabControl.Visible = true;
            panelContainer.Controls.Add(TabControl);
        }

        private void tsb_aracIslemleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible = false;
            FormAc(new FrmAracIslemleri());

        }

        private void tsb_odemeIslemleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible = false;
            FormAc(new frm_odemeIslemleri());
        }

        Form aktifForm = null;

        void FormAc(Form frm)
        {
            // Önce varsa eski formu kapat
            if (aktifForm != null)
                aktifForm.Close();

            aktifForm = frm;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(frm);

            frm.Show();
        }

        private void tsb_HasarIslemleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible = false;
            FormAc(new frm_aracKazaIslemleri());
        }

        private void tsb_kiraEvraklari_Click(object sender, EventArgs e)
        {
            TabControl.Visible = false;
            FormAc(new frm_kiraEvraklari());
        }

        private void tsb_kiraIslmeleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible = false;
            FormAc(new frm_KiraIslemleri());
        }

        private void tstcmb_manuleBaslatma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tstcmb_manuleBaslatma.SelectedIndex == 0)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("Araç Kiralama", "\"" + Application.ExecutablePath + "\"");
                MessageBox.Show("Başlangıca Kaydedildi");
            }

            else
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    key.DeleteValue("Araç Kiralama");
                }
                catch (Exception)
                {
                    MessageBox.Show("Uygulama Zaten Manuel Başlatma Durumunda");
                }


            }
        }

        private void notifyIconMenu_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible == false)
                this.Show();
            else
                this.Hide();
        }

        private void gosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simgeDurumunaAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cikisYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AnaMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_kaydet_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_sil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                btn_personelGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.T)
                btn_pTemizle_Click(sender, e);

            if (e.Alt && e.KeyCode == Keys.Z)
                btn_musteriKaydet_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.X)
                btn_musteriSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.C)
                btn_musteriGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.V)
                btn_mTemizle_Click(sender, e);

            if (e.Alt && e.KeyCode == Keys.Y)
                btn_GE_ekle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.U)
                btn_GE_sil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.I)
                btn_GE_guncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.O)
                btn_GE_temizle_Click(sender, e);

            if (e.Alt && e.KeyCode == Keys.K)
                btn_kodGonder_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.L)
                btn_kodGonder2_Click(sender, e);
          
        }

        private void n(object sender, EventArgs e)
        {

        }

        private void tbpg_kullaniciEkle_Enter(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select kullanici_id,kullaniciAdi,k.gorev_id,g.gorev_adi,olusturulma_tarihi from tbl_kullanici k
                                        join tbl_gorev g on g.gorev_id=k.gorev_id");

            dgv_kullaniciEkleme.DataSource = dt;
            dgv_kullaniciEkleme.Columns["kullanici_id"].Visible = false;
            dgv_kullaniciEkleme.Columns["gorev_id"].Visible = false;

            DataTable dt2 = vt.Select($@"select gorev_id,gorev_adi from tbl_gorev");

            cmb_KEgorev.DataSource = dt2;
            cmb_KEgorev.ValueMember = "gorev_id";
            cmb_KEgorev.DisplayMember = "gorev_adi";

        }

        private void dgv_kullaniciEkleme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txt_KEkullaniciAdi.Text = dgv_kullaniciEkleme.Rows[e.RowIndex].Cells["kullaniciAdi"].Value.ToString();
            cmb_KEgorev.Text = dgv_kullaniciEkleme.Rows[e.RowIndex].Cells["gorev_adi"].Value.ToString();

            //if (DateTime.TryParse(dgv_kullaniciEkleme.SelectedRows[0].Cells["olusturulma_tarihi"].Value.ToString(), out DateTime dogum))
            //    dtp_KE_olusturulmaTarihi.Value = dogum;
            //else
            //    dtp_KE_olusturulmaTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

            dtp_KE_olusturulmaTarihi.Value =
                                            Convert.ToDateTime(
                                                dgv_kullaniciEkleme.Rows[e.RowIndex].Cells["olusturulma_tarihi"].Value
                                            );
        }

       

        private void tbpg_gorevIslemleri_Enter(object sender, EventArgs e)
        {
            DataTable dt2 = vt.Select($@"select gorev_id,gorev_adi from tbl_gorev");

            dgv_GE_goruntule.DataSource = dt2;
            dgv_GE_goruntule.Columns["gorev_id"].Visible = false;

        }

        private void dgv_GE_goruntule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txt_GE_gorevAd.Text = dgv_GE_goruntule.Rows[e.RowIndex].Cells["gorev_adi"].Value.ToString();
        }

        private void btn_GE_ekle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select gorev_adi from tbl_gorev");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["gorev_adi"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_GE_gorevAd.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Görev Listede Zaten Mevcut");
                return;
            }
            if (txt_GE_gorevAd.Text == "")
            {
                MessageBox.Show("Görev Türü Boş Bırakılamaz.");
                return;
            }

            vt.Insert($@"insert into tbl_gorev(gorev_adi)
                        values('{txt_GE_gorevAd.Text.Replace("'", "''")}');");

            MessageBox.Show("Görev Başarıyla Eklendi.");
            tbpg_gorevIslemleri_Enter(null, null);

        }

        private void btn_GE_sil_Click(object sender, EventArgs e)
        {
            if (txt_GE_gorevAd.Text == "")
            {
                MessageBox.Show("Görev Türü Boş Bırakılamaz.");
                return;
            }
            vt.UpdateDelete($@"delete from tbl_gorev
                                where gorev_id ={dgv_GE_goruntule.SelectedRows[0].Cells["gorev_id"].Value.ToString()}");

            MessageBox.Show("Görev Başarıyla Silindi");
            tbpg_gorevIslemleri_Enter(null, null);

        }

        private void btn_GE_guncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select gorev_adi from tbl_gorev");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["gorev_adi"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_GE_gorevAd.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Görev Listede Zaten Mevcut");
                return;
            }
            if (txt_GE_gorevAd.Text == "")
            {
                MessageBox.Show("Görev Türü Boş Bırakılamaz.");
                return;
            }


            vt.UpdateDelete($@"update tbl_gorev 
                                set gorev_adi='{txt_GE_gorevAd.Text.Replace("'", "''")}'
                                where gorev_id={dgv_GE_goruntule.SelectedRows[0].Cells["gorev_id"].Value.ToString()}");

            MessageBox.Show("Görev Başarıyla Güncellendi.");
            tbpg_gorevIslemleri_Enter(null, null);
        }

        private void btn_GE_temizle_Click(object sender, EventArgs e)
        {
            txt_GE_gorevAd.Text = "";
            dgv_GE_goruntule.ClearSelection();
        }
    }
}
