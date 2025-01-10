using Microsoft.Extensions.DependencyInjection;

using WebhookTest.WebhookData;

namespace WebhookTest.Webhooks
{
    public static class Register
    {
        public static IServiceCollection AddWebhooks(this IServiceCollection services, WebhookOptions webhookOptions)
        {
            services.AddWebhookData(webhookOptions.ConnectionString);

            return services;
        }
    }
}
