using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseKey
{
    public partial class frmGenerate : Form
    {
        public frmGenerate()
        {
            InitializeComponent();
        }

        private void frmGenerate_Load(object sender, EventArgs e)
        {
            cboLicenseType.SelectedIndex = 0;
            txtProductID.Text = ComputerInfo.GetComputerId();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboLicenseType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            KeyManager Km = new KeyManager(txtProductID.Text);
            KeyValuesClass Kv;
            string productKey = String.Empty;
            if (cboLicenseType.SelectedIndex==0)
            {
                Kv = new KeyValuesClass()
                {
                    Type = LicenseType.FULL,
                    Header=Convert.ToByte(5),
                    Footer=Convert.ToByte(2),
                    ProductCode=(byte)ProductCode,
                    Edition= Edition.ENTERPRISE,
                    Version=1
                };
                if (!Km.GenerateKey(Kv, ref productKey))
                    txtProductKey.Text = "ERROR";
            }
            else
            {
                Kv = new KeyValuesClass()
                {
                    Type = LicenseType.TRIAL,
                    Header = Convert.ToByte(5),
                    Footer = Convert.ToByte(2),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1,
                    Expiration=DateTime.Now.AddDays(Convert.ToInt32(txtExperience.Text))
                };
                if (!Km.GenerateKey(Kv, ref productKey))
                    txtProductKey.Text = "ERROR";
            }
            txtProductKey.Text = productKey;
        }

        const int ProductCode = 1;
    }
}
