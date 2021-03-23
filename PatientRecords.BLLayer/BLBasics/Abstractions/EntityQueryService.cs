using AutoMapper;
using PatientRecords.DataLayer.DataBasics.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PatientRecords.BLLayer.BLBasics.Abstractions
{
    public abstract class EntityQueryService<TEntity, TEntityRepositry, TEntityDTO, TEntityView> : IQueryService<TEntityDTO, TEntityView>
    where TEntityRepositry : IRepository<TEntity>
    {
        private readonly TEntityRepositry _entityRepositry;
        private readonly IMapper  _mapper;

        public EntityQueryService(TEntityRepositry entityRepositry, IMapper mapper)
        {
            this._entityRepositry = entityRepositry;
            this._mapper = mapper;
        }

        public async Task<List<TEntityDTO>> GetAll()
        {
            var pocoList = await this._entityRepositry.GetAll().ToListAsync();

            return this._mapper.Map<List<TEntityDTO>>(pocoList);

        }

        public async Task<List<TEntityView>> GetAllView()
        {
            var pocoList = await this._entityRepositry.GetAll().ToListAsync();

            return this._mapper.Map<List<TEntityView>>(pocoList);

        }
         
        public async Task<TEntityDTO> GetSingle(params object[] keyValues)
        {
            var poco = await this._entityRepositry.FindAsync(keyValues);
 
            return this._mapper.Map<TEntityDTO>(poco);
        }

        public async Task<TEntityView> GetSingleView(params object[] keyValues)
        {
            var poco = await this._entityRepositry.FindAsync(keyValues);

            return  this._mapper.Map<TEntityView>(poco);
        }
    }
}
