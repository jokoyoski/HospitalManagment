using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using HospitalManagment.API.Interface;
using HospitalManagment.API.Mapper;
using HospitalManagment.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagment.API.Controllers
{[Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
       private readonly IConfiguration config;
       
        private readonly IAuthService authServices ;

        private readonly IMapper mapper ;
        private readonly IUserService userServices;
        private readonly UserManager<User> userManager;
       
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;

        public AuthController(IAuthService authService, UserManager<User> userManager,IMapper mapper , IUserService userServices ,IConfiguration config,SignInManager<User> signInManager,RoleManager<Role>roleManager)
        {
        this.authServices=authService;
        this.userManager=userManager;
        this.signInManager=signInManager;
        this.roleManager=roleManager;
        this.config=config;
        this.userServices=userServices;
        this.mapper=mapper;
        }

         [HttpPost("RegisterUser")]
        public async Task< IActionResult> RegisterUser(User userInfo)
        {
            string[] Errors=new string[]{};
            List<string>error=new List<string>();
        if(userInfo==null)
        {
            return BadRequest();
        }
        userInfo.UserName=userInfo.Email;
          
               var user=this.userManager.FindByNameAsync(userInfo.UserName);
              
                 var result=await this.userManager.CreateAsync(userInfo,userInfo.Password);
                 if(user.Result!=null)
                 {
                     
                       IEnumerable<IdentityError> errors=result.Errors;
         foreach(var j in errors)
         {
             error.Add(j.Description);
         }
         Errors=error.ToArray();
Response.AddApplicationError(Errors);
                         return BadRequest("UserName already exist");
                 }

                 var userModel=new User
                 {
                     UserName=userInfo.UserName
                 };
              
                 if(result.Succeeded)
                 {
    return Ok(new{
                     success="User Has been Registered Successfully, You can then proceed to login",
                   
                 });
                 }
       
            return BadRequest(
            
            );
    
        
        }
        

[HttpPost("SaveUserroles")]

        public async Task< IActionResult> SaveUserroles(string email,Role role)
        {
        
        
  
                
               var user=await this.userManager.FindByEmailAsync(email);
              
              var saveRoles=await this.userManager.AddToRoleAsync(user,role.Name);

                 
                 if(saveRoles.Succeeded)
                 {
    return Ok(new{
                     success="Roles has been assigned successfully",
                   
                 });
                 }
            
            return BadRequest(saveRoles.Errors);
    
        
        }
         

              

[   HttpGet("GetUsers")]
 [Authorize(Policy="RequiredAdminRole")]
        public async Task< IActionResult> GetUsers()
        {
        
        
            var users=this.userServices.GetUser();

        var userInfo=this.mapper.Map<List<UserForListDTO>>(users);

            return Ok(userInfo);
        
        }


[HttpPost("DeleteRoles")]
[Authorize(Policy="RequiredAdminRole")]
        public async Task< IActionResult> DeleteRoles(int userId,Role role)
        {
        
        string id= userId.ToString();
  
                
               var user=await this.userManager.FindByIdAsync(id);
              
              var saveRoles=await this.userManager.RemoveFromRoleAsync(user,role.Name);

                 
                 if(saveRoles.Succeeded)
                 {
    return Ok(new{
                     success="Roles has been removed successfully",
                   
                 });
                 }
            
            return BadRequest(saveRoles.Errors);
    
        
        }
        
   [       HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForRegisterDTO)
        {
            var result=string.Empty;
           try{
   var userInfo=await this.userManager.FindByNameAsync(userForRegisterDTO.UserName);
   var results= await this.signInManager.CheckPasswordSignInAsync(userInfo,userForRegisterDTO.Password,false);
   if(!results.Succeeded)
   {
  return BadRequest("You are not authorized");
   }

            
           
            
            
            var claims= new List<Claim>
            {
           new Claim(ClaimTypes.NameIdentifier,userInfo.Id.ToString()),
           new Claim(ClaimTypes.Name,userInfo.UserName),

            
            };
            var roles=await this.userManager.GetRolesAsync(userInfo);   //get roles
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config.GetSection("AppSettings:Token").Value));
            var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor= new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(claims),
                Expires=DateTime.UtcNow.AddHours(3),
                SigningCredentials=creds,
                NotBefore=DateTime.UtcNow,

            };
         
            var tokenHandler= new JwtSecurityTokenHandler ();

            var token= tokenHandler.CreateToken(tokenDescriptor); 

            var photoUrl=this.userServices.GetMainPhotoById(userInfo.Id);

   
            return Ok(new {
                token=tokenHandler.WriteToken(token) ,// we use this because we are returning it as ab oject
               photoUrl=photoUrl,
             
            });
       
           }
          
                catch (Exception e)
            {
                result = string.Format("Login- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return StatusCode(500,result);
           }
         
        
    }
}
