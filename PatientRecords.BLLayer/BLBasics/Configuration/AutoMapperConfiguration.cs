using AutoMapper;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Extend.ExtendModelClasses;
using PatientRecords.DataLayer.Data.Entities;


namespace PatientRecords.BLLayer.BLBasics.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<PatientRecord , PatientRecordDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<SignUpUserModel, UserDTO>().ReverseMap();
 
        }
    }
}
