using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state=>
            {
                WebClient webClient = new WebClient();
                string html = webClient.DownloadString("http://www.rupeng.com");
                Thread.Sleep(5000);
                textBox1.BeginInvoke(new Action(()=> 
                {
                    textBox1.Text = html;
                }));
                
            });
            
        }
    }
}
