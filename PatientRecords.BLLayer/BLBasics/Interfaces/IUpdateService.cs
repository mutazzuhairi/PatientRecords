

using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLBasics.Interfaces
{
    public interface IUpdateService<TEntityDTO>
    {
        Task<TEntityDTO> Create(TEntityDTO entityDTO);
        Task<TEntityDTO> Delete(params object[] keyValues);
        Task<TEntityDTO> Update(TEntityDTO entityDTO, params object[] keyValues);
    }
}
