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
    public class SectionConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections", TableBuilder =>
            {
                TableBuilder.HasCheckConstraint("CK_Section_Capacity", "[Capacity] > 0");
                TableBuilder.HasCheckConstraint("CK_Section_Gender", "[Gender] IS NULL OR [Gender] IN ('M', 'F')");


            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Capacity)
                .IsRequired();

            builder.Property(x => x.GradeLevelId)
                .IsRequired();

            builder.Property(x => x.AcademicYearId)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasMaxLength(1);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.GradeLevel)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.GradeLevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Section_GradeLevel");

            builder.HasOne(x => x.AcademicYear)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.AcademicYearId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Section_AcademicYear");

            // Indexes
            builder.HasIndex(x => new { x.GradeLevelId, x.AcademicYearId })
                .HasDatabaseName("IX_Section_GradeLevelYear");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("IX_Section_Name");




        }
    }
}
