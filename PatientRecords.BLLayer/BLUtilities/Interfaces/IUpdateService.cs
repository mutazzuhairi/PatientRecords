

using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.Interfaces
{
    public interface IUpdateService<TEntityDTO>
    {
        Task<TEntityDTO> CreateAsync(TEntityDTO entityDTO);
        Task<TEntityDTO> DeleteAsync(params object[] keyValues);
        Task<TEntityDTO> UpdateAsync(TEntityDTO entityDTO, params object[] keyValues);
    }
}
