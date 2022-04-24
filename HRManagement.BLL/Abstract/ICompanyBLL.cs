using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Core.Entity;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.CompanyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface ICompanyBLL
    {
        ResultService<List<CompanyVM>> GetAllCompanies();
        ResultService<bool> AddCompany(CompanyVM company);
    }
}
