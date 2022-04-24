using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface IUserBLL
    {
        //ResultService<UserCreateVM> Insert(UserCreateVM user);
        ResultService<bool> ActivedUser(Guid guid);
        ResultService<bool> AddUser(UserAddVM userAddVM);
        ResultService<UserRole> CheckUserForLogin(string email, string password);
        ResultService<bool> CheckUserLogin(string email, string password);
        UserInfoVM GetUserInfo(string email);
        bool ChangePassword(UserLoginVM userloginvm, string password);
        List<UserListVM> GetUserList();
    }
}
