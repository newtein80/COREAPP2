using COREAPP2.Domain.Entities.SpModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Configurations.SpConfig
{
    public class T_VULN_GROUP_Config : IEntityTypeConfiguration<T_VULN_GROUP>
    {
        public void Configure(EntityTypeBuilder<T_VULN_GROUP> builder)
        {
            builder.HasKey(e => e.GROUP_SEQ);

            builder.Property(e => e.GROUP_SEQ).ValueGeneratedNever();

            builder.Property(e => e.CREATE_DT).HasColumnType("datetime");

            builder.Property(e => e.CREATE_USER_ID).HasMaxLength(16);

            builder.Property(e => e.DIAG_KIND).HasMaxLength(32);

            builder.Property(e => e.DIAG_TERM).HasMaxLength(32);

            builder.Property(e => e.DIAG_TOOL).HasMaxLength(32);

            builder.Property(e => e.GROUP_ID).HasMaxLength(32);

            builder.Property(e => e.GROUP_NAME).HasMaxLength(128);

            builder.Property(e => e.GROUP_TYPE)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.UPDATE_DT).HasColumnType("datetime");

            builder.Property(e => e.UPDATE_USER_ID).HasMaxLength(16);

            builder.HasOne(d => d.COMP_SEQNavigation)
                .WithMany(p => p.T_VULN_GROUP)
                .HasForeignKey(d => d.COMP_SEQ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__T_VULN_GR__COMP___7F2BE32F");
        }
    }
}
