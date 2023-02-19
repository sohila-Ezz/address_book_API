using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace address_book_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(11)]
        public string mobileNumber { get; set; }
        public DateTime dateOfBirth  { get; set; }
       
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }

        public virtual Department department { get; set; }
        [ForeignKey("Job")]
        public int Job_Id { get; set; }
        public virtual Job job { get; set; }

    }
}
