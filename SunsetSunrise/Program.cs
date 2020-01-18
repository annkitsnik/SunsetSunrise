using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SunsetSunrise
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCategoryUrl = "https://api.sunrise-sunset.org/json?lat=59.436962&lng=24.753574&date=today";

            HttpWebRequest request = (HttpWebRequest)FtpWebRequest.Create(userCategoryUrl);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader= new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                SunMode sunMode = JsonConvert.DeserializeObject<SunMode>(response);
                Console.WriteLine(sunMode.Status);
                Console.WriteLine($"Sunrise{sunMode.Results.Sunrise}");
                Console.WriteLine($"Sunset{sunMode.Results.Sunset}");


            }
            Console.ReadLine();
        }
    }
}
