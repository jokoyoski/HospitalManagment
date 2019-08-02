using HospitalManagment.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagment.API.Interface
{
    public interface IUserService
    {
         Photo GetMainPhotoById(int userId);
        string SaveRole(string role);
        UserRole[] GetUser();

        Task<PagedList<User>> GetuserList(UserParam user);
    }
}