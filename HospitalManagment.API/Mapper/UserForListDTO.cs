namespace HospitalManagment.API.Mapper
{
    public class UserForListDTO
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Gender {get;set;}

        public string[] roles {get;set;}
    }
}