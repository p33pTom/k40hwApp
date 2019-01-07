using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace am40k.Models
{
    [Table("Detachment")]
    public class Detachment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string DetachmentCaption { get; set; }

        //public string UnitId { get; set; }
    }
}
