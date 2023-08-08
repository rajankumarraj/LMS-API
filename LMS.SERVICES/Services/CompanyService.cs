using AutoMapper;
using LMS.DATA.Model;
using LMS.MODELS.Response.CompanyResponse;
using LMS.REPOSITORIES.Interfaces;
using LMS.SERVICES.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SERVICES.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;   
        }
        public async Task<CreateCompanyReponse> CreateCompanyAsync(Company company) => await _companyRepository.CreateCompanyAsync(company);

        public async Task<bool> DeleteAsync(int id) => await _companyRepository.DeleteAsync(id);
    }
}
