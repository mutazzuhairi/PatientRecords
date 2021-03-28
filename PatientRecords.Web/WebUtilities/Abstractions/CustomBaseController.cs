using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using Microsoft.AspNetCore.Authorization;
using System;

namespace PatientRecords.Web.WebUtilities.Abstractions
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class CustomBaseController<TEntityDTO, TEntityView, TUpdateService, TQueryService> : ControllerBase
        where TEntityDTO : BaseEntityDTO
        where TUpdateService : IUpdateService<TEntityDTO>
        where TQueryService : IQueryService<TEntityDTO, TEntityView>
    {

        private readonly Lazy<TQueryService> _entityQueryService;
        private readonly Lazy<TUpdateService> _entityUpdateService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuildercs;

        public CustomBaseController(Lazy<TQueryService> entityQueryService,
                                    Lazy<TUpdateService> entityUpdateService,
                                    Lazy<IApiExceptionBuilder> iApiExceptionBuildercs)
        {
            _entityQueryService = entityQueryService;
            _entityUpdateService = entityUpdateService;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
        }

        [HttpGet]
        public virtual async Task<ActionResult<PagedResponse<List<TEntityDTO>>>> GetAll([FromQuery] PaginationFilter filter)
        {
            string route = Request.Path.Value;
            PagedResponse<List<TEntityDTO>> tEntityViews = await _entityQueryService.Value.GetPaginationAsync(filter, route);
            return Ok(new Response<PagedResponse<List<TEntityDTO>>>(tEntityViews));

        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityDTO>> Get(int id)
        {

            TEntityDTO tEntityView = await _entityQueryService.Value.GetSingleAsync(id);
            return Ok(new Response<TEntityDTO>(tEntityView));


        }
 

        [HttpPost]
        public virtual async Task<ActionResult<TEntityDTO>> Post(TEntityDTO entityDTO)
        {

            entityDTO = await _entityUpdateService.Value.CreateAsync(entityDTO);
            return Ok(new Response<TEntityDTO>(entityDTO));

        }
 
        [HttpPut]
        public virtual async Task<ActionResult<TEntityDTO>> Put(TEntityDTO entityDTO)
        {
      
            entityDTO = await _entityUpdateService.Value.UpdateAsync(entityDTO, entityDTO.Id);
            return Ok(new Response<TEntityDTO>(entityDTO));

        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntityDTO>> Delete(int id)
        {

            TEntityDTO entityDTO = await _entityUpdateService.Value.DeleteAsync(id);
            if (entityDTO == null)
                return NotFound();
            return Ok(new Response<TEntityDTO>(entityDTO));

        }


    }
}
