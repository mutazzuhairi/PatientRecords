using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
using System;
using System.Linq;


namespace PatientRecords.BLLayer.BLBasics.HelperServices
{
    public class ServiceBuildException: IServiceBuildException
    {
        public void BuildException(params string[] errors)
        {
            throw new Exception(string.Join(", ", errors.ToArray()));
        }
    }
}
