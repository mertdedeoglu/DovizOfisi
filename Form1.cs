using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizOfisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string xmlKurlar = "https://www.tcmb.gov.tr/kurlar/today.xml";
            XmlDocument xmlDosya = new XmlDocument();
            xmlDosya.Load(xmlKurlar);

            alisEuro.Text = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexBuying").InnerXml;
            satisEuro.Text = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexSelling").InnerXml;
            alisDolar.Text = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;
            satisDolar.Text = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;

            textKur.ReadOnly = true;
        }

        private void eurSatBtn_Click(object sender, EventArgs e)
        {
            textKur.Text = alisEuro.Text;
        }

        private void eurAlBtn_Click(object sender, EventArgs e)
        {
            textKur.Text = satisEuro.Text;
        }

        private void dolarSatBtn_Click(object sender, EventArgs e)
        {
            textKur.Text = alisDolar.Text;
        }

        private void dolarAlBtn_Click(object sender, EventArgs e)
        {
            textKur.Text = satisDolar.Text;
        }

        private void textMiktar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textMiktar.Text))
            {
                textTutar.Text = string.Empty;
                return;
            }

            decimal amountTl = Convert.ToDecimal(textKur.Text) * Convert.ToDecimal(textMiktar.Text);
            textTutar.Text = amountTl.ToString();
        }
    }
}
