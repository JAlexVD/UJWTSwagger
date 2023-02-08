
using Microsoft.EntityFrameworkCore;
using myFirstBackend.Modelos.DataModels;

namespace myFirstBackend.DataAcces
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options) 
        {

        }

        //Para crear las Tablas de la BD

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Cahpters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Stundets { get; set; }
        

    }
}
