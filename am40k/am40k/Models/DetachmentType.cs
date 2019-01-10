using SQLite;

namespace am40k
{
    [Table("DetachmentType")]
    public class DetachmentType
    {
        public DetachmentType() { }
        [PrimaryKey, AutoIncrement]
        public int DetachmentTypeId { get; set; }
        [NotNull]
        public string DetachmentTypeCaption { get; set; }
        public int DetachmentPointsBonus { get; set; }
    }
}
