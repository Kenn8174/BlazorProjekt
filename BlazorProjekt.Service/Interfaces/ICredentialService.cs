using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Interfaces
{
    public interface ICredentialService : IGenericService<CredentialDTO>
    {
        Task CreateNewCredentail(int ownerId, string username, string password);
        Task<bool> ChangePassword(int ownerId, string newPassword, string oldPassword);

        Task<OwnerDTO> Login(string username, string password);
    }
}
