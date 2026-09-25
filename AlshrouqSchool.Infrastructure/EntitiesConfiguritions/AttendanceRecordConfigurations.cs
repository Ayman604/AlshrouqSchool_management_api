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
    public class AttendanceRecordConfigurations:IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
            builder.ToTable("AttendanceRecords");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AttendanceSessionId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.AttendanceSession)
                .WithMany(x => x.Records)
                .HasForeignKey(x => x.AttendanceSessionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AttendanceRecord_AttendanceSession");

            builder.HasOne(x => x.Student)
                .WithMany(x => x.AttendanceRecords)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AttendanceRecord_Student");

            // Indexes
            builder.HasIndex(x => x.AttendanceSessionId)
                .HasDatabaseName("IX_AttendanceRecord_AttendanceSession");

            builder.HasIndex(x => x.StudentId)
                .HasDatabaseName("IX_AttendanceRecord_Student");

            builder.HasIndex(x => new { x.AttendanceSessionId, x.StudentId })
                .IsUnique()
                .HasDatabaseName("UX_AttendanceRecord_SessionStudent");
            builder.HasIndex(x => x.Status)
                .HasDatabaseName("IX_AttendanceRecord_Status");
        }


    }
}
