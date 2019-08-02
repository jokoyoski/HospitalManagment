using System.Threading.Tasks;


using HospitalManagment.API.Interface;
using HospitalManagment.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HospitalManagment.API.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
       private readonly IConfiguration config;
       
        private readonly IAuthService authServices ;

        
        private readonly IUserService userServices;
        private readonly UserManager<User> userManager;
       
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;

        public UsersController(IAuthService authService, UserManager<User> userManager, IUserService userServices ,IConfiguration config,SignInManager<User> signInManager,RoleManager<Role>roleManager)
        {
        this.authServices=authService;
        this.userManager=userManager;
        this.signInManager=signInManager;
        this.roleManager=roleManager;
        this.config=config;
        this.userServices=userServices;
        
        }



          [HttpGet("GetUserList")]
        public async Task< IActionResult> GetUserList([FromQuery] UserParam userParam)
        {
             var users=await this.userServices.GetuserList(userParam);
            Response.AddPagination(users.CurrentPage,users.PageSize,users.TotalCount,users.TotalPages);

          return Ok(users);
        }
        
    }
}