
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Domen2Vozvrashenie.Domain.Models;



namespace Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/ExistingDeposit")]
    public class ExistingDepositsController : ControllerBase
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _client;

        public ExistingDepositsController(IConfiguration conf)
        {
            _dalUrl = conf.GetValue<string>("DalUrl");
            _client = new HttpClient();
        }

        [HttpGet("ExistingDepositList")]
        public async Task<ActionResult<ExistingDeposit[]>> GetExistingDepositsByplace(string? place)
        {
            var response = await _client.GetAsync($"{_dalUrl}/ExistingDeposit?place={place}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ExistingDeposit[]>() ?? Array.Empty<ExistingDeposit>();
            if (string.IsNullOrWhiteSpace(place)) return result;
            return Array.FindAll(result, p => !string.IsNullOrWhiteSpace(p.Place) && p.Place.Contains(place));
        }
        [HttpPost]
        public async Task<ActionResult<ExistingDeposit>> PostExistingDeposit(ExistingDeposit existingdeposit)
        {
            JsonContent content = JsonContent.Create(existingdeposit);
            using var result = await _client.PostAsync($"{_dalUrl}/ExistingDeposit", content);
            var dalExistingDeposit = await result.Content.ReadFromJsonAsync<ExistingDeposit>();
            Console.WriteLine($"{dalExistingDeposit?.AgreementId}");
            if (dalExistingDeposit == null)
                return BadRequest();
            else
                return dalExistingDeposit;
        }

    }
}