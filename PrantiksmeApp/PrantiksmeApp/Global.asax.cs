using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.ViewModels.ProprietorViewModels;
using PrantiksmeApp.Models.ViewModels.SalesStoreViewModels;

namespace PrantiksmeApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Source, Destination>();

                cfg.CreateMap<ProprietorCreateVm, Employee>();
                cfg.CreateMap<Employee, ProprietorDetailsVm>();

                cfg.CreateMap<SalesStoreCreateVm, SalesStore>();
            });
        }
    }
}
