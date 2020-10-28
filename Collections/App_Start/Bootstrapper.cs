using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BAL.Business;
using BAL.IBusiness;
using DAL.IRepository;
using DAL.Repository;
using MODELS;

namespace Collections.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutoFracContainer();
        }

        private static void SetAutoFracContainer()
        {
            var builder = new ContainerBuilder();
            RegisterRepositoryAssembly(builder);
            RegisterBusinessAssembly(builder);
            
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterRepositoryAssembly(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                          .Where(t => t.Name.EndsWith("Repository"))
                                          .AsImplementedInterfaces()
                                          .InstancePerRequest();
            
            builder.RegisterType<VendorRepository>().As<IVendorRepository>();
            
            //builder.RegisterType<LogRepository>().As<ILogRepository>();
            //builder.RegisterType<CalibrationReminderRepository>().As<ICalibrationReminderRepository>();
        }

        private static void RegisterBusinessAssembly(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                           .Where(t => t.Name.EndsWith("Business"))
                                           .AsImplementedInterfaces()
                                           .InstancePerRequest();
            
            builder.RegisterType<VendorBusiness>().As<IVendorBusiness>();
            
            //builder.RegisterType<AccountBusiness>().As<IAccountBusiness>();
            //builder.RegisterType<CalibrationReminderBusiness>().As<ICalibrationReminderBusiness>();

        }
        
    }
}