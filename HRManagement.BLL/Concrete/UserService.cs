using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HRManagement.BLL.Concrete
{
    public class UserService : IUserBLL
    {
        IUserDAL _userRepository;
        IDepartmentDAL _departmentDAL;

        public UserService(IUserDAL userRepository,IDepartmentDAL departmentDAL)
        {
           this._userRepository = userRepository;
            this._departmentDAL = departmentDAL;
        }

        public ResultService<bool> ActivedUser(Guid guid)
        {
            throw new NotImplementedException();
        }

        public ResultService<UserRole> CheckUserForLogin(string email, string password)
        {
            ResultService<UserRole> userRole = new ResultService<UserRole>();
            User user = _userRepository.Get(a => a.Email == email && a.Password == password);
            if (user == null)
            {
                userRole.AddError("Login Hatası", "Login Başarısız");
                return userRole;
            }
            userRole.Data = user.Role;
            return userRole;
        }
        public ResultService<bool> CheckUserLogin(string email, string password)
        {
            ResultService<bool> result = new ResultService<bool>();
            User user = _userRepository.Get(a => a.Email == email && a.Password == password);
            if (user == null)
            {
                result.AddError("Login Hatası", "Login Başarısız");
                return result;
            }
            result.Data = true;
            return result;
        }

        public UserInfoVM GetUserInfo(string email)
        {
            User user = _userRepository.Get(a => a.Email == email);
            if (user != null)
            {
                UserInfoVM userInfo = new UserInfoVM()
                {
                    ImageUrl = user.ImageUrl,
                    Name = user.FirstName + " " + user.LastName,
                    UserRole = user.Role,
                    CompanyID = user.CompanyId
                };
                return userInfo;
            }
            return null;
        }
        public bool ChangePassword(UserLoginVM userloginvm, string password)
        {
            if (userloginvm != null || password != null)
            {

                User passChangeUser = _userRepository.Get(a => a.Email == userloginvm.Email);
                passChangeUser.Password = password;
                passChangeUser.IsActive = false;
                passChangeUser = _userRepository.Update(passChangeUser);

                return true;

            }
            return false;
        }

        public ResultService<bool> AddUser(UserAddVM userAddVM)
        {
            ResultService<bool> result = new ResultService<bool>();
            Guid id = Guid.NewGuid();
            string password = id.ToString().Substring(0, 8);

            string imageExtension = Path.GetExtension(userAddVM.PhotoPath.FileName);

            //string imageName = userAddVM.TC + imageExtension;
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + $"/wwwroot/images/UserImages/{userAddVM.TC}");
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/UserImages/{userAddVM.TC}/{userAddVM.PhotoPath.FileName}");

            using var stream = new FileStream(path, FileMode.Create);

            userAddVM.PhotoPath.CopyTo(stream);

            if (userAddVM != null)
            {
                User user = new User()
                {
                    Adress = userAddVM.Adress,
                    BirthDate = userAddVM.BirthDate,
                    CreatedDate = DateTime.Now,
                    Email = userAddVM.Mail,
                    FirstName = userAddVM.Name,
                    LastName = userAddVM.Surname,
                    TC = userAddVM.TC,
                    DepartmentID = userAddVM.DepartmentID,
                    ImageUrl = $"/images/UserImages/{userAddVM.TC}/{userAddVM.PhotoPath.FileName}",
                    Title = userAddVM.Title,
                    PhoneNumber = userAddVM.PhoneNumber,
                    CompanyId = userAddVM.CompanyID,
                    ModifiedDate = DateTime.Now,
                    Password = password,

                };
                _userRepository.Add(user);
                result.Data = true;
            }
            else
            {
                result.AddError("ErrorMessage", "Kullanıcı eklenemedi!");
                result.Data = false;
            }
            return result;
        }

        public List<UserListVM> GetUserList()
        {
           
          List<UserListVM> userList= _userRepository.GetAll(a=>a.Role==UserRole.Employee).OrderByDescending(a=>a.CreatedDate)
                .Select(user => new UserListVM
                {
             Title = user.Title,
             LastName = user.LastName,
             Email= user.Email,
             FirstName = user.FirstName,
             ID=user.Id,
             IsActive = user.IsActive,  
             PhoneNumber = user.PhoneNumber,
             Role=user.Role,
             StartDate = user.StartDate,
             Depertmant=_departmentDAL.Get(a=>a.Id==user.DepartmentID).Name,
             BirthDate=user.BirthDate,
             ImageURL=user.ImageUrl
                }).ToList();

            return userList;

        }
    }
}
