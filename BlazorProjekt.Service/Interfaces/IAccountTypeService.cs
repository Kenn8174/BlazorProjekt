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
        Task<AccountTypeDTO> GetAccountTypeById(int accountTypeId);
    }
}
