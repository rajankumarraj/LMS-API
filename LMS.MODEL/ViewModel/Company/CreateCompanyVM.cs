using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.ViewModel.Company
{
    public class CreateCompanyVM
    {
        [Required(ErrorMessage = "Rescue Name is required")]
        public string Name { get; set; }
        public string CompanyAcronym { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City or Township is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State or Locality Code is required")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }
        public int NumberUsersPurchased { get; set; }
        public string Notes { get; set; }
        public bool MailList { get; set; }
        public string EnteredBy { get; set; }
        public string EmailAddress { get; set; }
    }
}
