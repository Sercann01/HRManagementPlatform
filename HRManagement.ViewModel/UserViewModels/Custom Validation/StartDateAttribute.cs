using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IKProject.ViewModel.Custom_Validation
{
    class StartDateAttribute : ValidationAttribute
    {

        public StartDateAttribute() : base("İşe başlangıç tarihi 1 haftadan ileri olamaz.")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime currentdate = DateTime.Today;
            DateTime propValue = Convert.ToDateTime(value);

            if (propValue<= currentdate.AddDays(7))
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
