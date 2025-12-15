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
    public partial class frm_KiraIslemleri : Form
    {
        VTI.Veritabani vt = new VTI.Veritabani();
        public frm_KiraIslemleri()
        {
            InitializeComponent();
        }



        private void tbpg_Adres_ve_KiraDurumu_Enter(object sender, EventArgs e)
        {
            DataTable dt = vt.Select("select adres_id,teslimEdilenAdres,teslimAlınanAdres from tbl_adres");

            dgv_AdresIslemleri.DataSource = dt;
            dgv_AdresIslemleri.Columns["adres_id"].Visible = false;


            DataTable dt2 = vt.Select("select kiralamaDurum_id,kiralamaDurum from tbl_kiralamaDurum");
            dgv_kiralamaDurumIslemleri.DataSource = dt2;
            dgv_kiralamaDurumIslemleri.Columns["kiralamaDurum_id"].Visible = false;
        }

        private void dgv_AdresIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txt_teslimEdilenAdres.Text = dgv_AdresIslemleri.Rows[e.RowIndex].Cells["teslimEdilenAdres"].Value.ToString();
            txt_teslimAlınanAdres.Text = dgv_AdresIslemleri.Rows[e.RowIndex].Cells["teslimAlınanAdres"].Value.ToString();
        }
        private void dgv_kiralamaDurumIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txt_kiralamaDurumEkle.Text = dgv_kiralamaDurumIslemleri.Rows[e.RowIndex].Cells["kiralamaDurum"].Value.ToString();
        }
        private void btn_kiralamaDurumEkle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select kiralamaDurum from tbl_kiralamaDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["kiralamaDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_kiralamaDurumEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (txt_kiralamaDurumEkle.Text == "")
            {
                MessageBox.Show("Kiralama Durumu Boş Kalamaz");
                return;
            }

            vt.Insert($@"insert into tbl_kiralamaDurum(kiralamaDurum)
                        values('{txt_kiralamaDurumEkle.Text.Replace("'", "''")}')");

            MessageBox.Show("Kiralama Durumu Başarıyla Eklendi");

            tbpg_Adres_ve_KiraDurumu_Enter(null, null);
        }

        private void btn_kiralamaDurumSil_Click(object sender, EventArgs e)
        {
            if (dgv_kiralamaDurumIslemleri.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz.");
                return;
            }

            if (txt_kiralamaDurumEkle.Text == "")
            {
                MessageBox.Show("Kiralama Durumu Boş Kalamaz");
                return;
            }
            vt.UpdateDelete($@"Delete from tbl_kiralamaDurum
                            where kiralamaDurum_id ={dgv_kiralamaDurumIslemleri.SelectedRows[0].Cells["kiralamaDurum_id"].Value.ToString()}");

            MessageBox.Show("Kayıt Başarıyla Silindi");
            tbpg_Adres_ve_KiraDurumu_Enter(null, null);

        }

        private void btn_kiralamaDurumGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt = vt.Select(@"select kiralamaDurum from tbl_kiralamaDurum");

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["kiralamaDurum"].ToString().ToUpper().Trim());
            }

            if (list.Contains(txt_kiralamaDurumEkle.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Bu Durum Listede Zaten Mevcut");
                return;
            }

            if (txt_kiralamaDurumEkle.Text == "")
            {
                MessageBox.Show("Kiralama Durumu Boş Kalamaz");
                return;
            }

            vt.UpdateDelete($@"update tbl_kiralamaDurum
                                set kiralamaDurum = '{txt_kiralamaDurumEkle.Text.Replace("'", "''")}'
                                where kiralamaDurum_id={dgv_kiralamaDurumIslemleri.SelectedRows[0].Cells["kiralamaDurum_id"].Value.ToString()}");

            MessageBox.Show("Kiralama Durumu Başarıyla Güncellendi");

            tbpg_Adres_ve_KiraDurumu_Enter(null, null);
        }

        private void btn_kiralamaDurumTemizle_Click(object sender, EventArgs e)
        {
            txt_kiralamaDurumEkle.Text = "";
            dgv_kiralamaDurumIslemleri.ClearSelection();
        }

        private void btn_adresEkle_Click(object sender, EventArgs e)
        {
            if (txt_teslimAlınanAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }
            if (txt_teslimEdilenAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }
            vt.Insert($@"insert into tbl_adres(teslimAlınanAdres,teslimEdilenAdres)
                        values('{txt_teslimAlınanAdres.Text.Replace("'", "''")}','{txt_teslimEdilenAdres.Text.Replace("'", "''")}')");

            MessageBox.Show("Adres Başarıyla Eklendi");
            tbpg_Adres_ve_KiraDurumu_Enter(null, null);

        }

        private void btn_adresSil_Click(object sender, EventArgs e)
        {
            if (dgv_AdresIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz.");
                return;
            }
            if (txt_teslimAlınanAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }
            if (txt_teslimEdilenAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }

            vt.UpdateDelete($@"delete from tbl_adres
                                where adres_id={dgv_AdresIslemleri.SelectedRows[0].Cells["adres_id"].Value.ToString()}");

            MessageBox.Show("Adres Başarıyla Silindi.");
            tbpg_Adres_ve_KiraDurumu_Enter(null, null);
        }

        private void btn_adresGuncelle_Click(object sender, EventArgs e)
        {
            if (dgv_AdresIslemleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen Güncellenecek Kaydı Seçiniz.");
                return;
            }
            if (txt_teslimAlınanAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }
            if (txt_teslimEdilenAdres.Text == "")
            {
                MessageBox.Show("Teslim Alınan Adres Boş Kalamaz");
                return;
            }
            vt.UpdateDelete($@"update tbl_adres
                                set teslimAlınanAdres='{txt_teslimAlınanAdres.Text.Replace("'", "''")}',
                                teslimEdilenAdres='{txt_teslimEdilenAdres.Text.Replace("'", "''")}'
                                where adres_id={dgv_AdresIslemleri.SelectedRows[0].Cells["adres_id"].Value.ToString()}");
            MessageBox.Show("Adres Başarıyla Güncellendi.");
            tbpg_Adres_ve_KiraDurumu_Enter(null, null);
        }

        private void btn_adresTemizle_Click(object sender, EventArgs e)
        {
            txt_teslimAlınanAdres.Text = "";
            txt_teslimEdilenAdres.Text = "";
            dgv_AdresIslemleri.ClearSelection();
        }



        private void tbpg_aracKirala_Enter(object sender, EventArgs e)
        {

            DataTable dt = vt.Select($@"SELECT 
                                        k.kiralama_id,
                                        a.plaka,
                                        mk.kullaniciAdi AS musteri_kullanici_adi,
                                        pk.kullaniciAdi AS personel_kullanici_adi,
                                        k.kiralama_tarihi,
                                        k.beklenen_teslim,
                                        k.teslim_tarihi,
                                        k.toplam_fiyat,
                                        kd.kiralamaDurum,
                                        adr.teslimEdilenAdres,
                                        k.alis_km,
                                        k.teslim_km,
                                        ah.hasar_aciklama,
                                        k.kiralamaAciklama,
	                                    evr.senet
                                    FROM tbl_kiralama k
                                    JOIN tbl_arac a ON a.arac_id = k.arac_id
                                    JOIN tbl_musteri m ON m.musteri_id = k.musteri_id
                                    JOIN tbl_kullanici mk ON mk.kullanici_id = m.kullanici_id
                                    JOIN tbl_personel p ON p.personel_id = k.personel_id
                                    JOIN tbl_kullanici pk ON pk.kullanici_id = p.kullanici_id
                                    JOIN tbl_kiralamaDurum kd 
                                        ON kd.kiralamaDurum_id = k.kiralamaDurum_id
                                    JOIN tbl_adres adr 
                                        ON adr.adres_id = k.adres_id
                                    LEFT JOIN tbl_aracHasar ah 
                                        ON ah.kiralama_id = k.kiralama_id
                                    join tbl_evrak evr on evr.evrak_id= k.evrak_id");

            dgv_aracKiralamaIslemi.DataSource = dt;
            dgv_aracKiralamaIslemi.Columns["kiralama_id"].Visible = false;


            DataTable dt2 = vt.Select("select arac_id,plaka from tbl_arac");

            cmb_plaka.DataSource = dt2;
            cmb_plaka.ValueMember = "arac_id";
            cmb_plaka.DisplayMember = "plaka";

            DataTable dt3 = vt.Select($@"select m.musteri_id,k.kullaniciAdi from tbl_musteri m
                                        join tbl_kullanici k on k.kullanici_id = m.kullanici_id");
            cmb_musteri.DataSource = dt3;
            cmb_musteri.ValueMember = "musteri_id";
            cmb_musteri.DisplayMember = "kullaniciAdi";

            DataTable dt4 = vt.Select($@"select p.personel_id,k.kullaniciAdi from tbl_personel p
                                        join tbl_kullanici k on k.kullanici_id = p.kullanici_id");

            cmb_personel.DataSource = dt4;
            cmb_personel.ValueMember = "personel_id";
            cmb_personel.DisplayMember = "kullaniciAdi";

            DataTable dt5 = vt.Select($@"select kiralamaDurum_id,kiralamaDurum from tbl_kiralamaDurum");

            cmb_kiralamaDurum.DataSource = dt5;
            cmb_kiralamaDurum.ValueMember = "kiralamaDurum_id";
            cmb_kiralamaDurum.DisplayMember = "kiralamaDurum";

            DataTable dt6 = vt.Select($@"select adres_id,teslimEdilenAdres from tbl_adres");
            cmb_Adres.DataSource = dt6;
            cmb_Adres.ValueMember = "adres_id";
            cmb_Adres.DisplayMember = "teslimEdilenAdres";

            DataTable dt7 = vt.Select($@"select hasar_id,hasar_aciklama from tbl_AracHasar");
            cmb_HasarAciklama.DataSource = dt7;
            cmb_HasarAciklama.ValueMember = "hasar_id";
            cmb_HasarAciklama.DisplayMember = "hasar_aciklama";

            DataTable dt8 = vt.Select($@"select evrak_id,senet from tbl_evrak");
            cmb_senet.DataSource = dt8;
            cmb_senet.ValueMember = "evrak_id";
            cmb_senet.DisplayMember = "senet";


        }
        private void dgv_aracKiralamaIslemi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            cmb_plaka.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["plaka"].Value.ToString();
            cmb_musteri.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["musteri_kullanici_adi"].Value.ToString();
            cmb_personel.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["personel_kullanici_adi"].Value.ToString();
            dtp_kiralamaTarihi.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["kiralama_tarihi"].Value.ToString();
            dtp_beklenenTeslimTarihi.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["beklenen_teslim"].Value.ToString();
            dtp_teslimTarihi.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["teslim_tarihi"].Value.ToString();
            txt_toplamFiyat.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["toplam_fiyat"].Value.ToString();
            cmb_kiralamaDurum.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["kiralamaDurum"].Value.ToString();
            cmb_Adres.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["teslimEdilenAdres"].Value.ToString();
            txt_alisKM.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["alis_km"].Value.ToString();
            txt_teslimKilometresi.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["teslim_km"].Value.ToString();
            cmb_HasarAciklama.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["hasar_aciklama"].Value.ToString();
            txt_kiralamaAciklama.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["kiralamaAciklama"].Value.ToString();
            cmb_senet.Text = dgv_aracKiralamaIslemi.Rows[e.RowIndex].Cells["senet"].Value.ToString();
        }

        private void btn_aracKiralamaEkle_Click(object sender, EventArgs e)
        {
            
            if (cmb_plaka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir araç (plaka) seçiniz");
                return;
            }
            if (cmb_musteri.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
                return;
            }
            if (cmb_personel.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir personel seçiniz");
                return;
            }
            if (cmb_kiralamaDurum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kiralama durumunu seçiniz");
                return;
            }
            if (cmb_Adres.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen adres seçiniz");
                return;
            }
            if (cmb_senet.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen senet seçiniz");
                return;
            }


            double toplamFiyat;
            if (!double.TryParse(
                txt_toplamFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out toplamFiyat))
            {
                MessageBox.Show("Toplam fiyat geçerli bir sayı olmalıdır");
                return;
            }

            int alisKm;
            if (!int.TryParse(txt_alisKM.Text, out alisKm))
            {
                MessageBox.Show("Alış kilometresi tam sayı olmalıdır");
                return;
            }

            int teslimKm;
            if (!int.TryParse(txt_teslimKilometresi.Text, out teslimKm))
            {
                MessageBox.Show("Teslim kilometresi tam sayı olmalıdır");
                return;
            }

            //AYNI ARAÇ HALA KİRALIK MI KONTROL EDİYOM
            DataTable kontrol = vt.Select($@"
                    SELECT COUNT(*) AS adet
                    FROM tbl_kiralama
                    WHERE arac_id = {cmb_plaka.SelectedValue}
                    AND teslim_tarihi IS NULL
                ");

            if (Convert.ToInt32(kontrol.Rows[0]["adet"]) > 0)
            {
                MessageBox.Show("Bu araç henüz teslim edilmemiş. Yeni kiralama yapılamaz!");
                return;
            }

           
            try
            {
                vt.Insert($@"
                    INSERT INTO tbl_kiralama
                    (
                        arac_id,
                        musteri_id,
                        personel_id,
                        kiralama_tarihi,
                        beklenen_teslim,
                        teslim_tarihi,
                        toplam_fiyat,
                        kiralamaDurum_id,
                        adres_id,
                        alis_km,
                        teslim_km,
                        kiralamaAciklama,
                        evrak_id,
                        hasar_id
                    )
                    VALUES
                    (
                        {cmb_plaka.SelectedValue},
                        {cmb_musteri.SelectedValue},
                        {cmb_personel.SelectedValue},
                        '{dtp_kiralamaTarihi.Value:yyyy-MM-dd}',
                        '{dtp_beklenenTeslimTarihi.Value:yyyy-MM-dd}',
                        NULL,
                        {toplamFiyat},
                        {cmb_kiralamaDurum.SelectedValue},
                        {cmb_Adres.SelectedValue},
                        {alisKm},
                        {teslimKm},
                        '{txt_kiralamaAciklama.Text.Replace("'", "''")}',
                         {cmb_senet.SelectedValue},
                            {cmb_HasarAciklama.SelectedValue})");

                MessageBox.Show("Araç Kiralama Kaydı Başarıyla Tamamlandı");
                tbpg_aracKirala_Enter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralama sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void btn_aracKiralamaSil_Click(object sender, EventArgs e)
        {
            if (dgv_aracKiralamaIslemi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçiniz.");
                return;
            }

            int kiralamaId = Convert.ToInt32(dgv_aracKiralamaIslemi.SelectedRows[0].Cells["kiralama_id"].Value);

            DialogResult dr = MessageBox.Show(
                "Seçili kiralama kaydı silinecek. Emin misiniz?","Silme Onayı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (dr == DialogResult.No)
                return;

            try
            {
                // Önce hasar varsa sil (LEFT JOIN kullandığın için önemli)
                vt.UpdateDelete($@"
                                    DELETE FROM tbl_aracHasar
                                    WHERE kiralama_id = {kiralamaId}
                                ");

                // Kiralama sil
                vt.UpdateDelete($@"
                                    DELETE FROM tbl_kiralama
                                    WHERE kiralama_id = {kiralamaId}
                                ");

                MessageBox.Show("Kiralama kaydı başarıyla silindi.");

                tbpg_aracKirala_Enter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void tbn_aracKiralamaGuncelle_Click(object sender, EventArgs e)
        {
            if (dgv_aracKiralamaIslemi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir kayıt seçiniz.");
                return;
            }

            int kiralamaId = Convert.ToInt32(
                dgv_aracKiralamaIslemi.SelectedRows[0].Cells["kiralama_id"].Value
            );

            // Km kontrolleri
            int alisKm, teslimKm;
            if (!int.TryParse(txt_alisKM.Text, out alisKm) ||
                !int.TryParse(txt_teslimKilometresi.Text, out teslimKm))
            {
                MessageBox.Show("Kilometreler tam sayı olmalıdır.");
                return;
            }

            if (teslimKm < alisKm)
            {
                MessageBox.Show("Teslim km, alış km'den küçük olamaz.");
                return;
            }
            double toplamFiyat;
            if (!double.TryParse(
                txt_toplamFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out toplamFiyat))
            {
                MessageBox.Show("Toplam fiyat geçersiz");
                return;
            }
            try
            {

                vt.UpdateDelete($@"
                                UPDATE tbl_kiralama
                                SET
                                    arac_id = {cmb_plaka.SelectedValue},
                                    musteri_id = {cmb_musteri.SelectedValue},
                                    personel_id = {cmb_personel.SelectedValue},
                                    kiralama_tarihi = '{dtp_kiralamaTarihi.Value:yyyy-MM-dd}',
                                    beklenen_teslim = '{dtp_beklenenTeslimTarihi.Value:yyyy-MM-dd}',
                                    teslim_tarihi = {(dtp_teslimTarihi.Checked
                                        ? $"'{dtp_teslimTarihi.Value:yyyy-MM-dd}'"
                                        : "NULL")},
                                    toplam_fiyat = {toplamFiyat},
                                    kiralamaDurum_id = {cmb_kiralamaDurum.SelectedValue},
                                    adres_id = {cmb_Adres.SelectedValue},
                                    alis_km = {int.Parse(txt_alisKM.Text)},
                                    teslim_km = {int.Parse(txt_teslimKilometresi.Text)},
                                    kiralamaAciklama = '{txt_kiralamaAciklama.Text.Replace("'", "''")}',
                                    evrak_id = {cmb_senet.SelectedValue}
                                WHERE kiralama_id = {kiralamaId}
                                ");

                // HASAR VARSA GÜNCELLE / YOKSA EKLE
                DataTable dtHasar = vt.Select($@"
                                                SELECT hasar_id FROM tbl_aracHasar
                                                WHERE kiralama_id = {kiralamaId}
                                            ");

                if (dtHasar.Rows.Count > 0)
                {
                    // UPDATE
                    vt.UpdateDelete($@"
                                        UPDATE tbl_aracHasar SET
                                            hasar_aciklama = '{cmb_HasarAciklama.Text.Replace("'", "''")}'
                                        WHERE kiralama_id = {kiralamaId}
                                    ");
                }
                else
                {
                    // INSERT
                    vt.Insert($@"
                            INSERT INTO tbl_aracHasar (kiralama_id, hasar_aciklama)
                            VALUES ({kiralamaId}, '{cmb_HasarAciklama.Text.Replace("'", "''")}')
                        ");
                }

                MessageBox.Show("Kiralama başarıyla güncellendi");
                tbpg_aracKirala_Enter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void btn_aracKiralamaTemizle_Click(object sender, EventArgs e)
        {
            // TEXTBOXLAR
            txt_toplamFiyat.Clear();
            txt_alisKM.Clear();
            txt_teslimKilometresi.Clear();
            txt_kiralamaAciklama.Clear();

            // COMBOBOXLAR
            cmb_plaka.SelectedIndex = -1;
            cmb_musteri.SelectedIndex = -1;
            cmb_personel.SelectedIndex = -1;
            cmb_kiralamaDurum.SelectedIndex = -1;
            cmb_Adres.SelectedIndex = -1;
            cmb_HasarAciklama.SelectedIndex = -1;
            cmb_senet.SelectedIndex = -1;

            // DATETIMEPICKER
            dtp_kiralamaTarihi.Value = DateTime.Now;
            dtp_beklenenTeslimTarihi.Value = DateTime.Now;

            // Teslim tarihi opsiyonelse (Checked kullanıyorsan)
            dtp_teslimTarihi.Checked = false;

            // DATAGRIDVIEW SEÇİMİ KALDIR
            dgv_aracKiralamaIslemi.ClearSelection();
        }

        private void frm_KiraIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.E)
                btn_aracKiralamaEkle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.S)
                btn_aracKiralamaSil_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.G)
                tbn_aracKiralamaGuncelle_Click(sender, e);
            else if (e.Alt && e.KeyCode == Keys.T)
                btn_aracKiralamaTemizle_Click(sender, e);
        }
    }
}
