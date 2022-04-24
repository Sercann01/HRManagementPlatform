using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.CompanyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class CompanyService : ICompanyBLL
    {
        ICompanyDAL _companydal;
        IPackageDAL _packageDAL;
        public CompanyService(ICompanyDAL companydal,IPackageDAL packageDAL)
        {
            _companydal = companydal;
            _packageDAL = packageDAL;
        }

        public ResultService< bool> AddCompany(CompanyVM company)
        {

            ResultService<bool> result = new ResultService<bool>();
            try
            {
                if (company.Name != null && company.Address != null && company.TaxId != null )
                {
                    Company addeedPackage = _companydal.Add(
                        new Company
                        {
                            CompanyName = company.Name,
                            CompanyType = company.CompanyType,
                            Address = company.Address,
                            ImageUrl = company.ImageURL,
                            MailExtension = company.MailExtension,
                            TaxId = company.TaxId,
                            PackageId = _packageDAL.Get(a=>a.Name==company.PackageId).Id,
                            PhoneNumber = company.PhoneNumber,
                            Users= company.Users,
                            RegisterDate= company.RegisterDate,
                            DatePurchased= company.DatePurchased
                            
                        });
                    result.Data = true;
                    return result;
                }

            }
            catch (Exception)
            {

                result.AddError("Boş Alan", "Bu alan boş bırakılamaz");

            }
            return result;

        }



        public ResultService<List<CompanyVM>> GetAllCompanies()
        {
            ResultService<List<CompanyVM>> resultService = new ResultService<List<CompanyVM>>();
            try
            {
                List<CompanyVM> companies = _companydal.GetAll(a => a.CompanyName != null)
                .OrderByDescending(a => a.Id)
                .Select(company => new CompanyVM
                {
                    Id = company.Id,
                    Name = company.CompanyName,
                    Address = company.Address,
                    CompanyType = company.CompanyType,
                    MailExtension = company.MailExtension,
                    PhoneNumber = company.PhoneNumber,
                    RegisterDate = company.RegisterDate,
                    DatePurchased = company.DatePurchased,
                    TaxId = company.TaxId,
                    ImageURL = company.ImageUrl == null ? "değer yok" : company.ImageUrl.ToString(),
                    UserId = company.Users.Where(a => a.CompanyId == company.Id).Select(a => a.Id).SingleOrDefault(),
                    PackageId = company.PackageId == null ? "Paket yok!" : company.PackageId.ToString()
                }).ToList();
                resultService.Data = companies;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;


        }






    }
}
