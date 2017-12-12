using LTV.Data.Models;
using LTV.Service.Interfaces;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTV.Service
{  

    public class SnapshotService : Service<Snapshot>, ISnapshotService
    {
        public SnapshotService(IRepositoryAsync<Snapshot> repository) : base(repository)
        {
            
        }
        
    }


}
