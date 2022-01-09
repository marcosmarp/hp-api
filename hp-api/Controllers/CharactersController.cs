using Microsoft.AspNetCore.Mvc;
using hp_api.DTOs;
using Newtonsoft.Json;
using hp_api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using hp_api.Interfaces;
using AutoMapper;

namespace hp_api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController: ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CharactersController(IHttpClientFactory httpClientFactory, ApplicationDbContext context, IMapper mapper)
        {
            this.httpClientFactory = httpClientFactory;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<CharacterDTO>> Get([FromQuery] CharacterFilterDTO characterFilterDTO)
        {
            var charactersQueryable = context.Characters.AsQueryable();
            charactersQueryable = ApplyFilter(charactersQueryable, characterFilterDTO);
            
            var charactersDTO = mapper.Map<List<CharacterDTO>>(charactersQueryable);
            return charactersDTO;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDetailsDTO>> Get([FromRoute] Guid id)
        {
            var characterDB = await context.Characters
                .Include(c => c.Ancestry)
                .Include(c => c.Wand)
                .ThenInclude(w => w.Wood)
                .Include(c => c.Wand)
                .ThenInclude(w => w.Core)
                .Include(c => c.Patronus)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (characterDB == null) return NotFound();

            var characterDTO = mapper.Map<CharacterDetailsDTO>(characterDB);
            return characterDTO;
        }

        [HttpGet("sync")]
        public async Task<ActionResult> Sync()
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

        private IQueryable<Character> ApplyFilter(IQueryable<Character> queryable, CharacterFilterDTO filter)
        {
            if (!String.IsNullOrEmpty(filter.name))
            {
                queryable = queryable.Where(c => c.Name.Contains(filter.name));
            }

            if (!String.IsNullOrEmpty(filter.house))
            {
                House? house;
                try
                {
                    house = (House)Enum.Parse(typeof(House), ToTitleCase(filter.house.ToLower()));
                    queryable = queryable.Where(c => c.House == house);
                }
                catch (Exception ex)
                {
                }
            }

            if (!String.IsNullOrEmpty(filter.gender))
            {
                Gender? gender;
                try
                {
                    gender = (Gender)Enum.Parse(typeof(Gender), ToTitleCase(filter.gender));
                    queryable = queryable.Where(c => c.Gender == gender);
                }
                catch (Exception ex)
                {
                }
            }

            if (filter.isHogwartsStaff != null)
            {
                queryable = queryable.Where(c => c.IsHogwartsStaff == filter.isHogwartsStaff);
            }

            if (filter.isHogwartsStudent != null)
            {
                queryable = queryable.Where(c => c.IsHogwartsStudent == filter.isHogwartsStudent);
            }

            if (filter.isAlive != null)
            {
                queryable = queryable.Where(c => c.IsAlive == filter.isAlive);
            }

            if (filter.isWizard != null)
            {
                queryable = queryable.Where(c => c.IsWizard == filter.isWizard);
            }

            return queryable;
        }
    }
}


