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
        Task<Owner> GetOwnerById(int ownerId);
    }
}
