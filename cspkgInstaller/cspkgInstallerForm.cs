using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using cspkg;

namespace cspkgInstaller
{
    public partial class cspkgInstallerForm : Form
    {
        public string[] Args;
        public Package cspkgPackage;
        private string inPackage;

        public cspkgInstallerForm()
        {
            InitializeComponent();
            outputTextBox.Clear();
        }

        private void OutputLog(string Log)
        {
            outputTextBox.AppendText("<" + DateTime.Now.ToString("h:mm:ss") + "> " + Log + "\r\n");
        }

        private void CspkgInstallerForm_Load(object sender, EventArgs e)
        {
            if (Args.Length > 1)
                inPackage = Args[1];
            else
                inPackage = "main.cspkg";
            if (File.Exists(inPackage))
            {
                cspkgPackage = Package.GetInfoFromCspkg(inPackage);
                packageIdLabel.Text = cspkgPackage.GetPackageId();
                packageVersionLabel.Text = cspkgPackage.GetVersion();
                pathBox.Text = Path.Combine(Environment.CurrentDirectory, cspkgPackage.GetPackageId());
                Text = "Installer — " + cspkgPackage.GetPackageId() + " (" + cspkgPackage.GetVersion() + ")";
                OutputLog("Found " + inPackage + ", ready for installation");
                if (Directory.Exists(cspkgPackage.GetPackageId()))
                    OutputLog("Package already installed, will overwrite previous installation");
                return;
            }

            MessageBox.Show("Please place main package file (main.cspkg) in the directory of this installer.\n\nInstallation cannot proceed.");
            Environment.Exit(0);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This cspkg Installer is offered as part of the cspkg project." +
                            "\n\nhttps://github.com/LoukaMB/cspkg");
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            installButton.Enabled = false;
            closeButton.Enabled = false;
            OutputLog("Installing " + cspkgPackage.GetPackageId());
            try
            {
                if (Directory.Exists(cspkgPackage.GetPackageId()))
                    Directory.Delete(cspkgPackage.GetPackageId(), true);
                Package.InstallCspkg(inPackage, cspkgPackage.GetPackageId(),
                    Path.Combine(Environment.CurrentDirectory, cspkgPackage.GetPackageId()));
                OutputLog("Installation succeeded!");
                closeButton.Enabled = true;
            }
            catch (Exception ex)
            {
                OutputLog(ex.ToString());
                OutputLog("Installation cannot proceed because of exception above");
                closeButton.Enabled = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
