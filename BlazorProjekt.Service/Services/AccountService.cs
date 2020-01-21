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
    public class AccountService : GenericService<AccountDTO, IAccountRepository, Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly MappingService _mappingService;

        public AccountService(IAccountRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
        {
            _accountRepository = genericRepository;
            _mappingService = mappingService;
        }

        /// <summary>
        /// Gets the <see cref="AccountDTO"/> with the matching accountId or returns null if the <see cref="AccountDTO"/> does not exist
        /// </summary>
        public async Task<AccountDTO> GetAccountById(int accountId)
        {
            try
            {
                AccountDTO account = _mappingService._mapper.Map<AccountDTO>(await _accountRepository.GetAccountById(accountId));
                LogInformation($"Successfully fetched the account with the accountId: {accountId}");
                return account;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch the account with the accountId: {accountId}", e);
                return null;
            }
        }
    }
}