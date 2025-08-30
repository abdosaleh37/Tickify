using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickify.Core.Entities;

namespace Tickify.Infrastructure.Data.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.TicketNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(t => t.Status)
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            builder.HasOne(t => t.User)
                   .WithMany(u => u.Tickets)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Event)
                   .WithMany(e => e.Tickets)
                   .HasForeignKey(t => t.EventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Payment)
                   .WithOne(p => p.Ticket)
                   .HasForeignKey<Payment>(p => p.TicketId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
