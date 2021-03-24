﻿using PatientRecords.DataLayer.DataUtilities.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using Microsoft.AspNetCore.Http;

namespace PatientRecords.BLLayer.BLUtilities.Abstractions
{
    public abstract class EntityUpdateService<TEntity,TEntityRepositry, TEntityDTO, TEntityMapping,TEntityValidating> : IUpdateService<TEntityDTO> 
        where TEntityValidating : IValidate<TEntityDTO>
        where TEntityRepositry : IRepository<TEntity>
        where TEntityMapping : IMapping<TEntity, TEntityDTO>

    {
        private bool _isNewEntity;
        private readonly TEntityRepositry _entityRepositry;
        private TEntity _entityPoco;
        private TEntityMapping _entityeMapping;
        private TEntityValidating _entityeValidating;
        private List<string> _vealidationErrors;
        private readonly IMapper _mapper;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
         public EntityUpdateService(TEntityRepositry entityRepositry , 
                                   TEntityValidating entityValidating , 
                                   TEntityMapping entityMapping,
                                   Lazy<IServiceBuildException> serviceBuildException,
                                   IMapper mapper )
        {
            
            _entityRepositry = entityRepositry;
            _entityeMapping = entityMapping;
            _entityeValidating = entityValidating;
            _vealidationErrors = new List<string>();
            _serviceBuildException = serviceBuildException;
            _mapper = mapper;

        }

        public virtual async Task<TEntityDTO> CreateAsync(TEntityDTO entityDTO)
        {
            _isNewEntity = true;
            _entityPoco = (TEntity)Activator.CreateInstance(typeof(TEntity)); 
            this._entityeValidating.Validate(entityDTO, _vealidationErrors, _isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                this._entityeMapping.MapEntity(_entityPoco, entityDTO, _isNewEntity);
                this._entityRepositry.Add(_entityPoco);
                await this._entityRepositry.SubmitChanges();
            }
            else
            {
                _serviceBuildException.Value.BuildException(this._vealidationErrors.ToArray());
            }

            return entityDTO;
        }

        public virtual async Task<TEntityDTO> UpdateAsync(TEntityDTO entityDTO, params object[] keyValues)
        { 
            _isNewEntity = false;
            this._entityeValidating.Validate(entityDTO, _vealidationErrors, _isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                _entityPoco = await _entityRepositry.FindAsync(keyValues);
                this._entityeMapping.MapEntity(_entityPoco, entityDTO, _isNewEntity);
                this._entityRepositry.Update(_entityPoco);
                await this._entityRepositry.SubmitChanges();
            }
            else
            {
                _serviceBuildException.Value.BuildException(this._vealidationErrors.ToArray());
            }

            return entityDTO;
        }

        public virtual async Task<TEntityDTO> DeleteAsync(params object[] keyValues)
        {

            _entityPoco = await _entityRepositry.FindAsync(keyValues);
            if (_entityPoco!=null)
            {
                this._entityRepositry.Remove(_entityPoco);
                await this._entityRepositry.SubmitChanges();
            }
            else
            {
                _serviceBuildException.Value.BuildException("Entity Not Found !");

            }

            return this._mapper.Map<TEntityDTO>(_entityPoco);

        }
    }
}