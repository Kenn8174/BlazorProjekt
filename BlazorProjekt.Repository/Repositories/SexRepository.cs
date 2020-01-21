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
    public class SexRepository : GenericRepository<Sex>, ISexRepository
    {
        private readonly BlazorBankContext _dbContext;
        public SexRepository(BlazorBankContext blazorBankContext) : base(blazorBankContext)
        {
            _dbContext = blazorBankContext;
        }

        /// <summary>
        /// Gets the <see cref="Sex"/> with the matching sexId or throws if the <see cref="Sex"/> does not exist
        /// </summary>
        public async Task<Sex> GetSexById(int sexId)
        {
           return await _dbContext.Sexes.SingleAsync(o => o.SexId == sexId);
        }
    }
}
