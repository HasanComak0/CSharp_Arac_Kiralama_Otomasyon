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
using AracKiralama_HC;


namespace Arac_Kiralama
{
    public partial class GirisYap : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        Mail_islemler mail = new Mail_islemler();
        AracKiralama_HC.DigerIslemler dg = new AracKiralama_HC.DigerIslemler();
        public GirisYap()
        {
            InitializeComponent();
        }
        
        int hak = 3;
        private void GirisYap_Load(object sender, EventArgs e)
        {
            txt_sifre.UseSystemPasswordChar = true;
            
            txt_Kod.Text = mail.KodOlustur();
            //string md5Sifre = MD5Sifrele("ugur123");
            //vt.UpdateDelete("update tbl_kullanici set sifre ='" + md5Sifre + "' where kullanici_id = 2");
            //MessageBox.Show("ŞİFRE GÜNCELLENDİ");
            //Mert.3131
            // Yusuf.34
            if(ayarlar.Default.beniHatirla==true)
            {
                cbx_beniHatirla.Checked = true;
                txt_kullaniciAdi.Text = ayarlar.Default.KullaniciAdi;
                txt_sifre.Text = ayarlar.Default.Sifre;
            }
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
                else if (dg.MD5Sifrele(txt_sifre.Text) != gelenSifre)
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
                    if(cbx_beniHatirla.Checked)
                    {
                        ayarlar.Default.beniHatirla = true;
                        ayarlar.Default.KullaniciAdi = txt_kullaniciAdi.Text;
                        ayarlar.Default.Sifre = txt_sifre.Text;
                        ayarlar.Default.Save();
                    }
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

        private void cbx_beniHatirla_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_beniHatirla.Checked == false)
            {
                ayarlar.Default.KullaniciAdi="";
                ayarlar.Default.Sifre = "";
                ayarlar.Default.beniHatirla = false;
                ayarlar.Default.Save();
                txt_kullaniciAdi.Text = "";
                txt_sifre.Text="";
            }
        }

        private void GirisYap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_GirisYap_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_sifreGizleGoster_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.U)
                btn_SifremiUnuttum_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.Y)
                btn_Yenile_Click(sender, e);
        }
    }
}
