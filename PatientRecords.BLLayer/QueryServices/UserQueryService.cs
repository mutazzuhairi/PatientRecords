using AutoMapper;
using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;

namespace PatientRecords.BLLayer.QueryServices
{
    public class UserQueryService : EntityQueryService<User, IUserRepositry, UserDTO, UserView>, IUserQueryService
    {
        
        private readonly IUserRepositry _iEntityRepositry;
        private readonly IMapper _mapper;

        public UserQueryService(IUserRepositry iEntityRepositry, IMapper mapper) : base(iEntityRepositry, mapper)
        {

            _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }
 
    }
}
