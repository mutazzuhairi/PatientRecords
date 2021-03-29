using AutoMapper;
using PatientRecords.DataLayer.DataUtilities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using Microsoft.EntityFrameworkCore;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using System.Reflection;

namespace PatientRecords.BLLayer.BLUtilities.Abstractions
{
    public abstract class EntityQueryService<TEntity, TEntityRepositry, TEntityDTO, TEntityView> : IQueryService<TEntityDTO, TEntityView>
    where TEntityRepositry : IRepository<TEntity>
    {
        private readonly TEntityRepositry _entityRepositry;
        private readonly IMapper  _mapper;
        private readonly IUriService _uriService;
        private readonly Lazy<IPaginationHelper> _paginationHelper;
        public EntityQueryService(TEntityRepositry entityRepositry, 
                                  IMapper mapper, 
                                  IUriService uriService,
                                  Lazy<IPaginationHelper> paginationHelper)
        {
             _entityRepositry = entityRepositry;
             _mapper = mapper;
             _uriService = uriService;
             _paginationHelper = paginationHelper;
        }

        public virtual async Task<List<TEntityDTO>> GetAllAsync()
        {
            var pocoList = await this._entityRepositry.GetAll().ToListAsync();

            return _mapper.Map<List<TEntityDTO>>(pocoList);

        }

        public virtual async Task<List<TEntityView>> GetAllViewAsync()
        {
            var pocoList = await this._entityRepositry.GetAll().ToListAsync();

            return _mapper.Map<List<TEntityView>>(pocoList);

        }
         
        public virtual async Task<TEntityDTO> GetSingleAsync(params object[] keyValues)
        {
            var poco = await this._entityRepositry.FindAsync(keyValues);
 
            return  _mapper.Map<TEntityDTO>(poco);
        }

        public virtual async Task<TEntityView> GetSingleViewAsync(params object[] keyValues)
        {
            var poco = await this._entityRepositry.FindAsync(keyValues);

            return  _mapper.Map<TEntityView>(poco);
        }


        public virtual async Task<PagedResponse<List<TEntityDTO>>> GetPaginationAsync(PaginationFilter filter, string route)
        {

            var paginationData = await GetPaginationData(filter, route);
            var pagedData = await GetPaginationRecoreds(paginationData.ValidFilter);
            var pagedDataDTO = this._mapper.Map<List<TEntityDTO>>(pagedData);
            return _paginationHelper.Value.CreatePagedReponse<TEntityDTO>(pagedDataDTO, paginationData);
 
        }

        public virtual async  Task<PagedResponse<List<TEntityView>>> GetPaginationViewAsync(PaginationFilter filter, string route)
        {

            var paginationData = await GetPaginationData(filter, route);
            var pagedData = await GetPaginationRecoreds(paginationData.ValidFilter);
            var pagedDataDTO = this._mapper.Map<List<TEntityView>>(pagedData);
            return _paginationHelper.Value.CreatePagedReponse<TEntityView>(pagedDataDTO, paginationData);

        }



        private async Task<PaginationData> GetPaginationData(PaginationFilter filter, string route ,int? totalRecordsCount = null)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await this._entityRepositry.GetAll().CountAsync();
            var paginationData = new PaginationData()
            {
                TotalRecords = totalRecordsCount!=null? (int)totalRecordsCount:totalRecords,
                ValidFilter = validFilter,
                Route = route,
                UriService = _uriService,
            };

            return paginationData;
        }


        public virtual async Task<PagedResponse<List<TEntityView>>> GetCustomPaginationAsync<EntityType>(PaginationFilter filter, 
                                                                                                             string route, 
                                                                                                             IQueryable<EntityType> entityData,
                                                                                                             int? totalRecords=null)
        {

            var paginationData = await GetPaginationData(filter, route, totalRecords);
            var pagedData = await GetCustomPaginationRecoreds<EntityType>(paginationData.ValidFilter, entityData);
            var pagedDataDTO = this._mapper.Map<List<TEntityView>>(pagedData);
            return _paginationHelper.Value.CreatePagedReponse<TEntityView>(pagedDataDTO, paginationData);

        }



        private async Task<List<TEntity>> GetPaginationRecoreds(PaginationFilter validFilter)
        {

            var pagedData = await this._entityRepositry.GetAll()
                                  .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                  .Take(validFilter.PageSize)
                                  .ToListAsync();

            return pagedData;
        }


        public virtual async Task<List<EntityType>> GetCustomPaginationRecoreds<EntityType>(PaginationFilter validFilter, 
                                                                                            IQueryable<EntityType> entityData)
        {
            var pagedData = await entityData
                                  .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                  .Take(validFilter.PageSize)
                                  .ToListAsync();

            return pagedData;
        }
    }
}
