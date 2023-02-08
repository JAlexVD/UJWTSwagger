using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public class Category: BaseEntity
    {
        [Required, StringLength(50)]
        public String Name { get; set; } = String.Empty;
        
        //En una categoria hay varios cursos
        [Required]
        public ICollection<Course> Courses { get; set;} = new List<Course>();
    }
}
