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
    public class StudentEnrollmentConfigurations : IEntityTypeConfiguration<StudentEnrollment>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        {
            builder.ToTable("StudentEnrollments" , TableBuilder =>
            {

                // Constraints
                TableBuilder.HasCheckConstraint("CK_StudentEnrollment_Dates", "[LeftOn] IS NULL OR [LeftOn] > [EnrolledOn]");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.SectionId).IsRequired();
            builder.Property(x => x.EnrolledOn).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Student)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StudentEnrollment_Student");

            builder.HasOne(x => x.Section)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentEnrollment_Section");

            // Indexes
            builder.HasIndex(x => new { x.StudentId, x.SectionId })
                .HasDatabaseName("IX_StudentEnrollment_StudentSection");

            builder.HasIndex(x => x.SectionId)
                .HasDatabaseName("IX_StudentEnrollment_Section");

            builder.HasIndex(x => x.IsActive)
                .HasDatabaseName("IX_StudentEnrollment_IsActive");

            builder.HasIndex(x => new { x.StudentId, x.IsActive })
                .HasDatabaseName("IX_StudentEnrollment_StudentActive");

        }
    }
}
