﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.Common
{
    public interface IBaseOperationResult
    {
        string Message { get; set; }
        bool Success { get; set; }
        int StatusCode { get; set; }
        List<string> Errors { get; set; }
    }
}
