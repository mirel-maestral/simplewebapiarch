using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class AncillaryReference
    {
        public long Id { get; set; }
        public string AncillaryName { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
    }
}
