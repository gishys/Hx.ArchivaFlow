using Hx.ArchivaFlow.Domain;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    using Hx.ArchivaFlow.Domain.Shared;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Volo.Abp.EntityFrameworkCore.Modeling;

    public class ArchiveConfiguration : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder.ToTable("ARC_ARCHIVES");
            builder.ConfigureByConvention();

            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.ArchiveNo);
            builder.HasIndex(a => a.Title);
            builder.HasIndex(a => a.Year);
            builder.HasIndex(a => a.FilingDate);
            builder.HasIndex(a => a.Status);
            builder.HasIndex(a => a.BusinessKey);

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

            builder.Property(a => a.ContentType)
                   .HasMaxLength(ArchivaFlowConsts.ContentTypeMaxLength)
                   .HasColumnName("CONTENTTYPE")
                   .IsRequired();

            builder.Property(a => a.MediaType)
                   .HasColumnName("MEDIATYPE")
                   .IsRequired();

            builder.Property(a => a.SecretLevel)
                   .HasColumnName("SECRETLEVEL")
                   .IsRequired();

            builder.Property(a => a.RetentionPeriod)
                   .HasColumnName("RETENTIONPERIOD")
                   .IsRequired();

            builder.Property(a => a.FilingDate)
                   .HasColumnName("FILING_DATE")
                   .HasColumnType("timestamp with time zone");

            builder.Property(a => a.Status)
                   .HasColumnName("STATUS")
                   .IsRequired();

            builder.Property(a => a.BusinessKey)
                   .HasMaxLength(ArchivaFlowConsts.BusinessKeyMaxLength)
                   .IsRequired()
                   .HasColumnName("BUSINESS_KEY");

            builder.Property(a => a.Remarks)
                   .HasMaxLength(ArchivaFlowConsts.RemarksMaxLength)
                   .HasColumnName("REMARKS");

            builder.HasMany(a => a.Metadatas)
                   .WithOne(m => m.Archive)
                   .HasForeignKey(m => m.ArchiveId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Id).HasColumnName("ID");
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