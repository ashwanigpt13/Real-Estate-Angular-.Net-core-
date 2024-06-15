using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;
namespace WebAPI.Dtos
{
    public class PropertyDetailDto: PropertyListDto
    {
         public int CarpetArea { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloors { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; }
        public bool Gated { get; set; }
        public int Maintenance { get; set; }

        public DateTime EstPossessionOn { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
      
        public ICollection<PhotoDto>? Photos {  get; set; }
    }
}