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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        const int ProductCode = 1;
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProductID.Text = ComputerInfo.GetComputerId();
            KeyManager Km = new KeyManager(lblProductID.Text);
            LicenseInfo lic = new LicenseInfo();
            int value = Km.LoadSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), ref lic);
            string prodductKey = lic.ProductKey;
            if(Km.ValidKey(ref prodductKey))
            {
                KeyValuesClass Kv = new KeyValuesClass();
                if(Km.DisassembleKey(prodductKey, ref Kv))
                {
                    lblProductName.Text = "XENOS";
                    lblProductKey.Text = prodductKey;
                    if (Kv.Type == LicenseType.TRIAL)
                        lblLicenseType.Text = string.Format("{0} days", (Kv.Expiration - DateTime.Now.Date).Days);
                    else lblLicenseType.Text = "Full";
                }
            }
        }
    }
}
