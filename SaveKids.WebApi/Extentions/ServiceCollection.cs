using SaveKids.DAL.IRepositories;
using SaveKids.DAL.Repositories;
using SaveKids.Service.Interfaces;
using SaveKids.Service.Mappers;
using SaveKids.Service.Services;

namespace SaveKids.WebApi.Extentions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IAttachmentService, AttachmentService > ();
        services.AddScoped<ICrimeService, CrimeService > ();
        services.AddScoped<ICrimeCategoryService, CrimeCategoryService > ();
        services.AddScoped<ICriminalService, CriminalService > ();
        services.AddScoped<IUserService, UserService > ();

        services.AddAutoMapper(typeof(MappingProfile));
    }
}
