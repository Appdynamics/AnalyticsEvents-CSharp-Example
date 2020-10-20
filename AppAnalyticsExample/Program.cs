using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppAnalyticsExample
{
    class CustomAnalyticsData
    {
        public float price { get; set; }
        public int amount { get; set; }
        public string assets { get; set; }
        public DateTime order_date { get; set; }
        public int subscribers { get; set; }

    }

    class Program
    {
        static async Task Main(string[] args)
        {

            //AppD Constants

            var appd_key = "KEY";
            var appd_account_name = "AccountName";
            var app_schema = "analytics_orders";
            var analytics_endpoint = "https://fra-ana-api.saas.appdynamics.com/events/publish/";

            var custom_data = new CustomAnalyticsData();
            custom_data.price = 100;
            custom_data.amount = 80;
            custom_data.assets = "Name";
            custom_data.order_date = DateTime.UtcNow;
            custom_data.subscribers = 20;

            string output = JsonConvert.SerializeObject(custom_data);

            //var create_schema = "{\"schema\":{\"price\":\"float\",\"amount\":\"integer\",\"assets\":\"string\",\"created_at\":\"date\",\"subscribers\":\"integer\"}}";
            //var json = "[{\"price\": 800,\"amount\": 88,\"assets\": \"dd\",\"order_date\": \"2020-09-29T10:22:34+0000\",\"subscribers\": 30}]";

            var json = "[ "+ output + "]";

           // Console.WriteLine(json);
            var content_type = "application/vnd.appd.events+json";
            var data = new StringContent(json);
            data.Headers.ContentType = new MediaTypeWithQualityHeaderValue(content_type)
            {
                Parameters = { new NameValueHeaderValue("v", "2") }
            };
    
            var url = analytics_endpoint + app_schema;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Events-API-Key",appd_key);
            client.DefaultRequestHeaders.Add("X-Events-API-AccountName", appd_account_name);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content_type)
            {
                Parameters = { new NameValueHeaderValue("v", "2") }
            });

            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            string header = response.Headers.ToString();

            Console.WriteLine("########## Request Header ##########");
            Console.WriteLine(header);

            Console.WriteLine("########## Response Code ##########");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine("####################################");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully sent custom data to AppD ");
                Console.WriteLine(result);
                Console.WriteLine(json);
            }

        }
    }
}