using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.MODELS.Response.CompanyResponse;
using LMS.DATA;
using LMS.DATA.Model;

namespace LMS.REPOSITORIES.Interfaces
{
    public interface ICompanyRepository: IRepositoryBase<Company>
    {
        Task<CreateCompanyReponse> CreateCompanyAsync(Company company);
    }

}
