using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;

namespace PatientRecords.Web.WebUtilities.Abstractions
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomBaseViewController<TEntityDTO, TEntityView, TQueryService> : ControllerBase
        where TQueryService : IQueryService<TEntityDTO, TEntityView>
    {

        private readonly Lazy<TQueryService> _entityQueryService;
 
        public CustomBaseViewController(Lazy<TQueryService> entityQueryService)
        {
            _entityQueryService = entityQueryService;
 
        }

        [HttpGet]
        public virtual async Task<ActionResult<PagedResponse<List<TEntityView>>>> GetAll([FromQuery] PaginationFilter filter)
        {
            string route = Request.Path.Value;
            PagedResponse<List<TEntityView>> tEntityViews = await _entityQueryService.Value.GetPaginationViewAsync(filter, route);
            return Ok(new Response<PagedResponse<List<TEntityView>>>(tEntityViews));

        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityView>> Get(int id)
        {
 
            TEntityView tEntityView = await _entityQueryService.Value.GetSingleViewAsync(id);
            return Ok(new Response<TEntityView>(tEntityView));

        }

    }
}
