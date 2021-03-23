using System.Collections.Generic;

namespace PatientRecords.BLLayer.BLBasics.Interfaces
{
    public interface IValidate<TEntityPM>
    {
         void Validate(TEntityPM entityDTO, List<string> validationErrors, bool isNewEntity);
    }
}
