using AlshrouqSchool.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Infrastructure.Configuritions
{
    public class StudentParentConfigurations : IEntityTypeConfiguration<StudentParent>
    {
        public void Configure(EntityTypeBuilder<StudentParent> builder)
        {
            builder.ToTable("StudentParents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();
            builder.Property(x => x.Relationship)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IsPrimaryContact)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Student)
                .WithMany(x => x.Parents)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StudentParent_Student");

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StudentParent_Parent");

            // Indexes
            builder.HasIndex(x => new { x.StudentId, x.ParentId })
                .IsUnique()
                .HasDatabaseName("UX_StudentParent_StudentParent");

            builder.HasIndex(x => x.ParentId)
                .HasDatabaseName("IX_StudentParent_Parent");

            builder.HasIndex(x => x.IsPrimaryContact)
                .HasDatabaseName("IX_StudentParent_PrimaryContact");
        }
    }
}
