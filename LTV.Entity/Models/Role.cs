using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class Role: Entity
    {
        public Role()
        {
            this.Users_Roles = new List<Users_Roles>();
        }

       
        public override long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Users_Roles> Users_Roles { get; set; }

        public override void CopyFrom(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
