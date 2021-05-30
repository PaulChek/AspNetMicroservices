using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.App.Contracts.Persistence;
using System.Reflection;

namespace Ordering.App {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
