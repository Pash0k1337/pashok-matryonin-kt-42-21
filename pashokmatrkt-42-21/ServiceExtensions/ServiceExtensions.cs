﻿using pashokmatrkt_42_21.Interfaces.StudentsInterfces;

namespace pashokmatrkt_42_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
