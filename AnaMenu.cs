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

namespace Arac_Kiralama
{
    public partial class AnaMenu : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        GirisYap girisYap = new GirisYap();
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
            DataTable dt = vt.Select($@"select k.kullaniciAdi,k.gorev_id,k.profil_resim_yolu,p.personelAd,p.personelSoyad,p.tc_No,dogum_Tarihi,p.ehliyet_no,p.telefon,p.email
                                        from tbl_personel p
                                        join tbl_kullanici k on k.kullanici_id = p.kullanici_id
                                        where kullaniciAdi = '{anamenuKullaniciAdi}'");

            cbx_pozisyon.DataSource = vt.Select($@"Select gorev_id,gorev_adi from tbl_gorev");
            cbx_pozisyon.DisplayMember = "gorev_adi";
            cbx_pozisyon.ValueMember = "gorev_id";


            txt_kullaniciAdi.Text = dt.Rows[0]["kullaniciAdi"].ToString();
            var gorevId = Convert.ToInt32(dt.Rows[0]["gorev_id"]);
            var profilResimyolu = dt.Rows[0]["profil_resim_yolu"].ToString();
            txt_ad.Text = dt.Rows[0]["personelAd"].ToString();
            txt_soyad.Text = dt.Rows[0]["personelSoyad"].ToString();
            txt_tcNo.Text = dt.Rows[0]["tc_No"].ToString();
            dtp_dogumTarihi.Text = dt.Rows[0]["dogum_Tarihi"].ToString();
            txt_EhliyetNo.Text = dt.Rows[0]["ehliyet_no"].ToString();
            mtb_telefon.Text = dt.Rows[0]["telefon"].ToString();
            txt_ePosta.Text = dt.Rows[0]["email"].ToString();

            //cmb_personelTur.DataSource = vt.Select("select personelTur_id, personelTur from tbl_personelTur");
            //cmb_personelTur.DisplayMember = "personelTur";
            //cmb_personelTur.ValueMember = "personelTur_id";
            //cmb_personelTur.SelectedIndex = -1;





            if (gorevId == 1)
            {
                cbx_pozisyon.SelectedIndex = 2;
            }
            else if (gorevId == 2)
            {
                cbx_pozisyon.SelectedIndex = 1;
            }
            else if (gorevId == 4)
            {
                cbx_pozisyon.SelectedIndex = 0;
            }
        }
        int kullaniciGorevID;
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
                DataTable dt2 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= " + txt_pKullaniciAdi.Text);

                if (dt2.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                    return;
                }
                DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= " + txt_pTcNo.Text);

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
                DataTable dt4 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= " + mtb_pTelefon.Text);
                if (dt4.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                    return;
                }
                DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= " + txt_pEposta.Text);
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
                                        '{girisYap.MD5Sifrele(txt_pSifreTekrar.Text)}',
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

                   

                    // ------------------------------------------------------------
                    // PERSONEL SEÇİLİYSE PERSONEL TABLOSUNA EKLE
                    // ------------------------------------------------------------

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

                }

            
        }
        string dogrulamaKodu;
        private void btn_kodGonder_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_pEposta.Text);
            
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
                dtp_pDogumTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

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
            DataTable dt2 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= " + txt_pKullaniciAdi.Text);

            if (dt2.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                return;
            }
            DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= " + txt_pTcNo.Text);

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
            DataTable dt4 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= " + mtb_pTelefon.Text);
            if (dt4.Rows.Count > 0)
            {
                lbl_Uyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                return;
            }
            DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= " + txt_pEposta.Text);
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
                                        sifre = '{girisYap.MD5Sifrele(txt_pSifreTekrar.Text)}'
                                         where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Personel Bilgileri Başarıyla Güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Bir Hata Oluştu...\nHata: "+ex.Message);       
                }
                

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
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= " + txt_mKullaniciAdi.Text);

            if (dt2.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                return;
            }
            DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= " + txt_mTcNo.Text);

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
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= " + mtb_mTelefon.Text);
            if (dt4.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                return;
            }
            DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= " + txt_mEposta.Text);
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
            else if (txt_mOnayKodu.Text.ToUpper() != dogrulamaKodu)
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
                                        '{girisYap.MD5Sifrele(txt_mSifreTekrar.Text)}',
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

                // ------------------------------------------------------------
                // MÜŞTERİ SEÇİLİYSE MÜŞTERİ TABLOSUNA EKLE
                // ------------------------------------------------------------
               
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
                
            }
        }

        private void btn_kodGonder2_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_mEposta.Text);
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
            if (txt_pKullaniciAdi.Text != "")
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
        }

        private void btn_musteriGuncelle_Click(object sender, EventArgs e)
        {
            KullaniciID = "";

            DataTable dt = vt.Select($@"select p.kullanici_id from tbl_personel p
                                                join tbl_kullanici k on k.kullanici_id = p.kullanici_id
                                                where k.kullaniciAdi = '{txt_pKullaniciAdi.Text}'");

            KullaniciID = dt.Rows[0]["kullanici_id"].ToString();

            if (txt_mKullaniciAdi.Text == "")
            {

                MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                return;
            }
            DataTable dt2 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= " + txt_mKullaniciAdi.Text);

            if (dt2.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                return;
            }
            DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= " + txt_mTcNo.Text);

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
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= " + mtb_mTelefon.Text);
            if (dt4.Rows.Count > 0)
            {
                lbl_mUyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                return;
            }
            DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= " + txt_mEposta.Text);
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
            else if (txt_mOnayKodu.Text.ToUpper() != dogrulamaKodu)
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
                                        sifre = '{girisYap.MD5Sifrele(txt_mSifreTekrar.Text)}' 
                                         where kullanici_id = {KullaniciID}");

                    MessageBox.Show("Müşteri Bilgileri Başarıyla Güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Bir Hata Oluştu...\nHata: " + ex.Message);
                }
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

        private void tsb_profil_Islemleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible = true;
        }

        private void tsb_aracIslemleri_Click(object sender, EventArgs e)
        {
            TabControl.Visible=false;
        }
    }
}
