using SatlinTest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SatlinTest
{
    public class ServiceApi
    {
        private Uri uriApi;

        public ServiceApi(String urlApi)
        {
            this.uriApi = new Uri(urlApi);
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.uriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();                  
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        #region Get
        public async Task<List<User>> GetUsersAsync()
        {
            String request = "/users";
            var response = await this.CallApi<List<User>>(request);
            return response;
        }
        #endregion
    }
}
