using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infra.DTOs
{
    public class TeacherDto
    {
        public int TeacherID { get; set; }
        public int Registry { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public bool Active { get; set; }
    }
}
