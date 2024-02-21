using System.ComponentModel.DataAnnotations;

namespace MyBookStore.DTO.Authors
{
    public class CreateAuthorDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Pole musi mieć conajmniej 3 znaki")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Pole musi mieć conajmniej 3 znaki")]
        [MaxLength(50)]
        public string LastName { get; set; }

    }
}
