using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using System.Windows.Forms;
using System.IO;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Guardar(string fileName, string texto)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String link = "";
            if (!(comboBox1.Text.Contains(".")))
            {
                link = "https://www.google.com/search?q=" + comboBox1.Text;
                webView21.CoreWebView2.Navigate(link);
            }
            else
            {
                if (webView21 != null && webView21.CoreWebView2 != null)
                {
                    webView21.CoreWebView2.Navigate(comboBox1.Text);
                }
            }
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
           //webView.GoHome();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoForward();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                string fileName = "Hola";

                
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                
                {
                    comboBox1.Items.Add(reader.ReadLine());
                }
                
                reader.Close();
          
        }
    }
}
