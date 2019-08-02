
using HospitalManagment.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.API.Data
{


    //i added all these ones and add soemthing in the start yp page

                                                          //to set user table as int
    public class DataContext : IdentityDbContext<User,Role,int,IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        // we inherited the the identitytable, identity roles table
        //the IdentityDbcontext is the one that creates the tables Aspnet Tables in the db, but we are trying to set the id to be int
        //the next things we did was to add the idenity in the startup class 
        //run migrations and update database
        // call userManager on the controller and pass in the UserModel
        public DataContext(DbContextOptions<DataContext>options):base(options){}
       
        public DbSet<Values> Values{get;set;}

       
     
        public DbSet<Photo> Photos {get;set;}
       
    }

  
}