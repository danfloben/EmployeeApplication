using EmployeeApplication.Business.Entities;
using EmployeeApplication.Business.Interface;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApplication.Business
{
    public class EmployeeServices : IEmployeeServices
    {
        string baseurl = "https://dummy.restapiexample.com/";
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await SendRequestAsync<Employee>($"api/v1/employee/{id}"); ;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await SendRequestAsync<List<Employee>>("api/v1/employees"); ;
        }
        private async Task<T> SendRequestAsync<T>(string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage httpResponse = await client.GetAsync(endpoint);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var response = await httpResponse.Content.ReadAsStringAsync();
                    var data = JObject.Parse(response)["data"].ToString();
                    return JsonConvert.DeserializeObject<T>(data);
                }

            }
            return default;
        }

    }
}