using SQLite;

namespace am40k
{
    [Table("Unit")]
    public class Unit
    {       
        public Unit() { }

        [PrimaryKey, AutoIncrement]
        public int UnitId { get; set; }
        public int UnitArmyId { get; set; }

        public string UnitShortName { get; set; }
        public string UnitCaption { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
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

        public bool Psyker { get; set; }
    }
}
