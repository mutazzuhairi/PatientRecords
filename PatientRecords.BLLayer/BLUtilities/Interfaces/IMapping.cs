
using Microsoft.AspNetCore.Http;

namespace PatientRecords.BLLayer.BLUtilities.Interfaces
{
    public interface IMapping<TEntity,TEntityDTO>
    {
        void MapEntity(TEntity entity , TEntityDTO entityPm, bool isNewEntity);
    }
}
