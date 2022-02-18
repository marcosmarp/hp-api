namespace hp_api.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] AlternativeNames { get; set; }
        public Gender? Gender { get; set; }
        public House? House { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsWizard { get; set; }
        public Ancestry Ancestry { get; set; }
        public string EyeColour { get; set; }
        public string HairColour { get; set; }
        public Wand Wand { get; set; }
        public Patronus Patronus { get; set; }
        public bool IsHogwartsStudent { get; set; }
        public bool IsHogwartsStaff { get; set; }
        public string Actor { get; set; }
        public string[] AlternativeActors { get; set; }
        public bool IsAlive { get; set; }
        public Uri Image { get; set; }
    }
}

public enum Gender { Male, Female }
public enum House { Gryffindor, Slytherin, Ravenclaw, Hufflepuff }
