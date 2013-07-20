using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using AuctioNUS.Domain.Abstract;
using AuctioNUS.Domain.Concrete;
using System.Web.Routing;

namespace AuctioNUS.Domain.Controllers.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        //
        // GET: /NinjectControllerFactory/


        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // put additional bindings here
            ninjectKernel.Bind<IDealRepository>().To<EFDealRepository>();
            ninjectKernel.Bind<IBidRepository>().To<EFBidRepository>();
            ninjectKernel.Bind<IModuleRepository>().To<EFModuleRepository>();
            ninjectKernel.Bind<ISettingRepository>().To <EFSettingRepository>();
            ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}