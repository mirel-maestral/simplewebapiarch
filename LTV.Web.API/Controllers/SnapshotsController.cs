using LTV.Data.Models;
using LTV.Service.Interfaces;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LTV.Web.API.Controllers
{

    public class SnapshotsController : BaseController<Snapshot>
    {
        private ISnapshotService _service;
        private IUnitOfWorkAsync _uow;
        public SnapshotsController(ISnapshotService service, IUnitOfWorkAsync unitOfWork) : base(service, unitOfWork)
        {
            _service = service;
            _uow = unitOfWork;
        }
    }
}
