using HRManagement.DAL.Concrete.Context.EntityTypeConfiguration;
using HRManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Context
{
    public class HrManagementDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=insankaynakdb.database.windows.net; Database= HrManagementDb; User Id=insankaynaklarıyönetimiproje;Password=Proje123;");
            //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=HRProject;Trusted_Connection=True;");
        }

        DbSet<Package> Packages { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Department> Departments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            modelBuilder.Entity<User>()
            .HasOne(p => p.Department)
            .WithMany(b => b.Users)
            .HasForeignKey(p => p.DepartmentID);




        }


    }
}
