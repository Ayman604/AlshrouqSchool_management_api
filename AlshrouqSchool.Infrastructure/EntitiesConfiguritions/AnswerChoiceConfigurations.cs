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
    public class AnswerChoiceConfigurations : IEntityTypeConfiguration<AnswerChoice>
    {
        public void Configure(EntityTypeBuilder<AnswerChoice> builder)
        {
            builder.ToTable("AnswerChoices", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_AnswerChoice_DisplayOrder", "[DisplayOrder] > 0");

            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsCorrect)
                .HasDefaultValue(false);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.QuestionId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Question)
                .WithMany(x => x.Choices)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AnswerChoice_Question");

            // Indexes
            builder.HasIndex(x => x.QuestionId)
                .HasDatabaseName("IX_AnswerChoice_Question");

            builder.HasIndex(x => new { x.QuestionId, x.DisplayOrder })
                .HasDatabaseName("IX_AnswerChoice_QuestionOrder");

        }
    }
}
