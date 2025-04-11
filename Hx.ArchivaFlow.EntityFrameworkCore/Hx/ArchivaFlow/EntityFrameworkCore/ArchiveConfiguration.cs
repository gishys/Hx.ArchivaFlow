using Hx.ArchivaFlow.Domain;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    using Hx.ArchivaFlow.Domain.Shared;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArchiveConfiguration : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder.ToTable("ARC_ARCHIVES");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.ArchiveNo)
                   .HasMaxLength(ArchivaFlowConsts.ArchiveNoMaxLength)
                   .HasColumnName("ARCHIVE_NO")
                   .IsRequired();

            builder.Property(a => a.Title)
                   .HasMaxLength(ArchivaFlowConsts.TitleMaxLength)
                   .HasColumnName("TITLE")
                   .IsRequired();

            builder.Property(a => a.Year)
                   .HasColumnName("YEAR")
                   .IsRequired();

            builder.Property(a => a.FilingDate)
                   .HasColumnName("FILING_DATE")
                   .IsRequired()
                   .HasColumnType("timestamp with time zone");

            builder.Property(a => a.Status)
                   .HasColumnName("STATUS")
                   .IsRequired();

            builder.Property(a => a.BusinessKey)
                   .HasMaxLength(ArchivaFlowConsts.BusinessKeyMaxLength)
                   .HasColumnName("BUSINESS_KEY");

            builder.Property(a => a.Remarks)
                   .HasMaxLength(ArchivaFlowConsts.RemarksMaxLength)
                   .HasColumnName("REMARKS");

            builder.HasMany(a => a.Metadatas)
                   .WithOne(m => m.Archive)
                   .HasForeignKey(m => m.ArchiveId);

            builder.Property(p => p.ExtraProperties).HasColumnName("EXTRAPROPERTIES");
            builder.Property(p => p.ConcurrencyStamp).HasColumnName("CONCURRENCYSTAMP");
            builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
            builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
            builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
            builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
            builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
            builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
            builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
        }
    }
}
