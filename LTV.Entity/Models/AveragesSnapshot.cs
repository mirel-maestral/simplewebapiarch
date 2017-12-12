using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class AveragesSnapshot
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public long FKSnapshot { get; set; }
        public virtual Snapshot Snapshot { get; set; }
    }
}
