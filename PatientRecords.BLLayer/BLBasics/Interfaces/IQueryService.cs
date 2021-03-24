
using PatientRecords.BLLayer.BLBasics.HelperClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLBasics.Interfaces
{
    public interface IQueryService<TEntityDTO, TEntityView>
    {
        Task<List<TEntityDTO>> GetAllAsync();
        Task<TEntityDTO> GetSingleAsync(params object[] keyValues);
        Task<TEntityView> GetSingleViewAsync(params object[] keyValues);
        Task<List<TEntityView>> GetAllViewAsync();
        Task<PagedResponse<List<TEntityDTO>>> GetPaginationAsync(PaginationFilter filter, string route);
        Task<PagedResponse<List<TEntityView>>> GetPaginationViewAsync(PaginationFilter filter, string route);
    }
}
