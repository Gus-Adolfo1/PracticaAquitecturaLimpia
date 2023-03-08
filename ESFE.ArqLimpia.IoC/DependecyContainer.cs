using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESFE.ArqLimpia.DAL;
using ESFE.ArqLimpia.BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ESFE.ArqLimpia.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddESFEDependecies(this IServiceCollection services, IConfiguration configuration)
        {
             services.AddDALDependecies(configuration);
            services.AddBLDependecies();
            return services;
        }
    }
}
