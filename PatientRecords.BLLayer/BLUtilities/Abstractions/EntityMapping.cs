using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.DataLayer.DataUtilities.Abstractions;
using System.Security.Claims;
using System;

namespace PatientRecords.BLLayer.BLUtilities.Abstractions
{
    public abstract class EntityMapping<TEntity, TEntityDTO> : IMapping<TEntity, TEntityDTO>
        where TEntity : BaseEntity
        where TEntityDTO : BaseEntityDTO

    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EntityMapping(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual void MapEntity(TEntity entity, 
                                      TEntityDTO entityDto,
                                      bool isNewEntity)
        {
            var loggedUserName = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            if (isNewEntity)
            {
                entityDto.CreatedDate = DateTime.UtcNow;
                entityDto.CreatedBy = loggedUserName;
                entity.CreatedBy = entityDto.CreatedBy;
                entity.CreatedDate = entityDto.CreatedDate;
            }
            entityDto.UpdatedDate = DateTime.UtcNow;
            entityDto.UpdatedBy = loggedUserName;
            entity.UpdatedDate = entityDto.UpdatedDate;
            entity.UpdatedBy = entityDto.UpdatedBy;
 
        }



    }
}
