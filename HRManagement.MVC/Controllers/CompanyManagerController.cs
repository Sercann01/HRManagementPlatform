using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.Constraints;
using HRManagement.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.UI.MVC.Controllers
{
    public class CompanyManagerController : Controller
    {
        IUserBLL _userbll;
        public CompanyManagerController(IUserBLL userBLL)
        {
            _userbll = userBLL;
        }


        public IActionResult Index()
        {

           
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserAddVM userAddVM)
        {

            if (userAddVM != null)
            {
                userAddVM.CompanyID = Convert.ToInt32(HttpContext.Session.GetString("UserCompanyID"));



                ResultService<bool> success = _userbll.AddUser(userAddVM);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        public IActionResult UserList()
        {
            List<UserListVM> userList = _userbll.GetUserList();
            return View(userList);
        }
        public IActionResult UserDetail()
        {
            return View();
        }
        public IActionResult UpdateUser()
        {
            return View();
        }
    }
}
