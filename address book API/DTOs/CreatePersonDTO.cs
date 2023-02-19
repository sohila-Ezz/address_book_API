using address_book_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace address_book_API.DTOs
{
    public class CreatePersonDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(11)]
        public string mobileNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
        public int Department_Id { get; set; }

        public int Job_Id { get; set; }
      

    }
}
