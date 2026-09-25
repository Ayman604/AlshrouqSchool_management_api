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
    public class StudentAnswerConfigurations : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.ToTable("StudentAnswers", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_StudentAnswer_AwardedMarks", "[AwardedMarks] >= 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentQuizAttemptId).IsRequired();
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.IsCorrect).HasDefaultValue(false);
            builder.Property(x => x.AwardedMarks).HasPrecision(10, 2);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.StudentQuizAttempt)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.StudentQuizAttemptId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StudentAnswer_StudentQuizAttempt");

            builder.HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentAnswer_Question");

            builder.HasOne(x => x.SelectedAnswerChoice)
                .WithMany()
                .HasForeignKey(x => x.SelectedAnswerChoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_StudentAnswer_AnswerChoice");

            // Indexes
            builder.HasIndex(x => x.StudentQuizAttemptId)
                .HasDatabaseName("IX_StudentAnswer_StudentQuizAttempt");

            builder.HasIndex(x => x.QuestionId)
                .HasDatabaseName("IX_StudentAnswer_Question");
            // UNIQUE: One answer per question per attempt
            builder.HasIndex(x => new { x.StudentQuizAttemptId, x.QuestionId })
                .IsUnique()
                .HasDatabaseName("UX_StudentAnswer_AttemptQuestion");
           
        }
    }
}
