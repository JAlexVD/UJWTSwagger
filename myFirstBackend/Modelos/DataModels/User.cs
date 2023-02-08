using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public class User: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }= String.Empty;

        [Required, StringLength(100)]
        public String LastName { get; set; } = String.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
