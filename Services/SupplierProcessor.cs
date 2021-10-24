using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheShop.service;
using TheShop;

namespace Services
{
    public class SupplierProcessor
    {
        public async Task<Supplier> LoadSuppliers()
        {
            string Url = "";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Supplier supplier = await response.Content.ReadAsAsync<Supplier>();
                    return supplier;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
