using AgizVeDisSagligi.Services.Helpers;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Extensions
{
    public static class ServicesLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtention(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IGoalservices, Goalservices>();
            services.AddScoped<ISituationService, SituationServices>();
            services.AddScoped<ISuggestionService, SuggestionServices>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IPassawordHelper, PassawordHelper>();

            return services;
        }
    }
}
