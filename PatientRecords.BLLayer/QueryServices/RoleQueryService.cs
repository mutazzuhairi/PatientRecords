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
 
    public class RoleQueryService : EntityQueryService<Role, IRoleRepositry, RoleDTO, RoleView>, IRoleQueryService
    {
        private readonly Lazy<IRoleRepositry> _iEntityRepositry;
        private readonly Lazy<ICommonServices> _iCommonServices;
        private readonly Lazy<IUriService> _uriService;
        private readonly Lazy<IPaginationHelper> _paginationHelper;
        private readonly IMapper _mapper;

        public RoleQueryService(Lazy<IRoleRepositry> iEntityRepositry, 
                                Lazy<ICommonServices> iCommonServices,
                                Lazy<IUriService>  uriService,
                                Lazy<IPaginationHelper>  paginationHelper,
                                IMapper mapper) :
            base(iEntityRepositry, uriService, paginationHelper, mapper)
        {

            _iEntityRepositry = iEntityRepositry;
            _iCommonServices = iCommonServices;
            _uriService = uriService;
            _paginationHelper = paginationHelper;
            _mapper = mapper;

        }

    }
}