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
    internal class PostMediaConfigurations : IEntityTypeConfiguration<PostMedia>
    {
        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.ToTable("PostMedia",TableBuilder =>
            {
                // Constraints
                TableBuilder.HasCheckConstraint("CK_PostMedia_DisplayOrder", "[DisplayOrder] >= 0");

            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.MediaId).IsRequired();
            builder.Property(x => x.DisplayOrder).IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Media)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PostMedia_Post");

            builder.HasOne(x => x.Media)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.MediaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PostMedia_Media");

            // Indexes
            builder.HasIndex(x => x.PostId)
                .HasDatabaseName("IX_PostMedia_Post");

            builder.HasIndex(x => x.MediaId)
                .HasDatabaseName("IX_PostMedia_Media");

            // UNIQUE: Only one cover per post
            builder.HasIndex(x => new { x.PostId, x.MediaRole })
                .IsUnique()
                .HasFilter("[MediaRole] = 1") // Cover = 1
                .HasDatabaseName("UX_PostMedia_PostCover");

        }
    }
}
