using SQLite;

namespace am40k
{
    [Table("Roster")]
    public class Roster
    {
        public Roster() { }

        [PrimaryKey, AutoIncrement]
        public int RosterId { get; set; }
        public int DetachId { get; set; }
        public int TotalModels { get; set; }
        public int TotalPoints { get; set; }
    }
}
