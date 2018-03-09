using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedisAutocomplete;
using WebApplication1.Models;

namespace ImporterJobConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var importTask = DoImport();
            Task.WaitAll(importTask);
            Console.WriteLine("import done.");
        }

        private static async Task DoImport()
        {
            var watch = Stopwatch.StartNew();
            var client = new HttpClient();
            var products =
                await client.GetStringAsync(
                    "https://github.com/BestBuyAPIs/open-data-set/raw/master/products.json");
            var productList = JsonConvert.DeserializeObject<List<Product>>(products,
                new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore });
            var autocompleter = new RedisAutoComplete<string>("104.198.139.9:6379");
            var namesOnlyList = productList.Select(p => p.name).Where(n=>!String.IsNullOrEmpty(n)).ToList();

            var listOfTasks = new List<Task>();
            var chunks = namesOnlyList.Chunks(250);
            foreach (var chunk in chunks)
            {
                var task = autocompleter.SetValuesAsync(chunk.ToList());
                listOfTasks.Add(task);
            }
            Task.WaitAll(listOfTasks.ToArray());
            Console.WriteLine("import done. "+namesOnlyList.Count()+" products imported. "+watch.Elapsed.ToString());
        }
    }
}
