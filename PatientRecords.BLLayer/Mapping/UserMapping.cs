using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataBasics.HelperServices;
using System;

namespace PatientRecords.BLLayer.Mapping
{
    public class UserMapping  : IUserMapping
    {
        public void MapEntity(User entity, UserDTO entityDTO, bool isNewEntity)
        {
            var loggedInUser = WebsiteContext.LoggedInUser;

            if (isNewEntity)
            {
                entity.Email = entityDTO.Email;
                entity.PasswordHash = entityDTO.PasswordHash;
                entityDTO.CreatedDate = DateTime.UtcNow;
                entityDTO.CreatedBy = loggedInUser?.Id;
                entity.CreatedBy = entityDTO.CreatedBy;
                entity.CreatedDate = entityDTO.CreatedDate;
            }
            entityDTO.UpdatedDate = DateTime.UtcNow;
            entityDTO.UpdatedBy = loggedInUser?.Id;
            entity.UpdatedDate = entityDTO.UpdatedDate;
            entity.UpdatedBy = entityDTO.UpdatedBy;
            entity.UserName = entityDTO.UserName;
            entity.FirstName = entityDTO.FirstName;
            entity.LastName = entityDTO.LastName;
        }
    }
}
