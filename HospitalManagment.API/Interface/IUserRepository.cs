using HospitalManagment.API.Model;

namespace HospitalManagment.API.Interface
{
    public interface IUserRepository
    {
        
        Photo GetMainPhoto(int userId);
        string SaveRoles(string roleName);
        UserRole[] GetUsers ();
        User[] GetuserList();
    }
}