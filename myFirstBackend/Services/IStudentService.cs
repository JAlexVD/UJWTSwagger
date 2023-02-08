using myFirstBackend.Modelos.DataModels;

namespace myFirstBackend.Services
{
    public interface IStudentService
    {
        //Estidiantes con cursos
        IEnumerable<Student> GetStudentsWithCourses();

        //Estudiantes sin cursos
        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}
