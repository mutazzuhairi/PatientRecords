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
        
        private readonly Lazy<IPatientRecordRepositry> _iEntityRepositry;
        private readonly Lazy<ICommonServices> _commonServices;
        private readonly IMapper  _mapper;

        public PatientRecordQueryService(Lazy<IPatientRecordRepositry> iEntityRepositry, 
                                         Lazy<IUriService>  uriService,
                                         Lazy<IPaginationHelper>  paginationHelper,
                                         Lazy<ICommonServices> commonServices,
                                         IMapper mapper) :
            base(iEntityRepositry, uriService, paginationHelper, mapper)
        {

             _iEntityRepositry = iEntityRepositry;
             _commonServices = commonServices;
             _mapper = mapper;
        }


        public override async Task<PatientRecordDTO> GetSingleAsync(params object[] keyValues)
        {
            var poco = await _iEntityRepositry.Value.GetAll()
                                       .Include(s => s.Patient)
                                       .Where(s => s.Id == (int)keyValues.First())
                                       .FirstOrDefaultAsync();

            return _mapper.Map<PatientRecordDTO>(poco);
        }


        public override async Task<PagedResponse<List<PatientRecordView>>> GetPaginationViewAsync(PaginationFilter filter, string route)
        {
            var result = GetIQueryablePatientRecordView();
            var dataView = ApplyFilters(filter,result);

            return await base.GetCustomPaginationAsync<PatientRecordView>(filter, route, dataView, dataView.Count());
        }


        public async Task<PagedResponse<List<PatientRecordView>>> GetAllForPatientId(PaginationFilter filter, string route,int patientId)
        {
            var result = GetIQueryablePatientRecordView();
            result = result.Where(s=>s.PatientId == patientId);
            var dataView = ApplyFilters(filter, result);
            return await base.GetCustomPaginationAsync<PatientRecordView>(filter, route, dataView, dataView.Count());
        }

        private IQueryable<PatientRecordView> GetIQueryablePatientRecordView()
        {
            var result = _iEntityRepositry.Value.GetAll()
                   .OrderByDescending(s => s.TimeOfEntry)
                   .Include(a => a.Patient)
                   .Select(x => new PatientRecordView()
                   {
                       Id = x.Id,
                       Description = x.Description,
                       DiseaseName = x.DiseaseName,
                       CreatedDate = x.CreatedDate,
                       UpdatedDate = x.UpdatedDate,
                       TimeOfEntry = x.TimeOfEntry,
                       Bill = x.Bill,
                       PatientId = x.PatientId,
                       SearchField = x.SearchField,
                       Patient = this._mapper.Map<PatientView>(x.Patient),
                   });

            return result;
        }


        private IQueryable<PatientRecordView> ApplyFilters(PaginationFilter filter,IQueryable<PatientRecordView> dataView)
        {
            if (!string.IsNullOrEmpty(filter.SearchField))
                dataView = dataView.Where(s => s.SearchField.Contains(filter.SearchField));
            if (!string.IsNullOrEmpty(filter.DateFilter))
            {
                var dateFilter = _commonServices.Value.GetQueryDateFilter(filter.DateFilter);
                if (dateFilter != null)
                    dataView = dataView.Where(s => s.TimeOfEntry > dateFilter.Value);
            }

            return dataView;
        }


        public bool IsDiseaseNameAlreadyExist(string diseaseName)
        {
            return _iEntityRepositry.Value.GetAll().Where(s => s.DiseaseName == diseaseName).Any();
        }

    }
}
