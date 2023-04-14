using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SqlIslemleriKutuphanesi;

namespace MerkeziHekimRandevuSistemi
{
    public partial class FormAnaSayfa : DevExpress.XtraBars.TabForm
    {
        static int secilenDoktor;
        static string randevuTarihi;
        public FormAnaSayfa()
        {
            InitializeComponent();
            dtpRandevuTarihi.MinDate = DateTime.Now.AddDays(1);
            dtpRandevuTarihi.MaxDate = DateTime.Now.AddMonths(3);
            Response cvp = FormGiris.sql.SelectIslemi("select * from Iller");
            cbiller.DataSource = cvp.tablo;
            cbiller.DisplayMember = "ilAdi";
            cbiller.ValueMember = "ilID";
            cbiller.SelectedIndex = -1;
            cbilceler.SelectedIndex = -1;
            cbHastane.SelectedIndex = -1;
            cbKlinik.SelectedIndex = -1;
            tabPane1.Visible = false;
            GecmisRandevular();

        }

        private void Cbiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response response = FormGiris.sql.SelectIslemi("select * from Ilceler where ilID=@ilID", new SqlParametresi("@ilID", cbiller.SelectedValue));
            cbilceler.DataSource = response.tablo;
            cbilceler.DisplayMember = "ilceAdi";
            cbilceler.ValueMember = "ilceID";
            cbilceler.SelectedIndex = -1;
            cbHastane.SelectedIndex = -1;
            cbKlinik.SelectedIndex = -1;
            cbilceler.Enabled = true;
        }

        private void Cbilceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response res = FormGiris.sql.SelectIslemi("select distinct * from Hastaneler where ilceID=@ilceID", new SqlParametresi("@ilceID", cbilceler.SelectedValue));
            cbHastane.DataSource = res.tablo;
            cbHastane.DisplayMember = "HastaneAdi";
            cbHastane.ValueMember = "HastaneID";
            cbHastane.SelectedIndex = -1;
            cbKlinik.SelectedIndex = -1;
            cbHastane.Enabled = true;
        }

        private void CbHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response res = FormGiris.sql.SelectIslemi("select * from HastaneKlinik where HastaneID=@HastaneID", new SqlParametresi("@HastaneID", cbHastane.SelectedValue));
            cbKlinik.DataSource = res.tablo;
            cbKlinik.DisplayMember = "KlinikAdi";
            cbKlinik.ValueMember = "KlinikID";
            cbKlinik.SelectedIndex = -1;
            cbKlinik.Enabled = true;
        }

        private void BtnRandevuAra_Click(object sender, EventArgs e)
        {
            if (cbiller.Text == "" || cbilceler.Text == "" || cbHastane.Text == "" || cbKlinik.Text == "")
            {
                MessageBox.Show("Lütfen Seçimlerinizi Yapınız!");
                return;
            }
            else if (!dtpRandevuTarihi.Text.Contains("Pazartesi"))
            {
                if (dtpRandevuTarihi.Text.Contains("Pazar") || dtpRandevuTarihi.Text.Contains("Cumartesi"))
                {
                    MessageBox.Show("Lütfen haftaiçi bir gün seçiniz! ");
                    return;
                }
            }
            RandevuAra();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            dtpRandevuTarihi.Value = DateTime.Now.AddDays(1);
            cbiller.SelectedIndex = -1;
            cbilceler.SelectedIndex = -1;
            cbHastane.SelectedIndex = -1;
            cbKlinik.SelectedIndex = -1;
        }
        private void DgvRandevu_DoubleClick(object sender, EventArgs e)
        {
            RefreshSaat();
            tabPane1.Visible = true;
        }
        void RandevuAra()
        {
            tabPane1.Visible = false;
            Response res = FormGiris.sql.SelectIslemi("exec RandevuAra @KlinikID,@HastaneID",
            new SqlParametresi("@KlinikID", cbKlinik.SelectedValue),
            new SqlParametresi("@HastaneID", cbHastane.SelectedValue));
            dgvRandevular.DataSource = res.tablo;
            dgvRandevu.Columns["DoktorID"].Visible = false;
            dgvRandevu.Columns["KlinikID"].Visible = false;
            dgvRandevu.Columns["HastaneID"].Visible = false;
        }
        void SaatClick(object sender, EventArgs e)
        {
            SqlParametresi[] parametre =
            {
                new SqlParametresi("@KlinikID", cbKlinik.SelectedValue),
                new SqlParametresi("@TCKN", FormGiris.AktifKullaniciID),
                new SqlParametresi("@Tarih", randevuTarihi)
            };
            Response tbl = FormGiris.sql.SelectIslemi("exec sp_RandevuKontrol @KlinikID,@TCKN,@Tarih", parametre);
            if (tbl.tablo.Rows.Count == 0)
            {
                string tiklanan = (sender as SimpleButton).Text;
                DialogResult cevap = MessageBox.Show(tiklanan + " saatine randevu almak istediğinize emin misiniz?", "Randevu Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    string sorgu = "insert into Randevular(Tarih,Saat,DoktorID,HastaTC) values(@Tarih,@Saat,@DoktorID,@HastaTC)";
                    SqlParametresi[] parametreler =
                    {
                    new SqlParametresi("@Tarih",dtpRandevuTarihi.Value),
                    new SqlParametresi("@Saat",tiklanan),
                    new SqlParametresi("@DoktorID",secilenDoktor),
                    new SqlParametresi("HastaTC",FormGiris.AktifKullaniciID)
                    };
                    Response res = FormGiris.sql.FizikselKomut(sorgu, parametreler);
                    if (res.HataliMi)
                    {
                        MessageBox.Show(res.Mesaj);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Randevunuz Alındı. Kesbiş Olsun Ne Oltu");
                        RefreshSaat();
                        GecmisRandevular();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bir tarih için aynı klinikten iki kez randevu alamazsınız!", "HATA");
            }
        }
        void RefreshSaat()
        {
            ButonlarıAktifYap();
            randevuTarihi = dtpRandevuTarihi.Value.Year + "-" + dtpRandevuTarihi.Value.Month + "-" + dtpRandevuTarihi.Value.Day;
            Page1.PageText = dtpRandevuTarihi.Text;
            secilenDoktor = (int)dgvRandevu.GetFocusedRowCellValue("DoktorID");
            gbSaatler.Text = string.Format(dgvRandevu.GetFocusedRowCellValue("Hekim").ToString() + " için randevu saatleri");
            Response res = FormGiris.sql.SelectIslemi("select * from Randevular where DoktorID=@DoktorID and Tarih=@Tarih",
                new SqlParametresi("@DoktorID", secilenDoktor),
                new SqlParametresi("@Tarih", randevuTarihi));
            for (int i = 0; i < res.tablo.Rows.Count; i++)
            {
                foreach (var item in gbSaatler.Controls)
                {
                    if (item is SimpleButton)
                    {
                        if ((item as SimpleButton).Text == res.tablo.Rows[i]["Saat"].ToString())
                        {
                            (item as SimpleButton).Enabled = false;
                            (item as SimpleButton).Appearance.BackColor = Color.Firebrick;
                            (item as SimpleButton).ForeColor = Color.White;
                        }
                    }
                }
            }
        }
        void ButonlarıAktifYap()
        {
            foreach (var item in gbSaatler.Controls)
            {
                if (item is SimpleButton)
                {
                    (item as SimpleButton).Appearance.BackColor = Color.ForestGreen;
                    (item as SimpleButton).Enabled = true;
                }
            }
        }

        private void FormAnaSayfa_Load(object sender, EventArgs e)
        {
            HesapBilgileri();
        }
        void GecmisRandevular()
        {
            Response res = FormGiris.sql.SelectIslemi(@"select RandevuID, HastaTC as [T.C Kimlik No], Tarih, Saat, DoktorAdSoyadi as Doktor, KlinikAdi as Klinik from Randevular r 
                                                        left join Doktorlar d on d.DoktorID=r.DoktorID
                                                        left join Klinikler k on k.KlinikID=d.KlinikID where HastaTC=@TC", new SqlParametresi("@TC", FormGiris.AktifKullaniciID));
            dgvRandevuGec.DataSource = res.tablo;
            dgvGecmisRandevular.Columns["RandevuID"].Visible = false;
        }
        void HesapBilgileri()
        {
            Response res = FormGiris.sql.SelectIslemi(@"select * from Kullanicilar k 
                                                    left join KullaniciBilgileri kb on kb.TCKimlik=k.TCKimlikNo where k.TCKimlikNo=@TC", new SqlParametresi("@TC", FormGiris.AktifKullaniciID));
            txtTCKN.Text = res.tablo.Rows[0]["TCKimlik"].ToString();
            txtAd.Text = res.tablo.Rows[0]["Ad"].ToString();
            txtSoyad.Text = res.tablo.Rows[0]["Soyad"].ToString();
            txtCinsiyet.Text = res.tablo.Rows[0]["Cinsiyet"].ToString();
            txtDogumTarihi.Text = res.tablo.Rows[0]["DogumTarihi"].ToString().Substring(0, 10);
            txtDogumYeri.Text = res.tablo.Rows[0]["DogumYeri"].ToString();
            txtAnneAdi.Text = res.tablo.Rows[0]["AnneAdi"].ToString();
            txtBabaAdi.Text = res.tablo.Rows[0]["BabaAdi"].ToString();
            txtCepTel.Text = res.tablo.Rows[0]["CepTel"].ToString();
            txtEposta.Text = res.tablo.Rows[0]["Eposta"].ToString();
            txtSifre.Text = res.tablo.Rows[0]["Sifre"].ToString();
            txtSifreTekrar.Text = res.tablo.Rows[0]["Sifre"].ToString();

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor!");
                return;
            }
            Response rs = FormGiris.sql.FizikselKomut("update Kullanicilar set CepTel=@Ceptel, SabitTel=@Sabit, Eposta=@Epost, Sifre=@Sif where TCKimlikNo=@TC",
                                        new SqlParametresi("@Ceptel", txtCepTel.Text),
                                        new SqlParametresi("@Epost", txtEposta.Text),
                                        new SqlParametresi("@Sif", txtSifre.Text),
                                        new SqlParametresi("@TC", txtTCKN.Text));
            if (rs.HataliMi)
            {
                MessageBox.Show(rs.Mesaj);
                return;
            }
            else
                MessageBox.Show("Bilgileriniz Güncellendi");
        }

        private void SimpleButton16_Click(object sender, EventArgs e)
        {
            DateTime rt = (DateTime)dgvGecmisRandevular.GetFocusedRowCellValue("Tarih");
            if (rt <= DateTime.Now)
            {
                MessageBox.Show("Bu randevunun tarihi zaten geçmiş!");
            }
            else
            {
                DialogResult iptal = MessageBox.Show("Randevuyu iptal etmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iptal == DialogResult.Yes)
                {
                    int secilenRandevu = (int)dgvGecmisRandevular.GetFocusedRowCellValue("RandevuID");
                    Response Res = FormGiris.sql.SelectIslemi("delete from Randevular where RandevuID=@Randevu", new SqlParametresi("@Randevu", secilenRandevu));
                    if (!Res.HataliMi)
                    {
                        MessageBox.Show("Randevunuz iptal edilmiştir.");
                        GecmisRandevular();
                    }
                    else
                    {
                        MessageBox.Show(Res.Mesaj);
                    }
                }
                else return;
            }
        }
    }
}