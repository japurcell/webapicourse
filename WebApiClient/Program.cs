using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApi;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array.ForEach(new[] { "xml", "json", "bson" }, type =>
            //{
            //    ReadFromService("application/" + type).Wait();
            //    Console.WriteLine();
            //});

            AddNewItem().Wait();

            Console.ReadKey();
        }

        static async Task ReadFromService(string responseType)
        {
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(responseType));

                var message = new HttpRequestMessage(HttpMethod.Get, "http://localhost:29778/api/customers/get");

                var task = await client.SendAsync(message);

                var body = await task.Content.ReadAsStringAsync();

                Console.WriteLine(body);
            }
        }

        static async Task AddNewItem()
        {
            using(var client = new HttpClient())
            {
                var baseAddress = "http://localhost:29778/api";
                var customer = JsonConvert.SerializeObject(new Customer { Name = "New Customer" });

                var message = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/customers/post")
                {
                    Content = new StringContent(customer, Encoding.UTF8, "application/json")
                };

                var batchMessage = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/$batch")
                {
                    Content = new MultipartContent("mixed")
                    {
                        new HttpMessageContent(message),
                        new HttpMessageContent(new HttpRequestMessage(HttpMethod.Get, baseAddress + "/customers/get"))
                    }
                };

                var task = await client.SendAsync(batchMessage);
                var streamProvider = await task.Content.ReadAsMultipartAsync();

                foreach(var content in streamProvider.Contents)
                {
                    var response = await content.ReadAsHttpResponseMessageAsync();

                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await response.Content.ReadAsStringAsync();

                        dynamic customers = JsonConvert.DeserializeObject(body);
                        foreach(dynamic ctx in customers)
                            Console.WriteLine(string.Format("Customer Id: {0} has name {1}", ctx.Id, ctx.Name));
                    }
                }
            }
        }
    }
}
