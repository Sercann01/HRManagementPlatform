using HRManagement.Core.DataAccess.EntityFramework;
using HRManagement.DAL.Abstract;
using HRManagement.DAL.Concrete.Context;
using HRManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Repositories
{
    public class PackageRepository :EFRepositoryBase<Package,HrManagementDb>,IPackageDAL
    {
        public PackageRepository(HrManagementDb context) : base(context)
        {

        }
        

        
    }
}
