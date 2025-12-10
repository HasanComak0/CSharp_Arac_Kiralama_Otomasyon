using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama
{
    public partial class KullaniciOlusturGirisYap : Form
    {
        public KullaniciOlusturGirisYap()
        {
            InitializeComponent();
        }

        private void pnl_KullaniciOlustur_Click(object sender, EventArgs e)
        {
            KullaniciOlustur kullaniciOlustur = new KullaniciOlustur();
            this.Hide();
            kullaniciOlustur.Show();
        }

        private void pnl_GirisYap_Click(object sender, EventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            this.Hide();
            girisYap.Show();
        }
    }
}
