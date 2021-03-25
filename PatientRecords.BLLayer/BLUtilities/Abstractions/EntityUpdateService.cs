using PatientRecords.DataLayer.DataUtilities.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
 
namespace PatientRecords.BLLayer.BLUtilities.Abstractions
{
    public abstract class EntityUpdateService<TEntity,TEntityRepositry, TEntityDTO, TEntityMapping,TEntityValidating> : IUpdateService<TEntityDTO> 
        where TEntityValidating : IValidate<TEntityDTO>
        where TEntityRepositry : IRepository<TEntity>
        where TEntityMapping : IMapping<TEntity, TEntityDTO>

    {
        private bool _isNewEntity;
        private readonly Lazy<TEntityRepositry> _entityRepositry;
        private TEntity _entityPoco;
        private Lazy<TEntityMapping> _entityeMapping;
        private Lazy<TEntityValidating> _entityeValidating;
        private List<string> _vealidationErrors;
        private readonly IMapper _mapper;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
         public EntityUpdateService(Lazy<TEntityRepositry> entityRepositry ,
                                    Lazy<TEntityValidating> entityValidating , 
                                    Lazy<TEntityMapping> entityMapping,
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
            this._entityeValidating.Value.Validate(entityDTO, _vealidationErrors, _isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                this._entityeMapping.Value.MapEntity(_entityPoco, entityDTO, _isNewEntity);
                this._entityRepositry.Value.Add(_entityPoco);
                await this._entityRepositry.Value.SubmitChanges();
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
            this._entityeValidating.Value.Validate(entityDTO, _vealidationErrors, _isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                _entityPoco = await _entityRepositry.Value.FindAsync(keyValues);
                this._entityeMapping.Value.MapEntity(_entityPoco, entityDTO, _isNewEntity);
                this._entityRepositry.Value.Update(_entityPoco);
                await this._entityRepositry.Value.SubmitChanges();
            }
            else
            {
                _serviceBuildException.Value.BuildException(this._vealidationErrors.ToArray());
            }

            return entityDTO;
        }

        public virtual async Task<TEntityDTO> DeleteAsync(params object[] keyValues)
        {

            _entityPoco = await _entityRepositry.Value.FindAsync(keyValues);
            if (_entityPoco!=null)
            {
                this._entityRepositry.Value.Remove(_entityPoco);
                await this._entityRepositry.Value.SubmitChanges();
            }
            else
            {
                _serviceBuildException.Value.BuildException("Entity Not Found !");

            }

            return this._mapper.Map<TEntityDTO>(_entityPoco);

        }
    }
}
