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
    public class AcademicYearConfigurations : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            // Constraints
            builder.ToTable("AcademicYears",TableBuilder =>
            {
                TableBuilder.HasCheckConstraint("CK_AcademicYear_DateRange", "[StartsOn] < [EndsOn]");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StartsOn)
                .IsRequired();

            builder.Property(x => x.EndsOn)
                .IsRequired();

            builder.Property(x => x.IsCurrent)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(x => x.IsCurrent)
                .HasDatabaseName("IX_AcademicYear_IsCurrent");

            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("IX_AcademicYear_Name");

            
;

        }
    }
}
