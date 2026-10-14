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
    public class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_Question_Marks", "[Marks] > 0");
                TableBuilder.HasCheckConstraint("CK_Question_DisplayOrder", "[DisplayOrder] > 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Marks)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.QuizId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Quiz)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Question_Quiz");

            // Indexes
            builder.HasIndex(x => x.QuizId)
                .HasDatabaseName("IX_Question_Quiz");

            builder.HasIndex(x => new { x.QuizId, x.DisplayOrder })
                .HasDatabaseName("IX_Question_QuizOrder");



        }
    }
}
