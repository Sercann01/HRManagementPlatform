using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.CompanyViewModel;
using HRManagement.ViewModel.PackageVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        IPackageBLL packageBLL;
        ICompanyBLL companyBLL;

        public AdminController(IPackageBLL package, ICompanyBLL companyBLL)
        {
            this.packageBLL = package;
            this.companyBLL = companyBLL;
        }
  
        public IActionResult Index()
        {
            List<PackageVM> packageList = packageBLL.GetAllPackages();
            return View(packageList);

        }
        [HttpGet]
        public IActionResult PacketCreate()
        {


            return View();
        }
        [HttpPost]
        public IActionResult PacketCreate(PackageVM packageVM)
        {
            if (packageVM != null)
            {

                ResultService<bool> success = packageBLL.AddPackage(packageVM);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ResultService<bool> result = new ResultService<bool>();
                result.AddError("Boş Alan", "Bu alan boş bırakılamaz");
                return RedirectToAction(nameof(Index));
            }

        }

        static List<PackageVM> packageList = new List<PackageVM>();
        public IActionResult PacketList()
        {
            List<PackageVM> packageList = packageBLL.GetAllPackages();
            return View(packageList);

        }
        [HttpGet]
        public IActionResult CompaniesCreate()
        {
            ResultService<List<string>> result= packageBLL.GetPackagesNames();
            ViewBag.Packages = result.Data;
            return View();
        }
        [HttpPost]
        public IActionResult CompaniesCreate(CompanyVM companyVM)
        {
            ResultService<bool> result = companyBLL.AddCompany(companyVM);
          
            if (result.HasError)
            {
                ViewBag.Message = "Şirket eklenirken hata oluştu";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(CompaniesList));
        }

        public IActionResult CompaniesList()
        {
            ResultService<List<CompanyVM>> resultService = companyBLL.GetAllCompanies();
            if (!resultService.HasError)
            {
                return View(resultService.Data);
            }
            else
            {
                return View();
            }
        }





    }
}


