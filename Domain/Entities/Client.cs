using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
