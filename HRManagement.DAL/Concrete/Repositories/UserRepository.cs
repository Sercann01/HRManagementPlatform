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
   public class UserRepository : EFRepositoryBase<User, HrManagementDb>, IUserDAL
    {
        public UserRepository(HrManagementDb context) : base(context)
        {

        }
    }
}
