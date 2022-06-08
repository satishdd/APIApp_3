using System.ComponentModel.DataAnnotations;

namespace APIApp_3.Models
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public long PhoneNo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6, ErrorMessage ="Password must be minimum of 6 Charactors")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{6,}$", ErrorMessage = "Password must contain only Characters, and must contain Uppercase and Lowercase")]
        public string Password { get; set; }
    }
}