using System;
using System.Collections.Generic;

namespace School.Domain.Models 
{ 
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int? PrerequisiteID { get; set; } = null;
        public Subject Prerequisite { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public IEnumerable<StudentSubject> StudentsSubject { get; set; }
        public Subject() { }

        public Subject(int id, string name, int teacherId, int courseId)
        {
            SubjectID = id;
            Name = name;
            TeacherID = teacherId;
            CourseID = courseId;
        }
    }
}
