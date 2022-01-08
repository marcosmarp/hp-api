using Newtonsoft.Json;

namespace hp_api.DTOs
{

    public partial class CharacterSyncDTO
    {
        public string Name { get; set; }

        [JsonProperty("alternate_names")]
        public string[] AlternateNames { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string House { get; set; }
        public string DateOfBirth { get; set; }
        public string YearOfBirth { get; set; }
        public bool? Wizard { get; set; }
        public string Ancestry { get; set; }
        public string EyeColour { get; set; }
        public string HairColour { get; set; }
        public WandSyncDTO Wand { get; set; }
        public string Patronus { get; set; }
        public bool? HogwartsStudent { get; set; }
        public bool? HogwartsStaff { get; set; }
        public string Actor { get; set; }

        [JsonProperty("alternate_actors")]
        public string[] AlternateActors { get; set; }
        public bool? Alive { get; set; }
        public Uri Image { get; set; }
    }

    public partial class WandSyncDTO
    {
        public string Wood { get; set; }
        public string Core { get; set; }
        public float? Length { get; set; }
    }
}
