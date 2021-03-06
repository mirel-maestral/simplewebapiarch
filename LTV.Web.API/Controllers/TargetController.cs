﻿using LTV.Data.Models;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LTV.Web.API.Controllers
{
    public class TargetController : BaseController<Target>
    {
        public TargetController(IService<Target> service, IUnitOfWorkAsync unitOfWork) : base(service, unitOfWork)
        {

        }
    }
}
