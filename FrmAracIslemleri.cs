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
    public partial class FrmAracIslemleri : Form
    {
        public FrmAracIslemleri()
        {
            InitializeComponent();
        }
        AnaMenu ana = new AnaMenu();

        VTI.Veritabani vt = new VTI.Veritabani();


        int kullaniciGorev_id;
        private void FrmAracIslemleri_Load(object sender, EventArgs e)
        {
            kullaniciGorev_id = ana.kullaniciGorevID;
        }


        #region Arac Islemleri
        private void tbpg_AracIslemleri_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vt.Select($@"select arm.marka_ad,am.model_ad,a.plaka,r.renkAd, a.gunluk_fiyat,a.eklenme_tarihi,vt.vites_tur,yt.yakit_tur,d.durum,a.mevcut_Km from tbl_arac a
                                                    join tbl_aracModel am on am.model_id = a.model_id
                                                    join tbl_aracMarka arm on arm.marka_id = am.marka_id
                                                    join tbl_renk r on r.renk_id = a.renk_id
                                                    join tbl_yakitTur yt on yt.yakit_tur_id = a.yakit_tur_id
                                                    join tbl_vitesTur vt on vt.vites_tur_id = a.vites_tur_id
                                                    join tbl_durum d on d.durum_id = a.durum_id
                                                    ");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            cmb_marka.Text = dataGridView1.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();
            cmb_model.Text = dataGridView1.Rows[e.RowIndex].Cells["model_ad"].Value.ToString();
            txt_plaka.Text = dataGridView1.Rows[e.RowIndex].Cells["plaka"].Value.ToString();
            cmb_renk.Text = dataGridView1.Rows[e.RowIndex].Cells["renkAd"].Value.ToString();
            txt_gunlukFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["gunluk_fiyat"].Value.ToString();

            if (DateTime.TryParse(dataGridView1.SelectedRows[0].Cells["eklenme_tarihi"].Value.ToString(), out DateTime dogum))
                dtp_eklenmeTarihi.Value = dogum;
            else
                dtp_eklenmeTarihi.Value = DateTime.Now; // hata olursa bugüne set edelim

            //dtp_eklenmeTarihi.Value = dataGridView1.Rows[e.RowIndex].Cells["eklenme_tarihi"].Value.ToString("yyyy-MM-dd");
            cmb_vitesTur.Text = dataGridView1.Rows[e.RowIndex].Cells["vites_tur"].Value.ToString();
            cmb_yakitTur.Text = dataGridView1.Rows[e.RowIndex].Cells["yakit_tur"].Value.ToString();
            cmb_Durum.Text = dataGridView1.Rows[e.RowIndex].Cells["durum"].Value.ToString();
            txt_mevcutKM.Text = dataGridView1.Rows[e.RowIndex].Cells["mevcut_Km"].Value.ToString();
        }
        #endregion

        #region DGV Doldurma
        private void tbpg_markaModelRenk_Enter(object sender, EventArgs e)
        {
            //dgv_MarkaIslemleri.DataSource = vt.Select($@"select marka_ad from tbl_aracMarka");


            //MARKA DOLDURMA
            DataTable dt = vt.Select($@"select marka_id,marka_ad from tbl_aracMarka");
            dgv_MarkaIslemleri.DataSource = dt;
            dgv_MarkaIslemleri.Columns["marka_id"].Visible = false;

            cmb_markaSec.DataSource = dt;
            cmb_markaSec.ValueMember = "marka_id";
            cmb_markaSec.DisplayMember = "marka_ad";

            //MODEL DOLDURMA

            dgv_ModelIslemleri.DataSource = vt.Select($@"select 
                                                        mdl.model_id,
                                                        mrk.marka_ad,
                                                        mdl.model_ad
                                                    from tbl_aracMarka mrk
                                                    join tbl_aracModel mdl on mrk.marka_id = mdl.marka_id");
            dgv_ModelIslemleri.Columns["model_id"].Visible = false;

            //RENK DOLDURMA

            dgv_renkIslemleri.DataSource = vt.Select($@"select renk_id,renkAd from tbl_renk");
            dgv_renkIslemleri.Columns["renk_id"].Visible = false;

            //VİTES DOLDURMA
            dgv_vitesIslemleri.DataSource = vt.Select($@"select vites_tur_id,vites_tur from tbl_vitesTur");
            dgv_vitesIslemleri.Columns["vites_tur_id"].Visible = false;

            //YAKIT DOLDURMA
            dgv_yakitIslemleri.DataSource = vt.Select($@"select yakit_tur_id,yakit_tur from tbl_yakitTur");
            dgv_yakitIslemleri.Columns["yakit_tur_id"].Visible = false;

            //DURUM DOLDURMA
            dgv_durumIslemleri.DataSource = vt.Select($@"select durum_id,durum from tbl_durum");
            dgv_durumIslemleri.Columns["durum_id"].Visible=false;

            //ARAÇ TAMİR DURUM DOLDURMA
            dgv_aracTDIslemleri.DataSource = vt.Select($@"select tamirDurum_id,tamirDurum from tbl_AracTamirDurum");
            dgv_aracTDIslemleri.Columns["tamirDurum_id"].Visible = false;
        }
        #endregion

        #region DGV Tıklama
        private void dgv_MarkaIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txt_markaEkle.Text =
                dgv_MarkaIslemleri.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();
        }


        private void dgv_ModelIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cmb_markaSec.Text =
                dgv_ModelIslemleri.Rows[e.RowIndex].Cells["marka_ad"].Value.ToString();

            txt_modelEkle.Text =
                dgv_ModelIslemleri.Rows[e.RowIndex].Cells["model_ad"].Value.ToString();
        }
        private void dgv_renkIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_renkEkleme.Text = dgv_renkIslemleri.Rows[e.RowIndex].Cells["renkAd"].Value.ToString();
        }

        private void dgv_vitesIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            if (e.RowIndex < 0)
                return;
            txt_vitesEkleme.Text = dgv_vitesIslemleri.Rows[e.RowIndex].Cells["vites_tur"].Value.ToString();
        }

        private void dgv_yakitIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_yakitEkleme.Text = dgv_yakitIslemleri.Rows[e.RowIndex].Cells["yakit_tur"].Value.ToString();
        }
        private void dgv_durumIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_durumEkleme.Text = dgv_durumIslemleri.Rows[e.RowIndex].Cells["durum"].Value.ToString();
        }

        private void dgv_aracTDIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txt_aracTDekleme.Text = dgv_aracTDIslemleri.Rows[e.RowIndex].Cells["tamirDurum"].Value.ToString();
        }
        #endregion

        #region Marka Ekle Sil Güncelle

        private void btn_markaEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select marka_ad from tbl_aracMarka");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["marka_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_markaEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Marka Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"
                        insert into tbl_aracMarka (marka_ad)
                        values ('{txt_markaEkle.Text.Replace("'", "''")}')
                    ");

            MessageBox.Show("Marka Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_markaSil_Click(object sender, EventArgs e)
        {
            if (dgv_MarkaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_aracMarka where marka_ad = '{dgv_MarkaIslemleri.SelectedRows[0].Cells["marka_ad"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_markaGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select marka_ad from tbl_aracMarka");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["marka_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_markaEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Marka Listede Zaten Mevcut");
                return;
            }

            if (dgv_MarkaIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            vt.UpdateDelete($@"update tbl_aracMarka
                                set marka_ad ='{txt_markaEkle.Text.Replace("'", "''")}'
                                where marka_ad ='{dgv_MarkaIslemleri.SelectedRows[0].Cells["marka_ad"].Value.ToString()}'");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_markaTemizle_Click(object sender, EventArgs e)
        {
            txt_markaEkle.Text = "";
        }

        #endregion

        #region Model Ekle Sil Güncelle
        private void btn_modelEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select model_ad from tbl_aracModel");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["model_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_modelEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Model Listede Zaten Mevcut");
                return;
            }



            vt.Insert($@"insert into tbl_aracModel (marka_id,model_ad)
                            values ({cmb_markaSec.SelectedValue},'{txt_modelEkle.Text.Replace("'", "''")}')");

            MessageBox.Show("Model Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }
        private void btn_modelSil_Click(object sender, EventArgs e)
        {
            if (dgv_ModelIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            int kayitSay = vt.UpdateDelete($@"delete from tbl_aracModel where model_id = '{dgv_ModelIslemleri.SelectedRows[0].Cells["model_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_modelGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select model_ad from tbl_aracModel");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["model_ad"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_modelEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Model Listede Zaten Mevcut");
                return;
            }

            if (dgv_ModelIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Kaydı Seçiniz");
                return;
            }
            vt.UpdateDelete($@"
                                update tbl_aracModel
                                set 
                                    marka_id = {cmb_markaSec.SelectedValue},
                                    model_ad = '{txt_modelEkle.Text.Replace("'", "''")}'
                                where model_id = {Convert.ToInt32(dgv_ModelIslemleri.SelectedRows[0].Cells["model_id"].Value.ToString())}
                            ");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }
        private void btn_modelTemizle_Click(object sender, EventArgs e)
        {
            cmb_markaSec.SelectedIndex = -1;
            txt_modelEkle.Text = "";
        }



        #endregion

        #region Renk Ekle Sil Güncelle
        private void btn_renkEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select renkAd from tbl_renk");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["renkAd"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_renkEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Renk Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_renk (renkAd)
                                values('{txt_renkEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Renk Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_renkSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where renk_id = {Convert.ToInt32(dgv_renkIslemleri.SelectedRows[0].Cells["renk_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu renk araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_renkIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_renk
                                            where renkAd = '{dgv_renkIslemleri.SelectedRows[0].Cells["renkAd"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_renkGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select renkAd from tbl_renk");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["renkAd"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_renkEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Renk Listede Zaten Mevcut");
                return;
            }

            if (dgv_renkIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_renk
                                set renkAd ='{txt_renkEkleme.Text.Replace("'", "''").ToUpper()}'
                                where renk_id = {Convert.ToInt32(dgv_renkIslemleri.SelectedRows[0].Cells["renk_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_renkTemizle_Click(object sender, EventArgs e)
        {
            txt_renkEkleme.Text = "";
        }
        #endregion

        #region Vites Ekle Sil Güncelle
        private void btn_vitesEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select vites_tur from tbl_vitesTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["vites_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_vitesEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Vites Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_vitesTur (vites_tur)
                                values('{txt_vitesEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Vites Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }
        private void btn_vitesSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where vites_tur_id = {Convert.ToInt32(dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu vites araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_vitesTur
                                            where vites_tur = '{dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }

        private void btn_vitesGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select vites_tur from tbl_vitesTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["vites_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_vitesEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Vites Listede Zaten Mevcut");
                return;
            }

            if (dgv_vitesIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_vitesTur
                                set vites_tur ='{txt_vitesEkleme.Text.Replace("'", "''").ToUpper()}'
                                where renk_id = {Convert.ToInt32(dgv_vitesIslemleri.SelectedRows[0].Cells["vites_tur_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_vitesTemizle_Click(object sender, EventArgs e)
        {
            txt_vitesEkleme.Text = "";
        }


        #endregion

        #region Yakıt Ekle Sil Güncelle
        private void btn_yakitEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select yakit_tur from tbl_yakitTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["yakit_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_yakitEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Yakıt Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_yakitTur (yakit_tur)
                                values('{txt_yakitEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Yakıt Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_yakitSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where yakit_tur_id = {Convert.ToInt32(dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu yakıt araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_yakitIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_yakitTur
                                            where yakit_tur_id = '{dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi");
            }
        }
        private void btn_yakitGuncelle_Click(object sender, EventArgs e)
        {

            DataTable dt = vt.Select(@"select yakit_tur from tbl_yakitTur");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["yakit_tur"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_yakitEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Yakıt Listede Zaten Mevcut");
                return;
            }

            if (dgv_yakitIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_yakitTur
                                set yakit_tur ='{txt_yakitEkleme.Text.Replace("'", "''").ToUpper()}'
                                where yakit_tur_id = {Convert.ToInt32(dgv_yakitIslemleri.SelectedRows[0].Cells["yakit_tur_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_yakitTemizle_Click(object sender, EventArgs e)
        {
            txt_yakitEkleme.Text = "";
        }

        #endregion

        #region Durum Ekle Sil Güncelle
        private void btn_durumEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select durum from tbl_durum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["durum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_durumEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_durum (durum)
                                values('{txt_durumEkleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Durum Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_durumSil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_arac where durum_id = {Convert.ToInt32(dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu durum araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_durumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_durum
                                            where durum_id = '{dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Durum Başarıyla Silindi");
            }
        }

        private void btn_durumGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select durum from tbl_durum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["durum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_durumEkleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (dgv_durumIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_durum
                                set durum ='{txt_durumEkleme.Text.Replace("'", "''").ToUpper()}'
                                where durum_id = {Convert.ToInt32(dgv_durumIslemleri.SelectedRows[0].Cells["durum_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_durumTemizle_Click(object sender, EventArgs e)
        {
            txt_durumEkleme.Text = "";
        }

        #endregion

        #region Arac Tamir Durum Ekle Sil Güncelle
        private void btn_aracTDekle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_aracTDekleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            vt.Insert($@"insert into tbl_AracTamirDurum (tamirDurum)
                                values('{txt_aracTDekleme.Text.Replace("'", "''").ToUpper()}')");

            MessageBox.Show("Durum Başarıyla Eklendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_aracTDsil_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select($@"select * from tbl_AracHasar where tamirDurum_id = {Convert.ToInt32(dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString())}");

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bu durum araçlarda kullanılıyor, silinemez");
                return;
            }

            if (dgv_aracTDIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }

            int kayitSay = vt.UpdateDelete($@"Delete from tbl_AracTamirDurum
                                            where tamirDurum_id = '{dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString()}'");
            if (kayitSay > 0)
            {
                tbpg_markaModelRenk_Enter(null, null);
                MessageBox.Show("Durum Başarıyla Silindi");
            }
        }

        private void btn_aracTDGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select tamirDurum from tbl_AracTamirDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["tamirDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_aracTDekleme.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (dgv_aracTDIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Guncellenecek Kaydı Seçiniz");
                return;
            }

            vt.UpdateDelete($@"update tbl_AracTamirDurum
                                set tamirDurum ='{txt_aracTDekleme.Text.Replace("'", "''").ToUpper()}'
                                where tamirDurum_id = {Convert.ToInt32(dgv_aracTDIslemleri.SelectedRows[0].Cells["tamirDurum_id"].Value.ToString())}");

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            tbpg_markaModelRenk_Enter(null, null);
        }

        private void btn_aracTDtemizle_Click(object sender, EventArgs e)
        {
            txt_aracTDekleme.Text = "";
        }
        #endregion


    }






}

