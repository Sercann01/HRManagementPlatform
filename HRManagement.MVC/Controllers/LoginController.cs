using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.Constraints;
using HRManagement.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManagement.UI.MVC.Helpers;
using HRManagement.BLL.Concrete.SendMailService;

namespace HRManagement.UI.MVC.Controllers
{
    public class LoginController : Controller
    {
        IUserBLL _userbll;
        public LoginController(IUserBLL userbll)
        {
            _userbll = userbll;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Cookies["cookie"] != null)
            {
                string bilgi = Request.Cookies["cookie"];
                string[] bilgiParcasi = bilgi.Split("|");
                UserLoginVM userLogin = new UserLoginVM();
                userLogin.Email = bilgiParcasi[0];
                userLogin.Password = bilgiParcasi[1];
                userLogin.IsRemember = true;
                return View(userLogin);
            }
            return View();

        }

        [HttpPost]
        public IActionResult Index(UserLoginVM user)
        {

            if (user.IsRemember)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(10);

                Response.Cookies.Append("cookie", user.Email + "|" + user.Password, cookieOptions);
            }
            else
            {
                //Cookie nasıl silinir.
            }
            if (ModelState.IsValid)
            {
                ResultService<UserRole> userRole = _userbll.CheckUserForLogin(user.Email, user.Password);
                ResultService<bool> userMessage = _userbll.CheckUserLogin(user.Email, user.Password);
                if (userMessage.HasError)
                {
                    ViewBag.Message = UserMessage.LoginMessage;
                }
                else
                {
                    if (userRole.Data == UserRole.Admin)
                    {
                        UserInfoVM userInfo = _userbll.GetUserInfo(user.Email);
                        HttpContext.Session.SetString("UserName", userInfo.Name);
                        HttpContext.Session.SetString("UserRole", userInfo.UserRole.ToString());
                        HttpContext.Session.SetString("UserImage", userInfo.ImageUrl);
                      
                        return RedirectToAction(nameof(Index), "Admin");
                    }
                    else if (userRole.Data == UserRole.Manager)
                    {
                        UserInfoVM userInfo = _userbll.GetUserInfo(user.Email);
                        HttpContext.Session.SetString("UserName", userInfo.Name);
                        HttpContext.Session.SetString("UserRole", userInfo.UserRole.ToString());
                        HttpContext.Session.SetString("UserImage", userInfo.ImageUrl);
                        HttpContext.Session.SetString("UserCompanyID", userInfo.CompanyID.ToString());
                        return RedirectToAction(nameof(Index), "CompanyManager");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index), "Home");

                    }

                }
            }
            return View();

        }

        public IActionResult ForgetPassword()
        {
            return PartialView("ForgetPassword");
        }

        [HttpPost]
        public IActionResult ForgetPassword(UserLoginVM userLoginVM)
        {
            try
            {
                UserInfoVM user = _userbll.GetUserInfo(userLoginVM.Email);
                if (user == null)
                {
                    throw new Exception("Böyle bir kullanıcı bulunamadı");
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    string password = id.ToString().Substring(0, 8);
                    _userbll.ChangePassword(userLoginVM, password);
                    SendMailService.SendMail(userLoginVM.Email, password);

                }
                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
            }
            return View();
        }



    }
}
