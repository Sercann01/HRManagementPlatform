using IKProject.ViewModel.Custom_Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.UserViewModels
{
    public class UserAddVM
    {

        [Display(Name = "İsim*", Prompt = "İsim Giriniz.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lütfen İsim Giriniz.")]
        [RegularExpression("^[A-Za-z ĞğÜüÇçÖöİıŞş]{3,29}$", ErrorMessage = "Lütfen geçerli bir İsim giriniz")]
        public string Name { get; set; }                // Ad

        [Display(Name = "Soyisim*", Prompt = "Soyisim Giriniz.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lütfen Soyisim Giriniz.")]
        [RegularExpression("^[A-Za-z ĞğÜüÇçÖöİıŞş]{3,29}$", ErrorMessage = "Lütfen geçerli bir Soyisim giriniz")]
        public string Surname { get; set; }             // soyad

        [Display(Name = "Mail Adresi*", Prompt = "Mail Adresi Giriniz.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lütfen Mail Adresi Giriniz.")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9._-]{3,29}$", ErrorMessage = "Lütfen geçerli bir Mail adresi giriniz")]


        public string Mail { get; set; }                // Email Adresi       (textbox string )  serhatbayar

        [Display(Name = "TC Kimlik Numarası*", Prompt = "TC Kimlik Numarası Giriniz.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Lütfen 11 Haneli Tc Kimlik Numaranızı Giriniz.")]
        [Required(ErrorMessage = "Lütfen TC Kimlik Numarası Giriniz.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Lütfen geçerli bir TC kimlik numarası giriniz")]
        public string TC { get; set; }                  // Tc kimlik

        [Display(Name = "Doğum Tarihi*", Prompt = "Doğum Tarihi Giriniz.")]
        [Required(ErrorMessage = "Lütfen Doğum Tarihi Giriniz.")]
        [DataType(DataType.Date)]
        [BirthDate]

        public DateTime BirthDate { get; set; }         //Doğum tarihi


        [Display(Name = "Ünvan*", Prompt = "Ünvan Bilgisi Giriniz.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lütfen Ünvan Bilgisi Giriniz.")]
        [RegularExpression("^[A-Za-z ĞğÜüÇçÖöİıŞş]{3,29}$", ErrorMessage = "Lütfen geçerli bir Ünvan giriniz")]
        public string Title { get; set; }               //  Uzmanlık

        [Display(Name = "Başlangıç Tarihi*", Prompt = "Başlangıç Tarihi Giriniz.")]
        [Required(ErrorMessage = "Lütfen İşe Giriş Tarihi Giriniz.")]
        [DataType(DataType.Date)]
        [StartDate]
        public DateTime StartDate { get; set; }         // İşe Başlangıç Tarihi  Company    

        [Display(Name = "Telefon*", Prompt = "0(5xx)-(xxx)-(xxxx)")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Lütfen Telefon Bilgisi Giriniz.")]
        [RegularExpression(@"^\(?([0][0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen geçerli bir Telefon numarası giriniz")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz")]

        public string PhoneNumber { get; set; }         // Telefon Numarası

        [Display(Name = "Adres*", Prompt = "Adres Giriniz.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lütfen Adres Bilgisi Giriniz.")]
        [MinLength(10, ErrorMessage = "Lütfen geçerli bir adres bilgisi giriniz.")]

        public string Adress { get; set; }
        [Display(Name = "Departman Bilgisi*")]
        public int? DepartmentID { get; set; }

        public IFormFile? PhotoPath { get; set; }
        [Display(Name = "ŞirketID")]
        public int? CompanyID { get; set; }
    }
}
