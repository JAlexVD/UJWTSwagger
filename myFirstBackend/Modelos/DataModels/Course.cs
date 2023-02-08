using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public String Name { get; set; } = String.Empty;

        [Required, StringLength(280)]
        public String ShortDescription { get; set; } = String.Empty;

        [Required]
        public String Description { get; set; } = String.Empty;
        public Level Level { get; set; } = Level.Basic;
        //Un curso tiene varias categorias n<>*
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        //Curso temario (Index)
        [Required]
        public Chapter Chapter { get; set; } = new Chapter();

        //Un curso tiene un grupo de alumnos n<>*
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
