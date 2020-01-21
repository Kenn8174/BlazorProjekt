using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProjekt.Service.Interfaces;

namespace BlazorProjekt.Service.Interfaces
{
    public interface IOwnerService : IGenericService<OwnerDTO>
    {
        /// <summary>
        /// Checks if the <see cref="OwnerDTO"/> with the <paramref name="ownerId"/> is an admin
        /// </summary>
        Task<bool> IsAdmin(int ownerId);

        /// <summary>
        /// Gets the <see cref="OwnerDTO"/> with the matching ownerId or returns null if the <see cref="OwnerDTO"/> does not exist
        /// </summary>
        Task<OwnerDTO> GetOwnerById(int ownerId);
    }
}
