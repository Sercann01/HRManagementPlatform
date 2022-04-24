using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            IsActive = true;
            Users = new HashSet<User>();
        }


        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MailExtension { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime DatePurchased { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxId { get; set; }
        public short ActiveUsersNo { get; set; }
        public CompanyType CompanyType { get; set; }
        public int? PackageId { get; set; }
        public virtual Package Package { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
