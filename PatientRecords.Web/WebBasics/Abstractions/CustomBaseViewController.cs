using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using PatientRecords.Web.WebBasics.BasicServices.Interfaces;

namespace PatientRecords.Web.WebBasics.Abstractions
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CustomBaseViewController<TEntityDTO, TEntityView, TQueryService> : ControllerBase
        where TQueryService : IQueryService<TEntityDTO, TEntityView>
    {

        private readonly Lazy<TQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuildercs> _iApiExceptionBuildercs;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;

        public CustomBaseViewController(Lazy<TQueryService> entityQueryService,
                                        Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                                        Lazy<ITransactionFactory> transactionFactory)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
            _iTransactionFactory = transactionFactory;

        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TEntityView>>> GetAll()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        List<TEntityView> tEntityViews = await _entityQueryService.Value.GetAllView();
                        scope.Complete();
                        return Ok(tEntityViews);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityView>> Get(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        TEntityView tEntityView = await _entityQueryService.Value.GetSingleView(id);
                        scope.Complete();
                        return Ok(tEntityView);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }
        }

    }
}
