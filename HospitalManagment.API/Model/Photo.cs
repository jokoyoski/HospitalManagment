using System;
namespace HospitalManagment.API.Model
{
    public class Photo
    {
        public int Id {get;set;}

        public string URl {get;set;}

        public string Description {get;set;}

        public DateTime DateAdded {get;set;}

        public bool IsMain {get;set;}
        
       public string PublicId{get;set;}
        public int UserId {get;set;}
}
}