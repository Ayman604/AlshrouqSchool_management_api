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
    public class LessonSectionConfigurations : IEntityTypeConfiguration<LessonSection>
    {
        public void Configure(EntityTypeBuilder<LessonSection> builder)
        {
            builder.ToTable("LessonSections");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LessonId).IsRequired();
            builder.Property(x => x.SectionId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LessonSection_Lesson");

            builder.HasOne(x => x.Section)
                .WithMany(x => x.LessonSections)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LessonSection_Section");

            // UNIQUE: Lesson appears once per section
            builder.HasIndex(x => new { x.LessonId, x.SectionId })
                .IsUnique()
                .HasDatabaseName("UX_LessonSection_LessonSection");

            // Indexes
            builder.HasIndex(x => x.SectionId)
                .HasDatabaseName("IX_LessonSection_Section");
        }
    }
}
