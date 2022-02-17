using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace p1BTS
{
    public partial class MainWindow : Window
    {
        private static readonly string URL = "http://192.168.1.17/rest-api/?page=";
        private TextBlock ssTxt;
        public MainWindow()
        {
            InitializeComponent();
            ssTxt = (TextBlock)this.FindName("SplashScreenTxt");
            ssTxt.Text = "Initializing...";
            DoChecking();
        }
        public async void DoChecking()
        {
            await Task.Delay(2500);
            ssTxt.Text = "Checking...";
            await Task.Delay(1500);

            string url = "login";
            string jsonStr = JsonConvert.SerializeObject(new
            {
                username = "admin",
                password = "admin",
                is_admin = 1
            });
            await foreach(var data in sendJsonStr(url, jsonStr))
            {
                // Debug.WriteLine(data);
                LoginWindow login = new LoginWindow();
                login.Show();
                this.Close();
            }
            
        }
        private async IAsyncEnumerable<string> sendJsonStr(string url, string jsonStr)
        {
            using (var client = new HttpClient())
            {
                var res = await client.PostAsync(URL+url, new StringContent(jsonStr, Encoding.UTF8, "application/json"));
                var content = await res.Content.ReadAsStringAsync();
                yield return content;

            }
        }
    }
}
