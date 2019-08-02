using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagment.API.Model
{
    public class Role:IdentityRole<int>
    {
        public ICollection<UserRole>userRoles{get;set;}
        
    }
}