using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.DataLayer.DataBasics.Abstractions;
using PatientRecords.DataLayer.DataBasics.DBContext;


namespace PatientRecords.DataLayer.Data.Repositries
{
    public class PatientRecordRepositry : EntityRepository<PatientRecord >, IPatientRecordRepositry
    {
       
        public PatientRecordRepositry(MainContext context) : base(context)
        {
             
        }
 
    }
}
