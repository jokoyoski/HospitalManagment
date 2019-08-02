using HospitalManagment.API.Data;
using HospitalManagment.API.Interface;
using HospitalManagment.API.Model;
using HospitalManagment.API.Queries;
using System.Linq;

namespace HospitalManagment.API.Repository
{
    public class UserRepository:IUserRepository
    {
        
        private readonly DataContext dataContext;
        public UserRepository(DataContext dataContext)
        {
          this.dataContext=dataContext;
        }

        public Photo GetMainPhoto(int userId)
        {
           var result= UserQuery.GetMainPhotoById(dataContext,userId);
           return result;
        }
        public string SaveRoles(string roleName)
        {
          var result=string.Empty;
            //check for roles
             var role=dataContext.Roles.FirstOrDefault(x=>x.Name==roleName);
             if(role==null){

                dataContext.Roles.Add(role);
                dataContext.SaveChanges();
             }
             return result;
        }
        public UserRole[] GetUsers()
        {
           var users= AuthQuery.GetUsers(dataContext);
        return users;
        }

        public User[] GetuserList()
        {
           return UserQuery.GetUserList(dataContext);
        }
    }
}