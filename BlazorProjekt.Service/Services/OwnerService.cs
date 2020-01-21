using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Repository.Interfaces;
using BlazorProjekt.Service.DataTransferObjects;
using BlazorProjekt.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Services
{
    public class OwnerService : GenericService<OwnerDTO, IOwnerRepository, Owner>, IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly MappingService _mappingService;

        public OwnerService(IOwnerRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
        {
            _ownerRepository = genericRepository;
            _mappingService = mappingService;
        }

        /// <summary>
        /// Gets the <see cref="OwnerDTO"/> with the matching ownerId or returns null if the <see cref="OwnerDTO"/> does not exist
        /// </summary>
        public async Task<OwnerDTO> GetOwnerById(int ownerId)
        {
            try
            {
                OwnerDTO owner = _mappingService._mapper.Map<OwnerDTO>(await _ownerRepository.GetOwnerById(ownerId));
                LogInformation($"Successfully fetched the owner with the ownerId: {ownerId}");
                return owner;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch the owner with the ownerId: {ownerId}", e);
                return null;
            }
        }

        /// <summary>
        /// Checks if the <see cref="OwnerDTO"/> with the <paramref name="ownerId"/> is an admin
        /// </summary>
        public async Task<bool> IsAdmin(int ownerId)
        {
            if (ownerId == 0)
            {
                LogInformation($"Skipped admin check because ownerId was 0");
                return false;
            }
            try
            {
                bool result = await _ownerRepository.IsAdmin(ownerId);
                LogInformation($"Successfully checked if {ownerId} was Admin ({result})");
                return result;
            }
            catch (Exception e)
            {
                LogError($"Failed checked if {ownerId} was Admin", e);
                return false;
            }
        }
    }
}
