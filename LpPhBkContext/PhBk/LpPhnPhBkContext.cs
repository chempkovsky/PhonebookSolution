using Microsoft.EntityFrameworkCore;
using LpPhBkEntity.PhBk;

namespace LpPhBkContext.PhBk
{
    public class LpPhnPhBkContext : DbContext
    {

        public LpPhnPhBkContext(DbContextOptions<LpPhnPhBkContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

        //////////////////////////////////////////////////////////////////
        /// reset ".UseSqlServer"
        /// reset "ConfigurationManager.ConnectionStrings"
        /// optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        /////////////////////////////////////////////////////////////////
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        // }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LprPhone04>().HasKey(p => new { p.EmployeeIdRef, p.PhoneTypeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone03>().HasKey(p => new { p.PhoneTypeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone02>().HasKey(p => new { p.EmployeeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone01>().HasKey(p => new { p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LpdPhone>().HasAlternateKey(p => p.Phone).HasName("LpdPhoneUK");
            modelBuilder.Entity<LpdPhone>().HasKey(p => p.LpdPhoneId);

            modelBuilder.Entity<LprPhone01>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef01)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone02>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef02)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone03>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef03)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone04>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef04)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            int k = 1;
            for (int i = 1; i < 28; i++)
            {
                for (int t = 1; t < 5; t++)
                {
                    modelBuilder.Entity<LpdPhone>().HasData(new { LpdPhoneId = k, Phone = "+375(29)" + t + "0111" + i.ToString("D2") });
                    modelBuilder.Entity<LprPhone01>().HasData(new { LpdPhoneIdRef = k, PhoneId = k });
                    modelBuilder.Entity<LprPhone02>().HasData(new { LpdPhoneIdRef = k, PhoneId = k, EmployeeIdRef = i });
                    modelBuilder.Entity<LprPhone03>().HasData(new { LpdPhoneIdRef = k, PhoneId = k, PhoneTypeIdRef = t });
                    modelBuilder.Entity<LprPhone04>().HasData(new { LpdPhoneIdRef = k, PhoneId = k, EmployeeIdRef = i, PhoneTypeIdRef = t });
                    k++;
                }
            }

        }
        public DbSet<LpdPhone> LpdPhoneDbSet {
            get => Set<LpdPhone>();

        }

        public DbSet<LprPhone01> LprPhone01DbSet {
            get => Set<LprPhone01>();

        }

        public DbSet<LprPhone02> LprPhone02DbSet {
            get => Set<LprPhone02>();

        }

        public DbSet<LprPhone03> LprPhone03DbSet {
            get => Set<LprPhone03>();

        }

        public DbSet<LprPhone04> LprPhone04DbSet {
            get => Set<LprPhone04>();

        }
    }
}