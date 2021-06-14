using System;
using System.Collections.Generic;

namespace School.Infra.DTOs
{
    /// <summary>
    /// Este é o DTO de Aluno.
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// Identificador e chave primária no banco de dados
        /// </summary>
        public int StudentID { get; set; }
        public int Enrolment { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public bool Active { get; set; }
    }
}
