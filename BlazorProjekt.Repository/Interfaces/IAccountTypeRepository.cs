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
        Task<AccountType> GetAccountTypeById(int accountTypeId);
    }
}
