using AutoMapper;
using hp_api.DTOs;
using hp_api.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hp_api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, CharacterDTO>();
            CreateMap<Character, CharacterDetailsDTO>()
                .ForMember(c => c.BirthDate, options => options.MapFrom(DateOnlyToString))
                .ForMember(c => c.Ancestry, options => options.MapFrom(AncestryToString))
                .ForMember(c => c.House, options => options.MapFrom(HouseToString))
                .ForMember(c => c.Wand, options => options.MapFrom(WandToJson))
                .ForMember(c => c.Gender, options => options.MapFrom(GenderToString))
                .ForMember(c => c.Patronus, options => options.MapFrom(PatronusToString));
        }

        private string DateOnlyToString(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.BirthDate == null) return null;
            string dateString = character.BirthDate.ToString().Replace("/", "-");
            return dateString;
        }

        private string AncestryToString(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.Ancestry == null) return null;
            return character.Ancestry.Name;
        }

        private string HouseToString(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.House == null) return null;
            return Enum.GetName(typeof(House), character.House);
        }

        private string WandToJson(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.Wand == null) return null;
            var wandDTO = new WandDTO() { Core = character.Wand.Core.Name, Wood = character.Wand.Wood.Name, Length = character.Wand.Length };
            return JsonConvert.SerializeObject(wandDTO);
        }

        private string GenderToString(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.Gender == null) return null;
            return Enum.GetName(typeof(Gender), character.Gender); 
        }

        private string PatronusToString(Character character, CharacterDetailsDTO characterDetailsDTO)
        {
            if (character.Patronus == null) return null;
            return character.Patronus.Animal;
        }
    }
}
