
using WebhookTest.Webhooks;

namespace WebhookTest.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var webhookConnectionString = string.Empty;
        if (builder.Environment.IsDevelopment())
        {
            webhookConnectionString = "Server=127.0.0.1;Port=5432;Database=WebhookData;User Id=postgres;Password=qwe123**;";
        }
        else
        {
            Environment.GetEnvironmentVariable("WEBHOOK_DATA_CONNECTION_STRING");
        }

        builder.Services.AddWebhooks(new WebhookOptions
        {
            ConnectionString = webhookConnectionString
        });

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
