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
    public class AccountTypeRepository : GenericRepository<AccountType>, IAccountTypeRepository
    {
        private readonly BlazorBankContext _dbContext;
        public AccountTypeRepository(BlazorBankContext blazorBankContext) : base(blazorBankContext)
        {
            _dbContext = blazorBankContext;
        }

        /// <summary>
        /// Gets the <see cref="AccountType"/> with the matching accountTypeId or throws if the <see cref="AccountType"/> does not exist
        /// </summary>
        public async Task<AccountType> GetAccountTypeById(int accountTypeId)
        {
            return await _dbContext.AccountTypes.SingleAsync(o => o.AccountTypeId == accountTypeId);
        }
    }
}
