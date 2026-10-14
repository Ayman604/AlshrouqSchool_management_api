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
    public class StudentLiveSessionAttendanceConfigurations
    {
        public void Configure(EntityTypeBuilder<StudentLiveSessionAttendance> builder)
        {
            builder.ToTable("StudentLiveSessionAttendances");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LiveSessionId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.JoinedAtUtc).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.LiveSession)
                .WithMany(x => x.StudentAttendances)
                .HasForeignKey(x => x.LiveSessionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StudentLiveSessionAttendance_LiveSession");

            builder.HasOne(x => x.Student)
                .WithMany(x => x.LiveSessionAttendances)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentLiveSessionAttendance_Student");

            // Indexes
            builder.HasIndex(x => new { x.LiveSessionId, x.StudentId })
                .IsUnique()
                .HasDatabaseName("UX_StudentLiveSessionAttendance_SessionStudent");

            builder.HasIndex(x => x.StudentId)
                .HasDatabaseName("IX_StudentLiveSessionAttendance_Student");

            builder.HasIndex(x => new { x.LiveSessionId, x.JoinedAtUtc })
                .HasDatabaseName("IX_StudentLiveSessionAttendance_SessionJoined");

        }
    }
}
