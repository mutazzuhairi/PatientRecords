using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using AutoMapper;
using System;


namespace PatientRecords.BLLayer.UpdateServices
{
 
    public class mutazUpdateService : EntityUpdateService<mutaz, ImutazRepositry, mutazDTO, ImutazMapping, ImutazValidating>, ImutazUpdateService
    {

        private readonly Lazy<ImutazRepositry> _iEntityRepositry;
        private readonly Lazy<ImutazValidating> _entityValidating;
        private readonly Lazy<ImutazMapping> _entityMapping;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
        private readonly IMapper _mapper;

        public mutazUpdateService(Lazy<ImutazRepositry> entityRepositry,
                                    Lazy<ImutazValidating> entityValidating,
                                    Lazy<ImutazMapping> entityMapping,
                                    Lazy<IServiceBuildException> serviceBuildException,
                                    IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {
            _iEntityRepositry = entityRepositry;
            _entityValidating = entityValidating;
            _entityMapping = entityMapping;
            _serviceBuildException = serviceBuildException;
            _mapper = mapper;
        }
 
    }

}