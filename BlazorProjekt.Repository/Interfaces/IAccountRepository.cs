using BlazorProjekt.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        /// <summary>
        /// Gets the <see cref="Account"/> with the matching accountId or throws if the <see cref="Account"/> does not exist
        /// </summary>
        Task<Account> GetAccountById(int accountId);
    }
}
