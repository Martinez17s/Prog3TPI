using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Professor : User
    {
        // Propiedad de navegación para las actividades que enseña
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
