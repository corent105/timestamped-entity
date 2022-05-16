using System;

namespace TimestampedEntity.Entities
{
    public abstract class TimestampedEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}