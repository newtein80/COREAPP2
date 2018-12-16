using COREAPP2.Domain.Entities.EfModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Configurations.EfConfig
{
    public class T_COMMON_CODE_Config : IEntityTypeConfiguration<T_COMMON_CODE>
    {
        public void Configure(EntityTypeBuilder<T_COMMON_CODE> builder)
        {
            builder.HasKey(e => new { e.CODE_TYPE, e.CODE_ID });

            builder.Property(e => e.CODE_TYPE).HasMaxLength(32);

            builder.Property(e => e.CODE_ID).HasMaxLength(32);

            builder.Property(e => e.CODE_COMMENT).HasMaxLength(128);

            builder.Property(e => e.CODE_NAME)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.CODE_TYPE_NAME)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.CREATE_DT).HasColumnType("datetime");

            builder.Property(e => e.CREATE_USER_ID).HasMaxLength(16);
        }
    }
}
