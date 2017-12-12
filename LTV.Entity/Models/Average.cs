using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class Average
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Value { get; set; }
    }
}
