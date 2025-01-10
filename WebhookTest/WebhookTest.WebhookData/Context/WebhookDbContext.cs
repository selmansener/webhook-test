using Microsoft.EntityFrameworkCore;

using WebhookTest.Entities;

namespace WebhookTest.WebhookData.Context
{
    internal class WebhookDbContext : DbContext
    {
        public WebhookDbContext(DbContextOptions<WebhookDbContext> options)
            : base(options)
        {

        }

        public DbSet<EventGroup> EventGroups { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Webhook> Webhooks { get; set; }

        public DbSet<WebhookHeader> WebhookHeaders { get; set; }

        public DbSet<EventData> EventDatas { get; set; }

        public DbSet<WebhookState> WebhookStates { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties(typeof(string)).HaveMaxLength(5000);

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
