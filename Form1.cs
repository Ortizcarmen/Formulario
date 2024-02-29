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
        List <Url> urls = new List<Url>();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void leer()
        {
            string fileName = "historial.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while(reader.Peek() > -1)
            {
                Url url = new Url();
                url.Pagina = reader.ReadLine();
                url.Veces = Convert.ToInt32(reader.ReadLine());
                url.Fecha = Convert.ToDateTime(reader.ReadLine());

                urls.Add(url);
            }
            reader.Close();
        }

        private void Grabar (string fileName)
        {
            FileStream stream = new FileStream (fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var u in urls)
            {
                writer.WriteLine(u.Pagina);
                writer.WriteLine(u.Veces);
                writer.WriteLine(u.Fecha);
            }
            writer.Close();
        }
        private void Guardar(string fileName, string texto)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            //Cerrar el archivo
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
            string urlIngresada = comboBox1.Text;
            Url urlExiste = urls.Find(u=> u.Pagina == urlIngresada);
            if (urlExiste == null)
            {
                Url urlNueva = new Url();
                urlNueva.Pagina = urlIngresada;
                urlNueva.Veces = 1;
                urlNueva.Fecha = DateTime.Now;
                urls.Add(urlNueva);
                Grabar("historial.txt");
            }
            else
            {
                urlExiste.Veces++;
                urlExiste.Fecha = DateTime.Now;
                Grabar("historial.txt");
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
            leer();
        }

    }
 }
