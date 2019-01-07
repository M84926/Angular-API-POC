using Microsoft.Extensions.DependencyInjection;
using AngularPOC.Common;
using AngularPOC.Data.Repositories;
using AngularPOC.Data.Repositories.User;
using AngularPOC.Service.EntityService;
using AngularPOC.Service.UserService;

namespace AngularPOC
{
    internal class DependencyRegistrar
    {
        internal static void Register(IServiceCollection service)
        {
            // Repositories
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUserRepository, UserRepository>();
            
            // Unit of work
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            // services
            service.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            service.AddScoped<IUserService, UserService>();

            service.AddScoped<IHelper, Helper>();
        }
    }
}
