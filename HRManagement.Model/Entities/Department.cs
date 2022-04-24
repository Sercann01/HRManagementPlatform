using HRManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            IsActive = true;
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
