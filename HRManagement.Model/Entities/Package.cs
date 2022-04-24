using HRManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Package : BaseEntity
    {
        public Package()
        {
            IsActive = true;
            Companies = new HashSet<Company>();
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }        
        public int Duration { get; set; }
        public int UserNumber { get; set; }


        
        public ICollection<Company> Companies { get; set; }

    }
}
