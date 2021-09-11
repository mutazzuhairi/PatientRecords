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
 
    public class mutazQueryService : EntityQueryService<mutaz, ImutazRepositry, mutazDTO, mutazView>, ImutazQueryService
    {
        private readonly Lazy<ImutazRepositry> _iEntityRepositry;
        private readonly Lazy<ICommonServices> _iCommonServices;
        private readonly Lazy<IUriService> _uriService;
        private readonly Lazy<IPaginationHelper> _paginationHelper;
        private readonly IMapper _mapper;

        public mutazQueryService(Lazy<ImutazRepositry> iEntityRepositry, 
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