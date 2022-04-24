using HRManagement.BLL.Abstract;
using HRManagement.MVC.Models;
using HRManagement.ViewModel.PackageVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IPackageBLL packageBLL; 

        public HomeController(ILogger<HomeController> logger,IPackageBLL packageBLL)
        {
            _logger = logger;
            this.packageBLL = packageBLL;
        }

        public IActionResult Index()
        {
            List<PackageVM> packageList = packageBLL.GetAllPackages();
            return View(packageList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
