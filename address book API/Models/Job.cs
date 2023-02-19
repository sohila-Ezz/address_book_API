using System.ComponentModel.DataAnnotations;

namespace address_book_API.Models
{
    public class Job
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
       
        public string Name { get; set; }
    }
}
