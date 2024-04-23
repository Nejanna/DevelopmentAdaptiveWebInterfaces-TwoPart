using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication6.Hubs;

namespace WebApplication6.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly IHubContext<CurrencyHub> _hubContext;

        public CurrencyService(HttpClient httpClient, IHubContext<CurrencyHub> hubContext)
        {
            _httpClient = httpClient;
            _hubContext = hubContext;
        }


        public async Task GetCurrencyAsync()
        {
            var apiUrl = "https://api.profit.com/data-api/reference/crypto?token=8a4776b28f834a04af80a4237e599936&algorithm=SHA-256&skip=0&limit=1000&symbol=BTC,ETN&available_data=historical,fundamental&exchange=CC";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject(content);
                    await _hubContext.Clients.All.SendAsync("ReceiveData", data);
                   
                }
                else
                {
                    
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


    }
    }
