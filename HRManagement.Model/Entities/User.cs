using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{

    public class User : BaseEntity
    {

        public User()
        {
            IsActive = false;

        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Adress { get; set; }
        public DateTime SendEmailTime { get; set; }
        public bool EmailActiveUser { get; set; } = false;
        public UserRole Role { get; set; }


        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? DepartmentID { get; set; }
        public Department Department { get; set; }




    }
}
