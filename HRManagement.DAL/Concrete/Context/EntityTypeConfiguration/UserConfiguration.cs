using HRManagement.Model.Entities;
using HRManagement.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Context.EntityTypeConfiguration
{
     class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(18);            

            builder.HasIndex(a => a.Email)
                .IsUnique();

          

           

           
            

            //builder.HasData(new User
            //{
            //    Id = 1,
            //    FirstName = "admin",
            //    LastName = "admin",
            //    Email = "admin@bilgeadam.com",
            //    Password = "admin",
            //    Address = "Bilgeadam",
            //    Role = UserRole.Admin,
            //    IsActive = true,
            //   CompanyName ="admin",
            //   EstablishmentDate = DateTime.Now,
            //   CompanyType =CompanyType.Sahis,
            //   PhoneNumber ="55555555",
            //   TaxId ="55555555"
            //});
        }
    }
}
