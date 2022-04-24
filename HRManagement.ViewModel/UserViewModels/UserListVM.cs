using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.UserViewModels
{
    public class UserListVM
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Depertmant { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public UserRole Role { get; set; }
    }
}
