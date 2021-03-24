using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.DataLayer.DataUtilities.Abstractions;
using PatientRecords.DataLayer.DataUtilities.DBContext;


namespace PatientRecords.DataLayer.Data.Repositries
{
    public class PatientRecordRepositry : EntityRepository<PatientRecord >, IPatientRecordRepositry
    {
       
        public PatientRecordRepositry(MainContext context) : base(context)
        {
             
        }
 
    }
}
