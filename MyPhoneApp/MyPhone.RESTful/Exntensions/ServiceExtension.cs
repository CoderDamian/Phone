using Microsoft.EntityFrameworkCore;
using MyPhone.ApplicationService.Contracts;
using MyPhone.ApplicationService.Mappings;
using MyPhone.ApplicationService.Services;
using MyPhone.Domain.Contracts;
using MyPhone.Persistence.Contracts;
using MyPhone.Persistence.Data;
using MyPhone.Persistence.Repositories;

namespace MyPhone.RESTful.Exntensions
{
    public static class ServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPhoneService, PhoneService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PersonProfile));
            services.AddAutoMapper(typeof(PhoneProfile));
        }

        public static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Oracle"];

            services.AddDbContext<MyDBContext>(opt => opt.UseOracle(connectionString));
        }
    }
}
