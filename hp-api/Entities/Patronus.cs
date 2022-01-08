namespace hp_api.Entities
{
    public class Patronus
    {
        public Guid Id { get; set; }
        public string Animal { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
