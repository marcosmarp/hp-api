using hp_api.Entities;

namespace hp_api.DTOs
{
    public class CharacterDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
        public Uri Image { get; set; }
    }
}
