//using BankClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Domen2Vozvrashenie;
using Domen2Vozvrashenie.Domain.Models;

namespace Domen2Vozvrashenie.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Deposit")]
    public class DepositsController : ControllerBase
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _client;

        public DepositsController(IConfiguration conf)
        {
            _dalUrl = conf.GetValue<string>("DalUrl");
            _client = new HttpClient();
        }
        [HttpGet("GetDepositByName")]
        public async Task<ActionResult<Deposit[]>> GetDeposits(string? name)
        {
            var response = await _client.GetAsync($"{_dalUrl}/Deposit?name={name}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Deposit[]>() ?? Array.Empty<Deposit>();
            if (string.IsNullOrWhiteSpace(name)) return result;
            return Array.FindAll(result, p => !string.IsNullOrWhiteSpace(p.DepositName) && p.DepositName.Contains(name));
        }
        [HttpPost]
        public async Task<ActionResult<Deposit>> PostDeposit(Deposit deposit)
        {
            JsonContent content = JsonContent.Create(deposit);
            using var result = await _client.PostAsync($"{_dalUrl}/Deposit", content);
            var dalDeposit = await result.Content.ReadFromJsonAsync<Deposit>();
            Console.WriteLine($"{dalDeposit?.DepositId}");
            if (dalDeposit == null)
                return BadRequest();
            else
                return dalDeposit;
        }
    }
}