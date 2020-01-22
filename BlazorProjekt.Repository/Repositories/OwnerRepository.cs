using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Repository.Interfaces;
using BlazorProjekt.Repository.Context;
using System.Linq;
using System.Collections.Generic;

namespace BlazorProjekt.Repository.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly BlazorBankContext _dbContext;
        public OwnerRepository(BlazorBankContext blazorBankContext) : base(blazorBankContext)
        {
            _dbContext = blazorBankContext;
        }

        /// <summary>
        /// Checks if the <see cref="Owner"/> with the <paramref name="ownerId"/> is an admin
        /// </summary>
        public async Task<bool> IsAdmin(int ownerId)
        {
            IQueryable<Owner> query = _dbContext.Owners.AsNoTracking();

            return (await query.SingleAsync(o => o.OwnerId == ownerId)).Admin;
        }

        /// <summary>
        /// Gets the <see cref="Owner"/> with the matching ownerId or throws if the <see cref="Owner"/> does not exist
        /// </summary>
        public async Task<Owner> GetOwnerById(int ownerId)
        {
            IQueryable<Owner> query = _dbContext.Owners.AsNoTracking();

            return await query.SingleAsync(o => o.OwnerId == ownerId);
        }

        public async Task<List<Owner>> GetOwners()
        {
            return await _dbContext.Owners.Include(o => o.Sex).AsNoTracking().ToListAsync();
        }

    }
}
