using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2TPL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Async_Click(object sender, EventArgs e)
        {

                WebClient webClient = new WebClient();
                string html = await webClient.DownloadStringTaskAsync("https://github.com/");
             
                textBox1.Text = html;

          
        }

         void  TestWait(object sender, EventArgs e)
        {


            WebClient webClient = new WebClient();
            
            
            //这么写会卡死ui
            //string html =  webClient.DownloadStringTaskAsync("https://github.com/").Result;
            var html = webClient.DownloadStringTaskAsync("https://github.com/").GetAwaiter().GetResult();
            

            textBox1.Text = html;
        }


        private void Sync_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString("https://github.com/");

            textBox1.Text = html;
        }

        private async void MyTPL_Click(object sender, EventArgs e)
        {
            string name = await GetAuthorNameAsync3();
            textBox1.Text = name;
        }

        Task<string> GetAuthorNameAsync()
        {
            return Task.Run(()=>
            {
                Thread.Sleep(3000);
                return "dalong";
            });
        }

        async Task<string> GetAuthorNameAsync3()
        {
            await Task.Delay(3000);
            return await Task.FromResult("dalong");
        }

        async Task<string> GetAuthorNameAsync2()
        {
            HttpClient httpClient = new HttpClient();
            await httpClient.GetStringAsync("https://github.com/");
            return "dalong";
           
        }

        private async void Get_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string html= await httpClient.GetStringAsync("https://github.com/");
            textBox1.Text = html;
        }

        private async void PostForm_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues["userName"] = "admin";
            keyValues["password"] = "123";
            FormUrlEncodedContent content = new FormUrlEncodedContent(keyValues);
            var respMsg = await client.PostAsync("http://localhost:29386/Home/Login/", content);// 不要错误的调用了PutAsync，应该是PostAsync
            string msgBody = await respMsg.Content.ReadAsStringAsync();
            MessageBox.Show(respMsg.StatusCode.ToString());
            MessageBox.Show(msgBody);

        }

        private async void PostFile_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Headers.Add("UserName", "admin");
            content.Headers.Add("Password", "123");
            using (Stream stream = File.OpenRead(@"C:\Users\EYINLXI\Desktop\dalong.png"))
            {
                content.Add(new StreamContent(stream), "file", "dalong.png");
                var respMsg = await client.PostAsync("http://localhost:29386/Home/Upload/", content);
                MessageBox.Show(respMsg.RequestMessage.ToString());
                MessageBox.Show(respMsg.Headers.ToString());
                MessageBox.Show(respMsg.StatusCode.ToString());
                string msgBody = await respMsg.Content.ReadAsStringAsync();
                MessageBox.Show(msgBody);
            }
        }

        private async void PostJson_Click(object sender, EventArgs e)
        {
            string json = "{userName:'admin',password:'123'}";
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(json);
            //contentype必不可少
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var respMsg = await client.PostAsync("http://localhost:29386/Home/Login/", content);


            string msgBody = await respMsg.Content.ReadAsStringAsync();
            MessageBox.Show(respMsg.StatusCode.ToString());
            MessageBox.Show(msgBody);

        }

        private async void MyTPL2_Click(object sender, EventArgs e)
        {
            await ShowAuthorNameAsync2();
        }

        Task ShowAuthorNameAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                MessageBox.Show("dalong");
            });
        }

        async Task ShowAuthorNameAsync2()
        {
            await Task.Delay(3000);
                MessageBox.Show("dalong");
        }

        private void waitAll_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            var task1 = hc.GetStringAsync(textBox4.Text);
            var task2 = hc.GetStringAsync(textBox2.Text);
            var task3 = hc.GetStringAsync(textBox3.Text);
            Task.WaitAll(task1, task2, task3);
            label4.Text = task1.Result.Length.ToString();
            label2.Text = task2.Result.Length.ToString();
            label3.Text = task3.Result.Length.ToString();

        }

        private void AE_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient hc = new HttpClient();
                var task1 = hc.GetStringAsync(textBox4.Text);
                var task2 = hc.GetStringAsync(textBox2.Text);
                var task3 = hc.GetStringAsync(textBox3.Text);
                Task.WaitAll(task1, task2, task3);
                label4.Text = task1.Result.Length.ToString();
                label2.Text = task2.Result.Length.ToString();
                label3.Text = task3.Result.Length.ToString();
            }
            catch (AggregateException ae)
            {
                //MessageBox.Show(ae.GetBaseException().ToString());

                foreach (Exception exception in ae.InnerExceptions)
                {
                    MessageBox.Show(exception.Message);

                }


            }
        }
    }
}
