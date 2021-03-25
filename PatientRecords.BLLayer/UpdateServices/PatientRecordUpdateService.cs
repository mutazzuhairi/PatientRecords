using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using AutoMapper;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
 
namespace PatientRecords.BLLayer.UpdateServices
{
    public class PatientRecordUpdateService : EntityUpdateService<PatientRecord , IPatientRecordRepositry, PatientRecordDTO, IPatientRecordMapping, IPatientRecordValidating>, IPatientRecordUpdateService
    {

        public PatientRecordUpdateService(Lazy<IPatientRecordRepositry> entityRepositry,
                                          Lazy<IPatientRecordValidating> entityValidating,
                                          Lazy<IPatientRecordMapping> entityMapping,
                                          Lazy<IServiceBuildException> serviceBuildException,
                                          IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {

        }

 
    }
}
