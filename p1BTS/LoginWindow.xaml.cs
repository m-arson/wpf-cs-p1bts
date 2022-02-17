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
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Diagnostics;

namespace p1BTS
{
    public partial class LoginWindow : Window
    {
        private int priv_checked;
        TextBlock errorMessage;
        private static readonly string URL = "http://192.168.1.17/rest-api/?page=";
        public LoginWindow()
        {
            InitializeComponent();
            errorMessage = (TextBlock)this.errorMsg;
        }
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void ProcessLogin(Object sender, RoutedEventArgs e)
        {
            var user = (TextBox)this.username;
            var pass = (PasswordBox)this.password;
            if(user.Text.Equals("") || pass.Password.Equals("") || priv_checked == 9) {
                errorMessage.Text = "Field are empty!";
            } else
            {
                DoChecking(user.Text, pass.Password, priv_checked);
            }
        }
        protected void setCheckedPrev(object sender, RoutedEventArgs e)
        {
            if(this.owner.IsChecked == true)
            {
                priv_checked = 1;
            } else if(this.staff.IsChecked == true)
            {
                priv_checked = 0;
            } else
            {
                priv_checked = 9;
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        public async void DoChecking(string username, string password, int pcek)
        {
            string url = "login";
            string jsonStr = JsonConvert.SerializeObject(new
            {
                username = username,
                password = password,
                is_admin = pcek
            });
            await foreach (var data in sendJsonStr(url, jsonStr))
            {
                checkResponse(data);
            }

        }
        private void checkResponse(string data)
        {
            var objc = JsonConvert.DeserializeObject<dynamic>(data);
#pragma warning disable CS8602
            if (objc.status == "success")
            {
                string token1 = (objc.token).ToString();
                string[] msg = token1.Split(".");
                byte[] data1 = Convert.FromBase64String(msg[1]);
                string decstr = Encoding.UTF8.GetString(data1);
                var objd = JsonConvert.DeserializeObject<dynamic>(decstr);
                string ppriv = objd.is_admin == 1 ? "Owner" : "Staff";
                // DataTable dt = new DataTable();
                string connection = @"Data Source=./LocalSQL.db;Version=3;New=False;Compress=True;";
                using (var cnn = new SQLiteConnection(connection))
                {
                    try
                    {
                        cnn.Execute("UPDATE tb_token SET token = @token, fullname = @fullname, username = @username, priv = @priv WHERE id = @id", new { 
                            token = token1,
                            fullname = objd.fullname,
                            username = objd.username,
                            priv = ppriv,
                            id = 1
                        });
                        try
                        {
                            /*
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                            adapter.SelectCommand = new SQLiteCommand("SELECT * FROM tb_token WHERE id = 1", cnn);
                            adapter.Fill(dt);
                            errorMessage.Text = dt.Rows[0]["fullname"].ToString();
                            */
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Close();
                        } catch(Exception e)
                        {
                            Debug.WriteLine(e.Message);
                            errorMessage.Text = "Fail Select Database!";
                        }

                    } catch(Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        errorMessage.Text = "Fail Update Database!";
                    }
                }

            } else
            {
                errorMessage.Text = objc.message;
            }
#pragma warning restore CS8602
        }
        private async IAsyncEnumerable<string> sendJsonStr(string url, string jsonStr)
        {
            using (var client = new HttpClient())
            {
                var res = await client.PostAsync(URL + url, new StringContent(jsonStr, Encoding.UTF8, "application/json"));
                var content = await res.Content.ReadAsStringAsync();
                yield return content;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
