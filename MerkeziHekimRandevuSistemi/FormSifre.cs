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
    public partial class FormSifre : DevExpress.XtraEditors.XtraForm
    {
        public FormSifre()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            Response r = FormGiris.sql.FizikselKomut("update Kullanicilar set Sifre=@Sif where TCKimlikNo=@TC",
                                            new SqlParametresi("@Sif", txtEposta.Text),
                                            new SqlParametresi("@TC", FormSifremiUnuttum.tc));
            if (!r.HataliMi)
            {
                MessageBox.Show("Şifreniz başarıyla değiştirildi. Giriş yapabilirsiniz.");
                this.Close();
            }
            else
                MessageBox.Show(r.Mesaj);
        }
    }
}