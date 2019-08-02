using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HospitalManagment.API.Data;
using HospitalManagment.API.Interface;
using HospitalManagment.API.Model;
using HospitalManagment.API.Repository;
using HospitalManagment.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagment.API
{

  //  dotnet publish -c Release -o ./publish
        public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  //connection  to the db
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DevConnection")));    //1 
             services.AddAutoMapper();
             
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          services.AddCors();
              services.AddScoped<IAuthService,AuthService>();
              services.AddScoped<IUserService,UserServices>();
                services.AddScoped<IUserRepository,UserRepository>();
                services.AddScoped<IAuthRepository,AuthRepository>();

                 IdentityBuilder builder = services.AddIdentityCore<User>(Options =>
            {

                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireDigit = false;
                Options.Password.RequiredLength = 4;
                Options.Password.RequireUppercase = false;
            });  
        builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
        builder.AddEntityFrameworkStores<DataContext>();  // the data context i want to use to save all the user info
           builder.AddRoleValidator<RoleValidator<Role>>();
          builder.AddRoleManager<RoleManager<Role>>(); //register roles
            builder.AddSignInManager<SignInManager<User>>();  //register signin managers

 //authentication middleware for jwt authorize
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            services.AddAuthorization(Options =>
            {   // we added this to specify roles in the Authhorixe action method
                Options.AddPolicy("RequiredAdminRole", policy => policy.RequireRole("Admin"));
                Options.AddPolicy("RequiredModeratorRole", policy => policy.RequireRole("Doctor"));
                Options.AddPolicy("VipOnle", policy => policy.RequireRole("Nurse"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());  //cors 
            app.UseHttpsRedirection();
             app.UseAuthentication();  //for authentication middleware 
            app.UseMvc();
        }
    }
}
