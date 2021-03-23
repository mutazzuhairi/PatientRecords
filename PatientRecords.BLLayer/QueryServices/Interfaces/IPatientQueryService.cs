﻿using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
 

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IPatientQueryService : IQueryService<PatientDTO, PatientView>
    {
        public bool IsOfficialIdAlreadyExist(string officialId);
        public bool IsEmailAlreadyExist(string email);
    }

}
