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
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.StudentNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Student>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Student_User");

            // Indexes
            builder.HasIndex(x => x.UserId)
                .IsUnique()
                .HasDatabaseName("UX_Student_UserId");

            builder.HasIndex(x => x.StudentNumber)
                .IsUnique()
                .HasDatabaseName("UX_Student_StudentNumber");
        }
    }
}
