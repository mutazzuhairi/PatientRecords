﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using PatientRecords.Web.WebBasics.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLBasics.HelperClasses;

namespace PatientRecords.Web.WebBasics.Abstractions
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomBaseViewController<TEntityDTO, TEntityView, TQueryService> : ControllerBase
        where TQueryService : IQueryService<TEntityDTO, TEntityView>
    {

        private readonly Lazy<TQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuildercs;

        public CustomBaseViewController(Lazy<TQueryService> entityQueryService,
                                        Lazy<IApiExceptionBuilder> iApiExceptionBuildercs)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;

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
