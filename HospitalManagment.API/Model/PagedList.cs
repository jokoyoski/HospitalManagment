using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagment.API.Model
{


         public class PagedList<T> :List<T>
    {
        public int CurrentPage{get;set;}
        public int TotalPages {get;set;}
        public int PageSize{get;set;}

        public int TotalCount{get;set;}
        
        public PagedList(List<T>items,int count, int pageNumber,int pageSize)
        {
TotalCount=count;
PageSize=pageSize;
CurrentPage=pageNumber;
TotalPages=(int)System.Math.Ceiling(count/(double)PageSize);
this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(List<T> source,int pageNumber, int pageSize)
        {
            var count= source.Count();
            var items=source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items,count,pageNumber,pageSize);
        }
    }
}
    
