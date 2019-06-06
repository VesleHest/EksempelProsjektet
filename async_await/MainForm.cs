using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async_await
{
    public partial class MainForm : Form
    {
        #region Helper methods
        private Label currentTest;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Status(string message)
        {
            currentTest.Text = message;
        }

        private void CurrentTest(Label control)
        {
            currentTest = control;
        }

        private void StatusRunning()
        {
            Status("Running");
        }

        private void StatusFinalized()
        {
            Status("Finalized");
        }

        #endregion


        private class HttpClient
        {
            public async Task<dynamic> GetAsync(string url)
            {
                String part1 = null;
                String part2 = null;
                await Task.WhenAll(
                    Task.Run(() => part1 = "Hi!"),
                    Task.Run(() => part2 = "Content has been moved to"),
                    Task.Delay(200)
                );
                Func<Task<String>> ReadAsStringAsync = () => Task.FromResult($"{part1} {part2} <a href='{url}'>{url}</a>");
                return new { Content = new { ReadAsStringAsync } };
            }
        }

        private async Task<string> DownloadStringV1(string url)
        {
            // good code
            var request = await new HttpClient().GetAsync(url);
            var download = await request.Content.ReadAsStringAsync();
            return download;
        }

        private string DownloadStringV3(string url)
        {
            // bad code (?)
            var request = new HttpClient().GetAsync(url).Result;
            var download = request.Content.ReadAsStringAsync().Result;
            return download;
        }

        private async Task<string> DownloadStringV4(string url)
        {
            // bad code (?)
            var request = new HttpClient().GetAsync(url).Result;
            var download = await request.Content.ReadAsStringAsync();
            return download;
        }

        private String DownloadStringV5(String url)
        {
            // REALLY REALLY BAD CODE,
            // guaranteed deadlock 
            return Task.Run(() => {
                var request = new HttpClient().GetAsync(url).Result;
                var download = request.Content.ReadAsStringAsync().Result;
                return download;
            }).Result;
        }

        public object GetSqlConnString(RubrikkUser user, RubrikkDb db)
        {
            // deadlock if called from threadpool, 
            // works fine on UI thread, works fine from console main 
            return Task.Run(() =>
                GetSqlConnStringAsync(user, db)).Result;
        }

        private async Task<object> GetSqlConnStringAsync(RubrikkUser user, RubrikkDb db)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\INST; Integrated Security=SSPI");
            await conn.OpenAsync();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 'test'";
            return cmd.ExecuteScalarAsync();
        }

        private async void btnDownloadStringV1_Click(object sender, EventArgs e)
        {
            CurrentTest(lblDownloadStringV1);
            StatusRunning();
            string ret = await DownloadStringV1("http://www.google.com");
            edOutput.Text = ret;
            StatusFinalized();
        }

        private void btnDownloadStringV2_Click(object sender, EventArgs e)
        {
            CurrentTest(lblDownloadStringV3);
            StatusRunning();
            string ret = DownloadStringV3("http://www.google.com");
            edOutput.Text = ret;
            StatusFinalized();
        }

        private void btnDownloadStringV5_Click(object sender, EventArgs e)
        {
            CurrentTest(lblDownloadStringV5);
            StatusRunning();
            string ret = DownloadStringV5("http://www.google.com");
            edOutput.Text = ret;
            StatusFinalized();
        }

        private void btnAsyncConnection1_Click(object sender, EventArgs e)
        {
            CurrentTest(lblAsyncConnection1);
            StatusRunning();
            object ret = GetSqlConnString(new RubrikkUser(), new RubrikkDb());
            edOutput.Text = ret.ToString();
            StatusFinalized();
        }
    }
}
