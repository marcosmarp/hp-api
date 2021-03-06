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
                .ForMember(c => c.Ancestry, options => options.MapFrom(AncestryToString))
                .ForMember(c => c.House, options => options.MapFrom(HouseToString))
                .ForMember(c => c.Gender, options => options.MapFrom(GenderToString))
                .ForMember(c => c.Patronus, options => options.MapFrom(PatronusToString));

            CreateMap<Wand, WandDTO>();
            CreateMap<WandCore, WandCoreDTO>();
            CreateMap<WandWood, WandWoodDTO>();
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
