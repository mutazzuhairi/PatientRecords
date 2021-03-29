﻿using AutoMapper;
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
        private readonly Lazy<ICommonServices> _commonServices;
        public PatientQueryService(IPatientRepositry iEntityRepositry, 
                                   IMapper mapper,
                                   IUriService  uriService,
                                   Lazy<IPaginationHelper>  paginationHelper,
                                   Lazy<ICommonServices> commonServices) : 
            base(iEntityRepositry, mapper, uriService, paginationHelper)
        {
             _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;
            _commonServices = commonServices;
        }



        public override async Task<PagedResponse<List<PatientView>>> GetPaginationViewAsync(PaginationFilter filter, string route)
        {
            var dataView = ApplyFilters(filter);

            var result =  dataView.
                          OrderByDescending(s=>s.CreatedDate)
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

         

            return await base.GetCustomPaginationAsync<PatientView>(filter, route, result, dataView.Count());
        }


        private IQueryable<Patient> ApplyFilters(PaginationFilter filter)
        {
            var dataView = _iEntityRepositry.GetAll();
            if (!string.IsNullOrEmpty(filter.SearchField))
                dataView = dataView.Where(s => s.SearchField.Contains(filter.SearchField));
            if (!string.IsNullOrEmpty(filter.DateFilter))
            {
                var dateFilter = _commonServices.Value.GetQueryDateFilter(filter.DateFilter);
                if (dateFilter != null)
                    dataView = dataView.Where(s => s.CreatedDate > dateFilter.Value);
            }

            return dataView;
 
        }


 

        public bool IsOfficialIdAlreadyExist(string officialId , int entityId)
        {
            return _iEntityRepositry.GetAll().Where(s => s.OfficialId == officialId && s.Id!= entityId).Any();
        }
        public bool IsEmailAlreadyExist(string email , int entityId)
        {
            return _iEntityRepositry.GetAll().Where(s => s.Email == email && s.Id!= entityId).Any();
        }

    }
}
