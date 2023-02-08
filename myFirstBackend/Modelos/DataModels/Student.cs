using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public class Student : BaseEntity
    {
        [Required, StringLength(50)]
        public String FirstName { get; set; } = String.Empty;

        [Required, StringLength(100)]
        public String LastName { get; set; } = String.Empty;

        [Required]
        public DateTime Dob { get; set; }

        //Un estudiante varios cursos
        [Required]
        public ICollection<Course> Courses { get;set; } = new List<Course>();

    }
}
