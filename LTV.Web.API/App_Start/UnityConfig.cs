using LTV.Data.Models;
using LTV.Service;
using LTV.Service.Interfaces;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System.Web.Http;
using Unity.WebApi;

namespace LTV.Web.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDataContextAsync, ExtremityLTVDatabaseContext>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IRepositoryAsync<Snapshot>, Repository<Snapshot>>(new PerRequestLifetimeManager());
            container.RegisterType<ISnapshotService, SnapshotService>(new PerRequestLifetimeManager());
            //container.RegisterType <IService<Snapshot>, Service<Snapshot>>(new PerRequestLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}