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
    public partial class frm_aracKazaIslemleri : Form
    {
        public frm_aracKazaIslemleri()
        {
            InitializeComponent();
        }
        AnaMenu ana = new AnaMenu();
        VTI.Veritabani vt = new VTI.Veritabani();
        int kullaniciGorev_Id;
        private void frm_aracKazaIslemleri_Load(object sender, EventArgs e)
        {
            kullaniciGorev_Id = ana.kullaniciGorevID;

            DataTable dt = vt.Select($@"select tamirDurum_id,tamirDurum from tbl_AracTamirDurum");

            dgv_tamirDurumIslemleri.DataSource = dt;
            dgv_tamirDurumIslemleri.Columns["tamirDurum_id"].Visible = false;


            DataTable dt2 = vt.Select($@"select ah.hasar_id,
                                        ah.arac_id,a.plaka,
                                        ah.kiralama_id,k.kiralamaAciklama,
                                        hasar_aciklama,hasar_tarihi,hasar_ucreti,
                                        ah.tamirDurum_id , atd.tamirDurum 
                                        from tbl_AracHasar ah
                                        join tbl_arac a on a.arac_id = ah.arac_id
                                        join tbl_kiralama k on k.kiralama_id = ah.kiralama_id
                                        join tbl_AracTamirDurum atd on atd.tamirDurum_id = ah.tamirDurum_id");

            dgv_aracHasarIslemleri.DataSource = dt2;
            dgv_aracHasarIslemleri.Columns["hasar_id"].Visible = false;
            dgv_aracHasarIslemleri.Columns["arac_id"].Visible = false;
            dgv_aracHasarIslemleri.Columns["kiralama_id"].Visible = false;
            dgv_aracHasarIslemleri.Columns["tamirDurum_id"].Visible = false;

            DataTable dt3 = vt.Select("select arac_id,plaka from tbl_arac");
            cmb_aracPlaka.DataSource = dt3;
            cmb_aracPlaka.ValueMember = "arac_id";
            cmb_aracPlaka.DisplayMember = "plaka";

            DataTable dt4 = vt.Select("select kiralama_id,kiralamaAciklama from tbl_kiralama");
            cmb_kiraAciklama.DataSource = dt4;
            cmb_kiraAciklama.ValueMember = "kiralama_id";
            cmb_kiraAciklama.DisplayMember = "kiralamaAciklama";

            DataTable dt5 = vt.Select("select tamirDurum_id,tamirDurum from tbl_AracTamirDurum");

            cmb_tamirDurumu.DataSource = dt5;
            cmb_tamirDurumu.ValueMember = "tamirDurum_id";
            cmb_tamirDurumu.DisplayMember = "tamirDurum";

        }

        private void dgv_tamirDurumIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txt_tamirDurum.Text = dgv_tamirDurumIslemleri.Rows[e.RowIndex].Cells["tamirDurum"].Value.ToString();
        }

        private void btn_tamirDurumEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select("select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_tamirDurum.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Tamir Durumu Listede Zaten Mevcut");
                return;
            }
            if (txt_tamirDurum.Text == "")
            {
                MessageBox.Show("Tamir Durumu Boş Bırakılamaz.");
                return;
            }
            vt.Insert($@"insert into tbl_AracTamirDurum(tamirDurum)
                        values('{txt_tamirDurum.Text.Replace("'", "''")}')");

            MessageBox.Show("Tamir Durumu Sisteme Başarıyla Eklendi");
            frm_aracKazaIslemleri_Load(null, null);
        }

        private void btn_tamirDurumSil_Click(object sender, EventArgs e)
        {
            if (dgv_tamirDurumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            if (txt_tamirDurum.Text == "")
            {
                MessageBox.Show("Tamir Durumu Boş Bırakılamaz.");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_AracTamirDurum where tamirDurum = '{dgv_tamirDurumIslemleri.SelectedRows[0].Cells["tamirDurum"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                frm_aracKazaIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_tamirDurumGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select("select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_tamirDurum.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Tamir Durumu Listede Zaten Mevcut");
                return;
            }

            if (dgv_tamirDurumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            if (txt_tamirDurum.Text == "")
            {
                MessageBox.Show("Tamir Durumu Boş Bırakılamaz.");
                return;
            }


            vt.UpdateDelete($@"update tbl_AracTamirDurum
                                set tamirDurum ='{txt_tamirDurum.Text.Replace("'", "''")}'
                                where tamirDurum_id ={dgv_tamirDurumIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString()}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            frm_aracKazaIslemleri_Load(null, null);
        }

        private void btn_tamirDurumTemizle_Click(object sender, EventArgs e)
        {
            txt_tamirDurum.Text = "";
            dgv_tamirDurumIslemleri.ClearSelection();
        }


        //ARAÇ HASAR İŞLEMLERİ

        private void dgv_aracHasarIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            cmb_aracPlaka.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["plaka"].Value.ToString();
            cmb_kiraAciklama.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["kiralamaAciklama"].Value.ToString();
            txt_hasarAciklama.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["hasar_aciklama"].Value.ToString();
            dtp_hasarTarihi.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["hasar_tarihi"].Value.ToString();
            txt_hasarUcret.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["hasar_ucreti"].Value.ToString();
            cmb_tamirDurumu.Text = dgv_aracHasarIslemleri.Rows[e.RowIndex].Cells["tamirDurum"].Value.ToString();
        }

        private void btn_aracHasarEkle_Click(object sender, EventArgs e)
        {
            if (cmb_aracPlaka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Plaka Seçiniz");
                return;
            }
            if (cmb_kiraAciklama.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Açıklama Seçiniz");
                return;
            }
            if (txt_hasarAciklama.Text == "")
            {
                MessageBox.Show("Hasar Açıklaması Boş Bırakılamaz.");
                return;
            }
            if (dtp_hasarTarihi.Text == "")
            {
                MessageBox.Show("Hasar Tarihi Boş Bırakılamaz.");
                return;
            }

            double maliyet;

            // Kullanıcının girdiğini normalize ediyoruz
            string girilenMaliyet = txt_hasarUcret.Text.Trim().Replace(",", ".");

            if (!double.TryParse(
                    girilenMaliyet,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out maliyet))
            {
                MessageBox.Show("Hasar Ücreti geçerli bir sayı olmalıdır.");
                return;
            }
            if (cmb_tamirDurumu.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Tamir Durumu Seçiniz.");
                return;
            }

           
            vt.Insert($@"insert into tbl_AracHasar(arac_id,kiralama_id,hasar_aciklama,hasar_tarihi,hasar_ucreti,tamirDurum_id)
values({cmb_aracPlaka.SelectedValue},{cmb_kiraAciklama.SelectedValue},'{txt_hasarAciklama.Text.Replace("'","''")}','{dtp_hasarTarihi.Value.ToString("yyyy-MM-dd")}',{maliyet},{cmb_tamirDurumu.SelectedValue})");

            MessageBox.Show("Ödeme Bilgisi Sisteme Başarıyla Eklendi");
            frm_aracKazaIslemleri_Load(null, null);
        }

        private void btn_aracHasarSil_Click(object sender, EventArgs e)
        {
            if(dgv_aracHasarIslemleri.SelectedRows.Count==0)
            {
                MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz");
                return;
            }
            if(txt_hasarAciklama.Text=="")
            {
                MessageBox.Show("Hasar Açıklaması Boş bırakılamaz");
                return;
            }
            if(txt_hasarUcret.Text=="")
            {
                MessageBox.Show("Hasar Ücreti Boş bırakılamaz");
                return;
            }
            vt.UpdateDelete($@"delete from tbl_AracHasar
                            where hasar_id ={dgv_aracHasarIslemleri.SelectedRows[0].Cells["hasar_id"].Value.ToString()}");

            MessageBox.Show("Kayıt Başarıyla Silindi");
            frm_aracKazaIslemleri_Load(null, null);
        }

        private void btn_aracHasarGuncelle_Click(object sender, EventArgs e)
        {
            if (cmb_aracPlaka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Plaka Seçiniz");
                return;
            }
            if (cmb_kiraAciklama.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Açıklama Seçiniz");
                return;
            }
            if (txt_hasarAciklama.Text == "")
            {
                MessageBox.Show("Hasar Açıklaması Boş Bırakılamaz.");
                return;
            }
            if (dtp_hasarTarihi.Text == "")
            {
                MessageBox.Show("Hasar Tarihi Boş Bırakılamaz.");
                return;
            }

            double maliyet;

            // Kullanıcının girdiğini normalize ediyoruz
            string girilenMaliyet = txt_hasarUcret.Text.Trim().Replace(",", ".");

            if (!double.TryParse(
                    girilenMaliyet,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out maliyet))
            {
                MessageBox.Show("Hasar Ücreti geçerli bir sayı olmalıdır.");
                return;
            }
            if (cmb_tamirDurumu.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Tamir Durumu Seçiniz.");
                return;
            }

            vt.UpdateDelete($@"update tbl_AracHasar
                                set arac_id ={cmb_aracPlaka.SelectedValue},
                                kiralama_id={cmb_kiraAciklama.SelectedValue},
                                hasar_aciklama='{txt_hasarAciklama.Text.Replace("'", "''")}',
                                hasar_tarihi='{dtp_hasarTarihi.Value.ToString("yyyy-MM-dd")}',
                                hasar_ucreti ={maliyet},
                                tamirDurum_id={cmb_tamirDurumu.SelectedValue}
                                where hasar_id={dgv_aracHasarIslemleri.SelectedRows[0].Cells["hasar_id"].Value.ToString()}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi.");
            frm_aracKazaIslemleri_Load(null, null);
        }

        private void btn_aracHasarTemizle_Click(object sender, EventArgs e)
        {
            cmb_aracPlaka.SelectedIndex = -1;
            cmb_kiraAciklama.SelectedIndex = -1;
            cmb_tamirDurumu.SelectedIndex = -1;
            txt_hasarAciklama.Text = "";
            txt_hasarUcret.Text = "";
            dtp_hasarTarihi.Text = "";
            dgv_aracHasarIslemleri.ClearSelection();        
        }

        private void frm_aracKazaIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_aracHasarEkle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_aracHasarSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                btn_aracHasarGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.T)
                btn_aracHasarTemizle_Click(sender, e);

            if (e.Alt && e.KeyCode == Keys.Z)
                btn_tamirDurumEkle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.X)
                btn_tamirDurumSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.C)
                btn_tamirDurumGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.V)
                btn_tamirDurumTemizle_Click(sender, e);
        }

        
    }
}
