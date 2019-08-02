using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagment.API.Model
{
    public class UserRole:IdentityUserRole<int>
    {

        [NotMapped]
        public string FirstName{get;set;}
        
        [NotMapped]       
         public string LastName {get;set;}

        [NotMapped]
        public string[] roles {get;set;}

        [NotMapped]
        public string Gender{get;set;}
    }
}