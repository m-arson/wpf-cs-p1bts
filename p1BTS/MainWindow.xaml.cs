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
using System.Data.SQLite;
using System.Data;
using Dapper;

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

            DataTable dt = new DataTable();
            string connection = @"Data Source=./LocalSQL.db;Version=3;New=False;Compress=True;";
            using (var cnn = new SQLiteConnection(connection))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                adapter.SelectCommand = new SQLiteCommand("SELECT token FROM tb_token WHERE id = 1", cnn);
                adapter.Fill(dt);
#pragma warning disable CS8602
                if (!dt.Rows[0]["token"].ToString().Equals(""))
                {
                    string url = "auth";
                    string jsonStr = JsonConvert.SerializeObject(new
                    {
                        token = dt.Rows[0]["token"].ToString()
                    });
                    await foreach (var data in sendJsonStr(url, jsonStr))
                    {
                        var objc = JsonConvert.DeserializeObject<dynamic>(data);
                        if (objc.status == "success")
                        {
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Close();
                        } else
                        {
                            cnn.Execute("UPDATE tb_token SET token = @token, fullname = @fullname, username = @username, priv = @priv WHERE id = @id", new
                            {
                                token = "",
                                fullname = "",
                                username = "",
                                priv = "",
                                id = 1
                            });
                            LoginWindow login = new LoginWindow();
                            login.Show();
                            this.Close();
                        }
                    }
                } else
                {
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();
                }
#pragma warning restore CS8602
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
