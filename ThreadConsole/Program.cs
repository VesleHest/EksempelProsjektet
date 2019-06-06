using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreadConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            // fra: https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
            // Sjekk ut denne oversikten over tråder, task scheduler: https://cdn-images-1.medium.com/max/2000/1*JrvDmC-KS7iL2Aexb-lskA.png
            try
            {
                Console.WriteLine("Starter...");
                var result = DownloadStringV5("http://www.ba.no/");
                Console.WriteLine(result);

                Console.WriteLine("Ferdig...!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().Message);
            }
            Console.ReadKey();
                               }

        private static String DownloadStringV3(String url)
        {
            // NOT SAFE, instant deadlock when called from UI thread
            // deadlock when called from threadpool, works fine on console
            HttpClient client = CreateHttpClient();
            var request = client.GetAsync(url).Result;
            var download = request.Content.ReadAsStringAsync().Result;
            return download;
        }

        private static String DownloadStringV4(String url)
        {
            // NOT SAFE, deadlock when called from threadpool
            // works fine on UI thread or console main 
            return Task.Run(async () =>
            {
                HttpClient client = CreateHttpClient();
                var request = await client.GetAsync(url);
                var download = await request.Content.ReadAsStringAsync();
                return download;
            }).Result;
        }

        private static String DownloadStringV5(String url)
        {
            // REALLY REALLY BAD CODE,
            // guaranteed deadlock 
            return Task.Run(() =>
            {
                HttpClient client = CreateHttpClient();
                var request = client.GetAsync(url).Result;
                var download = request.Content.ReadAsStringAsync().Result;
                return download;
            }).Result;
        }

        public static HttpClient CreateHttpClient()
        {
            try
            {
                var proxy = new WebProxy()
                {
                    Address = new Uri("http://proxy.ihelse.net:3128"),
                    UseDefaultCredentials = true
                };

                var httpClientHandler = new HttpClientHandler()
                {
                    Proxy = proxy,
                };

                var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null;
        }

    }
}
