using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class Snapshot: Entity
    {
        public Snapshot()
        {
            this.AncillaryReferencesSnapshots = new List<AncillaryReferencesSnapshot>();
            this.AveragesSnapshots = new List<AveragesSnapshot>();
        }

        public override long Id { get; set; }
        public long FKTarget { get; set; }
        public decimal AnnualCollections { get; set; }
        public int NumberOfDoctors { get; set; }
        public Nullable<int> NumberOfPatients { get; set; }
        public Nullable<int> NumberOfVisits { get; set; }
        public Nullable<long> FKStatus { get; set; }
        public Nullable<decimal> RevenuePerPatient { get; set; }
        public Nullable<decimal> RevenuePerVisit { get; set; }
        public decimal Profit { get; set; }
        public decimal FirstYearRevenue { get; set; }
        public decimal FirstYearProfit { get; set; }
        public long FKConfidenceLevel { get; set; }
        public virtual ICollection<AncillaryReferencesSnapshot> AncillaryReferencesSnapshots { get; set; }
        public virtual ICollection<AveragesSnapshot> AveragesSnapshots { get; set; }
        public virtual ConfidenceLevel ConfidenceLevel { get; set; }
        public virtual EvaluationStatus EvaluationStatus { get; set; }
        public virtual Target Target { get; set; }

       

        public override void CopyFrom(object obj) 
        {
            throw new NotImplementedException();
        }
    }
}
