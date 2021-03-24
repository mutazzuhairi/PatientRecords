using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.DataLayer.DataUtilities.Abstractions;
using PatientRecords.DataLayer.DataUtilities.DBContext;
  

namespace PatientRecords.DataLayer.Data.Repositries
{
    public class PatientRepositry : EntityRepository<Patient>, IPatientRepositry
    {
    
        public PatientRepositry(MainContext context) : base(context)
        {
            
        }
 
    }
}
