using System;
using System.Collections.Generic;

namespace School.Domain.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public Course() { }
        public Course(int id, string name)
        {
            CourseID = id;
            Name = name;
        }
    }
}
