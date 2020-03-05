using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = args[0];
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(args[0]);

            if (responce.IsSuccessStatusCode)
            {
                var htmlContent = await responce.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z0-9-]+\\.[a-z]{2,6}",RegexOptions.IgnoreCase);

                var match = regex.Matches(htmlContent);
                foreach (var item in match)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.ReadKey();
        }


     
    }
}
