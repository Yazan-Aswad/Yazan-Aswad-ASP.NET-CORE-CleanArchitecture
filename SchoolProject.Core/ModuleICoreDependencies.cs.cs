using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleICoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            #region Configuration of MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            #endregion


            #region Configuration Of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
