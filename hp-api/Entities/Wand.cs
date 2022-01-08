namespace hp_api.Entities
{
    public class Wand
    {
        public Guid Id { get; set; }
        public WandWood Wood { get; set; }
        public WandCore Core { get; set; }
        public float? Length { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
