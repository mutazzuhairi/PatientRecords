using AutoMapper;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using System.Linq;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices;

namespace PatientRecords.BLLayer.QueryServices
{
    public class PatientQueryService : EntityQueryService<Patient, IPatientRepositry, PatientDTO, PatientView>, IPatientQueryService
    {
        
        private readonly IPatientRepositry _iEntityRepositry;
        private readonly IMapper _mapper;
 
        public PatientQueryService(IPatientRepositry iEntityRepositry, 
                                   IMapper mapper,
                                   IUriService _uriService,
                                   Lazy<IPaginationHelper> _paginationHelper) : 
            base(iEntityRepositry, mapper, _uriService, _paginationHelper)
        {

             _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }
 
        public bool IsOfficialIdAlreadyExist(string officialId)
        {
            return _iEntityRepositry.GetAll().Where(s => s.OfficialId == officialId).Any();
        }
        public bool IsEmailAlreadyExist(string email)
        {
            return _iEntityRepositry.GetAll().Where(s => s.Email == email).Any();
        }

    }
}
