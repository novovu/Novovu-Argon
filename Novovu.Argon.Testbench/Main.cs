using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGX11;
namespace Novovu.Argon.Testbench
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeChromium();
        }
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://novovu.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        public ChromiumWebBrowser chromeBrowser;
        private async Task Form1_Load(object sender, EventArgs e)
        {
            Composition1 comp = new Composition1("Novovu is my name");
            bool americaIsGreat = await comp.makeAmericaGreat<bool>(true, "Donald Trump");
            
        }

       
    }
}
