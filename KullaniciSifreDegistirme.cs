using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AracKiralama_HC;

namespace Arac_Kiralama
{
    public partial class KullaniciSifreDegistirme : Form
    {
        AracKiralama_HC.DigerIslemler dg = new AracKiralama_HC.DigerIslemler();
        public KullaniciSifreDegistirme(string kullanici)
        {
            InitializeComponent();
            kullaniciii = kullanici;
        }
        public string kullaniciii;

        
        GirisYap giris = new GirisYap();
        VTI.Veritabani vt = new VTI.Veritabani();
        
        private void btn_kullaniciSifreDegistirOnayla_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select kullaniciAdi,sifre from tbl_kullanici 
                            where kullaniciAdi = '{txt_kullaniciAdi.Text}'");
            
            var gelensifre = dt.Rows[0]["sifre"].ToString();

            if (dg.MD5Sifrele(txt_eskiSifre.Text) != gelensifre)
            {
                MessageBox.Show("Eski Şifre Yanlış Girildi");
                return;
            }

            if (txt_sifre.Text != txt_sifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Birbiriyle Uyuşmuyor");
                return;
            }
            if(txt_eskiSifre.Text ==null || txt_sifre.Text==null || txt_sifreTekrar.Text==null)
            {
                MessageBox.Show("Hiçbir Alanı Boş bırakmayınız.");
            }
            if(sayiVarmi(txt_sifre.Text)==false)
            {
                MessageBox.Show("Şifrenizde en az 1 adet sayı olmalıdır.");
                return;
            }
            if(buyukHarfVarmi(txt_sifre.Text)==false)
            {
                MessageBox.Show("Şifrenizde En az 1 adet Büyük Harf olmalıdır");
                return;
            }
            if(kucukHarfVarmi(txt_sifre.Text) == false)
            {
                MessageBox.Show("Şifrenizde en az 1 adet Küçük Harf olmalıdır.");
                return;
            }
            if(sembolVarMi(txt_sifre.Text) == false)
            {
                MessageBox.Show("Şifrenizde en az 1  adet Sembol olmalıdır.");
                return;
            }
            else
            {
                vt.Insert($@"update tbl_kullanici
                            set sifre = '{dg.MD5Sifrele( txt_sifreTekrar.Text)}'
                            where kullaniciAdi ='{txt_kullaniciAdi.Text}'");
                
               DialogResult dr =  MessageBox.Show("Şifre Değiştirildi Ana Menüye Dönülüyor.");
                if(dr == DialogResult.OK)
                {
                   // AnaMenu ana = new AnaMenu(kullaniciii);
                    
                    this.Close();
                }
            }

        }

        private void KullaniciSifreDegistirme_Load(object sender, EventArgs e)
        {
            txt_kullaniciAdi.Text = kullaniciii;
            txt_kullaniciAdi.Enabled = false;
        }
        public bool buyukHarfVarmi(string metin)
        {
            foreach (var item in metin)
            {
                if (Char.IsUpper(item))
                    return true;
            }

            return false;
        }
        public bool kucukHarfVarmi(string metin)
        {
            foreach (var item in metin)
            {
                if (Char.IsLower(item))
                    return true;
            }

            return false;
        }

        public bool sayiVarmi(string metin)
        {
            foreach (var item in metin)
            {
                if (Char.IsNumber(item))
                    return true;
            }

            return false;
        }

        public bool sembolVarMi(string metin)
        {
            foreach (var item in metin)
            {
                if (!Char.IsLetterOrDigit(item))
                    return true;
            }

            return false;
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
        {
            //AnaMenu ana = new AnaMenu(kullaniciii);
            //ana.Show();
            this.Close();
        }

        private void KullaniciSifreDegistirme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
                btn_kullaniciSifreDegistirOnayla_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                btn_geriDon_Click(sender, e);

        }
    }
}
