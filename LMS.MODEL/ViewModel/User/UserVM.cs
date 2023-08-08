﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.ViewModel.User
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public int TenantId { get; set; }
        public string Status { get; set; }
        public string Inviter { get; set; }
        public DateTime? DateInvited { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateActive { get; set; } = null;
        public DateTime? DateInactive { get; set; } = null;
        public CompanyUserVM CompanyUser { get; set; }
    }
}
