using System;
using System.Collections.Generic;

namespace School.Domain.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int Enrolment { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public DateTime? TerminationDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public Student(int id, 
                       int enrolment, 
                       string name, 
                       string lastName, 
                       string phone,
                       DateTime bornDate)
        {
            StudentID = id;
            Enrolment = enrolment;
            Name = name;
            LastName = lastName;
            Phone = phone;
            BornDate = bornDate;
        }
        public Student() { }
    }
}
