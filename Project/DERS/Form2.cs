using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DERS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Regex.IsMatch(textBox1.Text, @"^[0-9]{2}503[56](([0-9][0-9][1-9])|([0-9][1-9][0-9])|([1-9][0-9][0-9]))$"))
            //    MessageBox.Show("Bilgisayar Teknolojileri Bölümünden Öğrenci");
            //else
            //    MessageBox.Show("Tanınmayan bölümden");
            //Match match = Regex.Match(textBox1.Text, @"Adı: (.+)");
            //label1.Text = match.Groups[1].Value;
            label1.Text = "";
            MatchCollection matches = Regex.Matches(textBox1.Text, @"Adı: (\w+)");
            foreach (Match item in matches)
            {
                label1.Text += item.Groups[1].Value + ", ";
            }

        }
    }
}
