
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Pattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }

        long Id { get; set; }

        void CopyFrom(object obj);
    }
}