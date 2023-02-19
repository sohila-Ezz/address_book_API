using System.ComponentModel.DataAnnotations;

namespace address_book_API.DTOs
{
    public class CreateDepartmentDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
