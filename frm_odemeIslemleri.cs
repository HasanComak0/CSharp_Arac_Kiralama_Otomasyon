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
    public partial class frm_odemeIslemleri : Form
    {
        public frm_odemeIslemleri()
        {
            InitializeComponent();
        }
        VTI.Veritabani vt = new VTI.Veritabani();
        AnaMenu ana = new AnaMenu();
        int kullaniciGorevID;
        private void frm_odemeIslemleri_Load(object sender, EventArgs e)
        {
            kullaniciGorevID = ana.kullaniciGorevID;

            


            DataTable dt = vt.Select("select odemeTur_id,odemeTur from tbl_odemeTur");

            dgv_odemeTurIslemleri.DataSource = dt;
            dgv_odemeTurIslemleri.Columns["odemeTur_id"].Visible = false;

            DataTable dt2 = vt.Select($@"select odeme_id,o.kiralama_id,k.kiralamaAciklama,tutar,odeme_tarihi,o.odemeTur_id, od.odemeTur from tbl_odeme o
                                            join tbl_kiralama k on k.kiralama_id = o.kiralama_id
                                            join tbl_odemeTur od on od.odemeTur_id = o.odemeTur_id");

            dgv_odemeBilgileriIslemleri.DataSource = dt2;
            dgv_odemeBilgileriIslemleri.Columns["odeme_id"].Visible = false;
            dgv_odemeBilgileriIslemleri.Columns["kiralama_id"].Visible = false;
            dgv_odemeBilgileriIslemleri.Columns["odemeTur_id"].Visible = false;

            DataTable dt3 = vt.Select("Select kiralama_id,kiralamaAciklama from tbl_kiralama");
            cmb_kiralayanMusteri.DataSource = dt3;
            cmb_kiralayanMusteri.ValueMember = "kiralama_id";
            cmb_kiralayanMusteri.DisplayMember = "kiralamaAciklama";

            cmb_odemeTuru.DataSource = dt;
            cmb_odemeTuru.ValueMember = "odemeTur_id";
            cmb_odemeTuru.DisplayMember = "odemeTur";



        }
        private void dgv_odemeBilgileriIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            cmb_kiralayanMusteri.Text = dgv_odemeBilgileriIslemleri.Rows[e.RowIndex].Cells["kiralamaAciklama"].Value.ToString();
            txt_tutar.Text = dgv_odemeBilgileriIslemleri.Rows[e.RowIndex].Cells["tutar"].Value.ToString();
            if (DateTime.TryParse(dgv_odemeBilgileriIslemleri.SelectedRows[0].Cells["odeme_tarihi"].Value.ToString(), out DateTime baslangicT))
                dtp_odemeTarihi.Value = baslangicT;
            else
                dtp_odemeTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim
            cmb_odemeTuru.Text = dgv_odemeBilgileriIslemleri.Rows[e.RowIndex].Cells["odemeTur"].Value.ToString();
        }
        private void dgv_odemeTurIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_odemeTuru.Text = dgv_odemeTurIslemleri.Rows[e.RowIndex].Cells["odemeTur"].Value.ToString();
        }

        private void btn_odemeTurEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select("select odemeTur from tbl_odemeTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["odemeTur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_odemeTuru.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Ödeme Yöntemi Listede Zaten Mevcut");
                return;
            }
            if (txt_odemeTuru.Text == "")
            {
                MessageBox.Show("Ödeme Türü Boş Bırakılamaz.");
                return;
            }
            vt.Insert($@"insert into tbl_odemeTur(odemeTur)
                        values('{txt_odemeTuru.Text.Replace("'", "''")}')");

            MessageBox.Show("Ödeme Yöntemi Sisteme Başarıyla Eklendi");
            frm_odemeIslemleri_Load(null, null);
        }

        private void btn_odemeTurSil_Click(object sender, EventArgs e)
        {
            if (dgv_odemeTurIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            if (txt_odemeTuru.Text == "")
            {
                MessageBox.Show("Ödeme Türü Boş Bırakılamaz.");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_odemeTur where odemeTur = '{dgv_odemeTurIslemleri.SelectedRows[0].Cells["odemeTur"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                frm_odemeIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_odemeTurGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select("select odemeTur from tbl_odemeTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["odemeTur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_odemeTuru.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Ödeme Yöntemi Listede Zaten Mevcut");
                return;
            }

            if (dgv_odemeTurIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            if (txt_odemeTuru.Text == "")
            {
                MessageBox.Show("Ödeme Türü Boş Bırakılamaz.");
                return;
            }

            vt.UpdateDelete($@"update tbl_odemeTur
                                set odemeTur = '{txt_odemeTuru.Text.Replace("'", "''")}'
                                where odemeTur_id ={dgv_odemeTurIslemleri.SelectedRows[0].Cells["odemeTur_id"].Value.ToString()}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            frm_odemeIslemleri_Load(null, null);
        }

        private void btn_odemeTurTemizle_Click(object sender, EventArgs e)
        {
            txt_odemeTuru.Text = "";
            dgv_odemeTurIslemleri.ClearSelection();
        }

        private void btn_odemebilgisiEkle_Click(object sender, EventArgs e)
        {
            if (cmb_kiralayanMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Açıklama Seçiniz");
                return;
            }
            if (cmb_odemeTuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Ödeme Türü Seçiniz");
                return;
            }
            if (txt_tutar.Text == "")
            {
                MessageBox.Show("Tutar Boş Bırakılamaz.");
                return;
            }

            double maliyet;

            // Kullanıcının girdiğini normalize ediyoruz
            string girilenMaliyet = txt_tutar.Text.Trim().Replace(",", ".");

            if (!double.TryParse(
                    girilenMaliyet,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out maliyet))
            {
                MessageBox.Show("Maliyet geçerli bir sayı olmalıdır.");
                return;
            }

            vt.Insert($@"Insert into tbl_odeme(kiralama_id,tutar,odeme_tarihi,odemeTur_id)
                            values({cmb_kiralayanMusteri.SelectedValue},{maliyet},'{dtp_odemeTarihi.Value.ToString("yyyy-MM-dd")}',{cmb_odemeTuru.SelectedValue})");

            MessageBox.Show("Ödeme Bilgisi Sisteme Başarıyla Eklendi");
            frm_odemeIslemleri_Load(null, null);
        }

        private void btn_odemeBilgisiSil_Click(object sender, EventArgs e)
        {
            if (dgv_odemeBilgileriIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            if (txt_tutar.Text == "")
            {
                MessageBox.Show("Tutar Boş Bırakılamaz.");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"delete from tbl_odeme where odeme_id={dgv_odemeBilgileriIslemleri.SelectedRows[0].Cells["odeme_id"].Value.ToString()}");
            if (kayitSay > 0)
            {
                frm_odemeIslemleri_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_odemeBilgisiGuncelle_Click(object sender, EventArgs e)
        {
            if (cmb_kiralayanMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Açıklama Seçiniz");
                return;
            }
            if (cmb_odemeTuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Ödeme Türü Seçiniz");
                return;
            }
            if (txt_tutar.Text == "")
            {
                MessageBox.Show("Tutar Boş Bırakılamaz.");
                return;
            }
            if(dgv_odemeBilgileriIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz.");
                return;
            }

            double maliyet;

            // Kullanıcının girdiğini normalize ediyoruz
            string girilenMaliyet = txt_tutar.Text.Trim().Replace(",", ".");

            if (!double.TryParse(
                    girilenMaliyet,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out maliyet))
            {
                MessageBox.Show("Maliyet geçerli bir sayı olmalıdır.");
                return;
            }

            vt.UpdateDelete($@"update tbl_odeme
                                set kiralama_id ={cmb_kiralayanMusteri.SelectedValue},
                                tutar = {maliyet},
                                odeme_tarihi = '{dtp_odemeTarihi.Value.ToString("yyyy-MM-dd")}',
                                odemeTur_id={cmb_odemeTuru.SelectedValue}
                                where odeme_id ={dgv_odemeBilgileriIslemleri.SelectedRows[0].Cells["odeme_id"].Value.ToString()}");

            MessageBox.Show("Ödeme Bilgisi Başarıyla Güncellendi");
            frm_odemeIslemleri_Load(null, null);

        }

        private void btn_odemebilgisiTemizle_Click(object sender, EventArgs e)
        {
            cmb_kiralayanMusteri.SelectedIndex = -1;
            txt_tutar.Text = "";
            dtp_odemeTarihi.Text = "";
            cmb_odemeTuru.SelectedIndex = -1;
            dgv_odemeBilgileriIslemleri.ClearSelection();
        }

        private void frm_odemeIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_odemebilgisiEkle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_odemeBilgisiSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                btn_odemeBilgisiGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.T)
                btn_odemebilgisiTemizle_Click(sender, e);
        }
    }
}
