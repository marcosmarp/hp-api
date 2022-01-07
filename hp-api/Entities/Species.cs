namespace hp_api.Entities
{
    public class Species
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}
