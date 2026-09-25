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
    public class TeacherAssignmentConfigurations : IEntityTypeConfiguration<TeachingAssignment>
    {
        public void Configure(EntityTypeBuilder<TeachingAssignment> builder)
        {
            builder.ToTable("TeachingAssignments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.SectionId).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();
            builder.Property(x => x.AcademicYearId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.TeachingAssignments)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TeachingAssignment_Teacher");

            builder.HasOne(x => x.Section)
                .WithMany(x => x.TeachingAssignments)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TeachingAssignment_Section");

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.TeachingAssignments)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TeachingAssignment_Subject");

            builder.HasOne(x => x.AcademicYear)
                .WithMany(x => x.TeachingAssignments)
                .HasForeignKey(x => x.AcademicYearId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TeachingAssignment_AcademicYear");

            // UNIQUE CONSTRAINT: Teacher + Section + Subject + AcademicYear
            builder.HasIndex(x => new { x.TeacherId, x.SectionId, x.SubjectId, x.AcademicYearId })
                .IsUnique()
                .HasDatabaseName("UX_TeachingAssignment_TeacherSectionSubjectYear");

            // Indexes
            builder.HasIndex(x => x.TeacherId)
                .HasDatabaseName("IX_TeachingAssignment_Teacher");

            builder.HasIndex(x => x.SectionId)
                .HasDatabaseName("IX_TeachingAssignment_Section");

            builder.HasIndex(x => x.SubjectId)
                .HasDatabaseName("IX_TeachingAssignment_Subject");

            builder.HasIndex(x => x.AcademicYearId)
                .HasDatabaseName("IX_TeachingAssignment_AcademicYear");

        }
    }
}
