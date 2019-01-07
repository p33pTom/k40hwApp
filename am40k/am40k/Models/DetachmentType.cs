using SQLite;

namespace am40k
{
    [Table("DetachmentType")]
    public class DetachmentType
    {
        public DetachmentType() { }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string DetachmentCaption { get; set; }
        public int DetachmentPointsBonus { get; set; }
    }
}
