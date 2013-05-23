using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace get_mah_versions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> vers = new List<String>();
            string URI = this.textBox1.Text;
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI,"");
            Regex file_regex = new Regex("(" + this.textBox2.Text + @")\<\/td\>\<td\>([0-9.]+)", RegexOptions.IgnoreCase);
            MatchCollection m = file_regex.Matches(HtmlResult);
            string printer = "";
            int count = 1;
            foreach (Match ma in m)
            {
                string ver = ma.Groups[2].ToString();
                if (!vers.Contains(ver))
                {
                    vers.Add(ver);
                    printer += count +") " + ver + "\r\n\r\n";
                    count++;
                }
            }
            MessageBox.Show("Found " + vers.Count + " different versions for " + this.textBox2.Text + ".\r\n\r\n" + printer);
        }
    }
}
