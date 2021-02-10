using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models 
{ 
    public class Subject
    {
        public int SubjectID { get; set; }

        public string Name { get; set; }

        public int TeacherID { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<StudentSubject> StudentsSubject { get; set; }

        public Subject() {}

        public Subject(int id, string name, int teacherID)
        {
            SubjectID = id;
            Name = name;
            TeacherID = teacherID;
        }
    }
}
