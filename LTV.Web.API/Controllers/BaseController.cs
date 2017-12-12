using LTV.Data.Models;
using LTV.Service.Interfaces;
using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;
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
using System.Web.Http.Results;

namespace LTV.Web.API.Controllers
{
    /// <summary>
    /// Base Controller with basic CRUD APIs. It can be easily used by dervied controller out of the ox
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseController<T> : ApiController  where T : class, IObjectState
    {
        private readonly IService<T> _service;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public BaseController(IService<T> service, IUnitOfWorkAsync unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all items from the repo
        /// </summary>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _service.Query().SelectAsync();

        }

       /// <summary>
       /// Get item by Id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        protected virtual async Task<IHttpActionResult> Get(long id)
        {
            var model = await _service.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

       /// <summary>
       /// Update an item
       /// </summary>
       /// <param name="id">Item id</param>
       /// <param name="model">Item model</param>
       /// <returns></returns>
        public virtual async Task<IHttpActionResult> Put(long id, T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }


            try
            {
                _unitOfWork.BeginTransaction();
                _service.Insert(model);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

         /// <summary>
         /// Create a new item
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
        public virtual async Task<IHttpActionResult> Post(T model)
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

       
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        public virtual async Task<IHttpActionResult> DeleteSnapshot(long id)
        {
            T snapshot = await _service.FindAsync(id);
            if (snapshot == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.BeginTransaction();
                await _service.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(snapshot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(long id)
        {
            return _service.Find(id) != null;
        }
    }
}
