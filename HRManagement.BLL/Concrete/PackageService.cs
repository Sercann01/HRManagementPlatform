using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.PackageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class PackageService : IPackageBLL
    {
        IPackageDAL _packageDAL;
        public PackageService(IPackageDAL packageDal)
        {
            this._packageDAL = packageDal;
        }

        public ResultService<bool> AddPackage(PackageVM package)
        {
            ResultService<bool> result = new ResultService<bool>();
            try
            {
                if (package.Name != null && package.ImageURL != null && package.Price >0)
                {
                    Package addeedPackage = _packageDAL.Add(
                        new Package
                        {
                            Duration = package.Duration,
                            EndDate = package.EndDate,
                            StartDate = package.StartDate,
                            Price = package.Price,
                            IsActive = package.IsActive,
                            Name = package.Name,
                            UserNumber = package.UserNumber,
                            ImageUrl = package.ImageURL
                        });
                    result.Data = true;
                    return result;
                }

            }
            catch (Exception )
            {

                result.AddError("Boş Alan", "Bu alan boş bırakılamaz");

            }
            return result;

        }

        public List<PackageVM> GetAllPackages()
        {
            List<PackageVM> packages = _packageDAL.GetAll(a => a.IsActive)
                .OrderByDescending(a => a.Duration)
                .Select(package => new PackageVM
                {

                    Name = package.Name,
                    IsActive = package.IsActive,
                    Price = package.Price,
                    StartDate = package.StartDate,
                    EndDate = package.EndDate,
                    ImageURL = package.ImageUrl,
                    UserNumber = package.UserNumber,


                }).ToList();

            return packages;
        }

        public ResultService<List<string>> GetPackagesNames()
        {
           ResultService<List<string>> result = new ResultService<List<string>>();
            result.Data=_packageDAL.GetAll(a=>a.IsActive).Select(b=>b.Name).ToList();
            return result;
        }
    }
}
