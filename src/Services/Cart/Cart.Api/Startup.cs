using Cart.Api.Repository;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Cart.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            //Mass-Transit
            services.AddMassTransit(configure => configure.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(Configuration["RabbitMQ:Host"]);
            }));
            services.AddMassTransitHostedService();

            //grpc
            services.AddGrpcClient<Discount.gRPC.DiscountService.DiscountServiceClient>(op => {
                op.Address = new Uri(Configuration.GetValue<string>("DiscountServiceUri"));
            });

            services.AddScoped<GetCouponClient>();

            services.AddSingleton<IRepository, Repository.Repository>();

            //redis
            services.AddStackExchangeRedisCache(op => {
                op.Configuration = Configuration.GetValue<string>("Redis:Uri");
            });

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cart.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
