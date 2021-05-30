using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.App.Contracts.Infrastructure;
using Ordering.App.Contracts.Persistence;
using Ordering.App.Model;
using Ordering.infrastructure.Mail;
using Ordering.infrastructure.Persistence;
using Ordering.infrastructure.Repositories;

namespace Ordering.infrastructure {
    public static class infrastractureServiceRegestration {
        public static IServiceCollection AddInfrastractureService(this IServiceCollection service, IConfiguration config) {

            service.AddDbContext<OrderContext>(op => op.UseSqlServer(config.GetConnectionString("Sql")));

            service.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            service.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

            service.Configure<EmailSettings>(s => config.GetSection("EmailSettings"));

            service.AddSingleton<IEmailService, EmailService>();

            return service;
        }
    }
}
