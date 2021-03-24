using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.DataLayer.DataUtilities.Interfaces
{
    public interface IRepository <TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<int> SubmitChanges();
    }
}
