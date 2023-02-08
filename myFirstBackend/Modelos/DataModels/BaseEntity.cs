using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Modelos.DataModels
{
    public class BaseEntity
    {
        //Propiedades que van a estar en todos los elementos de la DB

        [Required]

        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }  = string.Empty;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeleteddAt { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}

