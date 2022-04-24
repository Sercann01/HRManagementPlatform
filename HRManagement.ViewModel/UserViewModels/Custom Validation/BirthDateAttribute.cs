using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IKProject.ViewModel.Custom_Validation
{
    public sealed class BirthDateAttribute : ValidationAttribute
    {
        public BirthDateAttribute() : base("{0} Kaydını yaptığınız personel 18 yaşından büyük olmalıdır.")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            DateTime currentdate = DateTime.Today;
            DateTime pastdate = propValue.AddYears(70);
            DateTime estimatedDate = propValue.AddYears(18);

            if (estimatedDate <= currentdate && pastdate >=currentdate)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
