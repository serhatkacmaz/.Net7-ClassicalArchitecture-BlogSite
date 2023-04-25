using Autofac;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using BlogSite.Repository;
using BlogSite.Repository.Repositories;
using BlogSite.Repository.UnitOfWork;
using BlogSite.Service.Mapping;
using BlogSite.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace BlogSite.API.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BlogSite.Service.Services.Service<,>))
                .As(typeof(IService<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<TokenService>().As<ITokenService>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repositoryAssembly = Assembly.GetAssembly(typeof(BlogSiteContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MasterProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //-> InstancePerLifetimeScope => scope
            //-> InstancePerDependency => transit
        }
    }
}
