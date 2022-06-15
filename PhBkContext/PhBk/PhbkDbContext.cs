using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using PhBkEntity.PhBk;



namespace PhBkContext.PhBk
{
    public class PhbkDbContext : DbContext
    {

        public PhbkDbContext(DbContextOptions<PhbkDbContext> options)
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
            modelBuilder.Entity<PhbkPhone>().HasKey(p => p.PhoneId);
            modelBuilder.Entity<PhbkPhone>().HasOne(d => d.PhoneType)
                .WithMany(m => m.Phones)
                .HasForeignKey(d => d.PhoneTypeIdRef)
                .HasPrincipalKey(p => p.PhoneTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PhbkPhone>().HasOne(d => d.Employee)
                .WithMany(m => m.Phones)
                .HasForeignKey(d => d.EmployeeIdRef)
                .HasPrincipalKey(p => p.EmployeeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PhbkEmployee>().HasKey(p => p.EmployeeId);
            modelBuilder.Entity<PhbkDivision>().HasKey(p => p.DivisionId);
            modelBuilder.Entity<PhbkEnterprise>().HasAlternateKey(p => p.EntrprsName).HasName("EntrprsNameUK");
            modelBuilder.Entity<PhbkEnterprise>().HasKey(p => p.EntrprsId);
            modelBuilder.Entity<PhbkPhoneType>().HasKey(p => p.PhoneTypeId);
            modelBuilder.Entity<PhbkDivision>().HasOne(d => d.Enterprise)
                .WithMany(m => m.Divisions)
                .HasForeignKey(d => d.EntrprsIdRef)
                .HasPrincipalKey(p => p.EntrprsId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PhbkEmployee>().HasOne(d => d.Division)
                .WithMany(m => m.Employees)
                .HasForeignKey(d => d.DivisionIdRef)
                .HasPrincipalKey(p => p.DivisionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
#if (!NOTMODELING)
            modelBuilder.Entity<LprPhone04>().HasKey(p => new { p.EmployeeIdRef, p.PhoneTypeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone03>().HasKey(p => new { p.PhoneTypeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone02>().HasKey(p => new { p.EmployeeIdRef, p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LprPhone01>().HasKey(p => new { p.LpdPhoneIdRef, p.PhoneId });
            modelBuilder.Entity<LpdPhone>().HasAlternateKey(p => p.Phone).HasName("LpdPhoneUK");
            modelBuilder.Entity<LpdPhone>().HasKey(p => p.LpdPhoneId);

            modelBuilder.Entity<LprEmployee02>().HasKey(p => new { p.DivisionIdRef, p.EmpLastNameIdRef, p.EmpFirstNameIdRef, p.EmpSecondNameIdRef, p.EmployeeId });
            modelBuilder.Entity<LprEmployee01>().HasKey(p => new { p.EmpLastNameIdRef, p.EmpFirstNameIdRef, p.EmpSecondNameIdRef, p.EmployeeId });
            modelBuilder.Entity<LpdEmpSecondName>().HasAlternateKey(p => p.EmpSecondName).HasName("LpdEmpSecondNameUK");
            modelBuilder.Entity<LpdEmpSecondName>().HasKey(p => p.EmpSecondNameId);
            modelBuilder.Entity<LpdEmpFirstName>().HasAlternateKey(p => p.EmpFirstName).HasName("LpdEmpFirstNameUK");
            modelBuilder.Entity<LpdEmpFirstName>().HasKey(p => p.EmpFirstNameId);
            modelBuilder.Entity<LpdEmpLastName>().HasAlternateKey(p => p.EmpLastName).HasName("LpdEmpLastNameUK");
            modelBuilder.Entity<LpdEmpLastName>().HasKey(p => p.EmpLastNameId);

            modelBuilder.Entity<LprDivision02>().HasKey(p => new { p.EntrprsIdRef, p.DivisionNameIdRef, p.DivisionId });
            modelBuilder.Entity<LprDivision01>().HasKey(p => new { p.DivisionNameIdRef, p.DivisionId });
            modelBuilder.Entity<LpdDivision>().HasAlternateKey(p => p.DivisionName).HasName("LpdDivisionNameUk");
            modelBuilder.Entity<LpdDivision>().HasKey(p => p.DivisionNameId);
            modelBuilder.Entity<LprDivision01>().HasOne(d => d.Division)
                .WithMany(m => m.DivisionRefs01)
                .HasForeignKey(d => d.DivisionId)
                .HasPrincipalKey(p => p.DivisionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprDivision01>().HasOne(d => d.DivisionNameDict)
                .WithMany(m => m.DivisionRef01)
                .HasForeignKey(d => d.DivisionNameIdRef)
                .HasPrincipalKey(p => p.DivisionNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprDivision02>().HasOne(d => d.Division)
                .WithMany(m => m.DivisionRefs02)
                .HasForeignKey(d => d.DivisionId)
                .HasPrincipalKey(p => p.DivisionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprDivision02>().HasOne(d => d.Enterprise)
                .WithMany(m => m.DivisionRefs02)
                .HasForeignKey(d => d.EntrprsIdRef)
                .HasPrincipalKey(p => p.EntrprsId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprDivision02>().HasOne(d => d.DivisionNameDict)
                .WithMany(m => m.DivisionRef02)
                .HasForeignKey(d => d.DivisionNameIdRef)
                .HasPrincipalKey(p => p.DivisionNameId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprEmployee01>().HasOne(d => d.Employee)
                .WithMany(m => m.EmployeeRefs01)
                .HasForeignKey(d => d.EmployeeId)
                .HasPrincipalKey(p => p.EmployeeId)
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
            modelBuilder.Entity<LprEmployee02>().HasOne(d => d.Employee)
                .WithMany(m => m.EmployeeRefs02)
                .HasForeignKey(d => d.EmployeeId)
                .HasPrincipalKey(p => p.EmployeeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
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
            modelBuilder.Entity<LprEmployee02>().HasOne(d => d.Division)
                .WithMany(m => m.EmployeeRefs02)
                .HasForeignKey(d => d.DivisionIdRef)
                .HasPrincipalKey(p => p.DivisionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone01>().HasOne(d => d.Phone)
                .WithMany(m => m.PhoneRefs01)
                .HasForeignKey(d => d.PhoneId)
                .HasPrincipalKey(p => p.PhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone01>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef01)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone02>().HasOne(d => d.Phone)
                .WithMany(m => m.PhoneRefs02)
                .HasForeignKey(d => d.PhoneId)
                .HasPrincipalKey(p => p.PhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone02>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef02)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone02>().HasOne(d => d.Employee)
                .WithMany(m => m.PhoneRefs02)
                .HasForeignKey(d => d.EmployeeIdRef)
                .HasPrincipalKey(p => p.EmployeeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone03>().HasOne(d => d.Phone)
                .WithMany(m => m.PhoneRefs03)
                .HasForeignKey(d => d.PhoneId)
                .HasPrincipalKey(p => p.PhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone03>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef03)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone03>().HasOne(d => d.PhoneType)
                .WithMany(m => m.PhoneRefs03)
                .HasForeignKey(d => d.PhoneTypeIdRef)
                .HasPrincipalKey(p => p.PhoneTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone04>().HasOne(d => d.PhoneDict)
                .WithMany(m => m.PhoneRef04)
                .HasForeignKey(d => d.LpdPhoneIdRef)
                .HasPrincipalKey(p => p.LpdPhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone04>().HasOne(d => d.Phone)
                .WithMany(m => m.PhoneRefs04)
                .HasForeignKey(d => d.PhoneId)
                .HasPrincipalKey(p => p.PhoneId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone04>().HasOne(d => d.Employee)
                .WithMany(m => m.PhoneRefs04)
                .HasForeignKey(d => d.EmployeeIdRef)
                .HasPrincipalKey(p => p.EmployeeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LprPhone04>().HasOne(d => d.PhoneType)
                .WithMany(m => m.PhoneRefs04)
                .HasForeignKey(d => d.PhoneTypeIdRef)
                .HasPrincipalKey(p => p.PhoneTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

#endif
            modelBuilder.Entity<PhbkPhoneType>().HasData(new { PhoneTypeId = 1, PhoneTypeName = "Office phone", PhoneTypeDesc = "Office phone (one or more than one)" });
            modelBuilder.Entity<PhbkPhoneType>().HasData(new { PhoneTypeId = 2, PhoneTypeName = "Home phone", PhoneTypeDesc = "Home phone (one or more than one)" });
            modelBuilder.Entity<PhbkPhoneType>().HasData(new { PhoneTypeId = 3, PhoneTypeName = "Office mobile", PhoneTypeDesc = "Office mobile phone (one or more than one)" });
            modelBuilder.Entity<PhbkPhoneType>().HasData(new { PhoneTypeId = 4, PhoneTypeName = "Personal mobile", PhoneTypeDesc = "Personal mobile phone (one or more than one)" });
            modelBuilder.Entity<PhbkEnterprise>().HasData(new { EntrprsId = 1, EntrprsName = "Enterprise 1", EntrprsDesc = "Short description for Enterprise 1" });
            modelBuilder.Entity<PhbkEnterprise>().HasData(new { EntrprsId = 2, EntrprsName = "Enterprise 2", EntrprsDesc = "Short description for Enterprise 2" });
            modelBuilder.Entity<PhbkEnterprise>().HasData(new { EntrprsId = 3, EntrprsName = "Enterprise 3", EntrprsDesc = "Short description for Enterprise 3" });
            modelBuilder.Entity<PhbkEnterprise>().HasData(new { EntrprsId = 4, EntrprsName = "Enterprise 4", EntrprsDesc = "Short description for Enterprise 4" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 11, EntrprsIdRef = 1, DivisionName = "Division 11", DivisionDesc = "Short description for Division 11" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 12, EntrprsIdRef = 1, DivisionName = "Division 12", DivisionDesc = "Short description for Division 12" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 13, EntrprsIdRef = 1, DivisionName = "Division 13", DivisionDesc = "Short description for Division 13" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 14, EntrprsIdRef = 1, DivisionName = "Division 14", DivisionDesc = "Short description for Division 14" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 21, EntrprsIdRef = 2, DivisionName = "Division 21", DivisionDesc = "Short description for Division 21" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 22, EntrprsIdRef = 2, DivisionName = "Division 22", DivisionDesc = "Short description for Division 22" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 23, EntrprsIdRef = 2, DivisionName = "Division 23", DivisionDesc = "Short description for Division 23" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 24, EntrprsIdRef = 2, DivisionName = "Division 24", DivisionDesc = "Short description for Division 24" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 31, EntrprsIdRef = 3, DivisionName = "Division 31", DivisionDesc = "Short description for Division 31" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 32, EntrprsIdRef = 3, DivisionName = "Division 32", DivisionDesc = "Short description for Division 32" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 33, EntrprsIdRef = 3, DivisionName = "Division 33", DivisionDesc = "Short description for Division 33" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 34, EntrprsIdRef = 3, DivisionName = "Division 34", DivisionDesc = "Short description for Division 34" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 41, EntrprsIdRef = 4, DivisionName = "Division 41", DivisionDesc = "Short description for Division 41" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 42, EntrprsIdRef = 4, DivisionName = "Division 42", DivisionDesc = "Short description for Division 42" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 43, EntrprsIdRef = 4, DivisionName = "Division 43", DivisionDesc = "Short description for Division 43" });
            modelBuilder.Entity<PhbkDivision>().HasData(new { DivisionId = 44, EntrprsIdRef = 4, DivisionName = "Division 44", DivisionDesc = "Short description for Division 44" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 1, DivisionIdRef = 11, EmpFirstName = "John", EmpLastName = "Johnson11", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 2, DivisionIdRef = 11, EmpFirstName = "Simon", EmpLastName = "Stanton11", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 3, DivisionIdRef = 11, EmpFirstName = "Peter", EmpLastName = "Peterson11", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 4, DivisionIdRef = 12, EmpFirstName = "John", EmpLastName = "Johnson12", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 5, DivisionIdRef = 12, EmpFirstName = "Simon", EmpLastName = "Stanton12", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 6, DivisionIdRef = 12, EmpFirstName = "Peter", EmpLastName = "Peterson12", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 7, DivisionIdRef = 13, EmpFirstName = "John", EmpLastName = "Johnson13", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 8, DivisionIdRef = 13, EmpFirstName = "Simon", EmpLastName = "Stanton13", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 9, DivisionIdRef = 13, EmpFirstName = "Peter", EmpLastName = "Peterson13", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 10, DivisionIdRef = 21, EmpFirstName = "John", EmpLastName = "Johnson21", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 11, DivisionIdRef = 21, EmpFirstName = "Simon", EmpLastName = "Stanton21", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 12, DivisionIdRef = 21, EmpFirstName = "Peter", EmpLastName = "Peterson21", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 13, DivisionIdRef = 22, EmpFirstName = "John", EmpLastName = "Johnson22", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 14, DivisionIdRef = 22, EmpFirstName = "Simon", EmpLastName = "Stanton22", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 15, DivisionIdRef = 22, EmpFirstName = "Peter", EmpLastName = "Peterson22", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 16, DivisionIdRef = 23, EmpFirstName = "John", EmpLastName = "Johnson23", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 17, DivisionIdRef = 23, EmpFirstName = "Simon", EmpLastName = "Stanton23", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 18, DivisionIdRef = 23, EmpFirstName = "Peter", EmpLastName = "Peterson23", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 19, DivisionIdRef = 31, EmpFirstName = "John", EmpLastName = "Johnson31", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 20, DivisionIdRef = 31, EmpFirstName = "Simon", EmpLastName = "Stanton31", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 21, DivisionIdRef = 31, EmpFirstName = "Peter", EmpLastName = "Peterson31", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 22, DivisionIdRef = 32, EmpFirstName = "John", EmpLastName = "Johnson32", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 23, DivisionIdRef = 32, EmpFirstName = "Simon", EmpLastName = "Stanton32", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 24, DivisionIdRef = 32, EmpFirstName = "Peter", EmpLastName = "Peterson32", EmpSecondName = "Petrovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 25, DivisionIdRef = 33, EmpFirstName = "John", EmpLastName = "Johnson33", EmpSecondName = "Johnovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 26, DivisionIdRef = 33, EmpFirstName = "Simon", EmpLastName = "Stanton33", EmpSecondName = "Simonovich" });
            modelBuilder.Entity<PhbkEmployee>().HasData(new { EmployeeId = 27, DivisionIdRef = 33, EmpFirstName = "Peter", EmpLastName = "Peterson33", EmpSecondName = "Petrovich" });
            int k = 1;
            for (int i = 1; i < 28; i++)
            {
                for (int t = 1; t < 5; t++)
                {
                    modelBuilder.Entity<PhbkPhone>().HasData(new { PhoneId = k, Phone = "+375(29)" + t + "0111" + i.ToString("D2"), PhoneTypeIdRef = t, EmployeeIdRef = i });
                    k++;
                }
            }
        }

        public DbSet<PhbkPhoneType> PhbkPhoneTypeDbSet {
            get => Set<PhbkPhoneType>();

        }

        public DbSet<PhbkEnterprise> PhbkEnterpriseDbSet {
            get => Set<PhbkEnterprise>();

        }

        public DbSet<PhbkDivision> PhbkDivisionDbSet {
            get => Set<PhbkDivision>();

        }
        public DbSet<PhbkEmployee> PhbkEmployeeDbSet {
            get => Set<PhbkEmployee>();

        }

        public DbSet<PhbkPhone> PhbkPhoneDbSet {
            get => Set<PhbkPhone>();

        }

#if (!NOTMODELING)
        public DbSet<LpdDivision> LpdDivisionDbSet {
            get => Set<LpdDivision>();

        }

        public DbSet<LprDivision01> LprDivision01DbSet {
            get => Set<LprDivision01>();

        }

        public DbSet<LprDivision02> LprDivision02DbSet {
            get => Set<LprDivision02>();

        }


        public DbSet<LpdEmpFirstName> LpdEmpFirstNameDbSet {
            get => Set<LpdEmpFirstName>();

        }

        public DbSet<LpdEmpLastName> LpdEmpLastNameDbSet {
            get => Set<LpdEmpLastName>();

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
#endif
    }
}
