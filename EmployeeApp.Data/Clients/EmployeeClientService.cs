using EmployeeApp.Data;
using EmployeeApp.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeApp.Services.Clients
{
    public class EmployeeClientService
    {
        private readonly HttpClient _httpClient;

        public EmployeeClientService(HttpClient httpClient, IUrls urls)
        {
            httpClient.BaseAddress = new Uri(urls.EmployeeDataEndpoint);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetAll()
        {
            var response = await _httpClient.GetAsync("Employees");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Trying to access the data repository yielded the following status: {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Employee>>(responseString);

            return result;
        }
    }
}