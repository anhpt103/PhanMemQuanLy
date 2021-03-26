using System;

namespace SM.Entity.IHasTimes
{
    public interface IHasTimestamps
    {
        DateTime? Added { get; set; }
        DateTime? Modified { get; set; }
        DateTime? Deleted { get; set; }
    }
}
