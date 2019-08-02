using System;
using Microsoft.AspNetCore.Http;

namespace HospitalManagment.API.Model
{
public class PhotoForCreationDTO
    {
 public string URl {get;set;}

public IFormFile FormFile {get;set;}
public int Id{get;set;}

public string Description{get;set;}

public bool IsMain {get;set;}
public string PublicId{get;set;}

        public DateTime DateAdded {get;set;}

  public int    UserId {get;set;}
        
    }
}