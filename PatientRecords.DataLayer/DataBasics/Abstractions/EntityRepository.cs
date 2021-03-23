using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PatientRecords.DataLayer.DataBasics.DBContext;
using PatientRecords.DataLayer.DataBasics.Interfaces;

namespace PatientRecords.DataLayer.DataBasics.Abstractions
{
    public abstract class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly MainContext _context;
        public EntityRepository(MainContext context)
        {
            _context = context;
        }
        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return   _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }
        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual async Task<int> SubmitChanges()
        {
             return await _context.SaveChangesAsync();
        }

    }
}
