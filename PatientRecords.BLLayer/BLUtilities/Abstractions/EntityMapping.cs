using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.DataLayer.DataUtilities.Abstractions;
using System.Security.Claims;
using System;
using AutoMapper;

namespace PatientRecords.BLLayer.BLUtilities.Abstractions
{
    public abstract class EntityMapping<TEntity, TEntityDTO> : IMapping<TEntity, TEntityDTO>
        where TEntity : BaseEntity
        where TEntityDTO : BaseEntityDTO

    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public EntityMapping(IHttpContextAccessor httpContextAccessor, 
                             IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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
            }
            entityDto.UpdatedDate = DateTime.UtcNow;
            entityDto.UpdatedBy = loggedUserName;

            entity = _mapper.Map<TEntity>(entityDto);

        }



    }
}
