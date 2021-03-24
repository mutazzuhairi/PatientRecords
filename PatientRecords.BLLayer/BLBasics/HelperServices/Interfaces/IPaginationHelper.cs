using PatientRecords.BLLayer.BLBasics.HelperClasses;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLBasics.HelperServices
{
    public interface IPaginationHelper 
    {
        public   PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationData paginationData);
    }
}
