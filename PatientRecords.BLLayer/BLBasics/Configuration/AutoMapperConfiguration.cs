using AutoMapper;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using PatientRecords.DataLayer.Data.Entities;


namespace PatientRecords.BLLayer.BLBasics.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<PatientRecord , PatientRecordDTO>().ReverseMap();
            CreateMap<PatientRecord, PatientRecordView>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, PatientView>().ReverseMap();
            CreateMap<SignUpUserModel, UserDTO>().ReverseMap();
            CreateMap<SignUpUserModel, UserView>().ReverseMap();

        }
    }
}
