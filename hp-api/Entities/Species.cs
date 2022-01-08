using hp_api.Interfaces;

namespace hp_api.Entities
{
    public class Species: IdNameInterface
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
