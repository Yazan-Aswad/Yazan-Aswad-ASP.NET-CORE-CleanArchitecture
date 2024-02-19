using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastacture.Abstracts;
using SchoolProject.Infrastacture.Repositories;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using SchoolProject.Service.Implementations;
using System;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            return services;

        }


    }
}
