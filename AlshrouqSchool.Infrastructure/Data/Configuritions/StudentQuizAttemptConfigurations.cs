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
    public class StudentQuizAttemptConfigurations : IEntityTypeConfiguration<StudentQuizAttempt>
    {
        public void Configure(EntityTypeBuilder<StudentQuizAttempt> builder)
        {
            builder.ToTable("StudentQuizAttempts", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_StudentQuizAttempt_Score", "[Score] >= 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.QuizId).IsRequired();
            builder.Property(x => x.StartedAtUtc).IsRequired();
            builder.Property(x => x.Score).HasPrecision(10, 2);
            builder.Property(x => x.QuestionOrderJson).HasMaxLength(2000);
            builder.Property(x => x.AnswerChoiceOrderJson).HasMaxLength(5000);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Student)
                .WithMany(x => x.QuizAttempts)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentQuizAttempt_Student");

            builder.HasOne(x => x.Quiz)
                .WithMany(x => x.Attempts)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentQuizAttempt_Quiz");

            // Indexes
            builder.HasIndex(x => new { x.StudentId, x.QuizId })
                .HasDatabaseName("IX_StudentQuizAttempt_StudentQuiz");

            builder.HasIndex(x => x.QuizId)
                .HasDatabaseName("IX_StudentQuizAttempt_Quiz");

            builder.HasIndex(x => new { x.StudentId, x.StartedAtUtc })
                .HasDatabaseName("IX_StudentQuizAttempt_StudentStarted");

          
        }
    }
}
