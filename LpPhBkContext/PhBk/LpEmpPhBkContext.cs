using Microsoft.EntityFrameworkCore;
using LpPhBkEntity.PhBk;


namespace LpPhBkContext.PhBk
{
    public class LpEmpPhBkContext : DbContext
    {
        public LpEmpPhBkContext(DbContextOptions<LpEmpPhBkContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LprEmployee02>().HasKey(p => new { p.DivisionIdRef, p.EmpLastNameIdRef, p.EmpFirstNameIdRef, p.EmpSecondNameIdRef, p.EmployeeId });
            modelBuilder.Entity<LprEmployee01>().HasKey(p => new { p.EmpLastNameIdRef, p.EmpFirstNameIdRef, p.EmpSecondNameIdRef, p.EmployeeId });
            modelBuilder.Entity<LpdEmpSecondName>().HasAlternateKey(p => p.EmpSecondName).HasName("LpdEmpSecondNameUK");
            modelBuilder.Entity<LpdEmpSecondName>().HasKey(p => p.EmpSecondNameId);
            modelBuilder.Entity<LpdEmpFirstName>().HasAlternateKey(p => p.EmpFirstName).HasName("LpdEmpFirstNameUK");
            modelBuilder.Entity<LpdEmpFirstName>().HasKey(p => p.EmpFirstNameId);
            modelBuilder.Entity<LpdEmpLastName>().HasAlternateKey(p => p.EmpLastName).HasName("LpdEmpLastNameUK");
            modelBuilder.Entity<LpdEmpLastName>().HasKey(p => p.EmpLastNameId);
            modelBuilder.Entity<LprEmployee02>().HasOne(d => d.EmpLastNameDict)
                .WithMany(m => m.EmployeeRef02)
                .HasForeignKey(d => d.EmpLastNameIdRef)
                .HasPrincipalKey(p => p.EmpLastNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee02>().HasOne(d => d.EmpFirstNameDict)
                .WithMany(m => m.EmployeeRef02)
                .HasForeignKey(d => d.EmpFirstNameIdRef)
                .HasPrincipalKey(p => p.EmpFirstNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee02>().HasOne(d => d.EmpSecondNameDict)
                .WithMany(m => m.EmployeeRef02)
                .HasForeignKey(d => d.EmpSecondNameIdRef)
                .HasPrincipalKey(p => p.EmpSecondNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee01>().HasOne(d => d.EmpLastNameDict)
                .WithMany(m => m.EmployeeRef01)
                .HasForeignKey(d => d.EmpLastNameIdRef)
                .HasPrincipalKey(p => p.EmpLastNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee01>().HasOne(d => d.EmpFirstNameDict)
                .WithMany(m => m.EmployeeRef01)
                .HasForeignKey(d => d.EmpFirstNameIdRef)
                .HasPrincipalKey(p => p.EmpFirstNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee01>().HasOne(d => d.EmpSecondNameDict)
                .WithMany(m => m.EmployeeRef01)
                .HasForeignKey(d => d.EmpSecondNameIdRef)
                .HasPrincipalKey(p => p.EmpSecondNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 1,  EmpLastName = "Johnson11"  });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 2,  EmpLastName = "Stanton11"  });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 3,  EmpLastName = "Peterson11" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 4,  EmpLastName = "Johnson12" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 5,  EmpLastName = "Stanton12" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 6,  EmpLastName = "Peterson12" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 7,  EmpLastName = "Johnson13" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 8,  EmpLastName = "Stanton13" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 9,  EmpLastName = "Peterson13" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 10, EmpLastName = "Johnson21" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 11, EmpLastName = "Stanton21" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 12, EmpLastName = "Peterson21" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 13, EmpLastName = "Johnson22" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 14, EmpLastName = "Stanton22" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 15, EmpLastName = "Peterson22" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 16, EmpLastName = "Johnson23" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 17, EmpLastName = "Stanton23" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 18, EmpLastName = "Peterson23" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 19, EmpLastName = "Johnson31" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 20, EmpLastName = "Stanton31" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 21, EmpLastName = "Peterson31" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 22, EmpLastName = "Johnson32" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 23, EmpLastName = "Stanton32" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 24, EmpLastName = "Peterson32" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 25, EmpLastName = "Johnson33" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 26, EmpLastName = "Stanton33" });
            modelBuilder.Entity<LpdEmpLastName>().HasData(new { EmpLastNameId = 27, EmpLastName = "Peterson33" });

            modelBuilder.Entity<LpdEmpFirstName>().HasData(new { EmpFirstNameId = 1, EmpFirstName = "John" });
            modelBuilder.Entity<LpdEmpFirstName>().HasData(new { EmpFirstNameId = 2, EmpFirstName = "Simon" });
            modelBuilder.Entity<LpdEmpFirstName>().HasData(new { EmpFirstNameId = 3, EmpFirstName = "Peter" });

            modelBuilder.Entity<LpdEmpSecondName>().HasData(new { EmpSecondNameId = 1, EmpSecondName = "Johnovich" });
            modelBuilder.Entity<LpdEmpSecondName>().HasData(new { EmpSecondNameId = 2, EmpSecondName = "Simonovich" });
            modelBuilder.Entity<LpdEmpSecondName>().HasData(new { EmpSecondNameId = 3, EmpSecondName = "Petrovich" });


            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 1,  EmpLastNameIdRef = 1,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 2,  EmpLastNameIdRef = 2,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 3,  EmpLastNameIdRef = 3,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 4,  EmpLastNameIdRef = 4,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 5,  EmpLastNameIdRef = 5,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 6,  EmpLastNameIdRef = 6,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 7,  EmpLastNameIdRef = 7,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 8,  EmpLastNameIdRef = 8,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 9,  EmpLastNameIdRef = 9,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 10, EmpLastNameIdRef = 10, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 11, EmpLastNameIdRef = 11, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 12, EmpLastNameIdRef = 12, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 13, EmpLastNameIdRef = 13, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 14, EmpLastNameIdRef = 14, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 15, EmpLastNameIdRef = 15, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 16, EmpLastNameIdRef = 16, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 17, EmpLastNameIdRef = 17, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 18, EmpLastNameIdRef = 18, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 19, EmpLastNameIdRef = 19, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 20, EmpLastNameIdRef = 20, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 21, EmpLastNameIdRef = 21, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 22, EmpLastNameIdRef = 22, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 23, EmpLastNameIdRef = 23, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 24, EmpLastNameIdRef = 24, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 25, EmpLastNameIdRef = 25, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 26, EmpLastNameIdRef = 26, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2 });
            modelBuilder.Entity<LprEmployee01>().HasData(new { EmployeeId = 27, EmpLastNameIdRef = 27, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3 });


            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 1,  EmpLastNameIdRef = 1,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 11 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 2,  EmpLastNameIdRef = 2,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 11 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 3,  EmpLastNameIdRef = 3,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 11 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 4,  EmpLastNameIdRef = 4,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 12 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 5,  EmpLastNameIdRef = 5,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 12 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 6,  EmpLastNameIdRef = 6,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 12 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 7,  EmpLastNameIdRef = 7,  EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 13 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 8,  EmpLastNameIdRef = 8,  EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 13 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 9,  EmpLastNameIdRef = 9,  EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 13 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 10, EmpLastNameIdRef = 10, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 21 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 11, EmpLastNameIdRef = 11, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 21 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 12, EmpLastNameIdRef = 12, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 21 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 13, EmpLastNameIdRef = 13, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 22 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 14, EmpLastNameIdRef = 14, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 22 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 15, EmpLastNameIdRef = 15, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 22 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 16, EmpLastNameIdRef = 16, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 23 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 17, EmpLastNameIdRef = 17, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 23 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 18, EmpLastNameIdRef = 18, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 23 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 19, EmpLastNameIdRef = 19, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 31 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 20, EmpLastNameIdRef = 20, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 31 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 21, EmpLastNameIdRef = 21, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 31 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 22, EmpLastNameIdRef = 22, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 32 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 23, EmpLastNameIdRef = 23, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 32 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 24, EmpLastNameIdRef = 24, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 32 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 25, EmpLastNameIdRef = 25, EmpFirstNameIdRef = 1, EmpSecondNameIdRef = 1, DivisionIdRef = 33 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 26, EmpLastNameIdRef = 26, EmpFirstNameIdRef = 2, EmpSecondNameIdRef = 2, DivisionIdRef = 33 });
            modelBuilder.Entity<LprEmployee02>().HasData(new { EmployeeId = 27, EmpLastNameIdRef = 27, EmpFirstNameIdRef = 3, EmpSecondNameIdRef = 3, DivisionIdRef = 33 });
        }

        public DbSet<LpdEmpLastName> LpdEmpLastNameDbSet {
            get => Set<LpdEmpLastName>();

        }

        public DbSet<LpdEmpFirstName> LpdEmpFirstNameDbSet {
            get => Set<LpdEmpFirstName>();

        }

        public DbSet<LpdEmpSecondName> LpdEmpSecondNameDbSet {
            get => Set<LpdEmpSecondName>();

        }

        public DbSet<LprEmployee01> LprEmployee01DbSet {
            get => Set<LprEmployee01>();

        }

        public DbSet<LprEmployee02> LprEmployee02DbSet {
            get => Set<LprEmployee02>();

        }
    }
}
