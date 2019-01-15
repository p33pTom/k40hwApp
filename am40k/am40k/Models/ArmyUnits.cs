using SQLite;

namespace am40k
{
    [Table("ArmyUnits")]
    public class ArmyUnits
    {
        public ArmyUnits() { }
        
        [PrimaryKey, AutoIncrement]
        public int ArmyUnitId { get; set; }
        public int UnitId { get; set; }
        [Unique, NotNull]
        public string Caption { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
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
        public int InvulnerableSave { get; set; }
        public bool IsPsyker { get; set; }
        [NotNull]
        public string ArmyOf { get; set; }
    }
}
