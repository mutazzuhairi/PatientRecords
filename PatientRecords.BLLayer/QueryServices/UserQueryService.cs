using AutoMapper;
using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLBasics.HelperServices;

namespace PatientRecords.BLLayer.QueryServices
{
    public class UserQueryService : EntityQueryService<User, IUserRepositry, UserDTO, UserView>, IUserQueryService
    {
        
        private readonly IUserRepositry _iEntityRepositry;
        private readonly IMapper _mapper;

        public UserQueryService(IUserRepositry iEntityRepositry, IMapper mapper,
                                IUriService _uriService,
                                Lazy<IPaginationHelper> _paginationHelper) :
            base(iEntityRepositry, mapper, _uriService, _paginationHelper)
        {

            _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }
 
    }
}
