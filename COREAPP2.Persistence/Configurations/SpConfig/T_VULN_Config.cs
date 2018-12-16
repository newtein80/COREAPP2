using COREAPP2.Domain.Entities.SpModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Configurations.SpConfig
{
    public class T_VULN_Config : IEntityTypeConfiguration<T_VULN>
    {
        public void Configure(EntityTypeBuilder<T_VULN> builder)
        {
            builder.HasKey(e => e.VULN_SEQ);

            builder.Property(e => e.APPLY_TARGET).HasMaxLength(1024);

            builder.Property(e => e.APPLY_TIME).HasMaxLength(2);

            builder.Property(e => e.CLIENT_STANDARD_ID).HasMaxLength(32);

            builder.Property(e => e.CREATE_DT).HasColumnType("datetime");

            builder.Property(e => e.CREATE_USER_ID).HasMaxLength(16);

            builder.Property(e => e.DETAIL).HasColumnType("text");

            builder.Property(e => e.DETAIL_PATH).HasMaxLength(256);

            builder.Property(e => e.EFFECT).HasMaxLength(2048);

            builder.Property(e => e.EXCEPT_CD).HasMaxLength(2);

            builder.Property(e => e.EXCEPT_DT).HasColumnType("datetime");

            builder.Property(e => e.EXCEPT_REASON).HasMaxLength(1024);

            builder.Property(e => e.EXCEPT_TERM_FR).HasColumnType("datetime");

            builder.Property(e => e.EXCEPT_TERM_TO).HasColumnType("datetime");

            builder.Property(e => e.EXCEPT_TERM_TYPE).HasMaxLength(2);

            builder.Property(e => e.EXCEPT_USER_ID).HasMaxLength(16);

            builder.Property(e => e.JUDGEMENT).HasMaxLength(2048);

            builder.Property(e => e.MANAGE_ID).HasMaxLength(32);

            builder.Property(e => e.ORG_PARSER_CONTENTS).HasColumnType("text");

            builder.Property(e => e.PARSER_CONTENTS).HasColumnType("text");

            builder.Property(e => e.REFRRENCE).HasMaxLength(2048);

            builder.Property(e => e.REMEDY).HasColumnType("text");

            builder.Property(e => e.REMEDY_DETAIL).HasColumnType("text");

            builder.Property(e => e.REMEDY_PATH).HasMaxLength(256);

            builder.Property(e => e.UPDATE_DT).HasColumnType("datetime");

            builder.Property(e => e.UPDATE_USER_ID).HasMaxLength(16);

            builder.Property(e => e.VULGROUP).HasDefaultValueSql("((0))");

            builder.Property(e => e.VULNO)
                .HasMaxLength(32)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.VULN_NAME).HasMaxLength(128);

            builder.HasOne(d => d.GROUP_SEQNavigation)
                .WithMany(p => p.T_VULN)
                .HasForeignKey(d => d.GROUP_SEQ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__T_VULN__GROUP_SE__04E4BC85");
        }
    }
}
