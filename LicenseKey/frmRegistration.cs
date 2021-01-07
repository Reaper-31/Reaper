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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        const int ProductCode = 1;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KeyManager Km = new KeyManager(txtProductID.Text);
            string productKey = txtProductKey.Text;
            if(Km.ValidKey(ref productKey))
            {
                KeyValuesClass Kv = new KeyValuesClass();
                if (Km.DisassembleKey(productKey, ref Kv))
                {
                    LicenseInfo Lic = new LicenseInfo();
                    Lic.ProductKey = productKey;
                    Lic.FullName = "XENOS";
                    if (Kv.Type == LicenseType.TRIAL)
                    {
                        Lic.Day = Kv.Expiration.Day;
                        Lic.Month = Kv.Expiration.Month;
                        Lic.Year = Kv.Expiration.Year;
                    }
                    Km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), Lic);
                    MessageBox.Show("Successfully registered.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
           
            }
            else
                MessageBox.Show("Your product key is invalid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            txtProductID.Text = ComputerInfo.GetComputerId();

        }
    }
}
