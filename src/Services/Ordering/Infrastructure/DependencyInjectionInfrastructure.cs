using Application.Contracts_Interfaces;
using Application.Model;
using Infrastructure.Data;
using Infrastructure.Mail;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure {
    public static class DependencyInjectionInfrastructure {
        public static IServiceCollection AddIfrastructureServices(this IServiceCollection services, IConfiguration config) {

            services.AddDbContext<OrderContext>(o => o.UseSqlServer(config.GetConnectionString("SqlOrders")));

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => config.GetSection("EmailSettings"));
            services.AddSingleton<IEmailService, EmailService>();

            return services;
        }
    }
}
