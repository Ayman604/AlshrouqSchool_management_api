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
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.EmployeeNumber)
                .HasMaxLength(20);

            builder.Property(x => x.Nationality)
                .HasMaxLength(50);

            builder.Property(x => x.Bio)
                .HasMaxLength(1000);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Teacher>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Teacher_User");

            // Indexes
            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasDatabaseName("UX_Teacher_UserId");

            builder.HasIndex(x => x.EmployeeNumber)
                .IsUnique()
                .HasDatabaseName("UX_Teacher_EmployeeNumber");
        }
    }
}
