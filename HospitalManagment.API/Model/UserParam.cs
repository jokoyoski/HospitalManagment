namespace HospitalManagment.API.Model
{
    public class UserParam
    {
      
        private const int MaxPageSize=50;
        
        private int pageNumber;

        public int PageNumber{
            get{
                return pageNumber;
            }
            set{
                pageNumber=PageNumber==0?pageNumber=1:PageNumber;
                
            }
        }


        public int UserId{get;set;}
        private int pageSize=10;
        
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize=(value>MaxPageSize)?MaxPageSize:value;}
        }
       
      
public string OrderBy{get;set;}
       
       
      
     
    

        
    
       
     

     

    }
}