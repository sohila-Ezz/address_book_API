using System.ComponentModel.DataAnnotations;

namespace address_book_API.Models
{
    public class RegisterModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(100),EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
