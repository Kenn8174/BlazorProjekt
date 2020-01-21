using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Interfaces
{
    public interface ISexService : IGenericService<SexDTO>
    {
        /// <summary>
        /// Gets the <see cref="SexDTO"/> with the matching sexId or returns null if the <see cref="SexDTO"/> does not exist
        /// </summary>
        Task<SexDTO> GetSexById(int sexId);
    }
}
