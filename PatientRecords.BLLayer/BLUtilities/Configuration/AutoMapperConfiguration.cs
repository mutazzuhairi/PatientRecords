using AutoMapper;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using PatientRecords.DataLayer.Data.Entities;


namespace PatientRecords.BLLayer.BLUtilities.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<UserView, UserDTO>().ReverseMap();
            CreateMap<PatientRecord , PatientRecordDTO>().ReverseMap();
            CreateMap<PatientRecord, PatientRecordView>().ReverseMap();
            CreateMap<PatientRecordView, PatientRecordDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, PatientView>().ReverseMap();
            CreateMap<PatientView, PatientDTO>().ReverseMap();
            CreateMap<SignUpUserModel, UserDTO>().ReverseMap();
            CreateMap<SignUpUserModel, UserView>().ReverseMap();
            CreateMap<SignUpUserModel, User>().ReverseMap();

        }
    }
}
