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
    public class LessonConfigurations : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.IsPublished)
                .HasDefaultValue(false);

            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Lesson_Teacher");

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Lesson_Subject");

            // Indexes
            builder.HasIndex(x => x.TeacherId)
                .HasDatabaseName("IX_Lesson_Teacher");

            builder.HasIndex(x => x.SubjectId)
                .HasDatabaseName("IX_Lesson_Subject");

            builder.HasIndex(x => new { x.SubjectId, x.DisplayOrder })
                .HasDatabaseName("IX_Lesson_SubjectOrder");

            builder.HasIndex(x => new { x.IsPublished, x.CreatedAtUtc })
                .HasDatabaseName("IX_Lesson_PublishedCreated");
        }
    }
}
