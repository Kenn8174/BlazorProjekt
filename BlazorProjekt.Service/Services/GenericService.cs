using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjekt.Repository.Interfaces;
using BlazorProjekt.Service.Interfaces;

namespace BlazorProjekt.Service.Services
{
    /// <summary>
    /// Generic service
    /// </summary>
    /// <typeparam name="T">The class type</typeparam>
    public abstract class GenericService<T, I, E> : LoggingService, IGenericService<T> where T : class where I : IGenericRepository<E> where E : class

    {
        private readonly I _genericRepository;
        private readonly MappingService _mappingService;
        private readonly string _entityName = typeof(E).ToString().Replace("BlazorProjekt.Repository.Entities.", "");

        public GenericService(I genericRepository, MappingService mappingService)
        {
            _genericRepository = genericRepository;
            _mappingService = mappingService;
        }

        /// <summary>
        /// Adds a new <paramref name="entity"/> to the database
        /// </summary>
        public async Task Create(T entity)
        {
            try
            {
                await _genericRepository.Create(_mappingService._mapper.Map<E>(entity));
                LogInformation($"Successfully created a new {_entityName}");
            }
            catch (Exception e)
            {
                LogError($"Failed to create a new {_entityName}", e);
            }
        }

        /// <summary>
        /// Removes an existing <paramref name="entity"/> from the database
        /// </summary>
        public async Task Delete(T entity)
        {
            try
            {
                await _genericRepository.Delete(_mappingService._mapper.Map<E>(entity));
                LogInformation($"Successfully deleted a {_entityName}");
            }
            catch (Exception e)
            {
                LogError($"Failed to delete a {_entityName}", e);
            }
        }


        /// <summary>
        /// Gets a list of all the <typeparamref name="T"/> entities from the database
        /// </summary>
        public async Task<List<T>> GetAll()
        {
            try
            {
                List<T> tempList = _mappingService._mapper.Map<List<T>>(await _genericRepository.GetAll());
                LogInformation($"Successfully fetched a list of {_entityName}s");
                return tempList;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a list of {_entityName}s", e);
                return new List<T>();
            }
        }

        /// <summary>
        /// Updates an existing <paramref name="entity"/> in the database
        /// </summary>
        public async Task Update(T entity)
        {
            try
            {
                await _genericRepository.Update(_mappingService._mapper.Map<E>(entity));
                LogInformation($"Successfully updated a {_entityName}");
            }
            catch (Exception e)
            {
                LogError($"Failed to updated a {_entityName}", e);
            }
        }
    }
}
