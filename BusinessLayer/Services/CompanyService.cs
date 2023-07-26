using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            return _mapper.Map<IEnumerable<CompanyInfo>>(await _companyRepository.GetAllAsync());
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            return _mapper.Map<CompanyInfo>(await _companyRepository.GetByCodeAsync(companyCode));
        }

        public async Task<bool> CreateCompanyAsync(CompanyInfo company)
        {
            return await _companyRepository.SaveCompanyAsync(_mapper.Map<Company>(company));
        }

        public async Task<bool> UpdateCompanyAsync(CompanyInfo company)
        {
            return await _companyRepository.SaveCompanyAsync(_mapper.Map<Company>(company));
        }

        public async Task<bool> DeleteCompanyAsync(string companyCode)
        {
            return await _companyRepository.DeleteCompanyAsync(companyCode);
        }
    }
}
