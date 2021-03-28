using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.QueryServices
{
    public class PatientRecordQueryService : EntityQueryService<PatientRecord , IPatientRecordRepositry, PatientRecordDTO, PatientRecordView> , IPatientRecordQueryService
    {
        
        private readonly IPatientRecordRepositry _iEntityRepositry;
        private readonly IMapper _mapper;

        public PatientRecordQueryService(IPatientRecordRepositry iEntityRepositry, IMapper mapper,
                                         IUriService  uriService,
                                         Lazy<IPaginationHelper>  paginationHelper) :
            base(iEntityRepositry, mapper, uriService, paginationHelper)
        {

             _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;
        }


        public override async Task<PatientRecordDTO> GetSingleAsync(params object[] keyValues)
        {
            var poco = await _iEntityRepositry.GetAll()
                                       .Include(s => s.Patient)
                                       .Where(s => s.Id == (int)keyValues.First())
                                       .FirstOrDefaultAsync();

            return _mapper.Map<PatientRecordDTO>(poco);
        }


        public override async Task<PagedResponse<List<PatientRecordView>>> GetPaginationViewAsync(PaginationFilter filter, string route)
        {

            var result = _iEntityRepositry.GetAll()
                .Include(a => a.Patient)
                .Select(x => new PatientRecordView()
                {
                   Id = x.Id,
                   Description =  x.Description,
                   DiseaseName =  x.DiseaseName,
                   CreatedDate =  x.CreatedDate,
                   UpdatedDate =  x.UpdatedDate,
                   TimeOfEntry = x.TimeOfEntry,
                   Bill =  x.Bill,
                   PatientId =  x.PatientId,
                   Patient = this._mapper.Map<PatientView>(x.Patient),
                });
 
            return await base.GetCustomPaginationAsync<PatientRecordView>(filter, route, result);
        }

        public bool IsDiseaseNameAlreadyExist(string diseaseName)
        {
            return _iEntityRepositry.GetAll().Where(s => s.DiseaseName == diseaseName).Any();
        }

    }
}
