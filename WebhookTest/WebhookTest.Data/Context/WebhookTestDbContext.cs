using Microsoft.EntityFrameworkCore;

namespace WebhookTest.Data.Context
{
    internal class WebhookTestDbContext : DbContext
    {
        public WebhookTestDbContext(DbContextOptions<WebhookTestDbContext> options)
            : base(options)
        {

        }
    }
}
