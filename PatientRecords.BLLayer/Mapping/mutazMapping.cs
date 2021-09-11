using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;

namespace PatientRecords.BLLayer.Mapping
{
 
    public class  mutazMapping : EntityMapping<mutaz , mutazDTO>, ImutazMapping
    {

        public mutazMapping(IHttpContextAccessor httpContextAccessor,
                                    IMapper mapper) : base(httpContextAccessor, mapper)
        {

        }
        public override void MapEntity(mutaz  entity, 
                                       mutazDTO entityDTO,
                                       bool isNewEntity)
        {
            base.MapEntity(entity, entityDTO, isNewEntity);
        }

    }

}


