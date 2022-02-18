using hp_api.Entities;

namespace hp_api.DTOs
{
    public class CharacterDetailsDTO
    {
        public string Name { get; set; }
        public string[] AlternativeNames { get; set; }
        public string Gender { get; set; }
        public string House { get; set; }
        public string BirthDate { get; set; }
        public bool IsWizard { get; set; }
        public string Ancestry { get; set; }
        public string EyeColour { get; set; }
        public string HairColour { get; set; }
        public WandDTO Wand { get; set; }
        public string Patronus { get; set; }
        public bool IsHogwartsStudent { get; set; }
        public bool IsHogwartsStaff { get; set; }
        public string Actor { get; set; }
        public string[] AlternativeActors { get; set; }
        public bool IsAlive { get; set; }
        public Uri Image { get; set; }
    }
}
