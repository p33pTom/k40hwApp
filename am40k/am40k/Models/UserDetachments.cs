using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace am40k
{
    [Table("UserDetachments")]
    public class UserDetachments
    {
        public UserDetachments() { }

        [PrimaryKey, AutoIncrement]
        public int DetachmentId { get; set; }
        public string DetachmentTypeId { get; set; }
        public string Name { get; set; }
        public int TotalModels { get; set; }
        public int TotalUnits { get; set; }
        public int TotalPoints { get; set; }
    }
}
