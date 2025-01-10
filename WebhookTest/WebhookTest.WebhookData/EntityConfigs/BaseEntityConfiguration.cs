using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebhookTest.Entities;

namespace WebhookTest.WebhookData.EntityConfigs
{
    internal abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Configuring primary key using HasKey
            builder.HasKey(x => x.Id);

            // Use HiLo pattern for key generation
            builder.Property(x => x.Id).UseHiLo($"{typeof(TEntity).Name}_Seq");

            // Additional common configurations can be added here
        }
    }
}
