using System.Collections.Generic;
using HospitalManagment.API.Model;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HospitalManagment.API.Data
{
    public class UserSeed
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> roleManager;
        public UserSeed(DataContext dataContext,UserManager<User> _userManager,RoleManager<Role> roleManager )
        {
        this._dataContext=dataContext;
        this._userManager=_userManager;
        this.roleManager=roleManager;
        }

        public void SeedUsers()
        {
            var user=new User{
                UserName="Admin"
            };
            IdentityResult  result=this._userManager.CreateAsync(user,"password").Result;
            if(result.Succeeded)
            {
                var admin=this._userManager.FindByNameAsync(user.UserName).Result;
                this._userManager.AddToRolesAsync(admin,new[]{"Admin","Moderator"}).Wait();
            }
        }


       
    }
}