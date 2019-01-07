using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace am40k
{
    [Table("RosterData")]
    public class RosterData
    {
        public RosterData() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int RosterId { get; set; }
        public string Unit { get; set; }
    }
}
