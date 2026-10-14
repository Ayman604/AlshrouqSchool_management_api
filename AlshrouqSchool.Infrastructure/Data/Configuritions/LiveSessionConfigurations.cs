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
    public class LiveSessionConfigurations : IEntityTypeConfiguration<LiveSession>
    {

        public void Configure(EntityTypeBuilder<LiveSession> builder)
        {
            builder.ToTable("LiveSessions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.ScheduledStartAtUtc).IsRequired();

            builder.Property(x => x.RoomName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.RecordingUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Status)
                .HasDefaultValue(LiveSessionStatus.Scheduled);

            builder.Property(x => x.RecordingAvailable)
                .HasDefaultValue(false);

            builder.Property(x => x.LessonId).IsRequired();
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.SectionId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.LiveSessions)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LiveSession_Lesson");

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.LiveSessions)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LiveSession_Teacher");

            builder.HasOne(x => x.Section)
                .WithMany()
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LiveSession_Section");

            // Indexes
            builder.HasIndex(x => new { x.LessonId, x.ScheduledStartAtUtc })
                .HasDatabaseName("IX_LiveSession_LessonScheduled");

            builder.HasIndex(x => x.TeacherId)
                .HasDatabaseName("IX_LiveSession_Teacher");

            builder.HasIndex(x => x.SectionId)
                .HasDatabaseName("IX_LiveSession_Section");

            builder.HasIndex(x => x.Status)
                .HasDatabaseName("IX_LiveSession_Status");
        }
    }
}