using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ESFE.ArqLimpia.BL.Interfaces;

namespace ESFE.ArqLimpia.APIClient
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddAPIClientDependecies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(configuration["API:url"])
            });

            services.AddScoped<IUserBL, UserAPIClient>();

            return services;
        }
    }
}
