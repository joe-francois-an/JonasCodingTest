using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
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
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            return _mapper.Map<IEnumerable<CompanyInfo>>(_companyRepository.GetAll());
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            return _mapper.Map<CompanyInfo>(_companyRepository.GetByCode(companyCode));
        }

        public bool CreateCompany(CompanyInfo company)
        {
            return _companyRepository.SaveCompany(_mapper.Map<Company>(company));
        }

        public bool UpdateCompany(CompanyInfo company)
        {
            return _companyRepository.SaveCompany(_mapper.Map<Company>(company));
        }

        public bool DeleteCompany(string companyCode)
        {
            return _companyRepository.DeleteCompany(companyCode);
        }
    }
}
