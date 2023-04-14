using SqlIslemleriKutuphanesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace MerkeziHekimRandevuSistemi
{
	public partial class FormGiris : DevExpress.XtraEditors.XtraForm
	{
		public static MSSQL sql;
		public static string AktifKullaniciID;
		public FormGiris()
		{
			InitializeComponent();
			sql = new MSSQL("BEYZA\\BEYZA", "MerkeziHekimRandevuSistemi", OturumTipi.WindowsAuthentication);
		}
		private void BtnGiris_Click(object sender, EventArgs e)
		{
			if (txtTCKN.Text.Length > 11 || txtTCKN.Text.Length < 11 || txtSifre.Text == "")
			{
				MessageBox.Show("TC Kimlik Numarası veya Şifre Hatalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Response response = sql.SelectIslemi("select * from Kullanicilar where TCKimlikNo=@TCKimlik and Sifre=@Sifre",
				new SqlParametresi("@TCKimlik", txtTCKN.Text),
				new SqlParametresi("@Sifre", txtSifre.Text));
			if (response.tablo.Rows.Count == 0)
			{
				MessageBox.Show("Kullanıcı adı ya da şifre yanlış", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
            AktifKullaniciID = (string)response.tablo.Rows[0]["TCKimlikNo"];
            FormAnaSayfa home = new FormAnaSayfa();
			this.Hide();
			home.ShowDialog();
			this.Show();
		}
		private void TxtTCKN_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void BtnUyeOl_Click(object sender, EventArgs e)
		{
			FormUyeOl frm = new FormUyeOl();
			frm.ShowDialog();
		}

		private void LinkSifreUnuttum_Click(object sender, EventArgs e)
		{
			FormSifremiUnuttum frm = new FormSifremiUnuttum();
			frm.ShowDialog();
		}
	}
}
