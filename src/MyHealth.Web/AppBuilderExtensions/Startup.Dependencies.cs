using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyHealth.API.Validators;
using MyHealth.Data;
using MyHealth.Data.Infraestructure;
using MyHealth.Data.Repositories;
using MyHealth.Model;

namespace MyHealth.Web.AppBuilderExtensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationUsersRepository>(
                provider =>
                {
                    return new ApplicationUsersRepository(
                        provider.GetRequiredService<MyHealthContext>(),
                        provider.GetRequiredService<UserManager<ApplicationUser>>());
                });
            services.AddScoped<ApplicationUserValidators>(
                provider =>
                {
                    return new ApplicationUserValidators(
                        provider.GetRequiredService<UserManager<ApplicationUser>>());
                });
            services.AddScoped<PatientsRepository>();
            services.AddScoped<ClinicAppointmentsRepository>();
            services.AddScoped<ReportsRepository>();
            services.AddScoped<HomeAppointmentRepository>();
            services.AddScoped<MedicinesRepository>();
            services.AddScoped<TipsRepository>();
            services.AddScoped<DoctorsRepository>();
            services.AddScoped<TenantsRepository>();
            services.AddScoped<MyHealthDataInitializer>();

            return services;
        }
    }
}