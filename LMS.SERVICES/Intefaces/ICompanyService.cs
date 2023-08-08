using LMS.DATA.Model;
using LMS.MODELS.Response.CompanyResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SERVICES.Intefaces
{
    public interface ICompanyService
    {
        Task<CreateCompanyReponse> CreateCompanyAsync(Company company);
        Task<bool> DeleteAsync(int id);
    }
}
