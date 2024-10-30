using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class EnrollmentCreateRequest
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
