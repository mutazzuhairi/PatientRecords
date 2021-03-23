using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping
{
    public class PatientMapping : EntityMapping<Patient, PatientDTO>, IPatientMapping
    {
        public override void MapEntity(Patient entity, PatientDTO entityDTO, bool isNewEntity)
        {
            base.MapEntity(entity, entityDTO, isNewEntity);
            if (isNewEntity)
            {
                entity.OfficialId = entityDTO.OfficialId;
            }
            entity.Email = entityDTO.Email;
            entity.Name = entityDTO.Name;
            entity.DateOfBirth = entityDTO.DateOfBirth;
        }
    }
}
