using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infra.DTOs
{
    public class TeacherRegisterDto
    {
        public int TeacherID { get; set; }
        public int Registry { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public DateTime? TerminationDate { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
