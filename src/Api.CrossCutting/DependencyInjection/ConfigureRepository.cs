using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=br894005";
            services.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
    }
}