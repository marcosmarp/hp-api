namespace hp_api.Entities
{
    public class Ancestry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}
