using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using System.Threading.Tasks;
using AutoMapper;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLBasics.BasicServices.Interfaces;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class PatientRecordUpdateService : EntityUpdateService<PatientRecord , IPatientRecordRepositry, PatientRecordDTO, IPatientRecordMapping, IPatientRecordValidating>, IPatientRecordUpdateService
    {

        public PatientRecordUpdateService(IPatientRecordRepositry entityRepositry, 
                                          IPatientRecordValidating entityValidating, 
                                          IPatientRecordMapping entityMapping,
                                          Lazy<IServiceBuildException> serviceBuildException,
                                          IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {

        }


        public override async Task<PatientRecordDTO> Create(PatientRecordDTO entityDTO)
        {
          return await base.Create(entityDTO);

        }

        public override async Task<PatientRecordDTO> Update(PatientRecordDTO entityDTO, params object[] keyValues)
        {
            return await base.Update(entityDTO, keyValues);

        }
    }
}
