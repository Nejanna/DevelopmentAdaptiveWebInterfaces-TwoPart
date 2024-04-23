using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebApplication6.Services;

namespace WebApplication6.Hubs
{
    public class CurrencyHub : Hub
    {
        private readonly CurrencyService _cryptoService;

        public CurrencyHub(CurrencyService cryptoService)
        {
            _cryptoService = cryptoService;
            
        }

        public async Task GetCurrency()
        {
             await _cryptoService.GetCurrencyAsync();
        }
    }
}
