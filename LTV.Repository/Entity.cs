using System;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6
{
    public abstract class Entity : IObjectState
    {
        public abstract long Id
        {
            get; set;
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public abstract void CopyFrom(object obj);
    }
}