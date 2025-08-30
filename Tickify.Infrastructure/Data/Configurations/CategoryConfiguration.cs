using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickify.Core.Entities;

namespace Tickify.Infrastructure.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                     .HasMaxLength(500)
                     .IsRequired(false);

            builder.Property(c => c.IsActive)
                     .IsRequired()
                     .HasDefaultValue(true);

            builder.HasMany(c => c.EventCategories)
                   .WithOne(ec => ec.Category)
                   .HasForeignKey(ec => ec.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
