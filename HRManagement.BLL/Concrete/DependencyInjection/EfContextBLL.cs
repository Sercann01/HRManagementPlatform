using HRManagement.BLL.Abstract;
using HRManagement.DAL.Abstract;
using HRManagement.DAL.Concrete.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete.DependencyInjection
{
    public static class EfContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IPackageBLL, PackageService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<ICompanyBLL, CompanyService>();
        }
    }
}
