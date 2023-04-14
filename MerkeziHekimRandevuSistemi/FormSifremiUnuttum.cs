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
    public partial class FormSifremiUnuttum : DevExpress.XtraEditors.XtraForm
    {
        public FormSifremiUnuttum()
        {
            InitializeComponent();
        }
        public static string tc;
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            SqlIslemleriKutuphanesi.Response response = FormGiris.sql.SelectIslemi("select * from Kullanicilar where TcKimlikNo=@TCKN", new SqlParametresi("@TCKN", txtTCKN.Text));
            if (txtTCKN.Text.Length > 11 || txtTCKN.Text.Length < 11 || txtEposta.Text == "" || response.tablo.Rows.Count == 0)
            {
                MessageBox.Show("TC Kimlik Numarası veya Eposta Hatalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tc = txtTCKN.Text;
            MailGonder.Gonder(txtEposta.Text);
            MessageBox.Show("Kodunuz Gönderildi.");
            this.Close();
            FormKod frm = new FormKod();
            frm.Show();
        }
    }
}