using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;

namespace DERS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = Genel.kullanici.YetkiKayit;
        }

        private void BTN_Getir_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Genel.db.Rehber.ToList();

            dataGridView1.Columns["grdSil"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["grdGuncelle"].DisplayIndex = dataGridView1.Columns.Count - 1;

            if (Genel.kullanici.YetkiSil)
            {
                dataGridView1.Columns["grdSil"].Visible = !dataGridView1.Columns["grdSil"].Visible;
            }
            if (Genel.kullanici.YetkiGuncelle)
            {
                dataGridView1.Columns["grdGuncelle"].Visible = !dataGridView1.Columns["grdGuncelle"].Visible;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Genel.db.Rehber.Where(x => x.AdSoyad.Contains(textBox1.Text) || x.Telefon.Contains(textBox1.Text)).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ID = " + Genel.kullanici.KullaniciID.ToString() + ", " + " Kullanıcı Adınız = " + Genel.kullanici.KullaniciAdi);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmEkleGuncelle frmEkle = new frmEkleGuncelle(new Rehber());
            frmEkle.ShowDialog();

            dataGridView1.DataSource = Genel.db.Rehber.ToList();
        }
        public int guncelleID = 0;
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["grdSil"].Selected)
            {
                if (MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells["AdSoyad"].Value.ToString() + " isimli kullanıcıyı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var silinecekOge = Genel.db.Rehber.Find(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RehberID"].Value));

                    Genel.db.Rehber.Remove(silinecekOge);
                    Genel.db.SaveChanges();
                    dataGridView1.DataSource = Genel.db.Rehber.ToList();
                }
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["grdGuncelle"].Selected)
            {
                
                if (MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells["AdSoyad"].Value.ToString() + " isimli kullanıcıyı güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var Oge = Genel.db.Rehber.Find(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RehberID"].Value));

                    frmEkleGuncelle fGuncelle = new frmEkleGuncelle(Oge);
                    fGuncelle.ShowDialog();

                    dataGridView1.DataSource = Genel.db.Rehber.ToList();
                }
            }
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
