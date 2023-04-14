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

namespace MerkeziHekimRandevuSistemi
{
    public partial class FormKod : DevExpress.XtraEditors.XtraForm
    {
        public FormKod()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if(MailGonder.kod==txtKod.Text)
            {
                this.Close();
                FormSifre frm = new FormSifre();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kodlar eşleşmiyor.");
                return;
            }
        }
    }
}