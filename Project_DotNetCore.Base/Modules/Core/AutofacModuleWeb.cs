using Autofac;
using MediatR;
using Project_DotNetCore.Base.Modules.Core.Data;
using System.Reflection;
using Module = Autofac.Module;

namespace Project_DotNetCore.Base.Modules.Core.Modules
{
    public class AutofacModuleWeb : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var webAssembly = Assembly.GetExecutingAssembly();
            //var repoAssembly = Assembly.GetAssembly(typeof(AdminUser));

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<NestedSet>().As<INestedSet>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(webAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(webAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();

            builder.RegisterAssemblyTypes(webAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(webAssembly)
                .Where(t => t.Name.EndsWith("Notification"))
                .InstancePerLifetimeScope();

            //builder.RegisterType<Auth>();
            //builder.RegisterType<AuthHelper>();
            //builder.RegisterType<S3Helper>();
            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            //builder.RegisterType<AjCache>();
        }
    }
}