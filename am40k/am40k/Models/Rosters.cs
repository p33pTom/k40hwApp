﻿using SQLite;

namespace am40k
{
    [Table("Rosters")]
    public class Rosters
    {
        public Rosters() { }

        [PrimaryKey, AutoIncrement]
        public int RosterId { get; set; }
        public int ArmyUnitId { get; set; }
        public int DetachmentId { get; set; }
        public string DetachmentType { get; set; }
        public int TotalModels { get; set; }
        public int TotalUnits { get; set; }
        public int TotalPoints { get; set; }
    }
}
