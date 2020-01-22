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
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        private readonly BlazorBankContext _dbContext;
        public CredentialRepository(BlazorBankContext blazorBankContext) : base(blazorBankContext)
        {
            _dbContext = blazorBankContext;
        }

        /// <summary>
        /// Changes the password for the owner with the matching ownerId<br></br>
        /// </summary>
        public async Task<bool> ChangePassword(int ownerId, string hashedNewPassword, string hashedOldPassword)
        {
            Credential credential = await _dbContext.Credentials.SingleAsync(o => o.FKOwnerId == ownerId);
            if (credential.HashedPassword == hashedOldPassword)
            {
                credential.HashedPassword = hashedNewPassword;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Owner> Login(string hashedUsername, string hashedPassword)
        {
            Credential credential = await _dbContext.Credentials.Include(o => o.Owner).ThenInclude(o => o.Accounts).AsNoTracking().SingleAsync(o => o.HashedUsername == hashedUsername & o.HashedPassword == hashedPassword);
            return credential.Owner;
        }
    }
}
