using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjekt.Repository.Entities;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        /// <summary>
        /// Checks if the <see cref="Owner"/> with the <paramref name="ownerId"/> is an admin
        /// </summary>
        Task<bool> IsAdmin(int ownerId);

        /// <summary>
        /// Gets the <see cref="Owner"/> with the matching ownerId or throws if the <see cref="Owner"/> does not exist
        /// </summary>
        Task<Owner> GetOwnerById(int ownerId);

        Task<int> CreateNewOwner(Owner owner);

        Task<List<Owner>> GetOwners();
    }
}
