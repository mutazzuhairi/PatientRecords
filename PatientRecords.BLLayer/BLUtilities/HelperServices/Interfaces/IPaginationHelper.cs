using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices
{
    public interface IPaginationHelper 
    {
        public   PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationData paginationData);
    }
}
