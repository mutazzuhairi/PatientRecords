using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces
{
    public interface IServiceBuildException
    {
        public  void BuildException(params string[] errors);
    }
}
