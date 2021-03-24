using AutoMapper;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<User> FindByEmailAsync(string email)
        {
            return await _iEntityRepositry.FindByEmailAsync(email);
        }


        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _iEntityRepositry.CheckPasswordAsync(user, password);
         }
    }
}
