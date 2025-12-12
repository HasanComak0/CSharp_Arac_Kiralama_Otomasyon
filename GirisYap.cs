using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTI;


namespace Arac_Kiralama
{
    public partial class GirisYap : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        Mail_islemler mail = new Mail_islemler();
        public GirisYap()
        {
            InitializeComponent();
        }
        //string[] onayKodu = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        //Random random = new Random();
        //string yazi = "";
        int hak = 3;
        private void GirisYap_Load(object sender, EventArgs e)
        {
            txt_sifre.UseSystemPasswordChar = true;
            
            txt_Kod.Text = mail.KodOlustur();
            //string md5Sifre = MD5Sifrele("ugur123");
            //vt.UpdateDelete("update tbl_kullanici set sifre ='" + md5Sifre + "' where kullanici_id = 2");
             //MessageBox.Show("ŞİFRE GÜNCELLENDİ");
             //Mert.3131
             //Yusuf.34
        }
        //Kullanıcının göreve göre  müşteri olup olmadığını falan kontrol etmem lazım yarın devam et.
        public string gelenKullaniciAdi;
        private void btn_GirisYap_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select kullanici_id,kullaniciAdi,sifre,gorev_id,profil_resim_yolu from tbl_kullanici
                                        where kullaniciAdi = '{txt_kullaniciAdi.Text}'");
            if (dt.Rows.Count > 0)
            {
               gelenKullaniciAdi = dt.Rows[0]["kullaniciAdi"].ToString();
                string gelenSifre = dt.Rows[0]["sifre"].ToString();

                if (txt_kullaniciAdi.Text != gelenKullaniciAdi)
                {
                    MessageBox.Show("Kullanıcı Adı Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;
                    txt_Kod.Text = mail.KodOlustur();
                }
                else if (MD5Sifrele(txt_sifre.Text) != gelenSifre)
                {
                    MessageBox.Show("Şifre Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;
                   txt_Kod.Text = mail.KodOlustur();
                }
                else if (txt_kodOnay.Text.ToUpper() != txt_Kod.Text)
                {
                    MessageBox.Show("Doğrulama Kodu Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;
                    txt_Kod.Text = mail.KodOlustur();
                }
                else
                {
                    AnaMenu anamenu = new AnaMenu(gelenKullaniciAdi);
                    anamenu.Show();
                    this.Hide();
                }
                if (hak == 0)
                {
                    MessageBox.Show("Deneme Hakkınız Kalmadı Çıkış Yapılıyor...");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunamadı.");
            }

        }

        private void btn_Yenile_Click(object sender, EventArgs e)
        {
            txt_Kod.Text = mail.KodOlustur();

        }
        //public string KodOlustur()
        //{
        //    yazi = "";

        //    for (int i = 0; i < 6; i++)
        //    {
        //        txt_Kod.Text = "";
        //        int sayi = random.Next(0, onayKodu.Length);
        //        string secilen_Kod = onayKodu[sayi].ToString();
        //        yazi += secilen_Kod;
        //    }
        //    return yazi;
        //}

        public string MD5Sifrele(string sifrelenecekMetin)
        {

            // MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Parametre olarak gelen veriyi byte dizisine dönüştürdük.
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            //dizinin hash'ini hesaplattık.
            dizi = md5.ComputeHash(dizi);
            //Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
            StringBuilder sb = new StringBuilder();
            //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürdük.
            return sb.ToString();
        }

        private void btn_SifremiUnuttum_Click(object sender, EventArgs e)
        {
            SifreDegistirme sifreDegistirme = new SifreDegistirme();
            sifreDegistirme.Show();
            this.Hide();
        }

        bool sifreGizliMi = false;
        private void btn_sifreGizleGoster_Click(object sender, EventArgs e)
        {
            if (sifreGizliMi)
            {
                btn_sifreGizleGoster.Text = "Şifre Göster";
                txt_sifre.UseSystemPasswordChar = true;
            }
            else
            {
                btn_sifreGizleGoster.Text = "Şifre Gizle";
                txt_sifre.UseSystemPasswordChar= false;
            }
            sifreGizliMi = !sifreGizliMi;
        }

        
    }
}
