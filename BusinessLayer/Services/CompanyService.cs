using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            _logger.LogInformation("Company GetAllCompaniesAsync service");
            return _mapper.Map<IEnumerable<CompanyInfo>>(await _companyRepository.GetAllAsync());
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            _logger.LogInformation("Company GetCompanyByCodeAsync service");
            return _mapper.Map<CompanyInfo>(await _companyRepository.GetByCodeAsync(companyCode));
        }

        public async Task<bool> CreateCompanyAsync(CompanyInfo company)
        {
            _logger.LogInformation("Company CreateCompanyAsync service");
            return await _companyRepository.SaveCompanyAsync(_mapper.Map<Company>(company));
        }

        public async Task<bool> UpdateCompanyAsync(CompanyInfo company)
        {
            _logger.LogInformation("Company UpdateCompanyAsync service");
            return await _companyRepository.SaveCompanyAsync(_mapper.Map<Company>(company));
        }

        public async Task<bool> DeleteCompanyAsync(string companyCode)
        {
            _logger.LogInformation("Company DeleteCompanyAsync service");
            return await _companyRepository.DeleteCompanyAsync(companyCode);
        }
    }
}
