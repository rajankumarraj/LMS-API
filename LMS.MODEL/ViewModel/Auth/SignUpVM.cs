using LMS.MODELS.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.ViewModel.Auth
{
    public class SignUpVm
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string AlternateEmailAddress { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }

        public CreateCompanyVM CompanyVM { get; set; }

    }
}
