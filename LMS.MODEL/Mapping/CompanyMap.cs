using AutoMapper;
using LMS.DATA.Model;
using LMS.MODELS.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.MODELS.Mapping
{
    public class CompanyMap: Profile
    {
        public CompanyMap() 
        {
            CreateMap<CreateCompanyVM, Company>();
        }
        
    }
}
