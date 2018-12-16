using System;
using COREAPP2.Domain.Entities.SpModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace COREAPP2.Persistence.DbContexts
{
    public partial class SpDbContext : DbContext
    {
        public SpDbContext()
        {
        }

        public SpDbContext(DbContextOptions<SpDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<T_COMP_INFO> T_COMP_INFO { get; set; }
        public virtual DbSet<T_VULN> T_VULN { get; set; }
        public virtual DbSet<T_VULN_GROUP> T_VULN_GROUP { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=PARKJS\\SQLEXPRESS;Initial Catalog=COREAPP;User ID=sa;Password=#skdlf12;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
