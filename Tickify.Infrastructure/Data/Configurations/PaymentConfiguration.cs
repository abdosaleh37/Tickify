using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickify.Core.Entities;

namespace Tickify.Infrastructure.Data.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(p => p.Status)
                   .IsRequired();

            builder.Property(p => p.TransactionId)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.FailureReason)
                   .HasMaxLength(500);

            builder.HasOne(p => p.User)
                   .WithMany(u => u.Payments)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
