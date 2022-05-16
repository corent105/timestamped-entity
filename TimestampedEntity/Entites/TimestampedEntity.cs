using System;

namespace TimestampedEntity.Entites
{
    public abstract class TimestampedEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}