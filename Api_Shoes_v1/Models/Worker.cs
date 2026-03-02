using System.ComponentModel.DataAnnotations;

namespace Api_Shoes_v1.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
