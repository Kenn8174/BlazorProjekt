using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Repository.Interfaces;
using BlazorProjekt.Service.DataTransferObjects;
using BlazorProjekt.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Services
{
    public class CredentialService : GenericService<CredentialDTO, ICredentialRepository, Credential>, ICredentialService
    {
        private readonly ICredentialRepository _credentialRepository;
        private readonly MappingService _mappingService;

        public CredentialService(ICredentialRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
        {
            _credentialRepository = genericRepository;
            _mappingService = mappingService;
        }

        public async Task<bool> ChangePassword(int ownerId, string newPassword, string oldPassword)
        {
            try
            {
                byte[] hashedNewPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newPassword));
                byte[] hashedOldPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(oldPassword));

                bool result = await _credentialRepository.ChangePassword(ownerId, Convert.ToBase64String(hashedNewPassword), Convert.ToBase64String(hashedOldPassword));
                LogInformation($"Successfully changed the password for the owner with the ownerId: {ownerId}");
                return result;
            }
            catch (Exception e)
            {
                LogError($"Failed to change the password for the owner with the ownerId: {ownerId}", e);
                return false;
            }
        }

        public async Task CreateNewCredentail(int ownerId, string username, string password)
        {
            byte[] hashedUsername = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(username));
            byte[] hashedPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

            try
            {
                Credential credential = new Credential()
                {
                    FKOwnerId = ownerId,
                    HashedUsername = Convert.ToBase64String(hashedUsername),
                    HashedPassword = Convert.ToBase64String(hashedPassword)
                };
                await _credentialRepository.Create(credential);
                LogInformation($"Successfully created a new credential for the owner with the ownerId: {ownerId}");
            }
            catch (Exception e)
            {
                LogError($"Failed to create a new credential for the owner with the ownerId: {ownerId}", e);
            }


        }

        public async Task<OwnerDTO> Login(string username, string password)
        {
            byte[] hashedUsername = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(username));
            byte[] hashedPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

            try
            {
                OwnerDTO owner = _mappingService._mapper.Map<OwnerDTO>(await _credentialRepository.Login(Convert.ToBase64String(hashedUsername), Convert.ToBase64String(hashedPassword)));
                LogInformation($"Successfully logged in");
                return owner;
            }
            catch (Exception e)
            {
                LogError($"Failed to login", e);
                return null;
            }

        }
    }
}
