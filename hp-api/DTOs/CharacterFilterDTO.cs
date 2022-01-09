namespace hp_api.DTOs
{
    public class CharacterFilterDTO
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string house { get; set; }
        public bool? isWizard { get; set; }
        public bool? isHogwartsStudent { get; set; }
        public bool? isHogwartsStaff { get; set; }
        public bool? isAlive { get; set; }
    }
}
