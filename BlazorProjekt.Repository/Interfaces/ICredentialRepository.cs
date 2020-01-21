using BlazorProjekt.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {

        Task<bool> ChangePassword(int ownerId, string hashedNewPassword, string hashedOldPassword);

        Task<Owner> Login(string hashedUsername, string hashedPassword);
       
    }
}
