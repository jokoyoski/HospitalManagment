using AutoMapper;
using HospitalManagment.API.Model;

namespace HospitalManagment.API.Mapper
{
            public class AutoMapperProfiles :Profile
    {
        
        public AutoMapperProfiles()
        {
            AllowNullDestinationValues=true;
            CreateMap<UserForLoginDTO,User>();
          CreateMap<UserRole, UserForListDTO>(MemberList.Source);
        // CreateMap<UserForListDTO ,UserRole>(MemberList.Source);
        }
    }
}