﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        // Propiedad de navegación para el profesor que enseña esta actividad
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        // Relación uno a muchos con Enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
