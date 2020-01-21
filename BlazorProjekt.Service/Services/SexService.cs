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
    public class SexService : GenericService<SexDTO, ISexRepository, Sex>, ISexService
    {
        private readonly ISexRepository _sexRepository;
        private readonly MappingService _mappingService;

        public SexService(ISexRepository genericRepository, MappingService mappingService) : base(genericRepository, mappingService)
        {
            _sexRepository = genericRepository;
            _mappingService = mappingService;
        }

        /// <summary>
        /// Gets the <see cref="SexDTO"/> with the matching sexId or returns null if the <see cref="SexDTO"/> does not exist
        /// </summary>
        public async Task<SexDTO> GetSexById(int sexId)
        {
            try
            {
                SexDTO sex = _mappingService._mapper.Map<SexDTO>(await _sexRepository.GetSexById(sexId));
                LogInformation($"Successfully fetched the sex with the sexId: {sexId}");
                return sex;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch the sex with the sexId: {sexId}", e);
                return null;
            }
        }
    }
}