﻿using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Models
{
    public class StudentSubject
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; } = null;
        public int? Grade { get; set; } = null;
        public StudentSubject() {}
        public StudentSubject(int studentId, int subjectId)
        {
            StudentID = studentId;
            SubjectID = subjectId;
        }
    }
}
