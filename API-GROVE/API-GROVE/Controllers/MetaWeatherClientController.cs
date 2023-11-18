using Microsoft.AspNetCore.Mvc;

namespace API_GROVE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaWeatherClientController : ControllerBase
    {

        private readonly HttpClient _client;

        public MetaWeatherClientController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://anapioficeandfire.com/api/characters/")
            };
        }

        [HttpGet(Name = "GetWeatherData/{characterId}")]
        public async Task<string> GetWeatherData(int characterId)
        {
            string? result = null;
            HttpResponseMessage response = await _client.GetAsync($"{characterId}/");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result ?? String.Empty;
        }
    }
}