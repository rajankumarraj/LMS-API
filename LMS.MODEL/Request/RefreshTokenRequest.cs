﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.Request
{
    public class RefreshTokenRequest
    {
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Refresh Token is required")]
        public string RefreshToken { get; set; }
    }
}
