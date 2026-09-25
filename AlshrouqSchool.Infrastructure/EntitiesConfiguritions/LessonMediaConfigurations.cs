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
    internal class LessonMediaConfigurations:IEntityTypeConfiguration<LessonMedia>
    {
        public void Configure(EntityTypeBuilder<LessonMedia> builder)
        {

            builder.ToTable("LessonMedia", TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_LessonMedia_DisplayOrder", "[DisplayOrder] >= 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LessonId).IsRequired();
            builder.Property(x => x.MediaId).IsRequired();
            builder.Property(x => x.DisplayOrder).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.Media)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LessonMedia_Lesson");

            builder.HasOne(x => x.Media)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.MediaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LessonMedia_Media");

            // Indexes
            builder.HasIndex(x => x.LessonId)
                .HasDatabaseName("IX_LessonMedia_Lesson");

            builder.HasIndex(x => x.MediaId)
                .HasDatabaseName("IX_LessonMedia_Media");

            
        }
    }
}
