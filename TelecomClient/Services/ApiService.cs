using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TelecomClient.Models;

namespace TelecomClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri("https://localhost:7105/api/");
        }

        public async Task<List<Abonent>> GetAbonents()
        {
            var response = await _client.GetAsync("Abonents");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Abonent>>(json);
        }




        public async Task AddAbonent(Abonent abonent)
        {
            var json = JsonConvert.SerializeObject(abonent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("abonents", content);
        }

        public async Task UpdateAbonent(string lastName, Abonent abonent)
        {
            var json = JsonConvert.SerializeObject(abonent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync($"abonents/{lastName}", content);
        }

        public async Task DeleteAbonent(string lastName)
        {
            await _client.DeleteAsync($"abonents/{lastName}");
        }

       
        public async Task<List<Payment>> GetPayments()
        {
            var response = await _client.GetAsync("payments");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Payment>>(json);
        }

        public async Task AddPayment(Payment payment)
        {
            var json = JsonConvert.SerializeObject(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("payments", content);
        }

        public async Task DeletePayment(int id)
        {
            await _client.DeleteAsync($"payments/{id}");
        }
    }
}

