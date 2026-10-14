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
    public class PostConfigrations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            //builder.Property(x => x.Content).IsRequired();
            //builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.Title).HasMaxLength(250);
            //builder.Property(x => x.Slug).HasMaxLength(250);
            //builder.HasIndex(x => x.Slug).IsUnique();
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.Excerpt)
                .HasMaxLength(500);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(x => x.IsPublished)
                .HasDefaultValue(false);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(x => x.Slug)
                .IsUnique()
                .HasDatabaseName("UX_Post_Slug");

            builder.HasIndex(x => new { x.IsPublished, x.CreatedAtUtc })
                .HasDatabaseName("IX_Post_PublishedCreated");

            builder.HasIndex(x => x.Type)
                .HasDatabaseName("IX_Post_Type");

            builder.HasIndex(x => x.DisplayOrder)
                .HasDatabaseName("IX_Post_DisplayOrder");

        }
    }

}
