using BlazorProjekt.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Repository.Interfaces
{
    public interface ISexRepository : IGenericRepository<Sex>
    {
        /// <summary>
        /// Gets the <see cref="Sex"/> with the matching sexId or throws if the <see cref="Sex"/> does not exist
        /// </summary>
        Task<Sex> GetSexById(int sexId);
    }
}
