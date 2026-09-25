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
    public class ClassScheduleConfigurations : IEntityTypeConfiguration<ClassSchedule>
    {
        public void Configure(EntityTypeBuilder<ClassSchedule> builder)
        {
            builder.ToTable("ClassSchedules", TableBuilder =>
            {
                // Constraints

                TableBuilder.HasCheckConstraint("CK_ClassSchedule_TimeRange", "[StartTime] < [EndTime]");

            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Day).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Room).HasMaxLength(50);
            builder.Property(x => x.TeachingAssignmentId).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.TeachingAssignment)
                .WithMany(x => x.ClassSchedules)
                .HasForeignKey(x => x.TeachingAssignmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ClassSchedule_TeachingAssignment");

            // Indexes
            builder.HasIndex(x => x.TeachingAssignmentId)
                .HasDatabaseName("IX_ClassSchedule_TeachingAssignment");

            builder.HasIndex(x => new { x.Day, x.StartTime })
                .HasDatabaseName("IX_ClassSchedule_DayTime");

        }
    }
}
