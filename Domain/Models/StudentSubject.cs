using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models
{
    public class StudentSubject
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }


        public StudentSubject() {}

        public StudentSubject(int studentId, int subjectId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
