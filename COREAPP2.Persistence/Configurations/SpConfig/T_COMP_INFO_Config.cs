using COREAPP2.Domain.Entities.SpModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Configurations.SpConfig
{
    public class T_COMP_INFO_Config : IEntityTypeConfiguration<T_COMP_INFO>
    {
        public void Configure(EntityTypeBuilder<T_COMP_INFO> builder)
        {
            builder.HasKey(e => e.COMP_SEQ);

            builder.Property(e => e.COMP_DESCRIPTION).HasMaxLength(1024);

            builder.Property(e => e.COMP_DETAIL_GUBUN)
                .HasMaxLength(32)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.COMP_NAME)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.COMP_REF).HasMaxLength(256);

            builder.Property(e => e.CREATE_DT).HasColumnType("datetime");

            builder.Property(e => e.CREATE_USER_ID).HasMaxLength(16);

            builder.Property(e => e.DIAG_TYPE)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.STANDARD_YEAR).HasMaxLength(4);

            builder.Property(e => e.UPDATE_DT).HasColumnType("datetime");

            builder.Property(e => e.UPDATE_USER_ID).HasMaxLength(16);
        }
    }
}
