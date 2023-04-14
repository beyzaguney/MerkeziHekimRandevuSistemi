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
	public partial class FormUyeOl : DevExpress.XtraEditors.XtraForm
	{
		public FormUyeOl()
		{
			InitializeComponent();
		}
		private void TxtTCKN_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void BtnUyeOl_Click(object sender, EventArgs e)
		{
			#region Kontroller
			if (txtTCKN.Text.Length < 11 || txtTCKN.Text.Length > 11 || txtAd.Text == "" || txtSoyad.Text == "" || cbCinsiyet.Text == "" || dtpDogumTarihi.Value >= DateTime.Now.Date||txtEposta.Text=="")
			{
				MessageBox.Show("Bilgileriniz hatalıdır. Lütfen tekrar deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtCepTel.Text == "")
			{
				MessageBox.Show("'*' içeren alanların doldurulması zorunludur!");
				return;
			}
			if (txtSifre.Text.Count() > 16)
			{
				MessageBox.Show("Şifreniz en fazla 16 karakter içermelidir!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtSifre.Text != txtSifreTekrar.Text)
			{
				MessageBox.Show("Şifreler eşleşmiyor!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			bool gecerliMi = false;
			if (txtEposta.Text != "")
			{
				for (char harf = 'a'; harf <= 'z'; harf++)
				{
					if (txtEposta.Text[0] == harf)
					{
						gecerliMi = true;
						break;
					}
				}
				if (!gecerliMi || txtEposta.Text[txtEposta.Text.IndexOf('@') + 1] == '.' || txtEposta.Text[txtEposta.Text.IndexOf('@') + 1] == ' ')
				{
					MessageBox.Show("E-Posta formatı yanlış", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (txtEposta.Text != txtEpostaTekrar.Text)
				{
					MessageBox.Show("E-Posta adresleri eşleşmiyor!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (Convert.ToInt16(dtpDogumTarihi.Value.Year) < DateTime.Now.Year - 90)
				{
					MessageBox.Show("Doğum Tarihiniz Hatalı. Lütfen tekrar deneyin.");
					return;
				}
			}
			#endregion
			string sorguu = "select * from Kullanicilar where TCKimlikNo=@TCKN";
			SqlParametresi parametre = new SqlParametresi("@TCKN", txtTCKN.Text);
			Response res = FormGiris.sql.SelectIslemi(sorguu, parametre);
			if (res.tablo.Rows.Count == 0)
			{
				string sorgu = "exec sp_KisiEkle @TCKimlik,@Sifre,@Eposta,@CepTel,@Ad,@Soyad,@Cinsiyet,@DogumTarihi,@DogumYeri,@AnneAdi,@BabaAdi";
				SqlParametresi[] parametreler =
				{
					new SqlParametresi("@TCKimlik", txtTCKN.Text),
					new SqlParametresi("@Sifre", txtSifre.Text),
					new SqlParametresi("@Eposta", txtEposta.Text),
					new SqlParametresi("@CepTel", txtCepTel.Text),
					new SqlParametresi("@Ad", txtAd.Text),
					new SqlParametresi("@Soyad", txtSoyad.Text),
					new SqlParametresi("@Cinsiyet", cbCinsiyet.Text),
					new SqlParametresi("@DogumTarihi", dtpDogumTarihi.Text),
					new SqlParametresi("@DogumYeri", txtDogumYeri.Text),
					new SqlParametresi("@AnneAdi", txtAnneAdi.Text),
					new SqlParametresi("@BabaAdi", txtBabaAdi.Text)
				};
				Response response = FormGiris.sql.FizikselKomut(sorgu, parametreler);
				if (!response.HataliMi)
				{
					MessageBox.Show("Kayıt Eklendi");
					Close();
				}
				else
				{
					MessageBox.Show(response.Mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
            else
            {
                MessageBox.Show("Bu TC Kimlik numarasına sahip bir kulllanıcı zaten var!");
            }
		}
	}
}