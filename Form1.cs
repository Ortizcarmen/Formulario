using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text.ToString();
            if (!(url.Contains("http")))
            {
                url = "http://" + url;
            }
            webBrowser1.Navigate(new Uri(url));
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void irToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
    }
}
