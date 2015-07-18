using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace bnifty.EHealthCertificateViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void cmdZoeken_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"ehealth\keystore");
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = dlg.FileName;
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = new X509Certificate2(txtPath.Text, txtPassword.Text);
                X509Certificate2UI.DisplayCertificate(cert);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.MsgErrorReadingFile);
            }
        }
    }
}
