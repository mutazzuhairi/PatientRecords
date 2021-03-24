using AutoMapper;
using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.BLBasics.HelperServices;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
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
        private readonly IMapper _mapper;

        public PatientRecordQueryService(IPatientRecordRepositry iEntityRepositry, IMapper mapper,
                                         IUriService _uriService,
                                         Lazy<IPaginationHelper> _paginationHelper) :
            base(iEntityRepositry, mapper, _uriService, _paginationHelper)
        {

             _iEntityRepositry = iEntityRepositry;
             _mapper = mapper;

        }

        public bool IsDiseaseNameAlreadyExist(string diseaseName)
        {
            return _iEntityRepositry.GetAll().Where(s => s.DiseaseName == diseaseName).Any();
        }

    }
}
