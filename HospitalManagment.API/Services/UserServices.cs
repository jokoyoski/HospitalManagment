using System.Threading.Tasks;
using HospitalManagment.API.Interface;
using HospitalManagment.API.Model;
using System.Linq;
namespace HospitalManagment.API.Services
{
    public class UserServices:IUserService
    {
         private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
        this.userRepository=userRepository;
        }

        public Photo GetMainPhotoById(int userId)
        {
            return this.userRepository.GetMainPhoto(userId);
        }

        public UserRole[] GetUser()
        {
            return this.userRepository.GetUsers();
        }

        public Task<PagedList<User>> GetuserList(UserParam user)
        {
            var users=this.userRepository.GetuserList();
           var userValue= users.ToList();
            return PagedList<User>.CreateAsync(userValue,user.PageNumber,user.PageSize);
        }

        public string SaveRole(string role)
        {
           return this.userRepository.SaveRoles(role);
        }
    }
}