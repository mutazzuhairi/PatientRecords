using PatientRecords.BLLayer.BLBasics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.DataLayer.DataBasics.Abstractions;
using Microsoft.AspNetCore.Authorization;
using PatientRecords.Web.WebBasics.Interfaces;
using System.Transactions;
using PatientRecords.DataLayer.DataBasics.BasicService;
using PatientRecords.BLLayer.BLBasics.Abstractions;

namespace PatientRecords.Web.WebBasics.Abstractions
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public abstract class CustomBaseController<TEntityDTO, TEntityView, TUpdateService, TQueryService> : ControllerBase
        where TEntityDTO : BaseEntityDTO
        where TUpdateService : IUpdateService<TEntityDTO>
        where TQueryService : IQueryService<TEntityDTO, TEntityView>
    {

        private readonly Lazy<TQueryService> _entityQueryService;
        private readonly Lazy<TUpdateService> _entityUpdateService;
        private readonly Lazy<IApiExceptionBuildercs> _iApiExceptionBuildercs;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;

        public CustomBaseController(Lazy<TQueryService> entityQueryService,
                                    Lazy<TUpdateService> entityUpdateService,
                                    Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                                    Lazy<ITransactionFactory> transactionFactory)
        {
            _entityQueryService = entityQueryService;
            _entityUpdateService = entityUpdateService;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
            _iTransactionFactory = transactionFactory;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TEntityDTO>>> GetAll()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        List<TEntityDTO> entityDTOs = await _entityQueryService.Value.GetAll();
                        scope.Complete();
                        return Ok(entityDTOs);
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
        public virtual async Task<ActionResult<TEntityDTO>> Get(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        TEntityDTO tEntityDTO = await _entityQueryService.Value.GetSingle(id);
                        scope.Complete();
                        return Ok(tEntityDTO);
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




        [HttpPost]
        public virtual async Task<ActionResult<TEntityDTO>> Post(TEntityDTO entityDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        entityDTO = await _entityUpdateService.Value.Create(entityDTO);
                        scope.Complete();
                        return Ok(entityDTO);
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




        [HttpPut]
        public virtual async Task<ActionResult<TEntityDTO>> Put(TEntityDTO entityDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        entityDTO = await _entityUpdateService.Value.Update(entityDTO, entityDTO.Id);
                        scope.Complete();
                        return Ok(entityDTO);
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

 
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntityDTO>> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        TEntityDTO entityDTO = await _entityUpdateService.Value.Delete(id);
                        scope.Complete();
                        if (entityDTO == null)
                            return NotFound();
                        return Ok(entityDTO);
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
