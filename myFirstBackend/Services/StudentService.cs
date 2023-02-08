using myFirstBackend.Modelos.DataModels;

namespace myFirstBackend.Services
{
    public class StudentService : IStudentService
    {
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
