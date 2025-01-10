using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var webhookDataConnectionString = builder.Configuration.GetConnectionString("WebhookData");

builder.AddProject<Projects.WebhookTest_API>("webhooktest-api")
    .WithEnvironment("WEBHOOK_DATA_CONNECTION_STRING", webhookDataConnectionString);

builder.Build().Run();
