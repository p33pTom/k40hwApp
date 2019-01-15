using SQLite;

namespace am40k
{
    [Table("DetachmentsTypes")]
    public class DetachmentsTypes
    {
        public DetachmentsTypes() { }
        [PrimaryKey, AutoIncrement]
        public int DetachmentTypeId { get; set; }
        [NotNull]
        public string DetachmentTypeCaption { get; set; }
        public int DetachmentPointsBonus { get; set; }
    }
}
