﻿using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public IEnumerable<StudentSubject> StudentSubjects { get; set; }

        public Student(int id, string name, string lastName, string phone)
        {
            StudentID = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
        }

        public Student()
        {

        }
    }
}
