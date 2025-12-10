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

        string[] onayKodu = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random random = new Random();
        string yazi = "";
        string dogrulamaKodu;
        GirisYap girisYap = new GirisYap();


        VTI.Veritabani vt = new VTI.Veritabani();
        private void btn_kodGonder_Click(object sender, EventArgs e)
        {

            dogrulamaKodu = girisYap.KodOlustur();
            try
            {

                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUser = "";//mail gönderen hesap
                string smtpPass = "";

                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);

                mail.From = new MailAddress(smtpUser);
                mail.To.Add(txt_ePosta.Text);//mail gönderilecek hesap
                mail.Subject = "Personel Kayıt Kodu";//mail konusu
                mail.Body = "Yeni Personeli Kaydetmeyi Onaylamak İçin Verilen Kodu Sisteme Giriniz: " + dogrulamaKodu;//mail içeriği(asıl yazılan mesaj)

                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                MessageBox.Show("Mail Hesabınıza Gönderilen Kodu Giriniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta Gönderilirken Bir Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<string> kullanicilar = new List<string>();
        List<string> emailler = new List<string>();
        List<string> telefonlar = new List<string>();
        List<string> tcler = new List<string>();

        SifreDegistirme sifreDegistirme = new SifreDegistirme();

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select k.kullaniciAdi,m.telefon,m.email,m.tc_no from tbl_kullanici as k
                                        join tbl_Musteri as m on m.kullanici_id= k.kullanici_id");

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
                if (kullanicilar.Contains(txt_kullaniciAdi.Text))
                {
                    lbl_Uyarilar.Text = "Bu Kullanıcı Adı Zaten Alınmış";
                    return;
                }
                if (tcler.Contains(txt_tcNo.Text))
                {
                    lbl_Uyarilar.Text = "Bu TC'ye Sahip Biri Zaten Var";
                    return;
                }
                if (txt_ad.Text.Length < 2 && txt_ad.Text.Length > 30)
                {
                    lbl_Uyarilar.Text = "Ad en az 2 en fazla 30 karakter olabilir.";
                    return;
                }
                if (txt_soyad.Text.Length < 2 && txt_soyad.Text.Length > 30)
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
                if (telefonlar.Contains(mtb_telefon.Text))
                {
                    lbl_Uyarilar.Text = "Bu Telefon Numarası Sistemde Kayıtlı... Başka Bir Telefon Numarası Giriniz.";
                    return;
                }
                //if(emailler.Contains(txt_ePosta.Text))
                //{
                // lbl_Uyarilar.Text = "Bu E-Posta Sistemde Zaten Kayıtlı... Başka Bir E-Posta Deneyin.";
                //return;
                //}
                if (sifreDegistirme.buyukHarfVarmi(txt_Sifre.Text))
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Büyük Harf Olmalıdır.";
                    return;
                }
                if (sifreDegistirme.kucukHarfVarmi(txt_Sifre.Text))
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Küçük Harf Olmalıdır.";
                    return;
                }
                if (sifreDegistirme.sayiVarmi(txt_Sifre.Text))
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sayı Bulunmalıdır.";
                    return;
                }
                if (sifreDegistirme.sembolVarMi(txt_Sifre.Text))
                {
                    lbl_Uyarilar.Text = "Şifrenizde En az 1 Adet Sembol Bulunmalıdır.";
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
            }
            else
            {
                object a = vt.Insert($@"");
            }
        }

        private void KullaniciOlustur_Load(object sender, EventArgs e)
        {
            lbl_Uyarilar.Text = "";
        }
    }
}
