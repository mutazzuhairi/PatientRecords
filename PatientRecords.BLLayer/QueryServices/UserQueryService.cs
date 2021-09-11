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
        
        private readonly Lazy<IUserRepositry> _iEntityRepositry;
        private readonly IMapper _mapper;

        public UserQueryService(Lazy<IUserRepositry> iEntityRepositry,
                                Lazy<IUriService>  uriService,
                                Lazy<IPaginationHelper>  paginationHelper,
                                IMapper mapper) :
            base(iEntityRepositry, uriService, paginationHelper, mapper)
        {

            _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }


        public async Task<User> FindByEmailAsync(string email)
        {
            return await _iEntityRepositry.Value.FindByEmailAsync(email);
        }

        public async Task<UserDTO> FindUserDTOByEmailAsync(string email)
        {
            User user =  await _iEntityRepositry.Value.FindByEmailAsync(email);
            return  _mapper.Map<UserDTO>(user);
        }

        public bool IsUserNameAlreadyExist(string userName,string entityId)
        {
            return _iEntityRepositry.Value.GetAll().Where(s => s.UserName == userName && s.Id != entityId).Any();
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _iEntityRepositry.Value.CheckPasswordAsync(user, password);
         }
    }
}
