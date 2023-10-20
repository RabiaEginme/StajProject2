using Microsoft.EntityFrameworkCore;
using StajProject2.Data;
using StajProject2.Entities;

namespace StajProject2.DAL
{
    public class LessonRepository : ILessonRepository, IDisposable
    {
        public SchoolContext context;

        public LessonRepository(SchoolContext context)
        {
            this.context = context;
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return context.Lessons;
        }
        public Lesson GetLessonByID(int lessonId)
        {
            return context.Lessons.FirstOrDefault(x => x.Id == lessonId);
        }
        public void InsertLesson(Lesson lesson)
        {
            context.Lessons.Add(lesson);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DeleteLesson(int lessonId)
        {
            Lesson lesson = context.Lessons.Find(lessonId);
            context.Lessons.Remove(lesson);
        }
        public void UpdateLesson(Lesson lesson)
        {
            context.Entry(lesson).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        

        
    }
}
