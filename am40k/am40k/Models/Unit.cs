using SQLite;

namespace am40k
{
    [Table("Unit")]
    public class Unit
    {       
        public Unit() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int RosterId { get; set; }

        [Unique, NotNull]
        public string Caption { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Type { get; set; }

        public string Description { get; set; }

        //[NotNull]
        public int ModelsInUnit { get; set; }

        public int Movement { get; set; }
        public int WeaponSkill { get; set; }
        public int BallisticSkill { get; set; }
        public int Strength { get; set; }
        public int Toughness { get; set; }
        public int Wounds { get; set; }
        public int Attacks { get; set; }
        public int Leadership { get; set; }
        public int Save { get; set; }

        public int InvulnerableSave { get; set; }

        //[NotNull]
        public bool Psyker { get; set; }

        [NotNull]
        public string ArmyOf { get; set; }
    }
}
