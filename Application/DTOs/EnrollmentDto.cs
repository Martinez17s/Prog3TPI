using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int SubjectId { get; set; }
        public int ClientId { get; set; }
        // Información adicional de la materia
        public string SubjectTitle { get; set; }
        public string SubjectDescription { get; set; }
        public int ProfessorId { get; set; }
    }
}
