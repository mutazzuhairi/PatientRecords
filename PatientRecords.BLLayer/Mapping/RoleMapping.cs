using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Entities;

namespace PatientRecords.BLLayer.Mapping
{
 
    public class RoleMapping : IRoleMapping
    {

        public RoleMapping(IHttpContextAccessor httpContextAccessor,
                                    IMapper mapper)  
        {

        }
        public  void MapEntity(Role  entity, 
                                       RoleDTO entityDTO,
                                       bool isNewEntity)
        {

        }

    }

}


