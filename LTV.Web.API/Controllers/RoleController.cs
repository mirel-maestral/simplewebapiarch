using LTV.Data.Models;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace LTV.Web.API.Controllers
{
    [RoutePrefix("role")]
    public class RoleController : BaseController<Role>
    {
        private readonly IService<Role> _service;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public RoleController(IService<Role> service, IUnitOfWorkAsync unitOfWork) : base(service, unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Overriding base implementation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override async Task<IHttpActionResult> Post(Role model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.BeginTransaction();
                var modelToUpdate = await _service.FindAsync(model.Id);
                modelToUpdate.CopyFrom(model);
                _service.Update(modelToUpdate);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
    }
}
