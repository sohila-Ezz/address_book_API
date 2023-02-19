﻿
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace address_book_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ MaxLength(50)]
        public string FirstName { get; set; }

        [ MaxLength(50)]
        public string LastName { get; set; }
    }
}
