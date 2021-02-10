using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }

        public string Name { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public Teacher() {}

        public Teacher(int id, string name)
        {
            TeacherID = id;
            Name = name;
        }
    }
}
