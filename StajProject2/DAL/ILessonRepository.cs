using StajProject2.Entities;

namespace StajProject2.DAL
{
    public interface ILessonRepository : IDisposable
    {
        IEnumerable<Lesson> GetLessons();
        Lesson GetLessonByID(int lessonId);
        void InsertLesson(Lesson lesson);
        void DeleteLesson(int lessonId);
        void UpdateLesson(Lesson lesson);
        void Save();
    }
}
