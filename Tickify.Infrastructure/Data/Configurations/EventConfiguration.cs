using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickify.Core.Entities;

namespace Tickify.Infrastructure.Data.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(e => e.Location)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Capacity)
                   .IsRequired();

            builder.Property(e => e.CreatedAt)
                   .IsRequired();

            builder.HasOne(e => e.Organizer)
                   .WithMany(u => u.OrganizedEvents)
                   .HasForeignKey(e => e.OrganizerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.EventCategories)
                   .WithOne(ec => ec.Event)
                   .HasForeignKey(ec => ec.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Tickets)
                   .WithOne(t => t.Event)
                   .HasForeignKey(t => t.EventId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}