using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Photos")]
    public class Photo: BaseEntity
    {
       public required string PublicId { get; set; }
        public required string ImageUrl{get;set;}

        public bool IsPrimary{get;set;}

        public int PropertyId {get;set;}

        public Property Property {get;set;}
    }
}