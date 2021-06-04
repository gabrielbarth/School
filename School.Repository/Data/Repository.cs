using Microsoft.EntityFrameworkCore;
using School.Domain.Models;
using System.Linq;

namespace School.Repository.Data
{
    public class Repository : IRepository
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
                query = query.Include(student => student.StudentSubjects)
                             .ThenInclude(studentSubject => studentSubject.Subject)
                             .ThenInclude(subject => subject.Teacher);

            query = query.AsNoTracking().OrderBy(student => student.StudentID);

            return query.ToArray();
        }

        public Student[] GetAllStudentsBySubject(int subjectId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
                query = query.Include(student => student.StudentSubjects)
                             .ThenInclude(studentSubject => studentSubject.Subject)
                             .ThenInclude(subject => subject.Teacher);

            query = query.AsNoTracking()
                         .OrderBy(student => student.StudentID)
                         .Where(student => student.StudentSubjects.Any(studentSubject => studentSubject.SubjectID == subjectId));

            return query.ToArray();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
                query = query.Include(student => student.StudentSubjects)
                             .ThenInclude(studentSubject => studentSubject.Subject)
                             .ThenInclude(subject => subject.Teacher);

            query = query.AsNoTracking().OrderBy(student => student.StudentID).Where(student => student.StudentID == studentId);

            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
                query = query.Include(teacher => teacher.Subjects)
                             .ThenInclude(subjects => subjects.StudentsSubject)
                             .ThenInclude(studentSubject => studentSubject.Student);

            query = query.AsNoTracking().OrderBy(teacher => teacher.TeacherID);

            return query.ToArray();
        }

        public Teacher[] GetAllTeachersBySubject(int subjectId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
                query = query.Include(teacher => teacher.Subjects)
                             .ThenInclude(subjects => subjects.StudentsSubject)
                             .ThenInclude(studentSubject => studentSubject.Student);

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.TeacherID)
                         .Where(teacher => teacher.Subjects.Any(subject => subject.SubjectID == subjectId));

            return query.ToArray();
        }

        public Teacher GetTeacherById(int teacherId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
                query = query.Include(teacher => teacher.Subjects)
                             .ThenInclude(subjects => subjects.StudentsSubject)
                             .ThenInclude(studentSubject => studentSubject.Student);

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.TeacherID)
                         .Where(teacher => teacher.TeacherID == teacherId);

            return query.FirstOrDefault();
        }
    }
}
