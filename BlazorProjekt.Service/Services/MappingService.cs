using BlazorProjekt.Repository.Entities;
using BlazorProjekt.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProjekt.Service.Services
{
    /// <summary>
    /// The MappingService. Used for Automapper so only 1 mapper is needed.
    /// </summary>
    public class MappingService : LoggingService
    {
        public readonly AutoMapper.IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingService"/> class.
        /// </summary>
        public MappingService()
        {
            AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                //Owner
                cfg.CreateMap<Owner, OwnerDTO>();
                cfg.CreateMap<OwnerDTO, Owner>();

                //Account
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<AccountDTO, Account>();

                //Sex
                cfg.CreateMap<Sex, SexDTO>();
                cfg.CreateMap<SexDTO, Sex>();

                //AccountType
                cfg.CreateMap<AccountType, AccountTypeDTO>();
                cfg.CreateMap<AccountTypeDTO, AccountType>();

                //Credential
                cfg.CreateMap<Credential, CredentialDTO>();
                cfg.CreateMap<CredentialDTO, Credential>();
            });

            try
            {
                _mapper = mapperConfig.CreateMapper();
                LogInformation("Successfully created mappings");

            }
            catch (Exception ex)
            {
                LogError("Failed to create mappings", ex);
            }

        }
    }

}
