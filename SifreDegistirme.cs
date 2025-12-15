using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using VTI;
using AracKiralama_HC;

namespace Arac_Kiralama
{
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }
        AracKiralama_HC.DigerIslemler dg = new AracKiralama_HC.DigerIslemler();
        VTI.Veritabani vt = new VTI.Veritabani();

        
        string dogrulamaKodu;

        GirisYap girisYap = new GirisYap();
        Mail_islemler mail = new Mail_islemler();
        private void btn_KodGonder_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = "";
            dogrulamaKodu = mail.KodOlustur();
            mail.EmailGonder(txt_ePosta.Text,dogrulamaKodu);

        }

        

        private void btn_SifreDegistirOnay_Click(object sender, EventArgs e)
        {
            //BLOKLAR BOŞ KALIRSA HATA VERMİYO

            if (rbtn_Musteri.Checked)
            {
                if (txt_kullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                    return;
                }

                DataTable dt = vt.Select($@"select k.kullanici_id, k.kullaniciAdi,m.tc_no,m.email,k.gorev_id from tbl_kullanici as k
                                            join tbl_Musteri as m on m.kullanici_id= k.kullanici_id
                                            where k.kullaniciAdi ='{txt_kullaniciAdi.Text}'");

                if (dt.Rows.Count > 0)
                {
                    string gelenKullaniciID = dt.Rows[0]["kullanici_id"].ToString();
                    string gelenKullaniciAdi = dt.Rows[0]["kullaniciAdi"].ToString();
                    string gelenMusteriTcNo = dt.Rows[0]["tc_no"].ToString();
                    string gelenMusteriEmail = dt.Rows[0]["email"].ToString();
                    string gelenGorev_id = dt.Rows[0]["gorev_id"].ToString();


                    if (gelenKullaniciAdi != txt_kullaniciAdi.Text)
                    {
                        MessageBox.Show("Kullanıcı Adı Hatalı.");
                        return;
                    }
                    else if (gelenMusteriTcNo != txt_tcNo.Text)
                    {
                        MessageBox.Show("TC No Hatalı.");
                        return;
                    }
                    else if (gelenMusteriEmail != txt_ePosta.Text)
                    {
                        MessageBox.Show("E-posta Hatalı.");
                        return;
                    }
                    else if (gelenGorev_id != "2")
                    {
                        MessageBox.Show("Bu Kullanıcı Bu Göreve Sahip Değil");
                        return;
                    }
                    else if (txt_yeniSifre.Text != txt_sifreTekrar.Text)
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor.");
                        return;
                    }
                    else if (buyukHarfVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 Adet Büyük Harf Olmalıdır");
                        return;
                    }
                    else if (kucukHarfVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet küçük Harf olmalıdır!!!");
                        return;
                    }
                    else if (sayiVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet sayı olmalıdır!!!");
                        return;
                    }
                    else if (sembolVarMi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet özel karakter olmalıdır!!!");
                        return;
                    }
                    else if (txt_onayKodu.Text.ToUpper() != dogrulamaKodu)
                    {
                        MessageBox.Show("Doğrulama Kodu Hatalı");
                        return;
                    }
                    else
                    {
                        vt.UpdateDelete($@"update tbl_kullanici set sifre = '{dg.MD5Sifrele(txt_sifreTekrar.Text)}' where kullanici_id = {int.Parse(gelenKullaniciID)}");
                        MessageBox.Show("Şifre Başarıyla Değiştirildi");
                        AnaMenu anaMenu = new AnaMenu(gelenKullaniciAdi);
                        anaMenu.Show();
                        this.Hide();
                    }


                }
            }
            else if (rbtn_Personel.Checked)
            {
                if (txt_kullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı Boş Kalamaz.");
                    return;
                }

                DataTable dt = vt.Select($@"select k.kullanici_id, k.kullaniciAdi,p.tc_No,p.email,k.gorev_id from tbl_kullanici as k
                                                join tbl_personel as p on p.kullanici_id = k.kullanici_id
                                                where k.kullaniciAdi ='{txt_kullaniciAdi.Text}'");

                if (dt.Rows.Count > 0)
                {
                    string gelenKullaniciID = dt.Rows[0]["kullanici_id"].ToString();
                    string gelenKullaniciAdi = dt.Rows[0]["kullaniciAdi"].ToString();
                    string gelenMusteriTcNo = dt.Rows[0]["tc_no"].ToString();
                    string gelenMusteriEmail = dt.Rows[0]["email"].ToString();
                    string gelenGorev_id = dt.Rows[0]["gorev_id"].ToString();

                    if (gelenKullaniciAdi != txt_kullaniciAdi.Text)
                    {
                        MessageBox.Show("Kullanıcı Adı Hatalı.");
                        return;
                    }
                    else if (gelenMusteriTcNo != txt_tcNo.Text)
                    {
                        MessageBox.Show("TC No Hatalı.");
                        return;
                    }
                    else if (gelenMusteriEmail != txt_ePosta.Text)
                    {
                        MessageBox.Show("E-posta Hatalı.");
                        return;
                    }
                    else if (gelenGorev_id != "1")
                    {
                        MessageBox.Show("Bu Kullanıcı Bu Göreve Sahip Değil");
                        return;
                    }
                    else if (txt_yeniSifre.Text != txt_sifreTekrar.Text)
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor.");
                        return;
                    }
                    else if (buyukHarfVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 Adet Büyük Harf Olmalıdır");
                        return;
                    }
                    else if (kucukHarfVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet küçük Harf olmalıdır!!!");
                        return;
                    }
                    else if (sayiVarmi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet sayı olmalıdır!!!");
                        return;
                    }
                    else if (sembolVarMi(txt_yeniSifre.Text) == false)
                    {
                        MessageBox.Show("Şifrenizde en az 1 adet özel karakter olmalıdır!!!");
                        return;
                    }
                    else if (txt_onayKodu.Text.ToUpper() != dogrulamaKodu)
                    {
                        MessageBox.Show("Doğrulama Kodu Hatalı");
                        return;
                    }
                    else
                    {
                        vt.UpdateDelete($@"update tbl_kullanici set sifre = '{dg.MD5Sifrele(txt_sifreTekrar.Text)}' where kullanici_id = {int.Parse(gelenKullaniciID)}");
                        MessageBox.Show("Şifre Başarıyla Değiştirildi");
                        AnaMenu anaMenu = new AnaMenu(gelenKullaniciAdi);
                        anaMenu.Show();
                        this.Hide();
                    }


                }
            }
            else
            {
                MessageBox.Show("Lütfen Pozisyonunuzu Belirtiniz.(Personel Veya Müşteri)", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void SifreDegistirme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
                btn_SifreDegistirOnay_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.K)
                btn_KodGonder_Click(sender, e);

        }
    }
}
