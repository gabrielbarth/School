using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Repository.Data
{
    public interface IRepository
    {
        void Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        #region Students
        Student[] GetAllStudents(bool includeTeacher = false);
        Student[] GetAllStudentsBySubject(int subjectId, bool includeTeacher = false);
        Student GetStudentById(int studentId, bool includeTeacher = false);
        #endregion Students
        #region Teachers
        Teacher[] GetAllTeachers(bool includeStudents = false);
        Teacher[] GetAllTeachersBySubject(int teacherId, bool includeStudents = false);
        Teacher GetTeacherById(int teacherId, bool includeStudents = false);
        #endregion Teachers
    }
}
