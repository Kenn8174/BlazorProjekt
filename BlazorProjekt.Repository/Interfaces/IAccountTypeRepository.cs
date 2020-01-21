using BlazorProjekt.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface IAccountTypeRepository : IGenericRepository<AccountType>
    {
        /// <summary>
        /// Gets the <see cref="AccountType"/> with the matching accountTypeId or throws if the <see cref="AccountType"/> does not exist
        /// </summary>
        Task<AccountType> GetAccountTypeById(int accountTypeId);
    }
}
