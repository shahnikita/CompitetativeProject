using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CompitetativeProject.Core.Controllers;
using CompitetativeProject.Core.Repository;
using CompitetativeProject.DataRepository.Repository;
using CompitetativeProject.Util.GlobalUtils;


namespace CompitetativeProject.App_Start
{
    public class IocConfig
    {
        public static Autofac.IContainer RegisterDependencies()
        {
            try
            {
                var containerBuilder = new ContainerBuilder();

                /*Register all the controllers within the current assembly.*/
                containerBuilder.RegisterControllers(typeof(HomeController).Assembly);

                /*Register Libs Files Here*/
             //   containerBuilder.RegisterType<SetUpLib>().As<ISetupLib>();
          


                /*Register ObjectContexts*/
                //containerBuilder.RegisterType<BM_COTOPAXIEntity>()
                //    .As<DbContext>().InstancePerDependency();



                /*Register other dependencies.*/
                containerBuilder.RegisterGeneric(typeof(DataRepository<>))
                                .As(typeof(IDataRepository<>))
                                .InstancePerDependency();


                var container = containerBuilder.Build();
                var resolver = new AutofacDependencyResolver(container);
                DependencyResolver.SetResolver(resolver);
                return container;

            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, typeof(IocConfig));
                return null;
            }
        }
    }
}