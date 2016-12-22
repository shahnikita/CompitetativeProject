using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitetativeProject.DataRepository.Models
{
   public class Post
    {
       public int Id { get; set; }
       public string ImagePath{get;set;}
       public string IdentificationId { get; set; }
       public string Description { get; set; }
       public DateTime OccurredDateTime { get; set; }

       public int AreaId { get; set; } 
       public int CityId { get; set; }
       }
}
