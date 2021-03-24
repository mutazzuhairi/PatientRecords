using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
using System;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class PatientUpdateService : EntityUpdateService<Patient, IPatientRepositry, PatientDTO, IPatientMapping, IPatientValidating>, IPatientUpdateService
    {

        public PatientUpdateService(IPatientRepositry entityRepositry, 
                                    IPatientValidating entityValidating, 
                                    IPatientMapping entityMapping,
                                    Lazy<IServiceBuildException> serviceBuildException,
                                    IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {

        }


        public override async Task<PatientDTO> CreateAsync(PatientDTO entityDTO)
        {
          return await base.CreateAsync(entityDTO);

        }

        public override async Task<PatientDTO> UpdateAsync(PatientDTO entityDTO, params object[] keyValues)
        {
            return await base.UpdateAsync(entityDTO, keyValues);

        }
    }
}
