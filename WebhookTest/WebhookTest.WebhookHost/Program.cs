using MassTransit;

using Microsoft.Extensions.Hosting;

namespace WebhookTest.WebhookHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            var services = builder.Services;

            services.AddMassTransit(mtConfig =>
            {
                mtConfig.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            var app = builder.Build();

            app.Run();
        }
    }
}
