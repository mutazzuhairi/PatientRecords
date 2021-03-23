
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLBasics.Interfaces
{
    public interface IQueryService<TEntityDTO, TEntityView>
    {
        Task<List<TEntityDTO>> GetAll();
        Task<TEntityDTO> GetSingle(params object[] keyValues);
        Task<TEntityView> GetSingleView(params object[] keyValues);
        Task<List<TEntityView>> GetAllView();

    }
}
