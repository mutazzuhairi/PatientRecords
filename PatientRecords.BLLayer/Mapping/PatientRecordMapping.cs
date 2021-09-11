using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;

namespace PatientRecords.BLLayer.Mapping
{
    public class  PatientRecordMapping : EntityMapping<PatientRecord , PatientRecordDTO>, IPatientRecordMapping
    {

        public PatientRecordMapping(IHttpContextAccessor httpContextAccessor,
                                    IMapper mapper) : base(httpContextAccessor, mapper)
        {

        }
        public override void MapEntity(PatientRecord  entity, 
                                       PatientRecordDTO entityDTO,
                                       bool isNewEntity)
        {
            base.MapEntity(entity, entityDTO, isNewEntity);
            if (isNewEntity)
            {
                entity.PatientId = entityDTO.PatientId;
            }
            entity.DiseaseName = entityDTO.DiseaseName;
            entity.Bill = entityDTO.Bill;
            entity.Description = entityDTO.Description;
            entity.TimeOfEntry = entityDTO.TimeOfEntry.AddHours(3);

            entity.SearchField = entityDTO.SearchField;

         }



      


    }
}
