using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaceTrack.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack
{
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
            {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                    configuration.GetConnectionString("DbDefaultConnection")));        

            return services;
            }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            return services;
        }

    }

}
