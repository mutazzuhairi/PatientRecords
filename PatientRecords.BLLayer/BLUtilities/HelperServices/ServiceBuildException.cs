using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using System.Linq;


namespace PatientRecords.BLLayer.BLUtilities.HelperServices
{
    public class ServiceBuildException: IServiceBuildException
    {
        public void BuildException(params string[] errors)
        {
            throw new AppException(string.Join(", ", errors.ToArray()));
        }
    }
}
