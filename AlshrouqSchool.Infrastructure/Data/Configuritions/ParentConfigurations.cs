using AlshrouqSchool.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Presistence.Data.EntitiesConfiguritions
{
    public class ParentConfigurations : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("Parents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Parent>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Parent_User");

            // Indexes
            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasDatabaseName("UX_Parent_UserId");
        }
    }
}
