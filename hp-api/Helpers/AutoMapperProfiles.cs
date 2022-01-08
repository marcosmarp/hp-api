using AutoMapper;
using hp_api.DTOs;
using hp_api.Entities;

namespace hp_api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, CharacterDTO>();
        }
    }
}
