using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebhookTest.Entities;

namespace WebhookTest.WebhookData.EntityConfigs
{
    internal class EventDataEntityConfig : BaseEntityConfiguration<EventData>
    {
        public override void Configure(EntityTypeBuilder<EventData> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Data).HasColumnType("TEXT");
        }
    }
}
