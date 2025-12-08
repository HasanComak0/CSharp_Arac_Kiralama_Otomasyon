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

namespace Arac_Kiralama
{
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }

        private void btn_KodGonder_Click(object sender, EventArgs e)
        {
            try
            {


                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUser = "";
                string smtpPass = "";

                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);

                mail.From = new MailAddress(smtpUser);
                mail.To.Add("");
                mail.Subject = "";
                mail.Body = "";

                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                MessageBox.Show("Mail Hesabınıza Gönderilen Kod Gönderildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta Gönderilirken Bir Hata oluştu: " + ex.Message,"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
