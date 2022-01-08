using Microsoft.AspNetCore.Mvc;
using hp_api.DTOs;
using Newtonsoft.Json;
using hp_api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using hp_api.Interfaces;

namespace hp_api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController: ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApplicationDbContext context;

        public CharactersController(IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            this.httpClientFactory = httpClientFactory;
            this.context = context;
        }

        [HttpGet("sync")]
        public async Task<ActionResult> Get()
        {
            var httpClient = httpClientFactory.CreateClient();
            var fetchUrl = "http://127.0.0.1:5500";
            var response = await httpClient.GetAsync(fetchUrl);
            var content = await response.Content.ReadAsStringAsync();
            var charactersSyncDTO = JsonConvert.DeserializeObject<List<CharacterSyncDTO>>(content);
            
            foreach (var characterSyncDTO in charactersSyncDTO)
            {
                if ((await context.Characters.FirstOrDefaultAsync(x => x.Name.ToLower() == characterSyncDTO.Name.ToLower()) != null))
                {
                    continue;
                }

                var species = String.IsNullOrEmpty(characterSyncDTO.Species) ? null : await GetOrCreateEntityObjectByName<Species>(characterSyncDTO.Species);
                Gender? gender = String.IsNullOrEmpty(characterSyncDTO.Gender) ? null : (Gender)Enum.Parse(typeof(Gender), ToTitleCase(characterSyncDTO.Gender));
                House? house = String.IsNullOrEmpty(characterSyncDTO.House) ? null : (House)Enum.Parse(typeof(House), ToTitleCase(characterSyncDTO.House));
                DateOnly? birthdate = String.IsNullOrEmpty(characterSyncDTO.DateOfBirth) ? null : DateOnly.FromDateTime(Convert.ToDateTime(characterSyncDTO.DateOfBirth));
                var ancestry = String.IsNullOrEmpty(characterSyncDTO.Ancestry) ? null : await GetOrCreateEntityObjectByName<Ancestry>(characterSyncDTO.Ancestry);
                var wandCore = String.IsNullOrEmpty(characterSyncDTO.Wand.Core) ? null : await GetOrCreateEntityObjectByName<WandCore>(characterSyncDTO.Wand.Core);
                var wandWood = String.IsNullOrEmpty(characterSyncDTO.Wand.Wood) ? null : await GetOrCreateEntityObjectByName<WandWood>(characterSyncDTO.Wand.Wood);
                var wand = wandCore != null && wandWood != null ? new Wand() { Id = new Guid(), Core = wandCore, Wood = wandWood, Length = characterSyncDTO.Wand.Length } : null;
                var patronus = String.IsNullOrEmpty(characterSyncDTO.Patronus) ? null :new Patronus() { Id = new Guid(), Animal = ToTitleCase(characterSyncDTO.Patronus.Replace("-", " ")) };

                var character = new Character()
                {
                    Id = new Guid(),
                    Name = characterSyncDTO.Name,
                    AlternativeNames = characterSyncDTO.AlternateNames,
                    Gender = gender,
                    House = house,
                    BirthDate = birthdate,
                    IsWizard = (bool)characterSyncDTO.Wizard,
                    Ancestry = ancestry,
                    EyeColour = characterSyncDTO.EyeColour,
                    HairColour = characterSyncDTO.HairColour,
                    IsHogwartsStudent = (bool)characterSyncDTO.HogwartsStudent,
                    IsHogwartsStaff = (bool)characterSyncDTO.HogwartsStaff,
                    Actor = characterSyncDTO.Actor,
                    AlternativeActors = characterSyncDTO.AlternateActors,
                    IsAlive = (bool)characterSyncDTO.Alive,
                    Image = characterSyncDTO.Image,
                    Patronus = patronus,
                    Wand = wand
                };

                context.Add(character);

                if (ancestry != null) ancestry.Characters.Add(character);

                if (patronus != null)
                {
                    patronus.Character = character;
                    context.Add(patronus);
                }

                if (wand != null)
                {
                    wand.Character = character;
                    context.Add(wand);
                }

            }

            await context.SaveChangesAsync();

            return Ok();
        }

        private async Task<T> GetOrCreateEntityObjectByName<T>(string name) where T : class, IdNameInterface, new()
        {
            var entityObject = await context.Set<T>().FirstOrDefaultAsync(x => x.Name.ToLower() == name.Replace("-", " ").ToLower());
            if (entityObject == null)
            {
                entityObject = new T() { Id = new Guid(), Name = ToTitleCase(name.Replace("-", " ")) };
                context.Add(entityObject);
                await context.SaveChangesAsync();
            }

            return entityObject;
        }

        private string ToTitleCase(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}


