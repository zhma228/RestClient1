using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //GetExample();
            //PostExample();
            GetExampleWithParams();
        }

        private static void GetExample()
        {
            HttpClient client = new HttpClient();
            var task = Task.Run(() => client.GetAsync("http://localhost:(порт из адр стр)/Cars"));


            task.Wait();
            HttpResponseMessage response = task.Result;
            string p = response.Content.ReadAsStringAsync().Result;
            Console.ReadKey();
        }
        private static void PostExample()
        {
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent("{\r\n  \"id\": 0,\r\n  \"name\": \"string\"\r\n}", Encoding.UTF8, "application/json");
            var task = Task.Run(() => client.PostAsync("http://localhost:(порт из адр стр)/Cars", httpContent));
            task.Wait();
            HttpResponseMessage response = task.Result;
            string p = response.Content.ReadAsStringAsync().Result;
            Console.ReadKey();
        }
        private static void GetExampleWithParams()
        {
            HttpClient client = new HttpClient();
            var task = Task.Run(() => client.GetAsync("http://localhost:(порт из адр стр)/Cars?param1=123&param2=345"));
            task.Wait();
            HttpResponseMessage response = task.Result;
            string p = response.Content.ReadAsStringAsync().Result;
            Console.ReadKey();
        }
    }
}
