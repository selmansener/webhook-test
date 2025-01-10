using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebhookTest.Entities;

namespace WebhookTest.WebhookData.EntityConfigs
{
    internal class WebhookStateEntityConfig : BaseEntityConfiguration<WebhookState>
    {
        public override void Configure(EntityTypeBuilder<WebhookState> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Data)
                .WithOne(x => x.WebhookState)
                .HasForeignKey<WebhookState>(x => x.EventDataId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
