using BlazorProjekt.Repository.Context;
using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly BlazorBankContext _dbContext;
        public AccountRepository(BlazorBankContext blazorBankContext) : base(blazorBankContext)
        {
            _dbContext = blazorBankContext;
        }

        /// <summary>
        /// Gets the <see cref="Account"/> with the matching accountId or throws if the <see cref="Account"/> does not exist
        /// </summary>
        public async Task<Account> GetAccountById(int accountId)
        {
            return await _dbContext.Accounts.SingleAsync(o => o.AccountId == accountId);
        }
    }
}
