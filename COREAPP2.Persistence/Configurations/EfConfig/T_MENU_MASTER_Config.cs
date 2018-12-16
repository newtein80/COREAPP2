using COREAPP2.Domain.Entities.EfModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Configurations.EfConfig
{
    public class T_MENU_MASTER_Config : IEntityTypeConfiguration<T_MENU_MASTER>
    {
        public void Configure(EntityTypeBuilder<T_MENU_MASTER> builder)
        {
            builder.HasKey(e => e.MENU_IDENTITY);

            builder.Property(e => e.CREATED_DATE).HasColumnType("datetime");

            builder.Property(e => e.CSS_CLASS).HasMaxLength(64);

            builder.Property(e => e.MENU_ACTION).HasMaxLength(64);

            builder.Property(e => e.MENU_AREA).HasMaxLength(64);

            builder.Property(e => e.MENU_CONTROLLER).HasMaxLength(64);

            builder.Property(e => e.MENU_ID).HasMaxLength(64);

            builder.Property(e => e.MENU_NAME).HasMaxLength(64);

            builder.Property(e => e.PARENT_MENUID).HasMaxLength(64);

            builder.Property(e => e.USER_ROLL).HasMaxLength(450);
        }
    }
}
