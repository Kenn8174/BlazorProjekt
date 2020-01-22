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
        /// Charges interests for all bank accounts.
        /// </summary>
        public async Task ChargeInterest()
        {
            try
            {
                await _accountRepository.ChargeInterest();
                LogInformation($"Successfully charged interests");
            }
            catch (Exception e)
            {
                LogError($"Failed to charged interests", e);
            }
        }

        /// <summary>
        /// Deposits an amount into the <see cref="AccountDTO"/> with a matching accountId.
        /// </summary>
        public async Task Deposit(int accountId, decimal amount)
        {
            try
            {
                await _accountRepository.Deposit(accountId, amount);
                LogInformation($"Successfully deposited {amount} into the account with the accountId: {accountId}");
            }
            catch (Exception e)
            {
                LogError($"Failed to deposit {amount} into the account with the accountId: {accountId}", e);
            }
        }

        /// <summary>
        /// Gets the <see cref="AccountDTO"/> with the matching accountId or returns null if the <see cref="AccountDTO"/> does not exist.
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

        public async Task<List<AccountDTO>> GetAccounts()
        {
            try
            {
                List<AccountDTO> accounts = _mappingService._mapper.Map<List<AccountDTO>>(await _accountRepository.GetAccounts());
                LogInformation($"Successfully fetched a list of accounts");
                return accounts;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a list of accounts", e);
                return null;
            }
        }

        /// <summary>
        /// Withdraws an amount from the <see cref="AccountDTO"/> with a matching accountId.
        /// </summary>
        public async Task Withdraw(int accountId, decimal amount)
        {
            try
            {
                await _accountRepository.Withdraw(accountId, amount);
                LogInformation($"Successfully withdrew {amount} from the account with the accountId: {accountId}");
            }
            catch (Exception e)
            {
                LogError($"Failed to withdraw {amount} from the account with the accountId: {accountId}", e);
            }
        }
    }
}