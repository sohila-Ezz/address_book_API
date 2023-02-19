using System.ComponentModel.DataAnnotations;

namespace address_book_API.Models
{
    public class TokenRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
