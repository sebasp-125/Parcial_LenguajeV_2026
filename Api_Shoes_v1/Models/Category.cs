using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_Shoes_v1.Models
{
    public class Category
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Shoe> Shoes { get; set; }
    }
}