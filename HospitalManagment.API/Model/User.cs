using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagment.API.Model
{
    public class User:IdentityUser<int>
    {
        
      

        public string FirstName{get;set;}
        public string LastName {get;set;}

        public string Gender {get;set;}

        public System.DateTime DateofBirth {get;set;}

       
  
   public byte[] PasswordSalt {get;set;}
        public DateTime LastActive {get;set;}


        

        public DateTime Created {get;set;}


       [NotMapped]
        public string PhotoUrl {get;set;}

        [NotMapped]
               public string Password {get;set;}
        public string City {get;set;}

        public string Country {get;set;}
        
        public ICollection<UserRole> userRoles{get;set;}

        
   
     
    }
}