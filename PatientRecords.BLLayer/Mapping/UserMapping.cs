using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
using System.Security.Claims;
using System;

namespace PatientRecords.BLLayer.Mapping
{
    public class UserMapping  : IUserMapping
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserMapping(IHttpContextAccessor httpContextAccessor)  
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void MapEntity(User entity, 
                              UserDTO entityDTO,
                              bool isNewEntity)
        {
            var loggedInUserName = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            if (isNewEntity)
            {
                entity.Email = entityDTO.Email;
                entity.PasswordHash = entityDTO.PasswordHash;
                entityDTO.CreatedDate = DateTime.UtcNow;
                entityDTO.CreatedBy = loggedInUserName;
                entity.CreatedBy = entityDTO.CreatedBy;
                entity.CreatedDate = entityDTO.CreatedDate;
            }
            entityDTO.UpdatedDate = DateTime.UtcNow;
            entityDTO.UpdatedBy = loggedInUserName;
            entity.UpdatedDate = entityDTO.UpdatedDate;
            entity.UpdatedBy = entityDTO.UpdatedBy;
            entity.UserName = entityDTO.UserName;
            entity.FirstName = entityDTO.FirstName;
            entity.LastName = entityDTO.LastName;
        }
    }
}
