using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class AncillaryReferencesSnapshot
    {
        public long Id { get; set; }
        public string AncillaryName { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
        public bool HasTheAncillary { get; set; }
        public decimal LTPPre { get; set; }
        public bool AdditionPossible { get; set; }
        public decimal LTPPost { get; set; }
        public long FKSnapshot { get; set; }
        public virtual Snapshot Snapshot { get; set; }
    }
}
