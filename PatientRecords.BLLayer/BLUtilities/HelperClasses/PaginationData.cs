using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.HelperClasses
{
    public class PaginationData
    {
        public PaginationFilter ValidFilter { get; set; }
        public int TotalRecords { get; set; }
        public IUriService UriService { get; set; }
        public string Route { get; set; }

    }
}
