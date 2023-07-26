using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbWrapper<Company> _companyDbWrapper;
        private readonly ILogger<CompanyRepository> _logger;

        public CompanyRepository(IDbWrapper<Company> companyDbWrapper, ILogger<CompanyRepository> logger)
        {
            _companyDbWrapper = companyDbWrapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Getting all companies");
                return await _companyDbWrapper.FindAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all companies");
                return null;
            }
        }

        public async Task<Company> GetByCodeAsync(string companyCode)
        {
            try
            {
                _logger.LogInformation($"Getting a company by code: {companyCode}");
                return (await _companyDbWrapper.FindAsync(t => t.CompanyCode.Equals(companyCode)).ConfigureAwait(false))?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting a company by code: {companyCode}");
                return null;
            }
        }

        public async Task<bool> SaveCompanyAsync(Company company)
        {
            try
            {
                var itemRepo = (await _companyDbWrapper.FindAsync(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode)).ConfigureAwait(false))?.FirstOrDefault();
                if (itemRepo != null)
                {
                    itemRepo.CompanyName = company.CompanyName;
                    itemRepo.AddressLine1 = company.AddressLine1;
                    itemRepo.AddressLine2 = company.AddressLine2;
                    itemRepo.AddressLine3 = company.AddressLine3;
                    itemRepo.Country = company.Country;
                    itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                    itemRepo.FaxNumber = company.FaxNumber;
                    itemRepo.PhoneNumber = company.PhoneNumber;
                    itemRepo.PostalZipCode = company.PostalZipCode;
                    itemRepo.LastModified = company.LastModified;

                    _logger.LogInformation($"Updating a company by code: {company.CompanyCode}");
                    return await _companyDbWrapper.UpdateAsync(itemRepo);
                }

                _logger.LogInformation("Creating a company");
                return await _companyDbWrapper.InsertAsync(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving a company");
                return false;
            }
        }

        public async Task<bool> DeleteCompanyAsync(string companyCode)
        {
            try
            {
                _logger.LogInformation($"Deleting a company by code: {companyCode}");
                return await _companyDbWrapper.DeleteAsync(c => c.CompanyCode.Equals(companyCode));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting a company");
                return false;
            }
        }
    }
}
