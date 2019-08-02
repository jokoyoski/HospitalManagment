using HospitalManagment.API.Data;
using HospitalManagment.API.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagment.API.Queries
{
    public class AuthQuery
    {
         private readonly DataContext dataContext;

        internal static Photo GetMainPhotoById(DataContext db , int userId)
        {
            var result=(from d in db.Users 
            join c in db.Photos on d.Id equals c.UserId
            where c.IsMain==true
            select new Photo{
             URl=c.URl
            }).FirstOrDefault();

            return result;
        }

          internal static UserRole[]  GetUsers(DataContext db )
        {
            var result=(from d in db.Users orderby d.Id
           
               
            select new UserRole{
             FirstName=d.UserName,
             Gender=d.Gender,
             roles=(from f in db.Roles
               
             join s in db.UserRoles on f.Id equals s.RoleId select f.Name).ToArray()
            }).OrderBy(x=>x.FirstName);

            return result.ToArray();
        }
        
    }
}