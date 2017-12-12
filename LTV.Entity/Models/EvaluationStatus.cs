using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class EvaluationStatus
    {
        public EvaluationStatus()
        {
            this.Snapshots = new List<Snapshot>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Snapshot> Snapshots { get; set; }
    }
}
