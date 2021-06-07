using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infra.DTOs
{
    public class StudentRegisterDto
    {
        public int StudentID { get; set; }
        public int Enrolment { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public DateTime? TerminationDate { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
