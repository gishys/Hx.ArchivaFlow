using Hx.ArchivaFlow.Domain;
using Hx.ArchivaFlow.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    public class MetadataConfiguration : IEntityTypeConfiguration<Metadata>
    {
        public void Configure(EntityTypeBuilder<Metadata> builder)
        {
            builder.ToTable("ARC_METADATA");

            builder.HasKey(m => new { m.ArchiveId, m.Key });

            builder.HasIndex(m => m.Key);
            builder.HasIndex(m => m.Value);
            builder.HasIndex(m => m.ArchiveId);

            builder.Property(m => m.Key)
                   .HasMaxLength(ArchivaFlowConsts.MetadataKeyMaxLength)
                   .HasColumnName("KEY")
                   .IsRequired();

            builder.Property(m => m.Value)
                   .HasColumnName("VALUE")
                   .IsRequired();

            builder.Property(m => m.DataType)
                   .HasColumnName("DATA_TYPE")
                   .IsRequired();

            builder.Property(m => m.ArchiveId)
                   .HasColumnName("ARCHIVE_ID")
                   .IsRequired();

            builder.Property(m => m.NavigationProperty)
                .HasMaxLength(ArchivaFlowConsts.MetadataNavigationPropertyMaxLength)
                   .HasColumnName("NAVIGATION_PROPERTY");
        }
    }
}