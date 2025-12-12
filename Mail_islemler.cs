using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;

namespace Arac_Kiralama
{
    internal class Mail_islemler
    {
        string[] onayKodu = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random random = new Random();
        public string yazi = "";
        public string dogrulamaKodu;

        public string KodOlustur()
        {
            yazi = "";

            for (int i = 0; i < 6; i++)
            {
                //textbox= "";
                int sayi = random.Next(0, onayKodu.Length);
                string secilen_Kod = onayKodu[sayi].ToString();
                yazi += secilen_Kod;
            }
            
            return yazi;
        }
        
        public void EmailGonder(string gonderilecekEmail)
        {
            DotEnv.Load();

            dogrulamaKodu = KodOlustur();
            try
            {

               

                string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
                string smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT");

                string smtpUser = Environment.GetEnvironmentVariable("SMTP_USER");
                string smtpPass = Environment.GetEnvironmentVariable("SMTP_PASS");

                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);

                mail.From = new MailAddress(smtpUser);
                mail.To.Add(gonderilecekEmail);//mail gönderilecek hesap
                mail.Subject = "Personel Kayıt Kodu";//mail konusu
                mail.Body = "Yeni Personeli Kaydetmeyi Onaylamak İçin Verilen Kodu Sisteme Giriniz: " + dogrulamaKodu;//mail içeriği(asıl yazılan mesaj)

                smtpClient.Port = Convert.ToInt32(smtpPort);
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
    }
}
