using Application;
using EvenetBus.Messges.Events;
using Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.Api.EventBusConsumers;

namespace Ordering.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services
                .AddApplicationServices()
                .AddIfrastructureServices(Configuration);

            //MassTransit Consumer
            services.AddScoped<CartCheckOutEvent>();

            services.AddMassTransit(configure => {

                configure.AddConsumer<CartCheckOutConsumer>();

                configure.UsingRabbitMq((context, config) => {
                    config.Host(Configuration["RabbitMQ:Host"], "/", h => {
                        h.Password(Configuration["RabbitMQ:Password"]);
                        h.Username(Configuration["RabbitMQ:Login"]);
                    });

                    config.ReceiveEndpoint(EventBusContants.CartCheckOutQueue, c => {
                        c.ConfigureConsumer<CartCheckOutConsumer>(context);
                    });

                });
            });

            services.AddMassTransitHostedService();
            //end 

            services.AddAutoMapper(typeof(Startup));


            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
