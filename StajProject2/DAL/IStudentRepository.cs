using StajProject2.Entities;

namespace StajProject2.DAL
{
    public interface IStudentRepository : IDisposable

    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();
        void SaveChanges();
    }
}
