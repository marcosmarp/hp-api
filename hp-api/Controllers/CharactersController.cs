using Microsoft.AspNetCore.Mvc;
using hp_api.DTOs;
using Newtonsoft.Json;

namespace hp_api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController: ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CharactersController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet("sync")]
        public async Task<ActionResult> Get()
        {
            var httpClient = httpClientFactory.CreateClient();
            var fetchUrl = "http://127.0.0.1:5500";
            var response = await httpClient.GetAsync(fetchUrl);
            var content = await response.Content.ReadAsStringAsync();
            var charactersSyncDTO = JsonConvert.DeserializeObject<List<CharacterSyncDTO>>(content);
            
            /* Characters creation logic goes here */

            return Ok();
        }
    }
}
