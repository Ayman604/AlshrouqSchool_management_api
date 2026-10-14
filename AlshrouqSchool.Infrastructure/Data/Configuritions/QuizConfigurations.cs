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
    public class QuizConfigurations : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizzes", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_Quiz_Marks", "[PassingMarks] <= [TotalMarks]");
                TableBuilder.HasCheckConstraint("CK_Quiz_Duration", "[DurationMinutes] > 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.TotalMarks)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.PassingMarks)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.DurationMinutes)
                .IsRequired();

            builder.Property(x => x.IsPublished)
                .HasDefaultValue(false);

            builder.Property(x => x.ShuffleQuestions)
                .HasDefaultValue(false);

            builder.Property(x => x.ShuffleAnswerChoices)
                .HasDefaultValue(false);

            builder.Property(x => x.LessonId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.Quizzes)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Quiz_Lesson");

            // Indexes
            builder.HasIndex(x => x.LessonId)
                .HasDatabaseName("IX_Quiz_Lesson");

            builder.HasIndex(x => new { x.IsPublished, x.CreatedAtUtc })
                .HasDatabaseName("IX_Quiz_PublishedCreated");

        }
    }
}
