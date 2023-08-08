using LMS.DATA;
using LMS.DATA.Model;
using LMS.MODELS.Constants;
using LMS.MODELS.Response.CompanyResponse;
using LMS.REPOSITORIES.Interfaces;

namespace LMS.REPOSITORIES.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>,  ICompanyRepository
    {
        public CompanyRepository(LMSDbContext context) : base(context) { }

        public async Task<CreateCompanyReponse> CreateCompanyAsync(Company company)
        {
            var result = new CreateCompanyReponse();
            try
            {
                var vComap = await base.AddAsync(company);
                result = new CreateCompanyReponse
                {
                    Data = new CreateCompanyData { Id = vComap.ID, Company = vComap },
                    Success = true,
                    Message = ResponseMessage.SUCCESS,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                result = new CreateCompanyReponse
                {
                    Success = false,
                    Message = ResponseMessage.FAILURE + " " + ex.Message,
                    StatusCode = 999,
                    Errors = new List<string> { "Oops! Something went wrong while creating tenant" }
                };
            }
            return result;
        }
    }
}
