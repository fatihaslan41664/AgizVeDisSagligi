using AgizVeDisSagligi.Data.Context;
using AgizVeDisSagligi.Data.Reporsitories.Abstract;
using AgizVeDisSagligi.Data.Reporsitories.Concrate;
using AgizVeDisSagligi.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Data.Extentions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtention(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
