using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LMS.DATA.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AlternateEmailAddress { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("DateEntered", TypeName = "datetime2")]
        public DateTime? DateEntered { get; set; }
        public string? EnteredBy { get; set; }
        public string? Status { get; set; }
        public DateTime? DateActive { get; set; } = null;
        public DateTime? DateInactive { get; set; } = null;
        public string? Notes { get; set; }
        public DateTime? DateInvited { get; set; } = null;
        public string? Inviter { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

    }
}
