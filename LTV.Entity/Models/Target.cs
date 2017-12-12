using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class Target: Entity
    {
        public Target()
        {
            this.Snapshots = new List<Snapshot>();
            this.Users = new List<User>();
        }

        public override long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public virtual ICollection<Snapshot> Snapshots { get; set; }
        public virtual ICollection<User> Users { get; set; }

     
        public override void CopyFrom(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
