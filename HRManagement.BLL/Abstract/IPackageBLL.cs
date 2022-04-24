using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.ViewModel.PackageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface IPackageBLL 
    {
        List<PackageVM> GetAllPackages();
        ResultService<bool> AddPackage(PackageVM package);
        ResultService<List<string>> GetPackagesNames();

    }
}
