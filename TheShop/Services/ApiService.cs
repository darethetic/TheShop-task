using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TheShop.Dtos;

namespace TheShop
{
    class ApiService
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();            
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<List<SupplierDto>> LoadSuppliers()
        {
            string Url = "https://suppliers-task.free.beeceptor.com/";

            using (HttpResponseMessage response = await ApiClient.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var suppliers = await response.Content.ReadAsAsync<List<SupplierDto>>();
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
