using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace IKProject.ViewModel.Custom_Validation
{
    class ProfilPictureAttribute : ValidationAttribute
    {
        public ProfilPictureAttribute() : base("Lütfen jpeg yada png dosya yüklemesi yapınız.")
        {

        }

        public override bool IsValid(object image)
        {
            IFormFile img = (IFormFile)image;
            string imgextension = Path.GetExtension(img.FileName);
            if (imgextension == ".jpg" || imgextension == ".png")
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
