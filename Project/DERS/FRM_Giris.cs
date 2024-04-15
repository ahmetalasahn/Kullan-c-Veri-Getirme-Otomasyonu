using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DERS
{
    public partial class FRM_Giris : Form
    {

        public FRM_Giris()
        {
            InitializeComponent();
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            var kullanici = Genel.db.Kullanici.Where(x => x.KullaniciAdi == txtKullaniciAdi.Text && x.Sifre== txtSifre.Text).ToList();
            if (kullanici.Count == 1)
            {
                Genel.kullanici = kullanici.First();
                MessageBox.Show("Giriş Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Parola Hatalı...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
