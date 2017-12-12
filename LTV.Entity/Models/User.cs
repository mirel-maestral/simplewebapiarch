using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class User: Entity
    {
        public override long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<System.DateTime> LastActivityDate { get; set; }
        public Nullable<long> FKTarget { get; set; }
        public virtual Target Target { get; set; }
        public virtual Users_Roles Users_Roles { get; set; }

        public override void CopyFrom(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
