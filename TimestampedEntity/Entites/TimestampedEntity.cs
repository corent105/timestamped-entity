using System;

namespace ImproveYourDotnetStyle.Entites
{
    public abstract class TimestampedEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}