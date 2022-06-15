#nullable disable

using Microsoft.EntityFrameworkCore;
using PhBkEntity.Auth;

/*
    This is a dummy(mock) class, and you must remove it from the project after generating the user interface.
*/

namespace PhBkContext.Auth
{
    public class aspnetchckdbcontext : DbContext
    {

        public aspnetchckdbcontext(DbContextOptions<aspnetchckdbcontext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnetmodel>().HasKey(p => p.ModelPk);
            modelBuilder.Entity<aspnetrolemask>().HasKey(p => new { p.RoleName, p.ModelPkRef });

            modelBuilder.Entity<aspnetrolemask>()
                .HasOne(d => d.AspNetModel)
                .WithMany(m => m.RoleMasks)
                .HasForeignKey(d => d.ModelPkRef)
                .HasPrincipalKey(p => p.ModelPk)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 1, ModelName = "PhbkPhoneTypeView", ModelDescription = "Phone Type" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 2, ModelName = "PhbkEnterpriseView", ModelDescription = "Enterprise" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 3, ModelName = "PhbkDivisionView", ModelDescription = "Division" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 4, ModelName = "LpdDivisionView", ModelDescription = "Division Name" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 5, ModelName = "LprDivision01View", ModelDescription = "Division Name ref01" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 6, ModelName = "LprDivision02View", ModelDescription = "Division Name ref02" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 7, ModelName = "PhbkEmployeeView", ModelDescription = "Employee" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 8, ModelName = "LpdEmpLastNameView", ModelDescription = "Last Name" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 9, ModelName = "LpdEmpFirstNameView", ModelDescription = "First Name" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 10, ModelName = "LpdEmpSecondNameView", ModelDescription = "Second Name" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 11, ModelName = "LprEmployee01View", ModelDescription = "Employee Dict Ref" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 12, ModelName = "LprEmployee02View", ModelDescription = "Employee Dict Ref" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 13, ModelName = "PhbkPhoneView", ModelDescription = "Phone" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 14, ModelName = "LpdPhoneView", ModelDescription = "Phone" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 15, ModelName = "LprPhone01View", ModelDescription = "Phone Dict Ref" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 16, ModelName = "LprPhone02View", ModelDescription = "Phone Dict Ref" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 17, ModelName = "LprPhone03View", ModelDescription = "Phone Dict Ref" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 18, ModelName = "LprPhone04View", ModelDescription = "Phone Dict Ref" });

            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 19, ModelName = "aspnetmodelView", ModelDescription = "Model" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 20, ModelName = "aspnetroleView", ModelDescription = "Role" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 21, ModelName = "aspnetrolemaskView", ModelDescription = "Role Mask" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 22, ModelName = "aspnetuserView", ModelDescription = "User" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 23, ModelName = "aspnetusermaskView", ModelDescription = "User Mask" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 24, ModelName = "aspnetuserpermsView", ModelDescription = "User perm" });
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 25, ModelName = "aspnetuserrolesView", ModelDescription = "User Role" });

            // features
            modelBuilder.Entity<aspnetmodel>().HasData(new { ModelPk = 26, ModelName = "SimpleDictionaryFtrComponent", ModelDescription = "Simple feature" });

            for (int i = 1; i < 26; i++)
            {
                modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "AdminRole", RoleDescription = "AdminRole", ModelPkRef = i, Mask1 = true, Mask2 = true, Mask3 = true, Mask4 = true, Mask5 = true });
            }
            // features
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "AdminRole", RoleDescription = "AdminRole", ModelPkRef = 26, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });


            // 1 "PhbkPhoneTypeView"
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 1, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = true });
            // 2 "PhbkEnterpriseView"
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 2, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });
            // 3 "PhbkDivisionView"
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 3, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });
            // 7 "PhbkEmployeeView"
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 7, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });
            // 13 "PhbkPhoneView"
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 13, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });

            // features
            modelBuilder.Entity<aspnetrolemask>().HasData(new { RoleName = "GuestRole", RoleDescription = "GuestRole", ModelPkRef = 26, Mask1 = true, Mask2 = false, Mask3 = false, Mask4 = false, Mask5 = false });

        }

        public DbSet< aspnetmodel > aspnetmodellDbSet
        {
            get;
            set;
        }

        public DbSet< aspnetrolemask > aspnetrolemaskDbSet
        {
            get;
            set;
        }


    }
}

