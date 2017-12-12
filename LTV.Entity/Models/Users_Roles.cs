using System;
using System.Collections.Generic;

namespace LTV.Data.Models
{
    public partial class Users_Roles
    {
        public long Id { get; set; }
        public long FKUser { get; set; }
        public long FKRole { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
