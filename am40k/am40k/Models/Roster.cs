using SQLite;

namespace am40k
{
    [Table("Roster")]
    public class Roster
    {
        public Roster() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RosterName { get; set; }
        public int Detachments { get; set; }
        public int Units { get; set; }
        public int Models { get; set; }
        public int Points { get; set; }
    }
}
