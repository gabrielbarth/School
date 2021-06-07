using System;
using System.Collections.Generic;

namespace School.Infra.DTOs
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public int Enrolment { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public bool Active { get; set; }
    }
}
