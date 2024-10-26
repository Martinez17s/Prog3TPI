using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProfessorId { get; set; }
    }
}
