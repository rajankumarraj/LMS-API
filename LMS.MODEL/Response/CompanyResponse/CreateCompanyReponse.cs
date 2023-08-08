using LMS.DATA.Model;
using LMS.MODELS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.Response.CompanyResponse
{
    public class CreateCompanyReponse: BaseOperationResult
    {
        public CreateCompanyData Data { get; set; }
    }
    public class CreateCompanyData
    {
        public int Id { get; set; }
        public Company Company{ get; set; }
    }
}
