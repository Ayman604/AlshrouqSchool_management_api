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
    public class AttendanceSessionConfigurations : IEntityTypeConfiguration<AttendanceSession>
    {
        public void Configure(EntityTypeBuilder<AttendanceSession> builder)
        {
            builder.ToTable("AttendanceSessions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
            builder.Property(x => x.ClassScheduleId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.ClassSchedule)
                .WithMany(x => x.AttendanceSessions)
                .HasForeignKey(x => x.ClassScheduleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AttendanceSession_ClassSchedule");

            // Indexes
            builder.HasIndex(x => x.ClassScheduleId)
                .HasDatabaseName("IX_AttendanceSession_ClassSchedule");

            builder.HasIndex(x => x.Date)
                .HasDatabaseName("IX_AttendanceSession_Date");

            // UNIQUE: One session per class per date
            builder.HasIndex(x => new { x.ClassScheduleId, x.Date })
                .IsUnique()
                .HasDatabaseName("UX_AttendanceSession_ScheduleDate");

        }
    }
}
