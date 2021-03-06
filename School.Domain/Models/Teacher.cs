﻿using System;
using System.Collections.Generic;

namespace School.Domain.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public int Registry { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public DateTime? TerminationDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Subject> Subjects { get; set; }
        public Teacher() { }
        public Teacher(int id, int registry, string name, string lastName)
        {
            TeacherID = id;
            Registry = registry;
            Name = name;
            LastName = lastName;
        }
    }
}
