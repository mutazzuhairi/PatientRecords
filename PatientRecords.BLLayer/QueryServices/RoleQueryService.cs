using System;
using AutoMapper;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;

namespace PatientRecords.BLLayer.QueryServices
{
 
    public partial class RoleQueryService : EntityQueryService<Role, IRoleRepositry, RoleDTO, RoleView>, IRoleQueryService
    {
        private readonly IRoleRepositry _iEntityRepositry;
        private readonly IMapper _mapper;

        public RoleQueryService(IRoleRepositry iEntityRepositry, IMapper mapper,
                                IUriService  uriService,
                                Lazy<IPaginationHelper>  paginationHelper) :
            base(iEntityRepositry, mapper, uriService, paginationHelper)
        {

            _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }

    }
}