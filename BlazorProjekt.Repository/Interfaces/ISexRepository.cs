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
        Task<Sex> GetSexById(int sexId);
    }
}
