using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Interfaces
{
    public interface IAccountTypeService : IGenericService<AccountTypeDTO>
    {
        /// <summary>
        /// Gets the <see cref="AccountTypeDTO"/> with the matching accountTypeId or returns null if the <see cref="AccountTypeDTO"/> does not exist
        /// </summary>
        Task<AccountTypeDTO> GetAccountTypeById(int accountTypeId);
    }
}
