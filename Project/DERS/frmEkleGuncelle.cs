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
    public partial class frmEkleGuncelle : Form
    {
        Rehber rehber;
        public frmEkleGuncelle(Rehber rehber)
        {
            this.rehber = rehber;
            InitializeComponent();
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var db = Genel.db.Rehber.Where(x => x.AdSoyad == txtAdSoyad.Text && x.Telefon == txtTelefon.Text).ToList();

            if (txtAdSoyad.Text == "" || txtAdSoyad.Text == "")
            {
                MessageBox.Show("Lütfen bilgileri doldurunuz.");
                return;
            }
            if (txtAdSoyad.Text.Length > 50 && txtTelefon.Text.Length > 10)
            {
                MessageBox.Show("Karakter sınırını aştınız.");
                return;
            }
            if (db.Count > 0)
            {
                MessageBox.Show("Böyle bir karakter zaten var.");
                return;
            }
            if (MessageBox.Show("Bu Kullanıcıyı " + (rehber.RehberID == 0 ? "Eklemek" : "Güncellemek") + " İstediğinize Emin misiniz?", "Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                rehber.AdSoyad = txtAdSoyad.Text;
                rehber.Telefon = txtTelefon.Text;

                if (rehber.RehberID == 0)
                {
                    Genel.db.Rehber.Add(rehber);
                }

                Genel.db.SaveChanges();

                Close();
            }

        }

        private void frmEkleGuncelle_Load(object sender, EventArgs e)
        {
            txtAdSoyad.Text = rehber.AdSoyad;
            txtTelefon.Text = rehber.Telefon;

            btnEkle.Text = rehber.RehberID == 0 ? "EKLE" : "GÜNCELLE";

            label3.Text = rehber.RehberID == 0 ? "Kayıt Ekleme Formu" : "Kayıt Güncelleme Formu";

            groupBox1.Text = rehber.RehberID == 0 ? "Kayıt Ekle" : "Kayıt Güncelle";
        }
        
        
    }
}
