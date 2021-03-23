 
namespace PatientRecords.BLLayer.BLBasics.Interfaces
{
    public interface IMapping<TEntity,TEntityDTO>
    {
        void MapEntity(TEntity entity , TEntityDTO entityPm, bool isNewEntity);
    }
}
