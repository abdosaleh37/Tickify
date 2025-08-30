using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickify.Core.Entities;

namespace Tickify.Infrastructure.Data.Configurations
{
    internal class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasKey(ec => new { ec.EventId, ec.CategoryId });

            builder.HasOne(ec => ec.Event)
                   .WithMany(e => e.EventCategories)
                   .HasForeignKey(ec => ec.EventId);

            builder.HasOne(ec => ec.Category)
                   .WithMany(c => c.EventCategories)
                   .HasForeignKey(ec => ec.CategoryId);
        }
    }
}
