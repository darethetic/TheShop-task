using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class Service
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("https://suppliers.free.beeceptor.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<List<Supplier>> LoadSuppliers()
        {
            string Url = "https://suppliers.free.beeceptor.com/";

            using (HttpResponseMessage response = await ApiClient.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var suppliers = await response.Content.ReadAsAsync<List<Supplier>>();
                    return suppliers;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
