using HRManagement.DAL.Abstract;
using HRManagement.DAL.Concrete.Context;
using HRManagement.DAL.Concrete.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.DependencyInjection
{
    public static class EfContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddDbContext<HrManagementDb>();
            services.AddScoped<IPackageDAL,PackageRepository>();
            services.AddScoped<IUserDAL,UserRepository>();
            services.AddScoped<ICompanyDAL, CompanyRepository>();
            services.AddScoped<IDepartmentDAL, DepartmentRepository>();
        }

    }
}
