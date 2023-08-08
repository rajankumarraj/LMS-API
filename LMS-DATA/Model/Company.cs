using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace LMS.DATA.Model
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CompanyAcronym { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }
        public string Status { get; set; }
        public int NumberUsersPurchased { get; set; }
        public string Notes { get; set; }
        public bool MailList { get; set; }
        public DateTime DateEntered { get; set; }
        [Column("DateModified", TypeName = "datetime2")]
        public DateTime DateModified { get; set; }
        public string EnteredBy { get; set; }
        [Column("ModifiedBy", TypeName = "nvarchar(256)")]
        public string? ModifiedBy { get; set; }
        public string EmailAddress { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
    }
}
