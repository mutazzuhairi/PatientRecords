using PatientRecords.BLLayer.BLBasics.BasicServices.Interfaces;
using System;
using System.Linq;


namespace PatientRecords.BLLayer.BLBasics.BasicServices
{
    public class ServiceBuildException: IServiceBuildException
    {
        public void BuildException(params string[] errors)
        {
            throw new Exception(string.Join(", ", errors.ToArray()));
        }
    }
}
