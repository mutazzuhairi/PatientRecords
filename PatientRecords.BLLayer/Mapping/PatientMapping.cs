using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping
{
    public class PatientMapping : EntityMapping<Patient, PatientDTO>, IPatientMapping
    {
        public PatientMapping(IHttpContextAccessor httpContextAccessor,
                              IMapper mapper) : base(httpContextAccessor, mapper)
        {
   
        }
        public override void MapEntity(Patient entity, 
                                       PatientDTO entityDTO,
                                       bool isNewEntity)
        {
            base.MapEntity(entity, entityDTO, isNewEntity);
            if (isNewEntity)
            {
                entity.OfficialId = entityDTO.OfficialId;
            }
            entity.Email = entityDTO.Email;
            entity.Name = entityDTO.Name;
            entity.DateOfBirth = entityDTO.DateOfBirth!=null?entityDTO.DateOfBirth.
                                                                       Value.
                                                                       AddHours(3):
                                                                       null;
            entity.SearchField = string.Join(",", entity.Email, entity.Name, entity.OfficialId);
        }
    }
}
