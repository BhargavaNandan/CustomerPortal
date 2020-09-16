using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Data.Models
{
    public partial class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblCustomerType> TblCustomerType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=bbvn.database.windows.net;Initial Catalog=Customer;Persist Security Info=False;User ID=bbvn;Password=Welcome@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("tbl_Customer");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblCustomerType>(entity =>
            {
                entity.ToTable("tbl_CustomerType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
