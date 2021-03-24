using System.Collections.Generic;

namespace PatientRecords.BLLayer.BLUtilities.Interfaces
{
    public interface IValidate<TEntityPM>
    {
         void Validate(TEntityPM entityDTO, List<string> validationErrors, bool isNewEntity);
    }
}
