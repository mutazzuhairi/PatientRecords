using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.DataLayer.DataBasics.Abstractions;
using PatientRecords.DataLayer.DataBasics.BasicService;
using System;

namespace PatientRecords.BLLayer.BLBasics.Abstractions
{
    public abstract class EntityMapping<TEntity, TEntityDTO> : IMapping<TEntity, TEntityDTO>
        where TEntity : BaseEntity
        where TEntityDTO : BaseEntityDTO

    { 
        public virtual void MapEntity(TEntity entity, TEntityDTO entityDto, bool isNewEntity)
        {
            var loggedInUser = WebsiteContext.LoggedInUser;

            if (isNewEntity)
            {
                entityDto.CreatedDate = DateTime.UtcNow;
                entityDto.CreatedBy = loggedInUser?.UserName;
                entity.CreatedBy = entityDto.CreatedBy;
                entity.CreatedDate = entityDto.CreatedDate;
            }
            entityDto.UpdatedDate = DateTime.UtcNow;
            entityDto.UpdatedBy = loggedInUser?.UserName;
            entity.UpdatedDate = entityDto.UpdatedDate;
            entity.UpdatedBy = entityDto.UpdatedBy;
 
        }



    }
}
