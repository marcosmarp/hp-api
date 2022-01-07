namespace hp_api.Entities
{
    public class Wand
    {
        public Guid Id { get; set; }
        public WandWood Wood { get; set; }
        public WandCore WandCore { get; set; }
        public float Length { get; set; }
        public Character Character { get; set; }
    }
}
