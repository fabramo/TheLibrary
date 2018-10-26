using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname required")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date Of Birth required")]
        public string DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}