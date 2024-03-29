﻿using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using AutoMapper;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class PatientUpdateService : EntityUpdateService<Patient, IPatientRepositry, PatientDTO, IPatientMapping, IPatientValidating>, IPatientUpdateService
    {

        public PatientUpdateService(Lazy<IPatientRepositry> entityRepositry,
                                    Lazy<IPatientValidating> entityValidating,
                                    Lazy<IPatientMapping> entityMapping,
                                    Lazy<IServiceBuildException> serviceBuildException,
                                    IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {

        }
 
    }
}
