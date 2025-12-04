using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTI;


namespace Arac_Kiralama
{
    public partial class GirisYap : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        public GirisYap()
        {
            InitializeComponent();
        }
        string[] onayKodu = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random random = new Random();
        string yazi = "";
        int hak = 3;
        private void GirisYap_Load(object sender, EventArgs e)
        {
            KodOlustur();
        }
        //Kullanıcının göreve göre  müşteri olup olmadığını falan kontrol etmem lazım yarın devam et.
        private void btn_GirisYap_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select * from tbl_kullanici");
            if (dt.Rows.Count > 0)
            {
                string gelenKullaniciAdi = dt.Rows[0]["kullaniciAdi"].ToString();
                string gelenSifre = dt.Rows[0]["sifre"].ToString();

                if (txt_kullaniciAdi.Text != gelenKullaniciAdi)
                {
                    MessageBox.Show("Kullanıcı Adı Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;
                }
                else if(txt_sifre.Text != gelenSifre)
                {
                    MessageBox.Show("Şifre Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;    
                }
                else if(txt_kodOnay.Text.ToUpper() != txt_Kod.Text)
                {
                    MessageBox.Show("Doğrulama Kodu Hatalı Tekrar Deneyiniz. Kalan hak: " + hak);
                    hak--;
                }
                else if (hak == 0)
                {
                    MessageBox.Show("Deneme Hakkınız Kalmadı Çıkış Yapılıyor...");
                    Application.Exit();
                }
                AnaMenu anamenu = new AnaMenu();
                anamenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunamadı.");
            }
            
        }
        
        private void btn_Yenile_Click(object sender, EventArgs e)
        {
            KodOlustur();
                
        }
        private void KodOlustur()
        {
            yazi = "";

            for (int i = 0; i < 6; i++)
            {
                txt_Kod.Text = "";
                int sayi = random.Next(0, onayKodu.Length);
                string secilen_Kod = onayKodu[sayi].ToString();
                yazi += secilen_Kod;
            }
            txt_Kod.Text = yazi;
        }
    }
}
