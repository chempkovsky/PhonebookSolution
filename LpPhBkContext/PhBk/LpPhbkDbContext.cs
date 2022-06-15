using Microsoft.EntityFrameworkCore;
using LpPhBkEntity.PhBk;


namespace LpPhBkContext.PhBk
{
    public class LpPhbkDbContext : DbContext
    {
        public LpPhbkDbContext(DbContextOptions<LpPhbkDbContext> options)
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
            modelBuilder.Entity<LprDivision02>().HasKey(p => new { p.EntrprsIdRef, p.DivisionNameIdRef, p.DivisionId });
            modelBuilder.Entity<LprDivision01>().HasKey(p => new { p.DivisionNameIdRef, p.DivisionId });
            modelBuilder.Entity<LpdDivision>().HasAlternateKey(p => p.DivisionName).HasName("LpdDivisionNameUk");
            modelBuilder.Entity<LpdDivision>().HasKey(p => p.DivisionNameId);
            modelBuilder.Entity<LprDivision01>().HasOne(d => d.DivisionNameDict)
                .WithMany(m => m.DivisionRef01)
                .HasForeignKey(d => d.DivisionNameIdRef)
                .HasPrincipalKey(p => p.DivisionNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprDivision02>().HasOne(d => d.DivisionNameDict)
                .WithMany(m => m.DivisionRef02)
                .HasForeignKey(d => d.DivisionNameIdRef)
                .HasPrincipalKey(p => p.DivisionNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 1,  DivisionName = "Division 11"  });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 2,  DivisionName = "Division 12" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 3,  DivisionName = "Division 13" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 4,  DivisionName = "Division 14" });

            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 5,  DivisionName = "Division 21" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 6,  DivisionName = "Division 22" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 7,  DivisionName = "Division 23" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 8,  DivisionName = "Division 24" });

            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 9,  DivisionName = "Division 31" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 10, DivisionName = "Division 32" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 11, DivisionName = "Division 33" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 12, DivisionName = "Division 34" });

            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 13, DivisionName = "Division 41" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 14, DivisionName = "Division 42" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 15, DivisionName = "Division 43" });
            modelBuilder.Entity<LpdDivision>().HasData(new { DivisionNameId = 16, DivisionName = "Division 44" });

            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 11, DivisionNameIdRef = 1 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 12, DivisionNameIdRef = 2 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 13, DivisionNameIdRef = 3 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 14, DivisionNameIdRef = 4 });

            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 21, DivisionNameIdRef = 5 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 22, DivisionNameIdRef = 6 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 23, DivisionNameIdRef = 7 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 24, DivisionNameIdRef = 8 });

            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 31, DivisionNameIdRef = 9   });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 32, DivisionNameIdRef = 10  });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 33, DivisionNameIdRef = 11  });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 34, DivisionNameIdRef = 12  });

            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 41, DivisionNameIdRef = 13 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 42, DivisionNameIdRef = 14 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 43, DivisionNameIdRef = 15 });
            modelBuilder.Entity<LprDivision01>().HasData(new { DivisionId = 44, DivisionNameIdRef = 16 });

            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 11, DivisionNameIdRef = 1,  EntrprsIdRef = 1 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 12, DivisionNameIdRef = 2,  EntrprsIdRef = 1 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 13, DivisionNameIdRef = 3,  EntrprsIdRef = 1 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 14, DivisionNameIdRef = 4,  EntrprsIdRef = 1 });

            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 21, DivisionNameIdRef = 5,  EntrprsIdRef = 2 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 22, DivisionNameIdRef = 6,  EntrprsIdRef = 2 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 23, DivisionNameIdRef = 7,  EntrprsIdRef = 2 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 24, DivisionNameIdRef = 8,  EntrprsIdRef = 2 });

            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 31, DivisionNameIdRef = 9,  EntrprsIdRef = 3 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 32, DivisionNameIdRef = 10, EntrprsIdRef = 3 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 33, DivisionNameIdRef = 11, EntrprsIdRef = 3 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 34, DivisionNameIdRef = 12, EntrprsIdRef = 3 });

            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 41, DivisionNameIdRef = 13, EntrprsIdRef = 4 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 42, DivisionNameIdRef = 14, EntrprsIdRef = 4 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 43, DivisionNameIdRef = 15, EntrprsIdRef = 4 });
            modelBuilder.Entity<LprDivision02>().HasData(new { DivisionId = 44, DivisionNameIdRef = 16, EntrprsIdRef = 4 });


        }

        public DbSet<LpdDivision> LpdDivisionDbSet {
            get => Set<LpdDivision>();

        }

        public DbSet<LprDivision01> LprDivision01DbSet {
            get => Set<LprDivision01>();

        }

        public DbSet<LprDivision02> LprDivision02DbSet {
            get => Set<LprDivision02>();

        }
    }
}
