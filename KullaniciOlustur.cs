using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama
{
    public partial class KullaniciOlustur : Form
    {
        public KullaniciOlustur()
        {
            InitializeComponent();
        }
        //KOD GÖNDERME OLAYINI AYRI BİR CLASS OLARAK YAP ŞİMDİLİK BÖYLE KULLANILSA DA OLUR
        //CONTAİNSLER ÇALIŞMIYO HOCAYA SOR
        string[] onayKodu = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random random = new Random();
        string yazi = "";
        string dogrulamaKodu;
        GirisYap girisYap = new GirisYap();


        VTI.Veritabani vt = new VTI.Veritabani();
        Mail_islemler mail = new Mail_islemler();
        private void btn_kodGonder_Click(object sender, EventArgs e)
        {

            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_ePosta.Text);
        }




        List<string> kullanicilar = new List<string>();
        List<string> emailler = new List<string>();
        List<string> telefonlar = new List<string>();
        List<string> tcler = new List<string>();

        SifreDegistirme sifreDegistirme = new SifreDegistirme();

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= "+ txt_kullaniciAdi.Text);

            kullanicilar.Clear();
            emailler.Clear();
            telefonlar.Clear();
            tcler.Clear();

            foreach (DataRow row in dt.Rows)
            {
                kullanicilar.Add(row["kullaniciAdi"].ToString());
                emailler.Add(row["email"].ToString());
                telefonlar.Add(row["telefon"].ToString());
                tcler.Add(row["tc_no"].ToString());
            }

            if (dt.Rows.Count > 0)
            {
                
                

                if (txt_kullaniciAdi.Text == "")
                {

                    MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                    return;
                }
                DataTable dt2 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where k.kullaniciAdi= " + txt_kullaniciAdi.Text);

                if (dt2.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                    return;
                }
                DataTable dt3 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.tc_no= " + txt_tcNo.Text);

                if (dt3.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu TC'ye Sahip Biri Zaten Var";
                    return;
                }
                if (txt_ad.Text == "")
                {
                    lbl_Uyarilar.Text = "Ad Boş Bırakılamaz";
                    return;
                }
                if ((txt_ad.Text.Length < 2 || txt_ad.Text.Length > 30))
                {
                    lbl_Uyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                    return;
                }
                if (txt_soyad.Text == "")
                {
                    lbl_Uyarilar.Text = "Soyad Boş Bırakılamaz";
                    return;
                }
                if (txt_soyad.Text.Length < 2 || txt_soyad.Text.Length > 30)
                {
                    lbl_Uyarilar.Text = "Soyad en az 2 en fazla 30 karakter olabilir.";
                    return;
                }
                if (dtp_dogumTarihi.Text == "")
                {
                    lbl_Uyarilar.Text = "Doğum Tarihi Boş Bırakılamaz.";
                    return;
                }
                if (txt_EhliyetNo.Text == "")
                {
                    lbl_Uyarilar.Text = "EhliyetNo Boş Bırakılamaz";
                    return;
                }
                if (mtb_telefon.Text == "")
                {
                    lbl_Uyarilar.Text = "Telefon Numarası Boş Bırakılamaz.";
                    return;
                }
              
                DataTable dt4 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.telefon= " + mtb_telefon.Text);
                if (dt4.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                    return;
                }
                DataTable dt5 = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id where m.email= " + txt_ePosta.Text);
                if (dt5.Rows.Count > 0)
                {
                    lbl_Uyarilar.Text = "Bu E-Posta Sistemde Zaten Kayıtlı... Başka Bir E-Posta Deneyin.";
                    return;
                }
                if (sifreDegistirme.buyukHarfVarmi(txt_Sifre.Text)==false)
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                    return;
                }
                if (sifreDegistirme.kucukHarfVarmi(txt_Sifre.Text)==false)
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                    return;
                }
                if (sifreDegistirme.sayiVarmi(txt_Sifre.Text)==false)
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                    return;
                }
                if (sifreDegistirme.sembolVarMi(txt_Sifre.Text) == false)
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
                    return;
                }
                if (txt_Sifre.Text != txt_sifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler Uyuşmuyor.");
                    return;
                }
                else if (txt_onayKodu.Text.ToUpper() != dogrulamaKodu)
                {
                    MessageBox.Show("Doğrulama Kodu Hatalı");
                    return;
                }
                else
                {
                    
                    // KULLANICI EKLE
                    vt.Insert($@"
                                insert into tbl_kullanici(kullaniciAdi, sifre, gorev_id, olusturulma_tarihi, profil_resim_yolu)
                                values(
                                    '{txt_kullaniciAdi.Text.Replace("'", "''")}',
                                    '{girisYap.MD5Sifrele(txt_sifreTekrar.Text)}',
                                    2,
                                    GETDATE(),
                                    'DenemeResimYolu'
                                )
                            ");

                    // EKLENEN KULLANICI ID'YI AL
                    DataTable dataT = vt.Select($@"
                                                    select top 1 kullanici_id
                                                    from tbl_kullanici
                                                    where kullaniciAdi = '{txt_kullaniciAdi.Text.Replace("'", "''")}'
                                                    order by kullanici_id desc
                                                ");

                    int yenikullaniciID = Convert.ToInt32(dataT.Rows[0]["kullanici_id"]);

                    // MÜŞTERİ EKLE
                    vt.Insert($@"
                                insert into tbl_musteri
                                (kullanici_id, tc_no, dogum_tarihi, ehliyet_no, email, telefon, musteriAd, musteriSoyad)
                                values(
                                    {yenikullaniciID},
                                    '{txt_tcNo.Text}',
                                    '{dtp_dogumTarihi.Value.ToString("yyyy-MM-dd")}',
                                    '{txt_EhliyetNo.Text.Replace("'", "''")}',
                                    '{txt_ePosta.Text.Replace("'", "''")}',
                                    '{mtb_telefon.Text}',
                                    '{txt_ad.Text.Replace("'", "''")}',
                                    '{txt_soyad.Text.Replace("'", "''")}'
                                )
                            ");

                   DialogResult dr = MessageBox.Show("Kullanıcı Oluşturuldu... Uygulamayı Yeniden Başlatın.");
                    if(dr == DialogResult.OK)
                        Application.Restart();
                    //AnaMenu ana = new AnaMenu();
                    //ana.Show();
                    //this.Hide();
                }
            
            }
            
        }

        private void KullaniciOlustur_Load(object sender, EventArgs e)
        {
            lbl_Uyarilar.Text = "";
        }
    }
}
