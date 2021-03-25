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
using System.Threading.Tasks;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using Microsoft.EntityFrameworkCore;
 
namespace PatientRecords.BLLayer.QueryServices
{
    public class PatientQueryService : EntityQueryService<Patient, IPatientRepositry, PatientDTO, PatientView>, IPatientQueryService
    {
        
        private readonly IPatientRepositry _iEntityRepositry;
        private readonly IMapper _mapper;
 
        public PatientQueryService(IPatientRepositry iEntityRepositry, 
                                   IMapper mapper,
                                   IUriService  uriService,
                                   Lazy<IPaginationHelper>  paginationHelper) : 
            base(iEntityRepositry, mapper, uriService, paginationHelper)
        {
             _iEntityRepositry = iEntityRepositry;
             _mapper = mapper; 
 
        }



        public override async Task<PagedResponse<List<PatientView>>> GetPaginationViewAsync(PaginationFilter filter, string route)
        {

            var result =  _iEntityRepositry.GetAll()
                         .Include(a => a.PatientRecords)
                         .Select(x => new PatientView()
                         {
                             Id = x.Id,
                             Email = x.Email,
                             Name = x.Name,
                             OfficialId = x.OfficialId,
                             DateOfBirth = x.DateOfBirth,
                             UpdatedBy = x.UpdatedBy,
                             CreatedBy = x.UpdatedBy,
                             CreatedDate = x.CreatedDate,
                             UpdatedDate = x.UpdatedDate,
                             LastEntry = this._mapper.Map<PatientRecordView>(x.PatientRecords.
                                                                             OrderByDescending(a => a.TimeOfEntry).
                                                                             FirstOrDefault(p => p.PatientId == x.Id)),
                         });



            return await base.GetCustomPaginationAsync<PatientView>(filter, route, result);
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
