using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using AndDigital.Customer.Models;
using System.Configuration;
using Newtonsoft.Json;


namespace AndDigital.Customer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            CallWebAPIAsyncList().Wait();
        }

        static async Task CallWebAPIAsyncList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/Customer");
                if (response.IsSuccessStatusCode)
                {
                    var items = await response.Content.ReadAsAsync<IEnumerable<Phone>>();
                    foreach (Phone item in items)
                    {
                        Console.WriteLine($"ID : { item.ID} , Phone Name : {item.PhoneNumber} , Phone Active : {item.IsActive}");
                    }
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("internal server error");
                    Console.ReadKey();
                }

            }
        }
    }
}
