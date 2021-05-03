using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WL.Sample.Model.Model;

namespace WL.Sample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            String apiUrl = "http://localhost:8888/api/Ad/Get";
            //String ROUTE_URI = "api/AdCenter/Get";


            //Intial HttpClient
            HttpClient httpClient = new HttpClient();
            //Set the http service uri
            httpClient.BaseAddress = new Uri(apiUrl);
            //The http service is based on JSON format
            httpClient.DefaultRequestHeaders.Accept.Add(
                   new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var msg = String.Empty;

            // Send request
            HttpResponseMessage resp = httpClient.GetAsync(apiUrl).Result;
            if (resp.IsSuccessStatusCode)
            {
                var users = resp.Content.ReadAsAsync<IEnumerable<AdUser>>().Result;
                foreach (var user in users)
                {
                    msg += String.Format("Cn : {0}，Sn : {1}，GivenName : {2}, DisplayName : {3}, Status : {4} \n",
                        user.Cn, user.Sn, user.GivenName, user.DisplayName, user.Status);
                }

            }
            else
            {
                msg = String.Format("{0} {1}", (int?)resp.StatusCode, resp.ReasonPhrase);
            }

            System.Console.WriteLine(msg);

            System.Console.ReadKey();
        }
    }
}
