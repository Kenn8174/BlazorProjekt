using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Repository.Interfaces;
using BlazorProjekt.Service.DataTransferObjects;
using BlazorProjekt.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Services
{
    public class AccountTypeService : GenericService<AccountTypeDTO, IAccountTypeRepository, AccountType>, IAccountTypeService
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly MappingService _mappingService;

        public AccountTypeService(IAccountTypeRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
        {
            _accountTypeRepository = genericRepository;
            _mappingService = mappingService;
        }

        public async Task<AccountTypeDTO> GetAccountTypeById(int accountTypeId)
        {
            try
            {
                AccountTypeDTO accountType = _mappingService._mapper.Map<AccountTypeDTO>(await _accountTypeRepository.GetAccountTypeById(accountTypeId));
                LogInformation($"Successfully fetched the accountType with the accountTypeId: {accountTypeId}");
                return accountType;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch the accountType with the accountTypeId: {accountTypeId}", e);
                return null;
            }
        }
    }
}