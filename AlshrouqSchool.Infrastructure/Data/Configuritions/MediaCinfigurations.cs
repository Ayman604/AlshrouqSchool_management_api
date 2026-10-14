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
    public class MediaCinfigurations : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.MimeType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.FileSizeBytes)
                .IsRequired();

            builder.Property(x => x.AltText)
                .HasMaxLength(500);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Category)
                .IsRequired();

            builder.Property(x => x.UploadedByUserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.UploadedByUser)
                .WithMany()
                .HasForeignKey(x => x.UploadedByUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Media_User");

            // Indexes
            builder.HasIndex(x => x.UploadedByUserId)
              .HasDatabaseName("IX_Media_UploadedBy");

            builder.HasIndex(x => new { x.Type, x.Category })
                .HasDatabaseName("IX_Media_TypeCategory");

            builder.HasIndex(x => x.CreatedAtUtc)
                .HasDatabaseName("IX_Media_CreatedAt");
        }
    }
}
