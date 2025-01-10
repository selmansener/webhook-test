using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebhookTest.WebhookData.Context;

namespace WebhookTest.WebhookData
{
    public static class Register
    {
        public static IServiceCollection AddWebhookData(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<WebhookDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
