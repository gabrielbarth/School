using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models
{
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; } = null;
        public StudentCourse() { }
        public StudentCourse(int studentId, int CourseId)
        {
            StudentID = studentId;
            CourseID = CourseId;
        }
    }
}
