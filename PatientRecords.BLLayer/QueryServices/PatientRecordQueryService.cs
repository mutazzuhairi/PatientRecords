using AutoMapper;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using System;
using System.Linq;

namespace PatientRecords.BLLayer.QueryServices
{
    public class PatientRecordQueryService : EntityQueryService<PatientRecord , IPatientRecordRepositry, PatientRecordDTO, PatientRecordView> , IPatientRecordQueryService
    {
        
        private readonly IPatientRecordRepositry _iEntityRepositry;
 
        public PatientRecordQueryService(IPatientRecordRepositry iEntityRepositry, IMapper mapper,
                                         IUriService  uriService,
                                         Lazy<IPaginationHelper>  paginationHelper) :
            base(iEntityRepositry, mapper, uriService, paginationHelper)
        {

             _iEntityRepositry = iEntityRepositry;
 
        }

        public bool IsDiseaseNameAlreadyExist(string diseaseName)
        {
            return _iEntityRepositry.GetAll().Where(s => s.DiseaseName == diseaseName).Any();
        }

    }
}
