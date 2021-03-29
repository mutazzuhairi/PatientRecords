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
using System.Threading.Tasks;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.BLLayer.QueryServices.Interfaces;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class PatientRecordUpdateService : EntityUpdateService<PatientRecord , IPatientRecordRepositry, PatientRecordDTO, IPatientRecordMapping, IPatientRecordValidating>, IPatientRecordUpdateService
    {
        private readonly Lazy<IPatientQueryService> _patientQueryService;

        public PatientRecordUpdateService(Lazy<IPatientRecordRepositry> entityRepositry,
                                          Lazy<IPatientRecordValidating> entityValidating,
                                          Lazy<IPatientRecordMapping> entityMapping,
                                          Lazy<IServiceBuildException> serviceBuildException,
                                          Lazy<IPatientQueryService>  patientQueryService,
                                          IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {
            _patientQueryService = patientQueryService;
        }


        public override async Task<PatientRecordDTO> CreateAsync(PatientRecordDTO entityDTO)
        {
            
            await AddPatientDataTOSearchField(entityDTO);
            return await base.CreateAsync(entityDTO);
        }

        public override async Task<PatientRecordDTO> UpdateAsync(PatientRecordDTO entityDTO, params object[] keyValues)
        {

            await AddPatientDataTOSearchField(entityDTO);
            return await base.UpdateAsync(entityDTO, keyValues);
        }


        private async Task AddPatientDataTOSearchField(PatientRecordDTO entity)
        {
            entity.SearchField = string.Join(",", entity.Bill, entity.DiseaseName, entity.Description);

            if (entity.PatientId != 0)
            {
                var patient = await _patientQueryService.Value.GetSingleAsync(entity.PatientId);
                entity.SearchField += string.Join(",", patient.Name, patient.Email, patient.OfficialId);

            }

        }

    }
}
